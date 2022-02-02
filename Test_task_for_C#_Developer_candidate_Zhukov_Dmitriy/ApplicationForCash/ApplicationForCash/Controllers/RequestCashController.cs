using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationForCash.Infrastructure.Abstract;
using ApplicationForCash.Models;
using ApplicationForCash.Models.ViewModels;
using ApplicationForCash.Models.RequestModels;
using System.Net.Http;
using ApplicationForCash.Infrastructure.Concrete;
using Newtonsoft.Json;
using ApplicationForCash.Models.ResponseModels;
using System.Net;
using System.IO;
using System.Text;
using NLog;

namespace ApplicationForCash.Controllers
{
    // Клиентский контроллер - имитирует отправку заявки клиента на получение валюты на удаленный сервер,
    // а также отправку запроса на получение статуса заявки.
    [Authorize(Roles = "Admin, User")]
    public class RequestCashController : Controller
    {
        private IUserRepository userRepository;
        private ICashRequestRepository cashRequestRepository;

        public RequestCashController(IUserRepository userRepo, ICashRequestRepository cashRequestRepo)
        {
            userRepository = userRepo;
            cashRequestRepository = cashRequestRepo;
        }

        // Подготавливает модель представления для визуализации форм подачи заявки на валюту
        // Также отвечает за подготовку модели для визуализации ответа от сервера
        public ViewResult Index(CashRequest cashRequest)
        {
            int userID = HttpContext.Session.GetInt32("UserID").Value;
            User user = userRepository.Users.FirstOrDefault(u => u.UserID == userID);

            // Инициализация модели представления
            // Подготавливает коллекцию департаметов и список валют
            CashRequestViewModel viewModel = new CashRequestViewModel()
            {
                User = user,
                Departments = cashRequestRepository.Departments,
                Currency = new List<string> { "UAH", "USD", "EUR" }
            };

            // В случае отправки сервером ответа о статусе заявки,
            // дополняет модель представление данными об ответе
            if (cashRequest.Amount != 0)
            {
                viewModel.CashRequest = cashRequest;
            }

            return View(viewModel);
        }

        // Перегруженный метод - отвечает за обработку данных отправленной формы
        [HttpPost]
        public ViewResult Index(CashRequestViewModel viewModel)
        {
            // Востанавливаем id пользователя, извлекая id из сессионных данных
            int userID = HttpContext.Session.GetInt32("UserID").Value;

            // Извлекаем объект из БД для получения адресса департамента по id департамента 
            // полученного из модели представления
            Department department = cashRequestRepository.Departments
                .FirstOrDefault(d => d.DepartmentID == viewModel.SelectedDepartmentID);

            // Инициализируем объект для дальнейшей сериализации и отправки запроса на сервер 
            JsonSaveRequest requestModel = new JsonSaveRequest()
            {
                ClientID = userID,
                DepartmentAddress = department.Address,
                Amount = viewModel.Amount,
                Currency = viewModel.SelectedCurrency
            };

            // Вызываем метод отвечающий за подготовку и отправку запроса на сервер.
            // Метод возвращает id запроса
            int orderId = RequestToApi(requestModel);

            return View("Result", orderId);
            //return RedirectToAction("Result", new { orderId = restoredResponse.order_id });
        }

        // Подготавливает JSON объект для отправки в теле HTTP запроса
        // на api контроллер (имитирующий удаленный сервер) 
        public int RequestToApi(JsonSaveRequest requestModel)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44379/api/RequestHandler");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                // Сериализуем объект модели в строку Json и записываем в тело запроса
                var json = JsonConvert.SerializeObject(requestModel, Formatting.Indented);

                streamWriter.Write(json);
            }

            // Отправляем данные на Api контроллер ожидая ответа
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string result = string.Empty;

            // Получаем ответ от сервера
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            // Десириализуем в объект
            JsonResponse restoredResponse = JsonConvert.DeserializeObject<JsonResponse>(result);

            return restoredResponse.order_id;
        }

        // Метод обрабатывает форму запроса на статус заявки
        // принимает id заказа
        [HttpPost]
        public ActionResult StatusCheck(string orderNum)
        {
            string queryString = "https://localhost:44379/api/RequestHandler/GetStatus?req=" + orderNum;

            HttpClientHandler clientHandler = new HttpClientHandler();
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                HttpClient client = new HttpClient(clientHandler);

                // Передаем серверу запрос, ожидая ответ 
                response = client.GetAsync(queryString).Result;
            }
            catch
            {
            }

            CashRequest cashRequest = new CashRequest();

            if (response.IsSuccessStatusCode)
            {
                // Получаем ответ от сервера - строку json 
                var dataObjcets = response.Content.ReadAsStringAsync().Result;

                if (dataObjcets != "")
                {
                    // Десириализуем в объект
                    cashRequest = JsonConvert.DeserializeObject<CashRequest>(dataObjcets);

                    // Вызываем представление Index, передавая модель ответа от сервера
                    return RedirectToAction("Index", cashRequest);
                }
            }

            TempData["Message"] = "Заявка не найдена";

            return RedirectToAction("Index");
        }
    }
}

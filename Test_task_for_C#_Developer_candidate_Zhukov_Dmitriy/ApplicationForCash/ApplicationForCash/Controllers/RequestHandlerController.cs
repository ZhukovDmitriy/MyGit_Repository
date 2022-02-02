using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApplicationForCash.Infrastructure.Abstract;
using ApplicationForCash.Models.RequestModels;
using ApplicationForCash.Models;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ApplicationForCash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestHandlerController : Controller
    {
        public class JsonResponse
        {
            public int order_id;
        }

        public class JsonStatus
        {
            public int amount;
            public string currency;
            public bool request_status;
            public string status_comment;
        }

        private ICashRequestRepository repository;

        public RequestHandlerController(ICashRequestRepository repo)
        {
            repository = repo;
        }

        // Метод получает запрос от клиента, сериализует в объект и сохраняет заявку в БД
        // В ответ отправляет клиенту id заказа
        [HttpPost]
        public string GetRequest([FromBody] dynamic data)
        {
            Program.Logger.Debug("Получение запроса от клиента");
            string jsonString = Convert.ToString(data);

            Program.Logger.Debug("Попытка сериализации");
            // Сериализация в объект класса
            JsonSaveRequest restoredRequest = JsonConvert.DeserializeObject<JsonSaveRequest>(jsonString);

            Program.Logger.Debug("Сохранение в базе данных");
            // Сохраняем данные в БД и возвращаем id заказа
            int orderId = repository.SaveRequest(restoredRequest);

            // Инициализация объекта для ответа клиенту
            JsonResponse response = new JsonResponse()
            {
                order_id = orderId
            };

            Program.Logger.Debug("Формирование ответа от сервера и отправка");
            var res = JsonConvert.SerializeObject(response, Formatting.Indented);

            return res;
        }

        [HttpGet("{id}")]
        public string GetStatus(int req)
        {
            Program.Logger.Info("Получение запроса на статус заявки");
            Program.Logger.Debug("Извлекаем данные из базы");
            CashRequest cashRequest = repository.GetStatus(req);

            if (cashRequest != null)
            {
                JsonStatus jsonStatus = new JsonStatus()
                {
                    amount = cashRequest.Amount,
                    currency = cashRequest.Currency,
                    request_status = cashRequest.RequestStatus,
                    status_comment = cashRequest.StatusComment
                };

                var res = JsonConvert.SerializeObject(jsonStatus, Formatting.Indented);

                Program.Logger.Debug("Отправка ответа клиенту");
                return res;
            }
            else
            {
                Program.Logger.Info("Объект не найден в базе");
                return null;
            }
        }
    }
}

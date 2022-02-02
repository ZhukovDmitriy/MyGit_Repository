using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationForCash.Infrastructure.Abstract;
using ApplicationForCash.Models;
using ApplicationForCash.Models.RequestModels;

namespace ApplicationForCash.Infrastructure.Concrete
{
    public class EFCashRequestRepository : ICashRequestRepository
    {
        private ApplicationDbContext context;

        public EFCashRequestRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<CashRequest> CashRequests => context.CashRequests;
        public IQueryable<Department> Departments => context.Departments;

        public int SaveRequest(JsonSaveRequest request)
        {
            CashRequest newRequest = new CashRequest()
            {
                ClientID = request.ClientID,
                DepartmentAddress = request.DepartmentAddress,
                Amount = request.Amount,
                Currency = request.Currency,
            };

            if (request.Amount >= 30000)
            {
                newRequest.RequestStatus = false;
                newRequest.StatusComment = "Превышен разрешенный лимит";
            }
            else
            {
                newRequest.RequestStatus = true;
                newRequest.StatusComment = "Запрос обработан успешно";
            }

            context.CashRequests.Add(newRequest);
            context.SaveChanges();

            // Извлекаем из БД последний сохраненный объект
            CashRequest lastSavedRequest = context.CashRequests
                .OrderByDescending(r => r.RequestID).FirstOrDefault();

            int orderId = lastSavedRequest.RequestID;

            return orderId;
        }

        public CashRequest GetStatus(int orderNum)
        {
            CashRequest dbEntry = context.CashRequests.FirstOrDefault(r => r.RequestID == orderNum);

            if (dbEntry != null)
            {
                return dbEntry;
            }
            else
            {
                return null;
            }
        }
    }
}

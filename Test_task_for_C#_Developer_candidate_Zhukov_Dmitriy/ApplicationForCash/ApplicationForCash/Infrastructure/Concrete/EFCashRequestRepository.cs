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
                UserID = request.ClientID,
                DepartmentAddress = request.DepartmentAddress,
                Amount = request.Amount,
                Currency = request.Currency,
                RequestStatus = false,
                StatusComment = "Заявка на обработке"
            };

            context.CashRequests.Add(newRequest);
            context.SaveChanges();

            // Извлекаем из БД последний сохраненный объект
            CashRequest lastSavedRequest = context.CashRequests
                .OrderByDescending(r => r.RequestID).FirstOrDefault();

            int orderId = lastSavedRequest.RequestID;

            return orderId;
        }

        public void EditStatus(int requestId, bool confirmStatus)
        {
            CashRequest dbEntry = context.CashRequests.FirstOrDefault(r => r.RequestID == requestId);

            if (dbEntry != null)
            {
                dbEntry.RequestStatus = confirmStatus;

                if (confirmStatus == true)
                {
                    dbEntry.StatusComment = "Запрос одобрен";
                }
                else
                {
                    dbEntry.StatusComment = "Запрос отклонен";
                }

                context.SaveChanges();
            }
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

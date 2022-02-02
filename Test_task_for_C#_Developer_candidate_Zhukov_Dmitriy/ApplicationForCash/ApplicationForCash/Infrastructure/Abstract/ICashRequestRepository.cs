using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationForCash.Models;
using ApplicationForCash.Models.RequestModels;

namespace ApplicationForCash.Infrastructure.Abstract
{
    public interface ICashRequestRepository
    {
        IQueryable<Department> Departments { get; }
        IQueryable<CashRequest> CashRequests { get; }

        int SaveRequest(JsonSaveRequest request);
        CashRequest GetStatus(int orderNum);
    }
}

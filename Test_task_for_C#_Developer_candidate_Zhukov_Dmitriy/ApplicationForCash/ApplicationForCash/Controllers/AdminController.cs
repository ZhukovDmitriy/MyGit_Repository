using ApplicationForCash.Infrastructure.Abstract;
using ApplicationForCash.Models;
using ApplicationForCash.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForCash.Controllers
{
    public class AdminController : Controller
    {
        private ICashRequestRepository cashRequestRepository;
        private IUserRepository userRepository;

        public AdminController(ICashRequestRepository cashRequestRepo, IUserRepository userRepo)
        {
            cashRequestRepository = cashRequestRepo;
            userRepository = userRepo;
        }

        public ViewResult RequestList()
        {
            List<CashRequest> requests = cashRequestRepository.CashRequests.Include(u => u.User).ToList();

            return View(requests);
        }

        public ViewResult UserInfo(int userId)
        {
            UserInfoViewModel viewModel = new UserInfoViewModel()
            {
                User = userRepository.Users.FirstOrDefault(u => u.UserID == userId),
                CashRequests = cashRequestRepository.CashRequests.Where(u => u.UserID == userId).ToList()
            };

            return View(viewModel);
        }

        public ActionResult EditRequest(int requestId, bool confirmStatus, string returnUrl, int userId)
        {
            cashRequestRepository.EditStatus(requestId, confirmStatus);

            if (userId == 0)
            {
                return RedirectToAction("RequestList");
            }
            else
            {

                return RedirectToAction("UserInfo", new { userId });
            }
        }
    }
}

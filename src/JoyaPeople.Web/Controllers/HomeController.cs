using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoyaPeople.Persistence.Repositories;
using JoyaPeople.Web.Models;

namespace JoyaPeople.Web.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index(SearchVM vm)
        {
            var repository = new MemberRepository();
            vm.FoundMembers = 
                repository.SearchByName(vm.FirstName, vm.LastName)
                .Select(m => new MemberDisplayVM(m)).ToList();
            return View(vm);
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoyaPeople.Domain;
using JoyaPeople.Persistence.Repositories;
using JoyaPeople.Web.Models;
using MongoDB.Bson;

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

        [HttpGet]
        public ActionResult Add()
        {
            return View("AddEdit");
        }

        [HttpGet]
        public ActionResult Edit(ObjectId id)
        {
            var repository = new MemberRepository();

            var member = repository.GetById(id);
            var vm = new MemberAddEditVM(member);

            return View("AddEdit", vm);
        }
    }

}

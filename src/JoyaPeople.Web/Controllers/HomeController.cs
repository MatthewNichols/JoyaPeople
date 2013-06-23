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
            var vm = new MemberAddEditVM();
            return View("AddEdit", vm);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var repository = new MemberRepository();

            var member = repository.GetById(ObjectId.Parse(id));
            var vm = new MemberAddEditVM(member);

            return View("AddEdit", vm);
        }

        [HttpPost]
        public ActionResult Save(MemberAddEditVM vm, string id)
        {
            //TODO: Do some validation here and return if something is wrong


            var objectId = ObjectId.Parse(id);
            vm.Id = objectId;

            var repository = new MemberRepository();

            var member = vm.ToMember();
            repository.Save(member);

            return RedirectToAction("Index");
        }
    }

}

using MachineTest.Services;
using MachineTestMVC.Data;
using MachineTestMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MachineTestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _service;

        public HomeController(IHomeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var r = _service.GetAllAsync();
            return View(r);
        }


        public async Task<IActionResult> Create([Bind("Name,Gender,Birthday,Address")] UserDetail userDetail)
        {
            
            if (!ModelState.IsValid)
            {
                return View(userDetail);
            }
            await _service.AddAsync(userDetail);
            return RedirectToAction(nameof(Index));
        }

        
        public ActionResult Delete(int Id)
        {
            
            var result = _service.Delete(Id);
            
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAll()
        {

            var result = _service.DeleteAll();

            return RedirectToAction("Index");
        }
        public IActionResult ShowAll()
        {
            var r = _service.ShowAll();
            return View(r);
        }

        public IActionResult Edit(int id)
        {
            MachineTestMVCContext context = new MachineTestMVCContext();
            var user = context.UserDetails.Where(i => i.Id == id).FirstOrDefault();

            return PartialView("Edit", user);
        }

        [HttpPost]
        public IActionResult Edit(UserDetail user)
        {
            MachineTestMVCContext context = new MachineTestMVCContext();

            int H = Int32.Parse(DateTime.Now.ToString("HH"));
            int M = Int32.Parse(DateTime.Now.ToString("mm"));
            int S = Int32.Parse(DateTime.Now.ToString("ss"));
            user.Time = new TimeSpan(H, M, S);
            user.IsActive = true;
            user.Status = "Active";
            context.UserDetails.Update(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



    }
}

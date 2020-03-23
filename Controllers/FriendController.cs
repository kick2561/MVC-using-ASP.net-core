using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.Controllers
{
    [Route("friend")]
    public class FriendController : Controller
    {
        private readonly FriendDataContext Data;

        public FriendController(FriendDataContext db)
        {
            Data = db;
        }
        // GET: /<controller>/
        [Route("")]
        public IActionResult Index()
        {
            var friends = Data.Friends.ToArray();
            return View(friends);
        }

        [HttpGet, Route("update")]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost, Route("update")]
        public IActionResult Update(IFormCollection form)
        {
            var id = int.Parse(Request.Form["FriendId"]);
            var result = Data.Friends.SingleOrDefault(x => x.FriendId == id);
            if (result != null)
            {
                result.FriendName = Request.Form["FriendName"];
                result.Place = Request.Form["Place"];
                Data.SaveChanges();
            }

            return View();
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public IActionResult Create(Friend friend)
        {
            if (!ModelState.IsValid)
                return View();
            Data.Friends.Add(friend);
            Data.SaveChanges();
            return View();
        }

        [HttpGet , Route("Delete")]

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost, Route("Delete")]

        public IActionResult Delete(Friend friend)
        {
            var id = int.Parse(Request.Form["FriendId"]);
            var result = Data.Friends.SingleOrDefault(x => x.FriendId == id);
            if (result != null)
            {
                Data.Friends.Remove(result);
                Data.SaveChanges();
            }

            return View();
        }
    }
    
    
}

using Microsoft.AspNetCore.Mvc;
using CRUD_Practice.Models;

namespace CRUD_Practice.Controllers
{
    public class PracticeController : Controller
    {
        //List to store Users
        public static List<User> Users = new List<User>();
        //Will create index view
        public IActionResult Index()        
        {
            return View(Users);
        }

        [HttpGet]
        //created create view
        [Route("Create")]
        public IActionResult Create()       
        {
            //Viewbag used to carry message data
            ViewBag.Messsage = "Enter the Details";     
            ViewBag.Gender = new List<string> { "Male", "Female", "Other" };
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(User user)
        {
            Users.Add(user);
            //Redirected to Index with User Details
            return RedirectToAction("Index", user);     
        }

        [HttpGet]
        //Created edit view
        [Route("Edit")]     
        public IActionResult Edit(int Id)
        {
            ViewBag.Gender = new List<string> { "Male", "Female", "Other" };
            //Viewdata used to display Note
            ViewData["Message"] = "NOTE:Id cannot be change";      
            User user = Users.Where(i => i.Id.Equals(Id)).Select(s => s).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(User user)
        {
            User oldUser = Users.Where(i => i.Id.Equals(user.Id)).FirstOrDefault();
            if (oldUser != null)
            {
                oldUser.Id = user.Id;
                oldUser.FName = user.FName;
                oldUser.LName = user.LName;
                oldUser.Age = user.Age;
                oldUser.Gender = user.Gender;
                oldUser.FavMovie = user.FavMovie;

            }
            return RedirectToAction("Index", Users);
        }

        [HttpGet]
        //Created Detail view
        [Route("Details")]
        public PartialViewResult Details(int Id)
        {
            User Data = Users.Where(i => i.Id.Equals(Id)).Select(s => s).FirstOrDefault();
            return PartialView("Index",Data);
        }

        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            User data = Users.Find(x => x.Id == id);

            if (data != null)
            {
                Users.Remove(data);
            }
            //Deleted user and redirected to Index
            return RedirectToAction("Index");       
        }

        [HttpGet]
        [Route("SortAge")]
        public IActionResult Sort(User user)
        {
            var Sorted = Users.OrderByDescending(x => x.Age);
            return View("Index", Sorted);
        }

        [HttpGet]
        [Route("SortGen")]
        public IActionResult SortGen(User user)
        {
            var SortGen = Users.OrderByDescending(x => x.Gender);
            return View("Index", SortGen);
        }

        [HttpGet]
        [Route("SortFName")]
        public IActionResult SortFName(User user)
        {
            var Sorted = Users.OrderByDescending(x => x.FName);
            return View("Index", Sorted);
        }

        [HttpGet]
        [Route("SortLName")]
        public IActionResult SortLName(User user)
        {
            var Sorted = Users.OrderByDescending(x => x.LName);
            return View("Index", Sorted);
        }
    }
}

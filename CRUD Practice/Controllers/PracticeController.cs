using Microsoft.AspNetCore.Mvc;
using CRUD_Practice.Models;

namespace CRUD_Practice.Controllers
{

    public class PracticeController : Controller
    {
        public static List<User> Users = new List<User>();  //List to store Users

        public int FilterAge { get; private set; }

        public IActionResult Index()        //Will create index view
        {
            return View(Users);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()       //created create view
        {
            ViewBag.Messsage = "Enter the Details";     //Viewbag used to carry message data
            ViewBag.Gender = new List<string> {"Male","Female","Other"};
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(User user)
        {
            Users.Add(user);
            return RedirectToAction("Index", user);     //Redirected to Index with User Details
        }

        [HttpGet]
        [Route("Edit")]     //Created edit view
        public IActionResult Edit(int Id)
        {
            ViewBag.Gender = new List<string> { "Male", "Female", "Other" };
            ViewData["Message"] = "NOTE:Id cannot be change";      //Viewdata used to display Note
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
                oldUser.UserFName = user.UserFName;
                oldUser.UserLName = user.UserLName;
                oldUser.UserAge = user.UserAge;
                oldUser.Gender = user.Gender;
                oldUser.FavMovie = user.FavMovie;

            }
            return RedirectToAction("Index", Users);
        }

        [HttpGet]
        [Route("Details")]      //Created Detail view
        public IActionResult Details(int Id)
        {
            User Data = Users.Where(i => i.Id.Equals(Id)).Select(s => s).FirstOrDefault();
            return View(Data);
        }

        [HttpPost]
        [Route("Details")]
        public IActionResult Details(User user)        //passes user to show details
        {
            var Details = Users.Where(i => i.Id == user.Id).Select(s => s).FirstOrDefault();
            return View("Index");
        }

        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            User data = Users.Find(x => x.Id == id);

            if (data != null)
            {
                Users.Remove(data);
            }
            return RedirectToAction("Index");       //Deleted user and redirected to Index

        }      
    
        [HttpGet]
        [Route("Sort")]
        public IActionResult Sort(User user)
        {
            var Sorted = Users.OrderByDescending(x => x.UserAge);
            return View("index",Sorted);
        }
    }
}

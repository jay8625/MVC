using Microsoft.AspNetCore.Mvc;
using CRUD_Practice.Models;

namespace CRUD_Practice.Controllers
{

    public class PracticeController : Controller
    {
        public static List<User> Users = new List<User>();  //List to store Users
        public IActionResult Index()        //Will create index view
        {
            return View(Users);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()       //created create view
        {
            ViewBag.Messsage = "Enter the Details";     //Viewbag used to carry message data
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
            ViewData["Message"] = "NOTE:Key cannot be change";      //Viewdata used to display Note
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

            }
            return RedirectToAction("Index", Users);        //Redirected to Index with User Updated Details
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
        public IActionResult Details(User user)
        {
            var i=Users.Where(i=>i.Id==user.Id).Select(s => s).FirstOrDefault();  
            return View("Index");       
        }
                
        [Route("Delete")]       //Deleted view created
        public IActionResult Delete(int id)
        {
            User data = Users.Find(x => x.Id == id);

            if (data!=null)
            { 
                Users.Remove(data);
            }
            return RedirectToAction("Index");       //Deleted user and redirected to Index

        }
    }
}

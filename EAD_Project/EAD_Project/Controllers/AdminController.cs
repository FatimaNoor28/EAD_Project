using EAD_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace EAD_Project.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("SignUpAdmin");
        }
        [HttpPost]
        public IActionResult SignUpAdmin(string CNIC,string Name, string password)
        {
            AdminRepository ar = new AdminRepository();
            if (ar.SignUpAdmin(CNIC,Name, password))
            {
                ViewData["Msg"] = "You are Siggned Up Successfully,LogIn to continue";
                return View("Login");
            }
            else
            {
                return View("UnsuccessfulSignUp");
            }
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View("Login");
        }
        [HttpPost]
        public IActionResult Login(string CNIC, string password)
        {

            AdminRepository ar = new AdminRepository();
            if (ar.Authenticate(CNIC, password))
            {
             var   a=ar.FindAdminId(CNIC, password);
                var A_name = ar.find_AdminName(CNIC, password);
                HttpContext.Response.Cookies.Append("Cookie", a.ToString());
                HttpContext.Response.Cookies.Append("UserType", "Admin");
                HttpContext.Response.Cookies.Append("AdminUserName", A_name);
                ViewData["AdminUserName"] = A_name;

                return View("Index");
            }
                
            else return View("UnsuccessfulLogin");
        }
       
        [HttpGet]
        public ViewResult AddPatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View("AddPatient");
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }

        }
        [HttpPost]
        public ViewResult AddPatient(/*int Id, string Name,*/ string CNIC, string name, string password, string Doctor/*, int RoomNo*/)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                PatientRepository pr = new PatientRepository();
                if(pr.SignUpPatient(CNIC, name, password))
                    return View("Index");
            }
            ViewData["Msg"] = "Login to Access this Page ,Error 404";
            return View("Login");

        }
        [HttpGet]
        public ViewResult FindPatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        [HttpPost]
        public ViewResult FindPatient(int Id)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                AdminRepository ar = new AdminRepository();
                Patient p = ar.find_Patient(Id);
                return View("DisplayPatient",p);
            }
            ViewData["Msg"] = "Login to Access this Page ,Error 404";
            return View("Login");
        }

        [HttpGet]
        public ViewResult DisplayPatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        [HttpGet]
        public ViewResult UpdatePatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];

                return View("UpdatePatient");
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
            
        }
        [HttpPost]
        public ViewResult UpdatePatient(int Id, string Name, string CNIC, string PhoneNum, string Doctor, int RoomNo)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
               
                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        [HttpGet]
        public ViewResult AssignRoom()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                return View("AssignRoom");
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
            
        }
        [HttpPost]
        public ViewResult AssignRoom(int Id, int RoomNo)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
               

                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }
        [HttpGet]
        public ViewResult DeletePatient()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                return View();
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
            
        }
        [HttpPost]
        public ViewResult DeletePatient(int Id)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                AdminRepository ar = new AdminRepository();
                Patient p = ar.find_Patient(Id);
                ar.RemovePatient(Id);
                if (ar.find_Patient(Id) == null)
                    return View("Index");
            }
            ViewData["Msg"] = "Login to Access this Page ,Error 404";
            return View("Login");
        }

        [HttpGet]
        public ViewResult AllPatients()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie") && HttpContext.Request.Cookies.ContainsKey("UserType") && (HttpContext.Request.Cookies["UserType"].Equals("Admin")))
            {
                ViewData["AdminUserName"] = HttpContext.Request.Cookies["AdminUserName"];
                AdminRepository ar = new AdminRepository();
                List<Patient> p = ar.GetAllPatients();
                return View(p);
            }
            else
            {
                ViewData["Msg"] = "Login to Access this Page ,Error 404";
                return View("Login");
            }
        }

    }
}

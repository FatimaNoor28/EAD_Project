using EAD_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace EAD_Project.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View("PatientSignUp");
        }
        [HttpPost]
        public IActionResult PatientSignUp(string CNIC,string username, string password) {
            PatientRepository pr = new PatientRepository();
            if (pr.SignUpPatient(CNIC,username, password))
            {
                ViewData["Msg"] = "You are Signed Up Successfully,LogIn to continue";
                return View("PatientLogin");
            }
            else
            {
                return View("UnsuccessfulSignUp");
            }
        }
        [HttpGet]
        public IActionResult PatientLogin()
        {

            return View("PatientLogin");
        }
        [HttpPost]
        public IActionResult PatientLogin(string CNIC, string password)
        {
            PatientRepository pr = new PatientRepository();

            if ((pr.Authenticate(CNIC, password)))
            {
                int p =  pr.find_Patient( CNIC,  password);
                HttpContext.Response.Cookies.Append("Cookie", p.ToString());
                AppointmentRepository ar = new AppointmentRepository();
                List<Appointment> appointments = new List<Appointment>();

                appointments = ar.GetAppointments(CNIC);
                MakeAppointment(appointments);

                return View("MakeAppointment");
            }    
            return View("LoginUnsuccessful");
        }

        [HttpGet]
        public IActionResult MakeAppointment(List<Appointment> p)
        {
            return View(p);
        }
        [HttpPost]
        public IActionResult Receipt(string name, string phone, string date, string doctor)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Cookie"))
            {
                int id = Convert.ToInt32( HttpContext.Request.Cookies["Cookie"]);
                PatientRepository repository = new PatientRepository();
                Patient p = repository.MakeAppointment(id, name, phone, date, doctor);

            }
            return View(p);
        }
        
    }
}

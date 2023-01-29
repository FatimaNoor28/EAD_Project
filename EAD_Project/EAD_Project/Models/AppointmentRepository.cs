namespace EAD_Project.Models
{
    public class AppointmentRepository
    {
        public AppointmentRepository() { }
        public List<Appointment> GetAppointments(string CNIC) { 
            List<Appointment> list = new List<Appointment>();
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            DateTime CurrentDate = DateTime.Now;
            DateOnly d = DateOnly.FromDateTime(CurrentDate);
            Console.WriteLine(d);
            list = db.Appointments.Select(p => p).Where(p => DateOnly.Parse(p.Date) >= d).ToList();/*.Where(p=> DateOnly.Parse(p.AppointmentDate) >= d )*/;
            return list;
        }
    }
}

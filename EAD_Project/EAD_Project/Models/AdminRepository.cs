using Microsoft.IdentityModel.Tokens;

namespace EAD_Project.Models
{
    public class AdminRepository
    {
        public AdminRepository() { }
        public bool Authenticate(string username, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            if ((db.Admins.Where(a => a.CNIC.Equals(username) && a.Password.Equals(password)).ToList()).IsNullOrEmpty())
                return false;
            return true;
        }
        public int FindAdminId(string username, string password)
        {

            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            var a = db.Admins.Where(a => (a.CNIC.Equals(username)) && a.Password.Equals(password)).Select(c => c.AdminId).FirstOrDefault();
            /* int p = System.Convert.ToInt32( db.Patients.Where(a => (a.CNIC.Equals(username)) && a.Password.Equals(password)).Select(p=>p.Id));*/
            return (int)a;


        }
        public string find_AdminName(string username, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            var p = db.Admins.Where(a => (a.CNIC.Equals(username)) && a.Password.Equals(password)).Select(c => c.Name).FirstOrDefault();
            return p;
        }
        public bool SignUpAdmin(string CNIC,string Name, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            if (db.Admins.Where(x => x.CNIC.Equals(CNIC)).ToList().IsNullOrEmpty())
            {
                Admin admin = new Admin();


                admin.Name = Name;
                admin.CNIC = CNIC;
                admin.Password = password;
                db.Admins.Add(admin);
                db.SaveChanges();
            }
            else
            {
                return false;
            }
           
            return (!db.Admins.Where(x => x.CNIC.Equals(CNIC) && x.Password.Equals(password)).ToList().IsNullOrEmpty());

        }
    }
}

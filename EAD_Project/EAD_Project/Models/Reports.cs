using System.ComponentModel.DataAnnotations.Schema;

namespace EAD_Project.Models
{
    public class Reports
    {
        public int Id { get; set; }
        public string link { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }    

    }
}

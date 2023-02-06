namespace EAD_Project.Models
{
    public class FullAudinModel: IAuditedModel
    {
     
        public DateTime CreatedDate { get; set; }
       
        public DateTime? LastModifiedDate { get; set; }
    }
}

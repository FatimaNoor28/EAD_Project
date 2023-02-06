namespace EAD_Project.Models
{
    public interface IAuditedModel
    {
        
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

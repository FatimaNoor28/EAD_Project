using System;
using System.Collections.Generic;

namespace EAD_Project.Models;

public partial class Patient:FullAudinModel
{
    public int Id { get; set; }
    public string CNIC { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

   public ICollection<Reports>? reports { get; set; }
    public ICollection<Appointment>? appointments { get; set; } 

}

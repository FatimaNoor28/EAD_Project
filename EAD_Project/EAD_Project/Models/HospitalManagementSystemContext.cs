using System;
using System.Collections.Generic;
using EAD_Project.Controllers;
using Microsoft.EntityFrameworkCore;

namespace EAD_Project.Models;
public partial class HospitalManagementSystemContext : DbContext {
    public HospitalManagementSystemContext()
    {
        Database.Migrate();
    }
    public  DbSet<Admin> Admins { get; set; }

    public  DbSet<Appointment> Appointments { get; set; }

    public  DbSet<Doctor> Doctors { get; set; }

    public  DbSet<Patient> Patients { get; set; }
    
    public DbSet<Reports> Reports { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlServer(@"Server = localhost, 1440; Database = master; User = sa; Password =\r\nDocker123!;");
           
           //$"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    public override int SaveChanges()
    {
        ProccessSave();
        return base.SaveChanges();
    }
    private void ProccessSave()
    {
        var tracker = ChangeTracker;
        foreach (var entry in tracker.Entries())
        {
            if(entry.Entity is FullAudinModel)
            {
                var referenceEntity = entry.Entity as FullAudinModel;
                switch (entry.State)
                {
                    case EntityState.Added:
                       
                        referenceEntity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        referenceEntity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
        }
    }
}
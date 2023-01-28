﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Numerics;

namespace EAD_Project.Models
{
    public class PatientRepository
    {
        public PatientRepository() { }
        public bool Authenticate(string username, string password)
        {

            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            if ((db.Patients.Where(a => (a.CNIC.Equals(username)) && a.Password.Equals(password)).ToList()).IsNullOrEmpty())
                return false;

            return true;
        }
        public Patient find_Patient(string username, string password)
        {

            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            Patient p = (Patient)db.Patients.Select(p => p).Where(a => (a.CNIC.Equals(username)) && a.Password.Equals(password));
            return p;

    
        }
        public bool SignUpPatient(int username, string password)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            Patient patient = new Patient();
            //patient.PatientId = username;
            patient.Password = password;
            db.Patients.Add(patient);
            db.SaveChanges();
            return (!db.Patients.Where(x => (x.CNIC.Equals(username)) && x.Password.Equals(password)).ToList().IsNullOrEmpty());
        }

        public List<Patient> GetAllAppointments(string username)
        {
            List<Patient> patients = new List<Patient>();
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            DateTime CurrentDate = DateTime.Now;/*.ToString("dd/MM/yyyy")*/
            DateOnly d = DateOnly.FromDateTime(CurrentDate);
            //DateOnly.TryParseExact(CurrentDate, "dd/MM/yyyy",d);

            Console.WriteLine(d);

            var p = db.Patients.Select(p => p.CNIC.Where(p => p.Equals(username)))/*.Where(p=> DateOnly.Parse(p.AppointmentDate) >= d )*/;



            return patients;
        }
        public Patient MakeAppointment(string name, string CNIC, string phone, string date,string department, string doctor)
        {
            HospitalManagementSystemContext db = new HospitalManagementSystemContext();
            Patient p  = (Patient)db.Patients.Where(p=>p.CNIC.Equals(CNIC));
            Appointment a = new Appointment
            {
                
            };
            //db.SaveChanges();
            return p;
        }
    }
}
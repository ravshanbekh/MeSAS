﻿using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.Doctors;

public class DoctorCreationDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string Password { get; set; }
    [Phone]
    public string Phone { get; set; }
    public string Score { get; set; }
    public long HospitalId { get; set; }
    public string Specialization { get; set; } // Shifokorning mutaxassisligi
    public string LicenseNumber { get; set; }
}

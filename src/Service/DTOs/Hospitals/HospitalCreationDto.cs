using Domain.Enums;
using Service.DTOs.Attachments;

namespace Service.DTOs.Hospitals;

public class HospitalCreationDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public HospitalType HospitalType { get; set; }
}

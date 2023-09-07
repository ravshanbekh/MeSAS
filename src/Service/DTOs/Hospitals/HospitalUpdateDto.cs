using Domain.Enums;
using Service.DTOs.Attachments;

namespace Service.DTOs.Hospitals;

public class HospitalUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public HospitalType HospitalType { get; set; }
    public long AttachmentId { get; set; }
}

using Domain.Enums;
using Service.DTOs.Analyses;
using Service.DTOs.Attachments;
using Service.DTOs.MedicalRecords;
using Service.DTOs.Messages;

namespace Service.DTOs.Users;

public class UserResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public UserRole Role { get; set; }
    public long? AttachmentId { get; set; }
    public ICollection<AnalyseResultDto> Analyses { get; set; }
    public ICollection<MedicalRecordResultDto> MedicalRecords { get; set; }
    public ICollection<MessageResultDto> Message { get; set; }

}

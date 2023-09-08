using Domain.Enums;

namespace MedicalHealthAssistantApi.Models;

public class UserViewUpdate
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public long? AttachmentId { get; set; }
}

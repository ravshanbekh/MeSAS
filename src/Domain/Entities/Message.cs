using Domain.Commons;

namespace Domain.Entities;

public class Message :Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long HospitalId { get; set; }
    public Hospital Hospital { get; set; }
    public string MessageBody { get; set; }
}

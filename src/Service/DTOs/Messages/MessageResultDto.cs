namespace Service.DTOs.Messages;

public class MessageResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long HospitalId { get; set; }
    public string BodyMassege { get; set; }
}

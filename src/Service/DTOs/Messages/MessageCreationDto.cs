namespace Service.DTOs.Messages;

public class MessageCreationDto
{
    public long UserId { get; set; }
    public long HospitalId { get; set; }
    public string BodyMassege { get; set; }
}

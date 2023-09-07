using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Attachments;

public class AttachmentCreationDto
{
    public IFormFile FormFile { get; set; }
}

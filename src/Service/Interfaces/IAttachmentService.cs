using Domain.Entities;
using Domain.Entitiesrg;
using Service.DTOs.Attachments;

namespace Service.Interfaces;

public interface IAttachmentService
{
    Task<Attachment> UploadAsync(AttachmentCreationDto dto);
    Task<bool> RemoveAsync(Attachment attachment);
}

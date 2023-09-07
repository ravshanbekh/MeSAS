using Domain.Entitiesrg;
using Service.DTOs.Attachments;
using Service.Interfaces;

namespace Service.Services;

public class AttachmentService : IAttchamentService
{
    public Task<bool> RemoveAsync(Attachment attachment)
    {
        throw new NotImplementedException();
    }

    public Task<Attachment> UploadAsync(AttachmentCreationDto dto)
    {
        throw new NotImplementedException();
    }
}

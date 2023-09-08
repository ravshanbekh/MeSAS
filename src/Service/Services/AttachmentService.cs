using DAL.IRepositories;
using Domain.Entities;
using Service.DTOs.Attachments;
using Service.Extensions;
using Service.Helpers;
using Service.Interfaces;


namespace Service.Services;

public class AttachmentService : IAttachmentService
{
    private readonly IRepository<Attachment> repository;

    public AttachmentService(IRepository<Attachment> repository)
    {
        this.repository = repository;
    }

    public async Task<Attachment> UploadAsync(AttachmentCreationDto dto)
    {
        var webrootPath = Path.Combine("C:\\Users\\hp\\source\\repos\\MedicalHelathAssistantApp\\src\\MedicalHealthAssistantApi\\wwwroot\\", "Files");
        if(!Directory.Exists(webrootPath))
        {
            Directory.CreateDirectory(webrootPath);
        }

        var fileExtension = Path.GetExtension(dto.FormFile.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtension}";
        var fullpath=Path.Combine(webrootPath, fileName);

        var fileStream = new FileStream(fullpath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(dto.FormFile.ToByte());

        var createAttachment = new Attachment
        {
            FileName = fileName,
            FilePath = fullpath,
        };

        await repository.AddAsync(createAttachment);
        await repository.SaveAsync();

        return createAttachment;
    }
    public Task<bool> RemoveAsync(Attachment attachment)
    {
        throw new NotImplementedException();
    }

}

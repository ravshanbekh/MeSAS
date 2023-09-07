using DAL.IRepositories;
using DAL.Repositories;
using Service.Interfaces;
using Service.Mappers;
using Service.Services;

namespace MedicalHealthAssistantApi.Extensions;

public static class ServicesCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAnalyseService, AnalyseService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IMedicalRecordService, MedicalRecordService>();
        services.AddScoped<IHospitalService, HospitalService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IAttachmentService, AttachmentService>();


        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddAutoMapper(typeof(MappingProfile));

    }

}

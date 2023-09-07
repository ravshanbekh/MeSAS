using AutoMapper;
using Domain.Entities;
using Domain.Entitiesrg;
using Service.DTOs.Analyses;
using Service.DTOs.Attachments;
using Service.DTOs.Bookings;
using Service.DTOs.Doctors;
using Service.DTOs.Hospitals;
using Service.DTOs.MedicalRecords;
using Service.DTOs.Messages;
using Service.DTOs.Users;

namespace Service.Mappers;

public class MappingProFile : Profile
{
    public MappingProFile()
    {
        // User
        CreateMap<User, UserResultDto>().ReverseMap();
        CreateMap<UserCreationDto, User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();

        // Message
        CreateMap<Message, MessageResultDto>().ReverseMap();
        CreateMap<MessageCreationDto, Message>().ReverseMap();
        CreateMap<MessageUpdateDto, Message>().ReverseMap();

        // MedicalRecord
        CreateMap<MedicalRecord, MedicalRecordResultDto>().ReverseMap();
        CreateMap<MedicalRecordCreationDto, MedicalRecord>().ReverseMap();

        // Hospital
        CreateMap<Hospital, HospitalResultDto>().ReverseMap();
        CreateMap<HospitalCreationDto, Hospital>().ReverseMap();
        CreateMap<HospitalUpdateDto, Hospital>().ReverseMap();

        // Doctor
        CreateMap<Doctor, DoctorResultDto>().ReverseMap();
        CreateMap<DoctorCreationDto, Doctor>().ReverseMap();
        CreateMap<DoctorUpdateDto, Doctor>().ReverseMap();

        // Booking
        CreateMap<Booking, BookingResultDto>().ReverseMap();
        CreateMap<BookingCreationDto, Booking>().ReverseMap();
        CreateMap<BookingUpdateDto, Booking>().ReverseMap();

        // Analyse
        CreateMap<Analyse, AnalyseResultDto>().ReverseMap();
        CreateMap<AnalyseCreationDto, Analyse>().ReverseMap();

        // Attachment
        CreateMap<Attachment, AttachmentResultDto>().ReverseMap();
        CreateMap<AttachmentCreationDto, Attachment>().ReverseMap();
    }
}

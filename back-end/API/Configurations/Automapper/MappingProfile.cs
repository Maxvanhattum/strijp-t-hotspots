using AutoMapper;
using DataTransferObjects;
using Models;
using ViewModels;
using ViewModels.CreateHotspot;

namespace Strijp_T_Hotspots.Configurations.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateRequest, UserCreateRequestDTO>(MemberList.Source);
            CreateMap<UserLoginRequest, UserLoginRequestDTO>(MemberList.Source);



            CreateMap<AddressVM, AddressDTO>(MemberList.Source);
            CreateMap<AR360VM, AR360DTO>(MemberList.Source);
            CreateMap<BusinessVM, BusinessDTO>();
            CreateMap<GeocoordinatesVM, GeocoordinatesDTO>(MemberList.Source);
            CreateMap<InterviewVM, InterviewDTO>(MemberList.Source);

            CreateMap<CreateAddressVM, AddressDTO>(MemberList.Source);
            CreateMap<CreateAR360VM, AR360DTO>(MemberList.Source);
            CreateMap<CreateBusinessVM, BusinessDTO>(MemberList.Source);
            CreateMap<CreateGeocoordinatesVM, GeocoordinatesDTO>(MemberList.Source);
            CreateMap<CreateInterviewVM, InterviewDTO>(MemberList.Source);

            CreateMap<CreateHotspotDTO, Hotspot>(MemberList.Source);
            CreateMap<AddressDTO, Address>(MemberList.Source);
            CreateMap<AR360DTO, AR360>(MemberList.Source);
            CreateMap<BusinessDTO, Business>(MemberList.Source);
            CreateMap<GeocoordinatesDTO, GeoCoordinates>(MemberList.Source);
            CreateMap<InterviewDTO, MovieInterviewDetails>(MemberList.Source);

            CreateMap<CreateHotspotVM, CreateHotspotDTO>(MemberList.Source);
            CreateMap<UpdateHotspotVM, UpdateHotspotDTO>(MemberList.Source);
        }
    }
}

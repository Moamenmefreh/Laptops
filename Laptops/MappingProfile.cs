using System.Diagnostics;
using AutoMapper;
using Laptops.DTo;
using Laptops.Model;

namespace Laptops
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Storage, StorageDTO>().
                ForMember(des=>des.storageId,opt=>opt.MapFrom(src=>src.Id)).
                ForMember(des => des.storageCapacity, opt => opt.MapFrom(src => src.Capacity)).
                ForMember(des => des.storageType, opt => opt.MapFrom(src => src.Type)).ReverseMap();
            CreateMap<Laptop, LaptopDTO>()
                .ReverseMap();

            CreateMap<Laptop, allLaptopDto >().ForMember(des=>des.processorName, opt=>opt.MapFrom(src=>src.Processor.Name)).
                ForMember(des=>des.ramType,opt=>opt.MapFrom(src=>src.Ram.Type)).
                ForMember(des=>des.storageType,opt=>opt.MapFrom(src=>src.Storage.Type))
                .ReverseMap();
            CreateMap<Ram, ramDTO>().
                ForMember(des => des.ramType, opt => opt.MapFrom(src => src.Type)).ReverseMap();
            CreateMap<Processor, processorDTO>().ReverseMap();
            CreateMap<User, userDTO>().
                ForMember(des => des.userId, opt => opt.MapFrom(src => src.Id)).
                ForMember(des => des.FullNameAndAddress, opt => opt.MapFrom(src => string.Join(' ', src.Name, src.Address))).
                ForMember(des => des.laptopName, opt => opt.MapFrom(src => src.Laptop.laptopName)).ReverseMap();

        }
    }
}

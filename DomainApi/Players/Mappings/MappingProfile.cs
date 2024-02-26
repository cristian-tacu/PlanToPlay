using AutoMapper;
using DomainApi.Players.Commands;
using DomainApi.Players.Enums;
using DomainApi.Players.Models;

namespace DomainApi.Players.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // CreateMap<TranslationResult, TranslationResultDto>()
        //     .ForMember(tr => tr.Id, opt => opt.Ignore());

        CreateMap<PostRoomCommand, RoomModel>()
            .ForMember(l => l.Name, opt => opt.MapFrom(l => l.Room.Name))
            .ForMember(l => l.Description, opt => opt.MapFrom(l => l.Room.Description))
            .ForMember(l => l.Id, opt => opt.MapFrom(src => KsuidDotNet.Ksuid.NewKsuid()));
        
        CreateMap<PostRoomCommand, PlayerRoomModel>()
            .ForMember(l => l.PlayerId, opt => opt.MapFrom(l => l.PlayerId))
            .ForMember(l => l.Role, opt => opt.MapFrom(l => l.RoomRole))
            .ForMember(l => l.Id, opt => opt.MapFrom(src => KsuidDotNet.Ksuid.NewKsuid()));
        
        CreateMap<JoinRoomCommand, PlayerRoomModel>()
            .ForMember(l => l.PlayerId, opt => opt.MapFrom(l => l.PlayerId))
            .ForMember(l => l.RoomId, opt => opt.MapFrom(l => l.RoomId))
            .ForMember(l => l.Role, opt => opt.MapFrom(src => RoomRole.Player))
            .ForMember(l => l.Id, opt => opt.MapFrom(src => KsuidDotNet.Ksuid.NewKsuid()));
        
        CreateMap<PostPlayerCommand, PlayerModel>()
            .ForMember(l => l.FirstName, opt => opt.MapFrom(l => l.Player.FirstName))
            .ForMember(l => l.LastName, opt => opt.MapFrom(l => l.Player.LastName))
            .ForMember(l => l.Email, opt => opt.MapFrom(l => l.Player.Email))
            .ForMember(l => l.Password, opt => opt.MapFrom(l => l.Player.Password))
            .ForMember(l => l.Grade, opt => opt.MapFrom(src => 8))
            .ForMember(l => l.Id, opt => opt.MapFrom(src => KsuidDotNet.Ksuid.NewKsuid()));
    }
}
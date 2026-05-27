using api.Infrastructure.ResponseDTOs.Abilities;
using api.Infrastructure.ResponseDTOs.Characters;
using api.Infrastructure.ResponseDTOs.Epochs;
using api.Infrastructure.ResponseDTOs.Pathways;
using api.Infrastructure.ResponseDTOs.Sequences;
using api.Infrastructure.ResponseDTOs.Users;
using AutoMapper;
using Common.Entity;

namespace api.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Ability, AbilityResponse>().IncludeAllDerived();
        CreateMap<User, UserResponse>().IncludeAllDerived();
        CreateMap<Sequence, SequenceResponse>().IncludeAllDerived();
        CreateMap<Character, CharacterResponse>().IncludeAllDerived();
        CreateMap<Pathway, PathwayResponse>().IncludeAllDerived();
        CreateMap<Epoch, EpochResponse>().IncludeAllDerived();
    }
}
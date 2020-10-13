using System;
using Commander.Models;
using AutoMapper;

namespace Commander.Profiles
{
    // Mapping Profile: Automapper class intended for use in mapping Database Model Objects to DTO's
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<Command, CommandReadDto>();
            // 
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
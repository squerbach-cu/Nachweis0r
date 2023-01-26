using AutoMapper;
using Nachweis0r.Models;

namespace Nachweis0r.Helper.AutoMapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<NotesViewModel, NotesModel>();
        CreateMap<NotesModel, NotesViewModel>();
    }
}
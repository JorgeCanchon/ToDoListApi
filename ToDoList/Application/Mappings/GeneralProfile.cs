using Application.DTOs;
using Application.Features.Categorias.Commands.CreateCategoriaCommand;
using Application.Features.Tareas.Commands.CreateTareaCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<Tarea, TareaDto>();
            //CreateMap<List<Categoria>, List<CategoriaDto>>();
            //CreateMap<List<Tarea>, List<TareaDto>>();
            #endregion

            #region Commands
            CreateMap<CreateCategoriaCommand, Categoria>().ReverseMap();
            CreateMap<CreateTareaCommand, Tarea>().ReverseMap();
            #endregion
        }
    }
}

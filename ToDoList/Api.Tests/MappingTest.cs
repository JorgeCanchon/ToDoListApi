using Application.DTOs;
using Application.Features.Categorias.Commands.CreateCategoriaCommand;
using Application.Features.Tareas.Commands.CreateTareaCommand;
using AutoMapper;
using Domain.Entities;

namespace Api.Tests
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<Tarea, TareaDto>();
            CreateMap<CreateCategoriaCommand, Categoria>().ReverseMap();
            CreateMap<CreateTareaCommand, Tarea>().ReverseMap();
        }
    }
}

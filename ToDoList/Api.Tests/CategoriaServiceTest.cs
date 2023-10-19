using Application.Features.Categorias.Queries.GetAllCategorias;
using AutoMapper;
using Domain.Entities;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence.Contexts;
using Persistence.Repository;
using Xunit;
using static Application.Features.Categorias.Queries.GetAllCategorias.GetAllCategoriasQuery;

namespace Api.Tests
{
    public class CategoriaServiceTest
    {
        private IEnumerable<Categoria> ObtenerDataPrueba()
        {
            A.Configure<Categoria>()
                .Fill(x => x.Id, () => { return Random.Shared.Next(); })
                .Fill(x => x.Nombre).AsFirstName()
                .Fill(x => x.Activo, () => { return true; });

            var lista = A.ListOf<Categoria>(30);

            return lista;
        }

        private Mock<ApplicationDbContext> CrearContexto()
        {
            var dataPrueba = ObtenerDataPrueba().AsQueryable();

            var dbSet = new Mock<DbSet<Categoria>>();
            dbSet.As<IQueryable<Categoria>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);
            dbSet.As<IQueryable<Categoria>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);
            dbSet.As<IQueryable<Categoria>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);
            dbSet.As<IQueryable<Categoria>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Categoria>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<Categoria>(dataPrueba.GetEnumerator()));

            dbSet.As<IQueryable<Categoria>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Categoria>(dataPrueba.Provider));

            var contexto = new Mock<ApplicationDbContext>();
            contexto.Setup(x => x.Categorias).Returns(dbSet.Object);

            return contexto;
        }

        [Fact]
        public async void GetClientes()
        {
            //System.Diagnostics.Debugger.Launch();

            var mockICLiente = new RepositoryAsync<Categoria>(CrearContexto().Object);
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });
            var mapper = mapConfig.CreateMapper();

            GetAllCategoriasQueryHandler manejador = new GetAllCategoriasQueryHandler(mockICLiente, mapper);
            GetAllCategoriasQuery request = new GetAllCategoriasQuery();

            var lista = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.True(lista.Result.Any());
        }
    }
}

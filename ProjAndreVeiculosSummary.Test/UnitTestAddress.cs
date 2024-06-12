using AndreVeiculosSummary.Controllers;
using AndreVeiculosSummary.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Xunit;

namespace ProjAndreVeiculosSummary.Test
{
    public class UnitTestAddress
    {
        private DbContextOptions<AndreVeiculosSummaryContext> options;

        private void InitializeDataBase()
        {
            options = new DbContextOptionsBuilder<AndreVeiculosSummaryContext>()
                               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                              .Options;

            using (var context = new AndreVeiculosSummaryContext(options))
            {
                context.Address.Add(new Address { Id = 1, Cep = "15997088", Descricao = "Rua do beco diagonal" });
                context.Address.Add(new Address { Id = 2, Cep = "15997080", Descricao = "Rua do beco diagonal" });
                context.Address.Add(new Address { Id = 3, Cep = "15997028", Descricao = "Rua do beco diagonal" });
                context.SaveChanges();
            }
        }

        [Fact]
        public void TestGetAll()
        {
            InitializeDataBase();

            using (var context = new AndreVeiculosSummaryContext(options))
            {
                AddressesController addressesController = new AddressesController(context);
                IEnumerable<Address> addresses = addressesController.GetAddress().Result.Value;
                Assert.Equal(3, addresses.Count());
            }
        }
        [Fact]
        public void TestGetById()
        {
            InitializeDataBase();

            using (var context = new AndreVeiculosSummaryContext(options))
            {
                AddressesController addressesController = new AddressesController(context);
                Address address = addressesController.GetAddress(1).Result.Value;
                Assert.Equal(1, address.Id);

            }
        }
        [Fact]
        public void TestCreate()
        {
            InitializeDataBase();

            using (var context = new AndreVeiculosSummaryContext(options))
            {
                AddressesController addressesController = new AddressesController(context);
                Address address = new Address { Id = 4, Cep = "15997030", Descricao = "Rua do lua" };
                var add = addressesController.PostAddress(address).Result.Value;
                Assert.Equal("15997030", add.Cep);
            }
        }
    }
}
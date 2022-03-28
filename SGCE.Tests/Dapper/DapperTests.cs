using SGCE.Domain.StoreContext.ClienteCommands.Inputs;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Enums;
using SGCE.Domain.StoreContext.ValueObjects;
using SGCE.Infra.DataContexts;
using SGCE.Infra.StoreContext.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SGCE.Tests
{
    //[TestClass]
    //public class DapperTests
    //{
    //    [TestMethod]
    //    public void DeleteMe()
    //    {
    //        var ctx = new SgceDataContext();
    //        var repo = new ClienteRepository(ctx);

    //        Assert.AreEqual(repo.CheckDocument("99999999999"), true);
    //    }

    //    [TestMethod]
    //    public void DeleteMeToo()
    //    {
    //        var ctx = new SgceDataContext();
    //        var repo = new ClienteRepository(ctx);

    //        // Recupera os produtos do banco
    //        var Nome = new Nome("André", "Baltieri");
    //        var document = new Document("46718115533");
    //        var email = new Email("hello@balta.io");
    //        var Cliente = new Cliente(Nome, document, email, "551999876542");
    //        var address = new Address("Rua", "1", "N/A", "Meu Bairro", "Piracicaba", "SP", "BR", "13400000", EAddressType.Billing);
    //        var address2 = new Address("Rua2", "2", "N/A", "Meu Bairro", "Piracicaba", "SP", "BR", "13400000", EAddressType.Shipping);
    //        Cliente.AddAddress(address);
    //        Cliente.AddAddress(address2);

    //        repo.Save(Cliente);
    //    }
    //}
}

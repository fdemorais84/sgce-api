using SGCE.Domain.StoreContext.ClienteCommands.Inputs;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Handlers;
using SGCE.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SGCE.Tests
{
    //[TestClass]
    //public class ClienteHandlerTests
    //{
    //    [TestMethod]
    //    public void ShouldRegisterClienteWhenCommandIsValid()
    //    {
    //        var command = new CreateClienteCommand();
    //        command.FirstNome = "André";
    //        command.LastNome = "Baltieri";
    //        command.Document = "28659170377";
    //        command.Email = "andrebaltieri@gmail.com";
    //        command.Phone = "11999999997";

    //        var handler = new ClienteHandler(new FakeClienteRepository(), new FakeEmailService());
    //        var result = handler.Handle(command);

    //        Assert.AreNotEqual(null, result);
    //        Assert.AreEqual(true, handler.IsValid);
    //    }
    //}
}

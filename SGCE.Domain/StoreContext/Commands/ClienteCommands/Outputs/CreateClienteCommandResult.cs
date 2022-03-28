using System;
using SGCE.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace SGCE.Domain.StoreContext.ClienteCommands.Inputs
{
    public class CreateClienteCommandResult : ICommandResult
    {
        public CreateClienteCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
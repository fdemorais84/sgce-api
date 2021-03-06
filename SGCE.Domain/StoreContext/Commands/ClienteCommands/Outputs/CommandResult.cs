using System;
using SGCE.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace SGCE.Domain.StoreContext.ClienteCommands.Inputs
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
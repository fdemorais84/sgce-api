using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Commands.CategoriaCommands.Outputs
{
    public class CreateCategoriaCommandResult : ICommandResult
    {
        public CreateCategoriaCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

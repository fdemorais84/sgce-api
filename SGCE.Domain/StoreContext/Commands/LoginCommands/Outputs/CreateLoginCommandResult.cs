using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Commands.LoginCommands.Outputs
{
    public class CreateLoginCommandResult : ICommandResult
    {
        public CreateLoginCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
            //Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        //public object Data { get; set; }
    }
}

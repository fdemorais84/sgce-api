﻿using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Commands.ClienteCommands.Outputs
{
    public class UpdateClienteCommandResult : ICommandResult
    {
        public UpdateClienteCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

using System;

namespace SGCE.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
        ICommandResult Handle(Guid id, T command);
    }
}
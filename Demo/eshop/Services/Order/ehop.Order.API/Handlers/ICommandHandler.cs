using ehop.Order.API.Commands;

namespace ehop.Order.API.Handlers
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);

    }
}

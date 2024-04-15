using MediatR;

namespace Grove.Shared.Abstraction
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out T> : IRequest<T>
    {
    }
}

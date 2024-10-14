using MediatR;

namespace Backend.Application.Handlers.Products.Requests.Commands
{
    public class DeleteProductCommand(Guid id) : IRequest<bool>
    {
        public Guid Id { get; set; } = id;
    }
}
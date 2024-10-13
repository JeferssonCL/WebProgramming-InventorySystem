using MediatR;

namespace Backend.Application.Handlers.Product.Requests.Commands
{
    public class DeleteProductCommand(int id) : IRequest<bool>
    {
        public int Id { get; set; } = id;
    }
}
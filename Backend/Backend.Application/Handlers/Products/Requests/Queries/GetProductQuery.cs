using Backend.Domain.Entities.Concretes;
using MediatR;

namespace Backend.Application.Handlers.Products.Requests.Queries
{
    public class GetProductQuery(Guid id) : IRequest<Product?>
    {
        public Guid Id { get; set; } = id;
    }
}
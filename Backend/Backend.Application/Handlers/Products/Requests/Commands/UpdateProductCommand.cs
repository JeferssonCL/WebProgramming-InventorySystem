using Backend.Application.Dtos;
using Backend.Domain.Entities.Concretes;
using MediatR;

namespace Backend.Application.Handlers.Products.Requests.Commands
{
    public class UpdateProductCommand(Product product) : IRequest<Product>
    {
        public Product Product { get; set; } = product;
    }

}
using Backend.Application.Dtos.Product;
using Backend.Application.Handlers.Product.Requests.Commands;
using MediatR;

namespace Backend.Application.Handlers.Product.RequestHandlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        public Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
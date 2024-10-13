using Backend.Application.Dtos;
using Backend.Application.Handlers.Products.Requests.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IGenericDAO<Product> _productDao;
        public CreateProductCommandHandler(IGenericDAO<Product> productDao)
        {
            _productDao = productDao;
        }
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Product;
            await _productDao.CreateAsync(request.Product);
            return product;
        }
    }
}
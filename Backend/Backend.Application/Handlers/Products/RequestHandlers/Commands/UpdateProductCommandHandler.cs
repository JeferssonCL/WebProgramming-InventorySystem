using Backend.Application.Handlers.Products.Requests.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IGenericDAO<Product> _productDao;
        public UpdateProductCommandHandler(IGenericDAO<Product> productDao)
        {
            _productDao = productDao;
        }

        public Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Product;
            _productDao.UpdateAsync(product);
            return Task.FromResult(product);
        }
    }
}
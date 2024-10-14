using Backend.Application.Handlers.Products.Requests.Commands;
using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.DAO.Interfaces;
using MediatR;

namespace Backend.Application.Handlers.Products.RequestHandlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IGenericDAO<Product> _productDao;
        public DeleteProductCommandHandler(IGenericDAO<Product> productDao)
        {
            _productDao = productDao;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productDao.DeleteAsync(request.Id);
            return true;
        }
    }
}
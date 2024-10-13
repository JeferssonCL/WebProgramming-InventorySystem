using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.DAO.Bases;

namespace Backend.Infrastructure.DAO.Concretes;

public class ProductAttributeDAO(PostgresContext context) : GenericDAO<ProductAttribute>(context);
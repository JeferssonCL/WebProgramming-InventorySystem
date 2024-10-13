using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.DAO.Bases;

namespace Backend.Infrastructure.DAO.Concretes;

public class OrderItemDAO(PostgresContext context) : GenericDAO<OrderItem>(context);
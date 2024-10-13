using Backend.Domain.Entities.Concretes;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.DAO.Bases;

namespace Backend.Infrastructure.DAO.Concretes;

public class OrderDAO(PostgresContext context) : GenericDAO<Order>(context);
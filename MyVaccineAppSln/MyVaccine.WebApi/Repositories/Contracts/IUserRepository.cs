using Microsoft.AspNetCore.Identity;
using MyVaccine.WebApi.Dtos.Auth;
using MyVaccine.WebApi.Models;
using System.Linq.Expressions;

namespace MyVaccine.WebApi.Repositories.Contracts;

public interface IUserRepository : IBaseRepository<User>
{
    Task AddAsync(User user);
    IQueryable<User> FindByAsNoTracking(Expression<Func<User, bool>> predicate);
    Task<IEnumerable<User>> GetAllAsync();
    Task<IdentityResult> AddUser(RegisterRequetDto request);
    Task Delete(User entity);
    Task<User?> GetByIdAsync(int id);
}

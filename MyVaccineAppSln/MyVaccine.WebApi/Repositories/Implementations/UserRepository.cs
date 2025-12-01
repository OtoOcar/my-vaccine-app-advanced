using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.Auth;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using System.Transactions;

namespace MyVaccine.WebApi.Repositories.Implementations;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly MyVaccineAppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public UserRepository(MyVaccineAppDbContext context, UserManager<IdentityUser> userManager) : base(context)
    {
        _context = context;
        _userManager = userManager;
    }

    // Implementación de AddAsync(User)
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    // Tu método especializado AddUser(RegisterRequetDto)
    public async Task<IdentityResult> AddUser(RegisterRequetDto request)
    {
        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var identityUser = new ApplicationUser
        {
            UserName = request.Username.ToLower(),
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(identityUser, request.Password);
        if (!result.Succeeded)
            return result;

        var newUser = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            AspNetUserId = identityUser.Id
        };

        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();

        scope.Complete();
        return result;
        //return response;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == id);
    }



}

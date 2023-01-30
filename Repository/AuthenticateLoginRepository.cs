using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;


namespace Library_Management_System.Repository
{
    public class AuthenticateLoginRepository : ILoginRepository
    {
        private readonly LibraryDbContext _context;

        public AuthenticateLoginRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<UserLogin> AuthenticateUser(string user, string pass)
        {
            var succeeded = await _context.UserLogins.FirstOrDefaultAsync(authUser => authUser.UserName == user && authUser.passcode == pass);
            return succeeded;
        }

        public async Task<IEnumerable<UserLogin>> getuser()
        {
            return await _context.UserLogins.ToListAsync();
        }
    }
}

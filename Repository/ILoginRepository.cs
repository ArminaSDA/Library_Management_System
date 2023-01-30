using Library_Management_System.Models;


namespace Library_Management_System.Repository
{
    public interface ILoginRepository
    {
        Task<IEnumerable<UserLogin>> getuser();
        Task<UserLogin> AuthenticateUser(string username, string passcode);
    }
}

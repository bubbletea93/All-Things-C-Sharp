namespace LegacyApp.Proxies
{
    using LegacyApp.DataAccess;
    using LegacyApp.Models;

    class UserDataAccessProxy : IUserDataAccess
    {
        public void AddUser(User user)
        {
            UserDataAccess.AddUser(user);
        }
    }
}

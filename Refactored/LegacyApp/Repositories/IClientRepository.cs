namespace LegacyApp.Repositories
{
    using LegacyApp.Models;

    public interface IClientRepository
    {
        public Client GetById(int id);
    }
}

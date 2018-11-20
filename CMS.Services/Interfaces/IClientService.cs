using CMS.Services.Models;
using System.Threading.Tasks;

namespace CMS.Services.Interfaces
{
    public interface IClientService
    {
        string AuthToken { get; set; }

        Task<Client[]> GetClientsForBranchAsync(string branchId);
        Task<Client> AddNewClientAsync(Client newClient);
        Task UpdateClientAsync(Client client);
        Task RemoveClientAsync(Client client);
    }
}

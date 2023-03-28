using WebApplicationForTestReactApi.DbContext;
using WebApplicationForTestReactApi.Model;

namespace WebApplicationForTestReactApi.Repository;

public class BankClientsRepository
{
    private CharpbankclientdbContext _dbContext;

    public BankClientsRepository()
    {
        _dbContext = new CharpbankclientdbContext();
    }

    public List<Client> GetAll()
    {
        return _dbContext.Clients.ToList();
    }

    public void AddNew(Client client)
    {
        _dbContext.Clients.Add(client);
        _dbContext.SaveChanges();
    }
}
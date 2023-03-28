using Microsoft.AspNetCore.Mvc;
using WebApplicationForTestReactApi.Model;
using WebApplicationForTestReactApi.Repository;

namespace WebApplicationForTestReactApi.Controller;

[ApiController]
[Route("[controller]/")]
public class BankClientsController : ControllerBase
{
    private BankClientsRepository _bankClientsRepository = new BankClientsRepository();

    [HttpGet("GetAll")]
    public List<Client> GetAll()
    {
        return _bankClientsRepository.GetAll();
    }
    
    [HttpPost("AddNew")]
    public void AddNew(Client client)
    {
        _bankClientsRepository.AddNew(client);
    }
}
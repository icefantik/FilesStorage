using FilesStorage.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilesStorage.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase
{
    public SearchController() 
    { 
    
    }

    [HttpGet(Name = "GetSearch")]
    public IEnumerable<Models.File> Get()
    {

    }
}

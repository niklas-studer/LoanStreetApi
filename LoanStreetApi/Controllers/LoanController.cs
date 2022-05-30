using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanStreetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ICosmosDBService cosmosDbService;

        public LoanController(ICosmosDBService cosmosDbService)
        {
            this.cosmosDbService = cosmosDbService;
        }


        // GET api/<LoanController>/5
        [HttpGet("{id}")]
        public async Task<Loan> Get(string id)
        {
            return await this.cosmosDbService.GetAsync(id);
        }

        // POST api/<LoanController>
        [HttpPost]
        public async Task Post([FromBody] Loan value)
        {
            if (value.id == null)
                value.id = new Guid();
            await this.cosmosDbService.AddAsync(value);
        }

        // PUT api/<LoanController>/5
        [HttpPut("{id}")]
        public async void Put(string id, [FromBody] Loan value)
        {
             await this.cosmosDbService.UpdateAsync(id, value);
        }
    }
}

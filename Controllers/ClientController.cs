using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Product.api.Domain.Models.User;
using Product.api.Infrastructure.Data.Contexts;
using ProductApi.Domain.Models.Dtos.Client;

namespace Product.api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly UserContext _context;

        public ClientController(UserContext context)
        {
            this._context = context;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {

            var response = await this._context.Clients.FindSync(new FilterDefinitionBuilder<Client>().Empty)
                .ToListAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {

            ObjectId objId = ObjectId.Parse(id);

            var response = await this._context.Clients.FindSync(
                    new FilterDefinitionBuilder<Client>().Where(x => x.Id == objId))
                .FirstOrDefaultAsync();

            return Ok(response);
        }

        [HttpPost()]
        public async Task<IActionResult> AddAsync(ClientRequest request)
        {

            if (!request.IsValid)
                return BadRequest(request.Erros);

            var product = (Client)request;
            product.Id = MongoDB.Bson.ObjectId.GenerateNewId(DateTime.Now);

            await this._context.Clients.InsertOneAsync(product);

            return Ok((ClientResponse)product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] ClientRequest request)
        {

            if (!request.IsValid)
                return BadRequest(request.Erros);

            ObjectId objId = ObjectId.Parse(id);

            var product = (Client)request;
            product.Id = objId;

            var filter = new FilterDefinitionBuilder<Client>()
                .Eq(nameof(product.Id), objId);

            var response = await this._context.Clients.ReplaceOneAsync(filter, product, null);

            return Ok((ClientResponse)product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {

            ObjectId objId = ObjectId.Parse(id);
            FilterDefinition<Client> filter = new FilterDefinitionBuilder<Client>()
                .Where(x => x.Id == objId);

            var response = await this._context.Clients.FindOneAndDeleteAsync(filter);

            return NoContent();
        }

    }
}
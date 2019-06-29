using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Product.api.Infrastructure.Data.Contexts;

namespace Product.api.Controllers {

    [ApiVersion ("1")]
    [Route ("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {

        private readonly ProductContext _context;

        public ProductController (ProductContext context) {
            this._context = context;
        }

        [HttpGet ()]
        public async Task<IActionResult> GetAsync () {

            var response = await this._context.Products.FindSync (new FilterDefinitionBuilder<Domain.Models.Product.Product> ().Empty)
                .ToListAsync ();

            return Ok (response);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetByIdAsync ([FromRoute] string id) {

            ObjectId objId = ObjectId.Parse (id);

            var response = await this._context.Products.FindSync (
                    new FilterDefinitionBuilder<Domain.Models.Product.Product> ().Where (x => x.Id == objId))
                .FirstOrDefaultAsync ();

            return Ok (response);
        }

        [HttpPost ()]
        public async Task<IActionResult> AddAsync (Domain.Models.Product.Product product) {

            product.Id = MongoDB.Bson.ObjectId.GenerateNewId (DateTime.UtcNow);
            await this._context.Products.InsertOneAsync (product);

            return CreatedAtAction (nameof (GetByIdAsync), product);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteAsync ([FromRoute] string id) {

            ObjectId objId = ObjectId.Parse (id);
            FilterDefinition<Domain.Models.Product.Product> filter = new FilterDefinitionBuilder<Domain.Models.Product.Product> ()
                .Where (x => x.Id == objId);

            var response = await this._context.Products.FindOneAndDeleteAsync (filter);

            return NoContent ();
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> DeleteAsync ([FromRoute] string id, [FromBody] Domain.Models.Product.Product product) {

            ObjectId objId = ObjectId.Parse (id);

            FilterDefinition<Domain.Models.Product.Product> filter = new FilterDefinitionBuilder<Domain.Models.Product.Product> ().Where (x => x.Id == objId);

            // var response = await this._context.Products.FindOneAndUpdateAsync (
            //        filter, 
            //         new UpdateDefinitionBuilder<Domain.Models.Product.Product> (),
            //         null, null);     

            return Ok ();
        }

    }
}
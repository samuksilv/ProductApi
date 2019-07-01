using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Product.api.Domain.Models.Dtos.Product;
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
        public async Task<IActionResult> AddAsync (ProductRequest request) {

            if (!request.IsValid)
                return BadRequest (request.Erros);

            var product = (Domain.Models.Product.Product) request;
            product.Id = MongoDB.Bson.ObjectId.GenerateNewId (DateTime.Now);

            await this._context.Products.InsertOneAsync (product);

            return Ok ((ProductResponse) product);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateAsync ([FromRoute] string id, [FromBody] ProductRequest request) {

            if (!request.IsValid)
                return BadRequest (request.Erros);

            ObjectId objId = ObjectId.Parse (id);

            var product = (Domain.Models.Product.Product) request;
            product.Id = objId;

            var filter = new FilterDefinitionBuilder<Domain.Models.Product.Product> ()
                .Eq (nameof (product.Id), objId);

            var response = await this._context.Products.ReplaceOneAsync (filter, product, null);

            return Ok ((ProductResponse) product);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteAsync ([FromRoute] string id) {

            ObjectId objId = ObjectId.Parse (id);
            FilterDefinition<Domain.Models.Product.Product> filter = new FilterDefinitionBuilder<Domain.Models.Product.Product> ()
                .Where (x => x.Id == objId);

            var response = await this._context.Products.FindOneAndDeleteAsync (filter);

            return NoContent ();
        }

    }
}
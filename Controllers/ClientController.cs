using Microsoft.AspNetCore.Mvc;
using Product.api.Infrastructure.Data.Contexts;

namespace Product.api.Controllers {
    [ApiVersion ("1")]
    [Route ("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase {

        private readonly UserContext _context;

        public ClientController(UserContext context)
        {
            this._context= context;
        }
    }
}
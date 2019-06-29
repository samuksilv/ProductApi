using Microsoft.AspNetCore.Mvc;

namespace Product.api.Controllers {

    [ApiVersion ("1")]
    [Route ("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {

    }
}
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Infrastructure;

namespace UniversityProcessing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
    }
}

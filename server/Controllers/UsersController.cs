using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Infrastructure;
using UniversityProcessing.API.Infrastructure.Entities;

namespace UniversityProcessing.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(ApplicationContext context) : ControllerBase
    {
        private readonly ApplicationContext _context = context;
    }
}

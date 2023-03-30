using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OFOP.Entity.Models;
using OFOP.Infrastructure;

namespace OFOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public IRepository<MenuType> _catRepo;

        public CategoryController(IRepository<MenuType> catRepo)
        {
            _catRepo = catRepo;

        }

        [Route("getAllCategory")]
        [HttpPost]
        public IEnumerable<MenuType> getAllCategory()
        {
            try
            {
                return _catRepo.GetAll().ToList();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

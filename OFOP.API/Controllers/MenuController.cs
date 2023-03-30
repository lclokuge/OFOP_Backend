using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OFOP.Entity.DTO;
using OFOP.Entity.Models;
using OFOP.Infrastructure;

namespace OFOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        public IRepository<Menu> _menuRepo;
        public IRepository<User> _userRepo;

        public MenuController(IRepository<Menu> menuRepo, IRepository<User> userRepo)
        {
            _menuRepo = menuRepo;
            _userRepo=userRepo;
        }

        [Route("getAllMenuByPostalcode")]
        [HttpPost]
        public IEnumerable<Menu> getAllMenuByPostalcode([FromBody]string postalcode)
        {
            try
            {
                var data = (from d in _menuRepo.GetAll()
                            join a in _userRepo.GetAll() on d.Cook.ToString() equals a.CustId.ToString()
                            where a.CustPostCode == postalcode
                            select d);
               
                return data;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Route("getAllMenuByCookID")]
        [HttpPost]
        public IEnumerable<Menu> getAllMenuByCookID([FromBody] int custid)
        {
            try
            {
                return _menuRepo.GetMany(x => x.Cook == custid);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Route("createMenu")]
        [HttpPost]
        public string  createMenu([FromBody] MenuViewModel menu)
        {
            try
            {
                var objmenu = new Menu()
                {

                    MenuName = menu.MenuName,
                    MenuTypeId = menu.MenuTypeId,
                    Price = menu.Price,
                    MenuImage = menu.MenuImage,
                    Ingredients = menu.Ingredients,
                    MenuActive = menu.MenuActive,
                    Cook = menu.Cook,
                };
                _menuRepo.Add(objmenu);
                return "menu is created";

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Route("getMenuByMenuID")]
        [HttpPost]
        public Menu getAllMenuByMenuID([FromBody] int menuid)
        {
            try
            {
                return _menuRepo.GetMany(x => x.MenuId == menuid && x.MenuActive==true).FirstOrDefault();
               
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Route("DeleteMenuByMenuID")]
        [HttpPost]
        public string DeleteMenuByMenuID([FromBody] int menuid)
        {
            try
            {
                var menu = _menuRepo.GetMany(x => x.MenuId == menuid).FirstOrDefault();
                if (menu != null)
                {
                    menu.MenuActive = false;
                    _menuRepo.Update(menu);
                    
                    return "Menu is deleted.";
                }
                else
                {
                    return "Menu is not fund.";
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }

    
}

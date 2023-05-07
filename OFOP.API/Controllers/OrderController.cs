using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OFOP.Entity.DTO;
using OFOP.Entity.Models;
using OFOP.Infrastructure;

namespace OFOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IRepository<Order> _orderRepo;
        public IRepository<Menu> _menuRepo;
        public IRepository<User> _userRepo;
        public IRepository<OrderStatus> _statusRepo;

        public OrderController(IRepository<Order> orderRepo, IRepository<Menu> menuRepo,
            IRepository<User> userRepo, IRepository<OrderStatus> statusRepo)
        {
           _orderRepo = orderRepo;
            _menuRepo = menuRepo;
            _userRepo = userRepo;
            _statusRepo = statusRepo;

        }

        [Route("createOrder")]
        [HttpPost]
        public string createOrder([FromBody] OrderViewModel order)
        {
            try
            {
                var objorder = new Order()
                {

                    CustId = order.CustId,
                    OrderDate = DateTime.Now,
                    TotAmount = order.TotAmount,
                    OrderStatus = false,
                    IsPaid = true,
                    MenuId = order.MenuId,
                    StatusId = 1,
                    Qty = order.Qty,
                };
                _orderRepo.Add(objorder);
                return "Order is created";

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Route("getAllOrderByCookID")]
        [HttpPost]
        public IEnumerable<OrderListViewModel> getAllOrderByCookID([FromBody] int cookid)
        {
            try
            {
                var data = (from d in _orderRepo.GetAll()
                            join a in _menuRepo.GetAll() on d.MenuId.ToString() equals a.MenuId.ToString()
                            join x in _userRepo.GetAll() on a.Cook.ToString() equals x.CustId.ToString()
                            join y in _statusRepo.GetAll() on a.MenuTypeId.ToString() equals y.StatusId.ToString()
                            where x.CustId == cookid
                            orderby d.OrderDate descending
                            select new OrderListViewModel()
                            {
                                OrderId = d.OrderId,
                                OrderDate= DateTime.Now,
                                TotAmount= d.TotAmount,
                                Qty= d.Qty,
                                Status= y.Name,
                                MenuId = d.MenuId,
                                MenuName= a.MenuName,
                                Price= a.Price,
                                MenuImage= a.MenuImage,
                                CustId= x.CustId,
                                CustName= x.CustName,
                                CustTelNumber= x.CustTelNumber,
                                CustAddress= x.CustAddress,
                                CustPostCode= x.CustPostCode

                            }).ToList();

                return data;


            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Route("getAllOrders")]
        [HttpPost]
        public IEnumerable<Order> getAllOrders()
        {
            try
            {
                return _orderRepo.GetAll().ToList();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }

    
}

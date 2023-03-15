using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OFOP.Entity.DTO;
using OFOP.Entity.Models;
using OFOP.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OFOP.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IRepository<User> _userRepo;
        IMapper _mapper;

        public UserController( IRepository<User> userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        // POST api/<UserController>
        [Route("login")]
        [HttpPost]
        public  UserViewModel Login([FromBody] LoginViewModel user)
        {
            try
            {
                var loginuser =  _userRepo.GetMany(x => x.CustUsername == user.Username && x.CustPassword== user.Password).FirstOrDefault();
                
                if (loginuser != null)
                {
                    //var token = this.GenerateToken(user.username);
                    return new UserViewModel { UserType = loginuser.UserType,  CustName = loginuser.CustName, CustPostCode=loginuser.CustPostCode, CustId=loginuser.CustId };
                }
                else
                {
                    throw new AuthenticationException("Username or password is invalid.");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Route("display")]
        [HttpGet]
        public UserViewModel display()
        {
            try
            {
                var loginuser = _userRepo.GetMany(x => x.CustUsername == "lak" && x.CustPassword == "123").FirstOrDefault();

                if (loginuser != null)
                {
                    //var token = this.GenerateToken(user.username);
                    return new UserViewModel { UserType = loginuser.UserType, CustName = loginuser.CustName, CustPostCode = loginuser.CustPostCode, CustId = loginuser.CustId };
                }
                else
                {
                    throw new AuthenticationException("Username or password is invalid.");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //Create JWT token and it return to user
        //public string GenerateToken(string user)
        //{
        ////create claims details based on the user information
        //var claims = new[] {
        //        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //        new Claim("UserName", user),

        //       };

        //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        //var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
        //    expires: DateTime.UtcNow.AddMinutes(5), signingCredentials: signIn);

        //return (new JwtSecurityTokenHandler().WriteToken(token));
        // }


        [Route("register")]
        [HttpPost]
        public string Register([FromBody] UserViewModel usermodel)
        {
            try
            {
                //var cashi =_mapper.Map<User>(usermodel);
                var objuser = new User()
                {
                    CustId = usermodel.CustId,
                    UserType = usermodel.UserType,
                    CustAddress = usermodel.CustAddress,
                    CustName = usermodel.CustName,
                    CustEmail = usermodel.CustEmail,
                    CustPostCode = usermodel.CustPostCode,
                    CustPassword = usermodel.CustPassword,
                    CustTelNumber = usermodel.CustTelNumber,
                    CustUsername = usermodel.CustUsername
                };
                _userRepo.Add(objuser);
                return "User is registerd";
            }
            catch (Exception e)
            {

                throw e;
            }
           

        }
    }
}

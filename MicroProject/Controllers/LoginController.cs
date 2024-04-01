using CrudMicroProject.Data;
using CrudMicroProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudMicroProject.Controllers
{

    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: api/<LoginController>
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [Route("api/GetUserDetails")]
        [HttpPost]
        public IActionResult GetUserDetails(LoginModel loginModel)
        {
            try 
            {
                string email = loginModel.Email!;
                string password = loginModel.Password!;
                UserModel olduser = _context.User.Where(user1 => user1.EmailID == email).FirstOrDefault()!;
                if (loginModel != null)
                {
                    return Ok(olduser);
                }
            }
            catch 
            {
                return BadRequest();
            }
            
            return BadRequest();
        }

        [Route("api/Login")]
        [HttpPost]
        public IActionResult LoginModel(LoginModel loginModel)
        {
            string email = loginModel.Email!;
            string password = loginModel.Password!;
            try
            {
                UserModel olduser = _context.User.Where(user1 => user1.EmailID == email).FirstOrDefault()!;
                AdminModel oldadmin = _context.Admin.Where(user1 => user1.EmailID == email).FirstOrDefault()!;
                if (olduser.EmailID == email && olduser != null)
                {
                    if (olduser.Password == password)
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":true}");
                    }
                    else
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":false}");
                    }
                }
            }

            catch (Exception)
            {
                AdminModel oldadmin = _context.Admin.Where(user1 => user1.EmailID == email).FirstOrDefault()!;
                if (oldadmin.EmailID == email && oldadmin != null)
                {
                    if (oldadmin.Password == password)
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":true,\"admin\":true}");
                    }
                    else
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":false}");
                    }
                }
                return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");
            }
            return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");
        }

        [Route("api/GetKey")]
        [HttpPost]
        public IActionResult getKey(LoginModel loginModel)
        {
            try
            {
                string email = loginModel.Email!;
                string password = loginModel.Password!;
                
                UserModel olduser = _context.User.Where(user1 => user1.EmailID == email).FirstOrDefault()!;
                if (olduser.EmailID == email && olduser != null)
                {
                    if (olduser.Password == password)
                    {
                        int id = olduser.UserID;
                        return Ok(id);
                    }
                    else
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":false}");
                    }
                }
            }

            catch (Exception)
            {
                return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");
            }
            return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");
        }

    }

}
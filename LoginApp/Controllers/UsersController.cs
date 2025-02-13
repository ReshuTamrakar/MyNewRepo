using LoginApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginApp.Controllers
{

    //Follow link https://www.youtube.com/watch?v=ZARDZAbpzZ8
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDBContext dbContext;
        public UsersController(MyDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var objUser = dbContext.Users.FirstOrDefault(x=> x.Email == userDTO.Email);
            if (objUser == null)
            {
                dbContext.Users.Add(new User
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Email = userDTO.Email,
                    Password = userDTO.Password,
                });
                dbContext.SaveChanges();
                return Ok("User Registered Successfully");
            }
            else { 
            
            return BadRequest("User is already exists with same email id");
            
            }
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserDTO userDTO)
        {
            var user = dbContext.Users.FirstOrDefault(x=>x.Email == userDTO.Email && x.Password == userDTO.Password);
            if (user == null) {

                return Ok(user);
            }
              return NoContent();
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers() { 
        
        return Ok(dbContext.Users.ToList());
        
        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(int id) {
            var user = dbContext.Users.FirstOrDefault(x => x.UserID == id);
            if (user != null) { 
            return Ok(user);
            }else
            return NoContent();
        }
    }
}

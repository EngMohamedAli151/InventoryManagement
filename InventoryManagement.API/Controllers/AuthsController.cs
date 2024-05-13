using InventoryManagement.Core.Dto;
using InventoryManagement.Database.Model;
using InventoryManagement.Services.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private IUserServices _userService;
        private readonly IConfiguration config;

        public AuthsController(IUserServices userService, IConfiguration config)
        {
            _userService = userService;
            this.config = config;
        }
        /// <summary>
        /// Create Login EndPoint
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromForm] LoginDto model)
        {
            var user = _userService.FindUserByEmailAndPassword(model.Email, model.Password);
            if (user != null)
            {
                var token = GenerateToken();
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });


            }
            return Unauthorized();
        }
        /// <summary>
        /// Create Registragion EndPoint
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task< IActionResult> Register([FromForm] RegistrationDto model)
        {
            var userExists = _userService.FindUserByEmail(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, "User already exists!");


            var result = new User()
            {
                UserName = model.userName,
                Email = model.Email,
                Password = model.Password,
                Role=model.Role
            };
           bool saved= await _userService.AddAsync(result);
            if (!saved )
                return StatusCode(StatusCodes.Status500InternalServerError, "User creation failed! Please check user details and try again.");

            
            return Ok("User created successfully!");
        }
        /// <summary>
        /// Create Token
        /// </summary>
        /// <returns></returns>
        private JwtSecurityToken GenerateToken()
        {
            SecurityKey securityKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));

            SigningCredentials signincred =
                           new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //Create token
            JwtSecurityToken mytoken = new JwtSecurityToken(
                issuer: config["JWT:ValidIssuer"],//url web api
                audience: config["JWT:ValidAudiance"],//url consumer angular
                claims: new List<Claim>(),
                expires: DateTime.Now.AddHours(5),
                signingCredentials: signincred
                );

            return mytoken;
        }
    }
}

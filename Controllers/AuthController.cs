using Microsoft.AspNetCore.Mvc;
using nheejods.Dtos.Commons;
using nheejods.Dtos.Requests.Auths;
using nheejods.Models;
using nheejods.Services.Dtos.User;
using nheejods.UnitOfWorks.Interfaces;

namespace nheejods.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceUnitOfWork serviceContainer;

        public AuthController(IServiceUnitOfWork serviceContainer)
        {
            this.serviceContainer = serviceContainer;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            try
            {
                // validate dto
                if (dto == null) return StatusCode(400, new BaseResponseDto<object>()
                {
                    IsSuccess = false,
                    Message = "Data should not be null",
                    Data = null
                });

                string email = dto.Email.Trim();
                string password = dto.Password.Trim();

                // validate data in dto
                if (email.Length <= 0 || password.Length <= 0) return StatusCode(400, new BaseResponseDto<object>()
                {
                    IsSuccess = false,
                    Message = "Data is invalid",
                    Data = null
                });

                // validate email is exists
                if (await this.serviceContainer.UserService.EmailIsExistsAsync(email)) return StatusCode(400, new BaseResponseDto<object>()
                {
                    IsSuccess = false,
                    Message = "Email is aleady exists",
                    Data = null
                });

                // encrypt password
                string passwordHashed = BCrypt.Net.BCrypt.HashPassword(password);

                // save new user
                await this.serviceContainer.UserService.CreateAsync(new CreateUserDto()
                {
                    Email = email,
                    PasswordHashed = passwordHashed
                });

                return StatusCode(201, new BaseResponseDto<object>()
                {
                    IsSuccess = true,
                    Message = "Successful",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return StatusCode(500, new BaseResponseDto<object>()
                {
                    IsSuccess = false,
                    Message = "Failed",
                    Data = null
                });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto) 
        {
            try 
            {
                // validate dto
                if (dto == null) return StatusCode(400, new BaseResponseDto<object>()
                {
                    IsSuccess = false,
                    Message = "Data should not be null",
                    Data = null
                });

                string email = dto.Email.Trim();
                string password = dto.Password.Trim();

                // validate data in dto
                if (email.Length <= 0 || password.Length <= 0) return StatusCode(400, new BaseResponseDto<object>()
                {
                    IsSuccess = false,
                    Message = "Data is invalid",
                    Data = null
                });

                // validate email is exists
                if (!(await this.serviceContainer.UserService.EmailIsExistsAsync(email))) return StatusCode(400, new BaseResponseDto<object>()
                {
                    IsSuccess = false,
                    Message = "Email or Password is invalid",
                    Data = null
                });

                // get user password
                string? currentPasswordHashed = await this.serviceContainer.UserService.GetPasswordByUserEmailAsync(email);
                if (currentPasswordHashed == null || currentPasswordHashed.Equals(string.Empty)) return StatusCode(400, new BaseResponseDto<object>()
                {
                    IsSuccess = false,
                    Message = "Email or Password is invalid",
                    Data = null
                });

                // check password is valid
                bool isPasswordMatched = BCrypt.Net.BCrypt.Verify(password, currentPasswordHashed);
                if (!isPasswordMatched) return StatusCode(400, new BaseResponseDto<object>()
                {
                    IsSuccess = false,
                    Message = "Email or Password is invalid",
                    Data = null
                });

                User? user = await this.serviceContainer.UserService.FindByEmailAsync(email);
                if (user == null) return StatusCode(400, new BaseResponseDto<object>()
                {
                    IsSuccess = false,
                    Message = "Email or Password is invalid",
                    Data = null
                });

                string token = this.serviceContainer.JwtService.GenerateToken(user);

                return StatusCode(200, new BaseResponseDto<string>()
                {
                    IsSuccess = true,
                    Message = "Successful",
                    Data = token
                });
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);

                return StatusCode(500, new BaseResponseDto<object>()
                {
                    IsSuccess = false,
                    Message = "Failed",
                    Data = null
                });
            }
        }

        [HttpGet("health-check")]
        public IActionResult GetHealthCheck()
        {
            return StatusCode(200, new BaseResponseDto<object>()
            {
                IsSuccess = true,
                Message = "Successful",
                Data = null
            });
        }
    }
}

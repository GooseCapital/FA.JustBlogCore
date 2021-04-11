using AutoMapper;
using FA.JustBlogCore.Services.Model;
using FA.JustBlogCore.Services.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlogCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var loginUser = this._unitOfWork.UserRepository.Authenticate(user.Username, user.Password);
            if (loginUser == null)
            {
                return BadRequest();
            }

            return Ok(loginUser);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult AddNewUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (this._unitOfWork.UserRepository.IsUserExists(user.Username))
            {
                return BadRequest(new { message = "Username exists" });
            }

            this._unitOfWork.UserRepository.Add(user);
            this._unitOfWork.SaveChanges();

            return Ok(user);
        }
    }
}
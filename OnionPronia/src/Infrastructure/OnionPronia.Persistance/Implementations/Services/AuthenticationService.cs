using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnionPronia.Application.DTOs.AppUsers;
using OnionPronia.Application.Interfaces.Services;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Persistance.Implementations.Services
{
    internal class AuthenticationService: IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AuthenticationService(UserManager<AppUser> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task RegisterAsync(RegisterDto userDto)
        {
            await _userManager.CreateAsync(_mapper.Map<AppUser>(userDto),userDto.Password);
        }
    }
}

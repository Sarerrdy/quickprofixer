using System;
using QuickProFixer.DTOs;
using QuickProFixer.Models;

namespace quickprofixer.Services;


public interface IAuthService
{
	Task<string> LoginUserAsync(LoginUserDto loginUserDto);
	Task<ApplicationUser?> GetUserByIdAsync(string userId);
}

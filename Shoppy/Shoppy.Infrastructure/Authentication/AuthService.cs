using Microsoft.AspNetCore.Identity;
using Shoppy.Application.Features.Authentication.Requests.Command;
using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Application.Utils;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;
using Shoppy.Infrastructure.Web.Authentication;
using Shoppy.Persistence.Identity;

namespace Shoppy.Infrastructure.Authentication;

public class AuthService(
    SignInManager<AppUser> signInManager,
    IJwtTokenGenerator tokenGenerator,
    UserManager<AppUser> userManager)
    : IAuthService
{
    public async Task<LoginResponse> LoginAsync(LoginCommand request)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is not { Status: UserStatus.Active })
        {
            throw new NotFoundException("User not found");
        }

        var result =
            await signInManager.PasswordSignInAsync(request.Email, request.Password, false, lockoutOnFailure: false);

        if (!result.Succeeded)
        {
            throw new BadRequestException("Incorrect password.");
        }

        var accessToken = await tokenGenerator.GenerateAccessTokenAsync(user);

        var response = new LoginResponse()
        {
            Id = user.Id,
            Email = user.Email ?? "",
            FullName = user.FullName,
            PictureUrl = user.PictureUrl,
            AccessToken = accessToken,
        };
        response.AccessToken = accessToken;
        return response;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterCommand request)
    {
        var existedUser = await userManager.FindByEmailAsync(request.Email);
        
        if (existedUser != null )
        {
            throw new ConflictException("Email has been existed");
        }

        var user = new AppUser()
        {
            Email = request.Email,
            FullName = request.FullName,
            UserName = request.Email,
            Status = UserStatus.Active,
        };

        var cart = new Cart()
        {
            TotalItem = 0
        };

        user.Cart = cart;

        var result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, RoleConstant.UserRole);

            // var accessTokenTask = tokenGenerator.GenerateAccessTokenAsync(user);
            // var refreshTokenTask = tokenGenerator.GenerateRefreshTokenAsync(user);
            //
            // await Task.WhenAll(accessTokenTask, refreshTokenTask);
            // var accessToken = accessTokenTask.Result;
            // var refreshToken = refreshTokenTask.Result;

            var accessToken = await tokenGenerator.GenerateAccessTokenAsync(user);
            var refreshToken = await tokenGenerator.GenerateRefreshTokenAsync(user);

            var response = new RegisterResponse()
            {
                Email = user.Email,
                FullName = StringUtils.FormatName(user.FullName),
                Id = user.Id,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
            return response;
        }

        throw new BadRequestException("Can not register new account.");
    }
}
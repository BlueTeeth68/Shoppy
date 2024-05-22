using System.ComponentModel.DataAnnotations;
using MediatR;
using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.SharedLibrary.Models.Requests.Auth;

namespace Shoppy.Application.Features.Authentication.Requests.Command;

public record LoginCommand : LoginDto, IRequest<LoginResponse>;
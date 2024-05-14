using System.ComponentModel.DataAnnotations;
using MediatR;
using Shoppy.Application.Features.Authentication.Results.Command;

namespace Shoppy.Application.Features.Authentication.Requests.Command;

public record LoginCommand(
    [Required]
    [DataType(DataType.EmailAddress)]
    string Email,
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    string Password
) : IRequest<LoginResult>;
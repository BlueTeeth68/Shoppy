using System.ComponentModel.DataAnnotations;
using MediatR;
using Shoppy.Application.Features.Authentication.Results.Command;

namespace Shoppy.Application.Features.Authentication.Requests.Command;

public record RegisterCommand(
    [Required]
    [DataType(DataType.EmailAddress)]
    [MaxLength(100)]
    string Email,
    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    string Password,
    [Required] [MaxLength(50)] string FullName
): IRequest<RegisterResult>;
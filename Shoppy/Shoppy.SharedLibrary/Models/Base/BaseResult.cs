using Microsoft.AspNetCore.Mvc;

namespace Shoppy.SharedLibrary.Models.Base;

public class BaseResult<T>
{
    public bool IsSuccess { get; set; } = true;

    public T? Result { get; set; }

    public ProblemDetails? Error { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Shoppy.SharedLibrary.Models.Requests.Orders;

public class GetUserOrderDto
{
    [Range(1, int.MaxValue)] public int? Page { get; set; }

    [Range(1, 100)] public int? Size { get; set; }
}
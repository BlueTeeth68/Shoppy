using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Domain.Repositories;

public interface IAddressRepository: IBaseRepository<Address, Guid>
{
    
}
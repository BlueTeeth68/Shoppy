﻿using Microsoft.Extensions.Logging;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Persistence.Repositories.Base;

namespace Shoppy.Persistence.Repositories;

public class AddressRepository: BaseRepository<Address,Guid>, IAddressRepository
{
    public AddressRepository(AppDbContext dbContext, ILogger<Address> logger) : base(dbContext, logger)
    {
    }
}
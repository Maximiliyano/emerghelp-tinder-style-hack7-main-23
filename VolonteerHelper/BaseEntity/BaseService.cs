using AutoMapper;
using VolonteerHelper.Api.Context;
using VolonteerHelper.Api.Extensions;

public abstract class BaseService
{
    private protected readonly VolonteerDbContext _dbContext;
    private protected readonly IMapper _mapper;

    public BaseService(VolonteerDbContext context)
    {
        _dbContext = context;
        _mapper = MapperResolver.InitiateMapping();
    }
}
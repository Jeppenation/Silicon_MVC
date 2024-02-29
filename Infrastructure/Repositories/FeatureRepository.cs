using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class FeatureRepository(DataContext context) : Repo<FeatureEntity>(context)
{
    private readonly DataContext _context = context;
}

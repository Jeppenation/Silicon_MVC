using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class FeatureItem(DataContext context) : Repo<FeatureItem>(context)
{
    private readonly DataContext _context = context;
}

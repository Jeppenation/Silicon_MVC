namespace Infrastructure.Entities;

public class FeatureEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Ingress { get; set; } = null!;

    public ICollection<FeatureItemEntity> FeatureItems { get; set; } = [];
}

public class FeatureItemEntity
{
    public int Id { get; set; }

    public int FeatureId { get; set; }
    public FeatureEntity Feature { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;

}

//TODO: - KOLLA PÅ VIDEON FRÅN 2:42:00
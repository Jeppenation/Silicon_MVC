using Infrastructure.Entities;

namespace SiliconMVC.ViewModels;

public class FeaturesViewModel
{
    public string Title { get; set; } = null!;
    public string Ingress { get; set; } = null!;
    public List<FeatureItemEntity> FeatureItems { get; set; } = [];


}



using SiliconMVC.Model.Sections;

namespace SiliconMVC.Model.Views
{
    public class HomeIndexViewModel
    {
        public string Title { get; set; } = "Ultimate Task Manager Assistant";
        public ShowcaseViewModel Showcase { get; set; } = new Model.Sections.ShowcaseViewModel
        {
            Id = "overview",
            ShowcaseImage = new() { ImageUrl = "images/Showcase-image.svg", AltText = "Task Management Assistant" },
            Title = "Task Managment Assistant You Gonna Love",
            Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
            Link = new() { ControllerName = "downloads", ActionName = "index", Text = "Get started for free" },
            BrandsText = "Largest companies use our tool to work efficiently",
            Brands =
                    [
                        new() { ImageUrl = "images/logo1.svg", AltText = "Brand 1" },
                        new() { ImageUrl = "images/logo2.svg", AltText = "Brand 2" },
                        new() { ImageUrl = "images/logo3.svg", AltText = "Brand 3" },
                        new() { ImageUrl = "images/logo4.svg", AltText = "Brand 4" }
                    ],


        };

           
    }

}

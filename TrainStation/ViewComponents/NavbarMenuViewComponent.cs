using Microsoft.AspNetCore.Mvc;

namespace TrainStation.ViewComponents
{
    public class NavbarMenuViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApplicationFront_End.Models;
namespace WebApplicationFront_End.Views.Shared.Components.LifeStyle
{
    [ViewComponent]
    public class LifeStyle:ViewComponent
    {
        private readonly QuynhPhuongContext _context;

        public LifeStyle(QuynhPhuongContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var lstLifeStyle = _context.News.Where(p => (p.IsDeleted == false || p.IsDeleted == null) && p.IsShow == true).Take(2).ToList();
            return View(lstLifeStyle);
        }
    }
}

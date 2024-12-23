using Microsoft.AspNetCore.Mvc;
using WebApplicationFront_End.Models;

namespace WebApplicationFront_End.Views.Shared.Components.MenuBar
{
    [ViewComponent]
    public class MenuBar: ViewComponent
    {
        private readonly QuynhPhuongContext _context;

        public MenuBar(QuynhPhuongContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var lstMenuBar = _context.News.Where(p => (p.IsDeleted == false || p.IsDeleted == null) && p.IsShow == true).Skip(0).Take(5).ToList();
            return View(lstMenuBar);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApplicationFront_End.Models;

namespace WebApplicationFront_End.Views.Shared.Components.Categories
{
    [ViewComponent]
    public class Categories: ViewComponent
    {
        private readonly QuynhPhuongContext _context;

        public Categories(QuynhPhuongContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var lstCategories = _context.NewsTypes.Where(p => (p.IsDeleted == false || p.IsDeleted == null) && p.IsShow == true).ToList();
            return View(lstCategories);
        }
    }

}


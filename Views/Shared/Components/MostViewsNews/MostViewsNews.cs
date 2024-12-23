using Microsoft.AspNetCore.Mvc;
using WebApplicationFront_End.Models;
namespace WebApplicationFront_End.Views.Shared.Components.MostViewsNews
{
    [ViewComponent]
    public class MostViewsNews:ViewComponent
    {
        private readonly QuynhPhuongContext _context;

        public MostViewsNews(QuynhPhuongContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int type)
        {
            var lstMostViewsNews = _context.News.Where(p => (p.IsDeleted == false || p.IsDeleted == null) && p.IsShow == true && p.TypeId == type).ToList();
            return View(lstMostViewsNews);
        }

    }
}

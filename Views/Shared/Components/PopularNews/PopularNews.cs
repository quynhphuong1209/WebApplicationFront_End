using Microsoft.AspNetCore.Mvc;
using WebApplicationFront_End.Models;

namespace WebApplicationFront_End.Views.Shared.Components.Popular_News
{
    [ViewComponent]
    public class PopularNews: ViewComponent
    {
        private readonly QuynhPhuongContext _context;

        public PopularNews(QuynhPhuongContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var lstPopularNews = _context.News.Where(p => (p.IsDeleted == false || p.IsDeleted == null) && p.IsShow == true).Skip(15).Take(5).ToList();
            return View(lstPopularNews);
        }
    }
}

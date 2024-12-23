using Microsoft.AspNetCore.Mvc;
using WebApplicationFront_End.Models;

namespace WebApplicationFront_End.Views.Shared.Components.TopStory
{
    [ViewComponent]
    public class TopStory : ViewComponent
    {
        private readonly QuynhPhuongContext _context;

        public TopStory(QuynhPhuongContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var lstTopStory = _context.News.Where(p => (p.IsDeleted == false || p.IsDeleted == null) && p.IsShow == true).OrderByDescending(p => p.Id).FirstOrDefault();
            return View(lstTopStory);
        }
    }
}

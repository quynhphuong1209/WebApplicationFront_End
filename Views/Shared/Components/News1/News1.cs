using Microsoft.AspNetCore.Mvc;
using WebApplicationFront_End.Models;

namespace WebApplicationFront_End.Views.Shared.Components.News1
{
    [ViewComponent]
    public class News1 : ViewComponent
    {
        private readonly QuynhPhuongContext _context;

        public News1(QuynhPhuongContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var lstNews1 = _context.News.Where(p => (p.IsDeleted == false || p.IsDeleted == null) && p.IsShow == true).OrderByDescending(p=>p.Id).FirstOrDefault();
            return View(lstNews1);
        }
    }
}

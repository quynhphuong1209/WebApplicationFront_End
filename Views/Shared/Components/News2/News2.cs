using Microsoft.AspNetCore.Mvc;
using WebApplicationFront_End.Models;
namespace WebApplicationFront_End.Views.Shared.Components.News2
{
    [ViewComponent]
    public class News2:ViewComponent
    {
        private readonly QuynhPhuongContext _context;

        public News2(QuynhPhuongContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int type)
        {
            var lstNews2 = _context.News.Where(p => (p.IsDeleted == false || p.IsDeleted == null) && p.IsShow == true && p.TypeId==type).Skip(0).Take(5).ToList();
            return View(lstNews2);
        }
    }
}

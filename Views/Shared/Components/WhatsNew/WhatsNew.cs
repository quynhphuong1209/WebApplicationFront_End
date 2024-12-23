using Microsoft.AspNetCore.Mvc;
using WebApplicationFront_End.Models;

namespace WebApplicationFront_End.Views.Shared.Components.WhatsNew
{
    [ViewComponent]
    public class WhatsNew: ViewComponent
    {
        private readonly QuynhPhuongContext _context;

        public WhatsNew(QuynhPhuongContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var lstWhatsNew = _context.NewsTypes.Where(p => (p.IsDeleted == false || p.IsDeleted == null) && p.IsShow == true).ToList();
            return View(lstWhatsNew);
        }
    }
}

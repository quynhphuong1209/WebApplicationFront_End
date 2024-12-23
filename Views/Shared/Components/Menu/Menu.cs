using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationFront_End.Models;

namespace WebApplicationFront_End.Views.Shared.Components.Menu
{
    [ViewComponent]
    public class Menu : ViewComponent
    {
        private readonly QuynhPhuongContext _context;

        public Menu(QuynhPhuongContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var lstMenu = _context.NewsTypes.Where(p=>(p.IsDeleted==false || p.IsDeleted==null) && p.IsShow==true).ToList();
            return View(lstMenu);
        }
    }
}

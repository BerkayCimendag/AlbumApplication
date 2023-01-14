using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlbumApplication.ViewComponents
{
    public class ListingViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public ListingViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_db.Albums.ToList());
        }
    }
}

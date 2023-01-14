using Microsoft.AspNetCore.Mvc;

namespace AlbumApplication.Controllers
{
    public class AlbumController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AlbumController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(Admin admin)
        {
            return View();
        }

        public IActionResult Add()
        {

            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Add(Album album)
        {
            if (ModelState.IsValid)
            {
                
                _db.Albums.Add(album);
                _db.SaveChanges();
            }
            return View("Index",album);
        }
        
        public IActionResult Edit(int id)
        {
            var updatingAlbum = _db.Albums.Find(id);
            if (updatingAlbum == null) 
            {
                return NotFound();
            }
            return View(updatingAlbum);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Album album)
        {
            var updatingAlbum = _db.Albums.Find(album.Id);
            if (ModelState.IsValid)
            {
                updatingAlbum.Name = album.Name;
                updatingAlbum.Artist = album.Artist;
                updatingAlbum.Price = album.Price;
                updatingAlbum.Discount = album.Discount;
                updatingAlbum.IsItOnSale = album.IsItOnSale;
                updatingAlbum.ReleaseDate = album.ReleaseDate;

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        public IActionResult Delete(int id)
        {
            var deletingAlbum = _db.Albums.Find(id);
            if (deletingAlbum == null)
            {
                return NotFound();
            }
            _db.Albums.Remove(deletingAlbum);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

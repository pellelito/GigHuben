

using GigHuben.Models;
using GigHuben.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHuben.Controllers
{
    public class GigsController : Controller
    {
        private Models.ApplicationDbContext _context;
        public GigsController()
        {
            _context = new Models.ApplicationDbContext();
        }
        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()

            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {


            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = System.DateTime.Parse(string.Format("{0}{1}", viewModel.Date, viewModel.Time)),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
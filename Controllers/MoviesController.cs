using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieCollectionContext _context;

        // This constructor connects the controller to the database context
        // so we can access and modify movie records.
        public MoviesController(MovieCollectionContext context)
        {
            _context = context;
        }

        // This action retrieves all movies from the database
        // and sends them to the Index view so they can be displayed in a list.
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies.ToListAsync();
            return View(movies);
        }

        // This action simply loads the form that allows a user
        // to add a new movie to the collection.
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View(new Movie());
        }

        // When the form is submitted, this action checks to make sure
        // the data is valid. If it is, the movie is saved to the database.
        // If not, the form is redisplayed with validation errors.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return View("Confirmation", movie);
        }

        // This action loads the selected movie into an edit form
        // so the user can update its information.
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // After the user submits changes, this action updates the movie
        // in the database and then redirects back to the full movie list.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            _context.Update(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // This action displays a confirmation page before deleting a movie.
        // It ensures the correct movie is being removed.
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // Once deletion is confirmed, this action removes the movie
        // from the database and returns to the main movie list.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
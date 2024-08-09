using EsteraApp.Data;
using EsteraApp.Models;
using EsteraApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EsteraApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly JokeService _jokeService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, JokeService jokeService)
        {
            _logger = logger;
            _context = context;
            _jokeService = jokeService;
        }

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

        public async Task<IActionResult> GetRandomJoke()
        {
            try
            {
                var joke = await _jokeService.GetRandomJokeAsync();

                var existingJoke = _context.Jokes.FirstOrDefault(j => j.Setup == joke.Setup && j.Punchline == joke.Punchline);
                if (existingJoke == null)
                {
                    _context.Jokes.Add(joke);
                    await _context.SaveChangesAsync();
                }

                return Json(joke);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}

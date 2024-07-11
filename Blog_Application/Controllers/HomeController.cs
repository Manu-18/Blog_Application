using Blog_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Blog_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataDbContext dbContext;

        public HomeController(DataDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        //--------------------------Create----------------------------------
        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(BlogPost post)
        {
            if (ModelState.IsValid)
            {
                dbContext.BlogPosts.AddAsync(post);
                dbContext.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        //--------------------------View Post List----------------------------------
        public IActionResult PostList()
        {
            return View();
        }
        public async Task<IActionResult> list()
        {
            var postlist = await dbContext.BlogPosts.ToListAsync();


            return Json(postlist);
        }
        [HttpPost]
        public IActionResult Edit(int id, BlogPost std) //Update
        {
            
            
                dbContext.BlogPosts.Update(std);
                dbContext.SaveChanges();
                return RedirectToAction("Postlist", "Home");
            
            return View();


        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id) //Delete
        {
            var stud = dbContext.BlogPosts.Find(id);
            dbContext.BlogPosts.Remove(stud);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");

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
    }
}

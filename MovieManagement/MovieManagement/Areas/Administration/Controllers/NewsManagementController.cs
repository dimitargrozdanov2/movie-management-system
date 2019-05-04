using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Areas.Administration.Models.News;
using MovieManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class NewsManagementController : Controller
    {
        private readonly INewsService newsService;

        private readonly IHostingEnvironment hostingEnvironment;

        public NewsManagementController(INewsService newsService, IHostingEnvironment hostingEnvironment)
        {
            this.newsService = newsService ?? throw new ArgumentNullException(nameof(newsService));
            this.hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }


        // GET: News/Create


        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateNewsViewModel();
            return View(model);
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewsViewModel model)
        {
            var imageNameToSave = Guid.NewGuid() + ".jpg";

            var role = await this.newsService.CreateNewsAsync(model.CreatedOn, model.Title, model.Text, imageNameToSave);

            using (var ms = new MemoryStream())
            {
                model.Image.CopyTo(ms);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
                var filePath = Path.Combine(uploads, imageNameToSave);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }
            }

            // TODO: RETURN DIRECTOYL TO THE DETAILS OF THIS ONE;
            return this.RedirectToAction("Index", "Home");
        }

        //[Area("Administration")]
        //[Authorize(Roles = "Admin")]
        //public IActionResult ShowFields(string firstName)
        //{
        //    ViewData["fname"] = firstName;
        //}
        //// GET: News/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var news = await _context.News.FindAsync(id);
        //    if (news == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(news);
        //}

        //// POST: News/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("Id,DatePosted,Title,Text")] News news)
        //{
        //    if (id != news.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(news);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!NewsExists(news.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(news);
        //}

        //// GET: News/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var news = await _context.News
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (news == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(news);
        //}

        //// POST: News/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var news = await _context.News.FindAsync(id);
        //    _context.News.Remove(news);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool NewsExists(string id)
        //{
        //    return _context.News.Any(e => e.Id == id);
        //}
    }
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Tj.ResponseTimer.Models;

namespace Tj.ResponseTimer.Controllers
{
    public class SomeDataClassForViewsController : Controller
    {
        private AppDbContext _context;

        public SomeDataClassForViewsController(AppDbContext context)
        {
            _context = context;    
        }

        // GET: SomeDataClassForViews
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sdcfv.ToListAsync());
        }

        // GET: SomeDataClassForViews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SomeDataClassForView someDataClassForView = await _context.Sdcfv.SingleAsync(m => m.Id == id);
            if (someDataClassForView == null)
            {
                return HttpNotFound();
            }

            return View(someDataClassForView);
        }

        // GET: SomeDataClassForViews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SomeDataClassForViews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SomeDataClassForView someDataClassForView)
        {
            if (ModelState.IsValid)
            {
                _context.Sdcfv.Add(someDataClassForView);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(someDataClassForView);
        }

        // GET: SomeDataClassForViews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SomeDataClassForView someDataClassForView = await _context.Sdcfv.SingleAsync(m => m.Id == id);
            if (someDataClassForView == null)
            {
                return HttpNotFound();
            }
            return View(someDataClassForView);
        }

        // POST: SomeDataClassForViews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SomeDataClassForView someDataClassForView)
        {
            if (ModelState.IsValid)
            {
                _context.Update(someDataClassForView);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(someDataClassForView);
        }

        // GET: SomeDataClassForViews/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SomeDataClassForView someDataClassForView = await _context.Sdcfv.SingleAsync(m => m.Id == id);
            if (someDataClassForView == null)
            {
                return HttpNotFound();
            }

            return View(someDataClassForView);
        }

        // POST: SomeDataClassForViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            SomeDataClassForView someDataClassForView = await _context.Sdcfv.SingleAsync(m => m.Id == id);
            _context.Sdcfv.Remove(someDataClassForView);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

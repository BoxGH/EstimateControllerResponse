using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Tj.ResponseTimer.Models;

namespace Tj.ResponseTimer.Controllers
{
    public class ForTablesController : Controller
    {
        private AppDbContext _context;

        public ForTablesController(AppDbContext context)
        {
            _context = context;    
        }

        // GET: ForTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ftdb.ToListAsync());
        }

        // GET: ForTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ForTable forTable = await _context.Ftdb.SingleAsync(m => m.Id == id);
            if (forTable == null)
            {
                return HttpNotFound();
            }

            return View(forTable);
        }

        // GET: ForTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForTables/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ForTable forTable)
        {
            if (ModelState.IsValid)
            {
                _context.Ftdb.Add(forTable);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(forTable);
        }

        // GET: ForTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ForTable forTable = await _context.Ftdb.SingleAsync(m => m.Id == id);
            if (forTable == null)
            {
                return HttpNotFound();
            }
            return View(forTable);
        }

        // POST: ForTables/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ForTable forTable)
        {
            if (ModelState.IsValid)
            {
                _context.Update(forTable);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(forTable);
        }

        // GET: ForTables/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ForTable forTable = await _context.Ftdb.SingleAsync(m => m.Id == id);
            if (forTable == null)
            {
                return HttpNotFound();
            }

            return View(forTable);
        }

        // POST: ForTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ForTable forTable = await _context.Ftdb.SingleAsync(m => m.Id == id);
            _context.Ftdb.Remove(forTable);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

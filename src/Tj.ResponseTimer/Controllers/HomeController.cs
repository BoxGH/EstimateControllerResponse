using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.PlatformAbstractions;
using Tj.ResponseTimer.Models;
using Tj.ResponseTimer.ModelsViews;

namespace Tj.ResponseTimer.Controllers
{
    public class HomeController : Controller
    {
        readonly IApplicationEnvironment appEnvironment;
        public AppDbContext appDbContext;
        public HomeController(IApplicationEnvironment _appEnvironment, AppDbContext _appDbContext)
        {
            appEnvironment = _appEnvironment;
            appDbContext = _appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult GetFile( string fname )
        {
            string path = appEnvironment.ApplicationBasePath + "\\Views\\Home\\HtmlMoq\\"+fname+".html";
            return PhysicalFile(path, "text/html");
        }
        public IActionResult Report()
        {
            IQueryable<RequestResponseTime> rrt = appDbContext.Rrt.OrderByDescending(x => x.MeasureTime).Take(10);

            long maxMeasP = rrt.Max(x => x.MeasureTime)/100;
            long maxScP = rrt.Select(x => new { longRes = (x.EndRequest - x.ServerOut) }).Max(x=>x.longRes)/100;
 
            IEnumerable<WrapResult> Result = rrt.Select(x => new WrapResult
            {
                PagePath = x.PagePath,
                measSerTime = x.MeasureTime,
                measScTime = (x.EndRequest - x.ServerOut)/10000000,
                measScPersTime = (x.EndRequest - x.ServerOut) / maxScP,
                measSerPersTime =  x.MeasureTime / maxMeasP
            });

            return View(Result);
        }
        public async Task<IActionResult> GetPageData(string index_path, DateTime time_load)
        {
            RequestResponseTime rrt = appDbContext.Rrt.FirstOrDefault(x => x.PagePath == index_path);
            if(null == rrt)
            {
                return HttpNotFound();
            }
            else
            {
                rrt.EndRequest = time_load.Ticks;
                await appDbContext.SaveChangesAsync();
            }
            long max_measure = appDbContext.Rrt.Max(x => x.MeasureTime);
            long cur_measure = appDbContext.Rrt.FirstOrDefault(x => x.PagePath == index_path).MeasureTime;

            long res = cur_measure / (max_measure / 100);

            string strPath = appDbContext.Rrt.FirstOrDefault(x => x.MeasureTime == max_measure).PagePath;

            return Json(new { result = res, path = strPath });
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}

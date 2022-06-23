using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        dbQuanLyPhimDataContext data = new dbQuanLyPhimDataContext();
        public ActionResult Index()
        {
            var all_phim = from s in data.Phims select s;
            return View(all_phim);
        }
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            var chitietSP = from s in data.Phims where s.maphim == id select s;
            return View(chitietSP.Single());
        }

        public ActionResult LichChieuPhim()
        {
            var all_lich = from s in data.LichChieus select s;
            return View(all_lich);
        }
        public ActionResult PhimDangChieu()
        {
            var GioHienTai = DateTime.Now;
            var all_phim =from s in data.Phims.Where(s => s.ngaychieu < GioHienTai).OrderByDescending(i => i.ngaychieu).ToList() select s;
            return View(all_phim);
        }
        public ActionResult PhimSapChieu()
        {
            var GioHienTai = DateTime.Now;
            var all_phim = from s in data.Phims.Where(s => s.ngaychieu > GioHienTai).OrderByDescending(i => i.ngaychieu).ToList() select s;
            return View(all_phim);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class GioHangController : Controller
    {
        dbQuanLyPhimDataContext data = new dbQuanLyPhimDataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> list = Session["GioHang"] as List<GioHang>;
            if (list == null)
            {
                list = new List<GioHang>();
                Session["GioHang"] = list;
            }
            return list;
        }
        public ActionResult ThemGioHang(int id, string strUrl)
        {

            List<GioHang> gioHangs = LayGioHang();

            GioHang sp = gioHangs.Find(n => n.id == id);
            if (sp == null)
            {
                sp = new GioHang(id);
                gioHangs.Add(sp);
                return Redirect(strUrl);
            }
            else
            {
                sp.iSoluong++;
                return Redirect(strUrl);
            }
        }
        private int TongSoLuong()
        {
            int Tongsoluong = 0;
            List<GioHang> gioHangs = Session["GioHang"] as List<GioHang>;
            if (gioHangs != null)
            {
                Tongsoluong = gioHangs.Sum(n => n.iSoluong);
            }
            Session["TongSoLuong"] = Tongsoluong;
            return Tongsoluong;
        }
        private int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<GioHang> gioHangs = Session["GioHang"] as List<GioHang>;
            if (gioHangs != null)
            {
                tsl = gioHangs.Count;
            }
            return tsl;
        }
        private double TongTien()
        {
            double tongtien = 0;
            List<GioHang> gioHangs = Session["GioHang"] as List<GioHang>;
            if (gioHangs != null)
            {
                tongtien = gioHangs.Sum(n => n.dThanhtien);
            }
            return tongtien;
        }
        public ActionResult GioHang()
        {
            List<GioHang> gioHangs = LayGioHang();
            if (gioHangs.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(gioHangs);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return PartialView();
        }
        public ActionResult XoaGioHang(int id)
        {
            List<GioHang> gioHangs = LayGioHang();
            GioHang sessiongiohang = gioHangs.SingleOrDefault(n => n.id == id);
            if (sessiongiohang != null)
            {
                gioHangs.RemoveAll(n => n.id == id);
                return RedirectToAction("GioHang");
            }
            if (gioHangs.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult CapNhatGioHang(int id, FormCollection f)
        {
            List<GioHang> gioHangs = LayGioHang();
            GioHang sessiongiohang = gioHangs.SingleOrDefault(n => n.id == id);
            if (sessiongiohang != null)
            {
                sessiongiohang.iSoluong = int.Parse(f["txtSoLg"].ToString());

            }
            return RedirectToAction("Giohang");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<GioHang> gioHangs = LayGioHang();
            gioHangs.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
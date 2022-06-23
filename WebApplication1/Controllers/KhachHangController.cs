using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class KhachHangController : Controller
    {
        dbQuanLyPhimDataContext data = new dbQuanLyPhimDataContext();
        // GET: KhachHang
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, KhachHang kh)
        {
            var hoten = collection["HOTEN"];
            var MK = collection["Pass"];
            string Address = collection["Address"];
            string SDT = collection["SDT"];
            if (hoten == null ||  MK == null || Address == null || SDT == null)
            {
                return HttpNotFound();
            }
            else
            {
                kh.hoten = hoten;
                kh.diachi = Address;
                kh.dienthoai = SDT;
                kh.matkhau = MK;
                data.KhachHangs.InsertOnSubmit(kh);
                data.SubmitChanges();
                return RedirectToAction("Login", "KhachHang");

            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            string TK = collection["TaiKhoan"];
            KhachHang kh = data.KhachHangs.SingleOrDefault(a => a.dienthoai == TK);
            if (kh != null)
            {
                Session["User"] = kh.hoten;
                Session["Taikhoan"] = kh;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Thongbao = "Tên Tài Khoản Hoặc Mật Khẩu Không Đúng";
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session["User"] = null;
            Session["Taikhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
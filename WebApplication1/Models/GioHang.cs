using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class GioHang
    {
        dbQuanLyPhimDataContext data = new dbQuanLyPhimDataContext();
        public int id { get; set; }
        
        [Display(Name = "Mã Lịch Chiếu Phim")]
        public string malc { get; set; }
        [Display(Name = "Mã Phim")]
        public string ten { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string hinh { get; set; }
        [Display(Name = "Giá bán")]
        public double gia { get; set; }
        [Display(Name = "Số Lượng")]
        public int iSoluong { get; set; }

        [Display(Name = "Thành tiền")]
        public Double dThanhtien
        {
            get { return iSoluong * gia; }
        }
        public GioHang(int id)
        {
            //Phim p = data.Phims.SingleOrDefault(n => n.maphim == id);
            this.id = id;
            Phim p = data.Phims.SingleOrDefault(n => n.maphim == id);
            //LichChieu lichchieu = data.LichChieus.SingleOrDefault(n => n.maphim == id);
            ten = p.tenphim;
            hinh = p.hinh;
            gia = double.Parse(p.gia.ToString());
            iSoluong = 1;
        }

    }
}
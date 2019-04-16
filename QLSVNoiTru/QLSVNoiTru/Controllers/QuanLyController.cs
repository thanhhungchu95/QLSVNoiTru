using QLSVNoiTru.Database;
using QLSVNoiTru.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QLSVNoiTru.Controllers
{
    public class QuanLyController : Controller
    {
        // GET: QuanLy
        public ActionResult KhoiTaoPhongKTXMoi()
        {
            var db = new DB();
            List<Tang> tangs = db.Tangs.OrderByDescending(x => x.TangId).ToList();
            if (tangs == null)
                tangs = new List<Tang>();
            List<ETang> eTangs = new List<ETang>();
            tangs.ForEach(x =>
            {
                ETang eTang = new ETang()
                {
                    TangId = x.TangId,
                    TenTang = x.TenTang,
                    Phongs = new List<EPhong>()
                };
                x.Phongs.ToList().ForEach(y =>
                {
                    int svDaO = db.SinhViens.Where(z => z.SoHieuPhong == y.SoHieuPhong && z.TrangThaiO == (int)TrangThaiO.DangO).Count();
                    eTang.Phongs.Add(new EPhong()
                    {
                        LoaiPhong = y.LoaiPhong,
                        MaLoaiPhong = y.MaLoaiPhong,
                        SoHieuPhong = y.SoHieuPhong,
                        SoPhongDaO = svDaO,
                        SucChuaToiDa = y.SucChuaToiDa,
                        TangId = y.TangId
                    });
                });
                eTangs.Add(eTang);
            });
            List<ESinhVien> eSinhViens = new List<ESinhVien>();
            List<SinhVien> sinhViens = db.SinhViens.OrderByDescending(x => x.NgayNhanPhong).ToList();
            sinhViens.ForEach(x =>
            {
                bool svOLai = db.SinhVienOLais.Any(y => y.MaSinhVien == x.MaSinhVien);
                eSinhViens.Add(new ESinhVien()
                {
                    SinhVien = x,
                    Chon = svOLai,
                    MaSinhVien = x.MaSinhVien
                });
            });

            ViewData["eTangs"] = eTangs;
            ViewData["eSinhViens"] = eSinhViens;
            return View();
        }

        [HttpPost]
        public ActionResult KhoiTaoPhongKTXMoi(List<ESinhVien> eSinhViens)
        {
            var db = new DB();
            db.SinhVienOLais.RemoveRange(db.SinhVienOLais);
            List<SinhVien> sinhViens = db.SinhViens.Where(x => x.TrangThaiO == (int)TrangThaiO.DangO).ToList();
            sinhViens.ForEach(x =>
            {
                if (eSinhViens.Any(y => y.MaSinhVien == x.MaSinhVien && y.Chon))
                    x.TrangThaiO = (int)TrangThaiO.ChoNhanPhongMoi;
                else
                    x.TrangThaiO = (int)TrangThaiO.CheckOut;
            });
            eSinhViens.ForEach(x =>
            {
                if (x.Chon)
                {
                    db.SinhVienOLais.Add(new SinhVienOLai()
                    {
                        MaSinhVien = x.MaSinhVien
                    });
                }
            });
            db.SaveChanges();
            return RedirectToAction("KhoiTaoPhongKTXMoi");
        }
    }
}
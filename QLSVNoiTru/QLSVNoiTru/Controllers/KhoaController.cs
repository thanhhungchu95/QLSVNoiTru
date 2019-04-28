using QLSVNoiTru.Database;
using QLSVNoiTru.Models;
using System.Linq;
using System.Web.Mvc;

namespace QLSVNoiTru.Controllers
{
    public class KhoaController : BaseController
    {
        // GET: Khoa
        public ActionResult DanhSachKhoa()
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Redirect("/Login/DangNhap");
            var db = new DB();
            ViewData["khoas"] = db.Khoas.ToList();
            return View();
        }

        public JsonResult KiemTraTrung(string maKhoa)
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Json("");
            var db = new DB();
            bool result = db.Khoas.Any(x => x.MaKhoa == maKhoa);
            return Json(new
            {
                result = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ThemMoi(Khoa khoa)
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Redirect("/Login/DangNhap");
            var db = new DB();
            db.Khoas.Add(khoa);
            db.SaveChanges();
            return RedirectToAction("DanhSachKhoa");
        }

        public ActionResult Xoa(string maKhoa)
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Redirect("/Login/DangNhap");
            var db = new DB();
            Khoa khoa = db.Khoas.FirstOrDefault(x => x.MaKhoa == maKhoa);
            if (khoa != null)
            {
                db.Khoas.Remove(khoa);
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachKhoa");
        }

        public JsonResult ChiTiet(string maKhoa)
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Json("");
            var db = new DB();
            Khoa khoa = db.Khoas.FirstOrDefault(x => x.MaKhoa == maKhoa);
            return Json(new
            {
                khoa.MaKhoa,
                khoa.TenKhoa
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CapNhat(Khoa khoa)
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Redirect("/Login/DangNhap");
            var db = new DB();
            Khoa khoaCu = db.Khoas.FirstOrDefault(x => x.MaKhoa == khoa.MaKhoa);
            if (khoaCu != null)
            {
                khoaCu.TenKhoa = khoa.TenKhoa;
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachKhoa");
        }
    }
}
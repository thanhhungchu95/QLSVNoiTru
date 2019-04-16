using QLSVNoiTru.Database;
using System.Linq;
using System.Web.Mvc;

namespace QLSVNoiTru.Controllers
{
    public class KhoaController : Controller
    {
        // GET: Khoa
        public ActionResult DanhSachKhoa()
        {
            var db = new DB();
            ViewData["khoas"] = db.Khoas.ToList();
            return View();
        }

        public JsonResult KiemTraTrung(string maKhoa)
        {
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
            var db = new DB();
            db.Khoas.Add(khoa);
            db.SaveChanges();
            return RedirectToAction("DanhSachKhoa");
        }

        public ActionResult Xoa(string maKhoa)
        {
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
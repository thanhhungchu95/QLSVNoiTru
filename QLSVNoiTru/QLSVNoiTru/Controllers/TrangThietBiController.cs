using QLSVNoiTru.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSVNoiTru.Controllers
{
    public class TrangThietBiController : Controller
    {
        // GET: TrangThietBi
        public ActionResult DanhSachThietBi()
        {
            var db = new DB();
            ViewData["thietBis"] = db.ThietBis.ToList();
            return View();
        }
        public JsonResult KiemTraTrung(string maThietBi)
        {
            var db = new DB();
            bool result = db.ThietBis.Any(x => x.MaThietBi == maThietBi);
            return Json(new
            {
                result = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ThemMoi(ThietBi thietBi)
        {
            var db = new DB();
            db.ThietBis.Add(thietBi);
            db.SaveChanges();
            return RedirectToAction("DanhSachThietBi");
        }

        public ActionResult Xoa(string maThietBi)
        {
            var db = new DB();
            ThietBi thietBi = db.ThietBis.FirstOrDefault(x => x.MaThietBi == maThietBi);
            if (thietBi != null)
            {
                db.ThietBis.Remove(thietBi);
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachThietBi");
        }

        public JsonResult ChiTiet(string maThietBi)
        {
            var db = new DB();
            ThietBi thietBi = db.ThietBis.FirstOrDefault(x => x.MaThietBi == maThietBi);
            return Json(new
            {
                thietBi.MaThietBi,
                thietBi.TenThietBi,
                thietBi.HinhAnh,
                thietBi.Gia
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CapNhat(ThietBi thietBi)
        {
            var db = new DB();
            ThietBi thietBiCu = db.ThietBis.FirstOrDefault(x => x.MaThietBi == thietBi.MaThietBi);
            if (thietBiCu != null)
            {
                thietBiCu.TenThietBi = thietBi.TenThietBi;
                thietBiCu.HinhAnh = thietBi.HinhAnh;
                thietBiCu.Gia = thietBi.Gia;
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachThietBi");
        }
    }
}
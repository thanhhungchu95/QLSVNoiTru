using QLSVNoiTru.Database;
using System.Linq;
using System.Web.Mvc;

namespace QLSVNoiTru.Controllers
{
    public class LoaiPhongController : Controller
    {
        // GET: Admin/LoaiPhong
        public ActionResult DanhSachLoaiPhong()
        {
            var db = new DB();
            ViewData["loaiphongs"] = db.LoaiPhongs.ToList();
            return View();
        }

        public JsonResult KiemTraTrung(string maLoaiPhong)
        {
            var db = new DB();
            bool result = db.LoaiPhongs.Any(x => x.MaLoaiPhong == maLoaiPhong);
            return Json(new
            {
                result = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ThemMoi(LoaiPhong loaiPhong)
        {
            var db = new DB();
            db.LoaiPhongs.Add(loaiPhong);
            db.SaveChanges();
            return RedirectToAction("DanhSachLoaiPhong");
        }

        public ActionResult Xoa(string maLoaiPhong)
        {
            var db = new DB();
            LoaiPhong loaiPhong = db.LoaiPhongs.FirstOrDefault(x => x.MaLoaiPhong == maLoaiPhong);
            if (loaiPhong != null)
            {
                db.Phongs.RemoveRange(db.Phongs.Where(x => x.MaLoaiPhong == maLoaiPhong));
                db.LoaiPhongs.Remove(loaiPhong);
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachLoaiPhong");
        }

        public JsonResult ChiTiet(string maLoaiPhong)
        {
            var db = new DB();
            LoaiPhong loaiPhong = db.LoaiPhongs.FirstOrDefault(x => x.MaLoaiPhong == maLoaiPhong);
            return Json(new
            {
                loaiPhong.MaLoaiPhong,
                loaiPhong.TenLoaiPhong,
                loaiPhong.MucDich
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CapNhat(LoaiPhong loaiPhong)
        {
            var db = new DB();
            LoaiPhong loaiPhongCu = db.LoaiPhongs.FirstOrDefault(x => x.MaLoaiPhong == loaiPhong.MaLoaiPhong);
            if (loaiPhong != null)
            {
                loaiPhongCu.TenLoaiPhong = loaiPhong.TenLoaiPhong;
                loaiPhongCu.MucDich = loaiPhong.MucDich;
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachLoaiPhong");
        }
    }
}
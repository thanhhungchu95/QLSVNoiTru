using QLSVNoiTru.Database;
using QLSVNoiTru.Models;
using System.Linq;
using System.Web.Mvc;

namespace QLSVNoiTru.Controllers
{
    public class KyTucXaController : BaseController
    {
        // GET: KyTucXa
        public ActionResult ManHinhKyTucXa()
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Redirect("/Login/DangNhap");
            var db = new DB();
            KyTucXa kyTucXa = db.KyTucXas.FirstOrDefault();
            if (kyTucXa is null)
            {
                kyTucXa = new KyTucXa()
                {
                    DiaChi = "",
                    Email = "",
                    HinhAnh = "/Files/img-default.gif",
                    SoDienThoai = "",
                    TenKyTucXa = ""
                };
            }
            ViewData["kyTucXa"] = kyTucXa;
            return View();
        }
        [HttpPost]
        public ActionResult CapNhat(KyTucXa kyTucXa)
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Redirect("/Login/DangNhap");
            var db = new DB();
            KyTucXa kyTucXaOld = db.KyTucXas.FirstOrDefault();
            if (kyTucXaOld is null)
            {
                db.KyTucXas.Add(kyTucXa);
            }
            else
            {
                kyTucXaOld.TenKyTucXa = kyTucXa.TenKyTucXa;
                kyTucXaOld.DiaChi = kyTucXa.DiaChi;
                kyTucXaOld.Email = kyTucXa.Email;
                kyTucXaOld.HinhAnh = kyTucXa.HinhAnh;
                kyTucXaOld.SoDienThoai = kyTucXa.SoDienThoai;
            }
            db.SaveChanges();
            return RedirectToAction("ManHinhKyTucXa");
        }
    }
}
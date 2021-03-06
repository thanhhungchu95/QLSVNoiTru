﻿using QLSVNoiTru.Database;
using QLSVNoiTru.Models;
using System.Linq;
using System.Web.Mvc;

namespace QLSVNoiTru.Controllers
{
    public class KyLuatController : BaseController
    {
        // GET: KyLuat
        public ActionResult DanhSachKyLuat()
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Redirect("/Login/DangNhap");
            var db = new DB();
            ViewData["kyluats"] = db.KyLuats.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(KyLuat kyLuat)
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Redirect("/Login/DangNhap");
            var db = new DB();
            db.KyLuats.Add(kyLuat);
            db.SaveChanges();
            return RedirectToAction("DanhSachKyLuat");
        }

        public ActionResult Xoa(int maKyLuat)
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Redirect("/Login/DangNhap");
            var db = new DB();
            KyLuat kyLuat = db.KyLuats.FirstOrDefault(x => x.MaKyLuat == maKyLuat);
            if (kyLuat != null)
            {
                db.SinhVienKyLuats.RemoveRange(db.SinhVienKyLuats.Where(x => x.MaKyLuat == maKyLuat));
                db.KyLuats.Remove(kyLuat);
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachKyLuat");
        }

        public JsonResult ChiTiet(int maKyLuat)
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Json("");
            var db = new DB();
            KyLuat kyLuat = db.KyLuats.FirstOrDefault(x => x.MaKyLuat == maKyLuat);
            return Json(new
            {
                kyLuat.MaKyLuat,
                kyLuat.TenKyLuat,
                kyLuat.MucDo
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CapNhat(KyLuat kyLuat)
        {
            if (!CheckLogin(QuyenDangNhap.BPQuanLy))
                return Redirect("/Login/DangNhap");
            var db = new DB();
            KyLuat KyLuatCu = db.KyLuats.FirstOrDefault(x => x.MaKyLuat == kyLuat.MaKyLuat);
            if (KyLuatCu != null)
            {
                KyLuatCu.MucDo = kyLuat.MucDo;
                KyLuatCu.TenKyLuat = kyLuat.TenKyLuat;
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachKyLuat");
        }
    }
}
using QLSVNoiTru.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSVNoiTru.Controllers
{
    public class GiaDienController : Controller
    {
        // GET: GiaDien
        public ActionResult CapNhatGiaDien()
        {
            var db = new DB();
            ViewData["giaDiens"] = db.GiaDiens.OrderByDescending(x=>x.NgayCapNhat).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CapNhat(float DonGia)
        {
            var db = new DB();
            GiaDien giaDien = new GiaDien()
            {
                Dongia = DonGia,
                NgayCapNhat = DateTime.Now
            };
            db.GiaDiens.Add(giaDien);
            db.SaveChanges();
            return RedirectToAction("CapNhatGiaDien");
        }
    }
}
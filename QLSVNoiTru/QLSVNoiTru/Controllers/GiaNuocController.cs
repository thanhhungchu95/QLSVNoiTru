using QLSVNoiTru.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSVNoiTru.Controllers
{
    public class GiaNuocController : Controller
    {
        // GET: GiaNuoc
        public ActionResult CapNhatGiaNuoc()
        {
            var db = new DB();
            ViewData["giaNuocs"] = db.GiaNuocs.OrderByDescending(x => x.NgayCapNhat).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CapNhat(float DonGia)
        {
            var db = new DB();
            GiaNuoc giaNuoc = new GiaNuoc()
            {
                Dongia = DonGia,
                NgayCapNhat = DateTime.Now
            };
            db.GiaNuocs.Add(giaNuoc);
            db.SaveChanges();
            return RedirectToAction("CapNhatGiaNuoc");
        }
    }
}
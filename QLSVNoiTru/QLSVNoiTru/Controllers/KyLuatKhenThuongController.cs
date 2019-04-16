using QLSVNoiTru.Database;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QLSVNoiTru.Controllers
{
    public class KyLuatKhenThuongController : Controller
    {
        // GET: KyLuatKhenThuong
        public ActionResult KhenThuong(string masinhvien = "")
        {
            ViewBag.masinhvien = masinhvien;
            var db = new DB();
            SinhVien sinhVien = db.SinhViens.FirstOrDefault(x => x.MaSinhVien == masinhvien);
            ViewData["sinhVien"] = sinhVien;
            return View();
        }
        public ActionResult KyLuat(string masinhvien = "", int mucdo = 0)
        {
            ViewBag.masinhvien = masinhvien;
            var db = new DB();
            SinhVien sinhVien = db.SinhViens.FirstOrDefault(x => x.MaSinhVien == masinhvien);
            List<SinhVienKyLuat> sinhVienKyLuats = new List<SinhVienKyLuat>();
            if (mucdo == 0)
            {
                SinhVienKyLuat sinhVienKyLuatCheckExist = db.SinhVienKyLuats.FirstOrDefault(x => x.MaSinhVien == masinhvien);
                if (sinhVienKyLuatCheckExist != null)
                    mucdo = sinhVienKyLuatCheckExist.KyLuat.MucDo.Value;
            }
            List<KyLuat> kyLuats = db.KyLuats.Where(x => x.MucDo == mucdo).ToList();
            if (kyLuats != null)
            {
                kyLuats.ForEach(x =>
                {
                    SinhVienKyLuat sinhVienKyLuat = db.SinhVienKyLuats.FirstOrDefault(y => y.MaSinhVien == masinhvien && y.MaKyLuat == x.MaKyLuat);
                    if (sinhVienKyLuat == null)
                    {
                        sinhVienKyLuat = new SinhVienKyLuat()
                        {
                            Chon = false,
                            KyLuat = x,
                            MaKyLuat = x.MaKyLuat,
                            MaSinhVien = masinhvien
                        };
                    }
                    sinhVienKyLuats.Add(sinhVienKyLuat);
                });
            }
            ViewBag.mucdo = mucdo;
            ViewData["sinhVien"] = sinhVien;
            ViewData["sinhVienKyLuats"] = sinhVienKyLuats;
            return View();
        }

        [HttpPost]
        public ActionResult CapNhatKyLuat(string MaSinhVien, int MucDo, List<SinhVienKyLuat> sinhVienKyLuats)
        {
            if (sinhVienKyLuats == null)
                sinhVienKyLuats = new List<SinhVienKyLuat>();
            var db = new DB();
            SinhVien sinhVien = db.SinhViens.FirstOrDefault(x => x.MaSinhVien == MaSinhVien);
            if (sinhVien != null)
            {
                if (MucDo > 0)
                {
                    db.SinhVienKyLuats.RemoveRange(db.SinhVienKyLuats.Where(x => x.MaSinhVien == MaSinhVien));
                    sinhVienKyLuats.ForEach(x =>
                    {
                        db.SinhVienKyLuats.Add(new SinhVienKyLuat()
                        {
                            MaSinhVien = MaSinhVien,
                            Chon = x.Chon,
                            MaKyLuat = x.MaKyLuat
                        });
                    });
                    db.SaveChanges();
                }
            }
            return RedirectToAction("KyLuat", new { masinhvien = MaSinhVien, mucdo = MucDo });
        }
        [HttpPost]
        public ActionResult CapNhatKhenThuong(string MaSinhVien, string KhenThuong)
        {
            var db = new DB();
            SinhVien sinhVien = db.SinhViens.FirstOrDefault(x => x.MaSinhVien == MaSinhVien);
            if (sinhVien != null)
            {
                sinhVien.KhenThuong = KhenThuong;
                db.SaveChanges();
            }
            return RedirectToAction("KhenThuong", new { masinhvien = MaSinhVien });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class ProjeController : Controller
    {
        // GET: Proje
        ProjeRepository repo = new ProjeRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult ProjeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProjeEkle(TblProjelerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult ProjeSil(int id)
        {
            TblProjelerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ProjeGetir(int id)
        {
            TblProjelerim t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult ProjeGetir(TblProjelerim p)
        {
            TblProjelerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Supermarket.Models;
using Supermarket.Models.Товары_в_чеке;

namespace Supermarket.Controllers
{
    public class ЧекиController : Controller
    {
        private SupermarketContext db = new SupermarketContext();

        // GET: Чеки
        public ActionResult Index()
        {
            var чеки = db.Чеки.Include(ч => ч.Дисконтные_карты).Include(ч => ч.Кассиры).Include(ч => ч.Смены).Include(ч => ч.Смены.Кассы).Include(t => t.Строка_в_чеке)
                .Select(
                    ч => new ИнфоЧек
                    {
                        ID_чека = ч.ID_чека,
                        ID_смены = ч.ID_смены,
                        ID_кассира = ч.ID_кассира,
                        Фамилия = ч.Кассиры.Фамилия,
                        Имя = ч.Кассиры.Имя,
                        Время_открытия_чека = ч.Время_открытия_чека,
                        Время_закрытия_чека = ч.Время_закрытия_чека,
                        Номер_карты = ч.Номер_карты,
                        Наличные = ч.Наличные,
                        НомерКассы = ч.Смены.Номер_кассы
                    }).ToList();
            return View(чеки);
        }

        // GET: Чеки/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tovary = db.Строка_в_чеке.Include(с => с.Товары).Include(с => с.Чеки).Where(c => c.Чеки.ID_чека == id.Value)
                .Select(t => new ТоварВЧеке
                {
                    ID_товара = t.ID_товара,
                    Количество = t.Количество,
                    Наименование = t.Товары.Наименование,
                    Номер = t.Номер_строки
                }).ToList();           

            return View(tovary);
        }

        // GET: Чеки/Create
        public ActionResult Create()
        {
            ViewBag.Номер_карты = new SelectList(db.Дисконтные_карты, "Номер_карты", "Номер_карты");
            return View();
        }

        // POST: Чеки/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_чека,Время_открытия_чека,Время_закрытия_чека,Номер_карты,ID_кассира,ID_смены,Наличные")] Чеки чеки)
        {
            if (ModelState.IsValid)
            {
                чеки.ID_чека = Guid.NewGuid();
                db.Чеки.Add(чеки);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Номер_карты = new SelectList(db.Дисконтные_карты, "Номер_карты", "Номер_карты", чеки.Номер_карты);
            return View(чеки);
        }

        // GET: Чеки/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Чеки чеки = db.Чеки.Find(id);
            if (чеки == null)
            {
                return HttpNotFound();
            }
            ViewBag.Номер_карты = new SelectList(db.Дисконтные_карты, "Номер_карты", "Номер_карты", чеки.Номер_карты);
            return View(чеки);
        }

        // POST: Чеки/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_чека,Время_открытия_чека,Время_закрытия_чека,Номер_карты,ID_кассира,ID_смены,Наличные")] Чеки чеки)
        {
            if (ModelState.IsValid)
            {
                db.Entry(чеки).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Номер_карты = new SelectList(db.Дисконтные_карты, "Номер_карты", "Номер_карты", чеки.Номер_карты);
            return View(чеки);
        }

        // GET: Чеки/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Чеки чеки = db.Чеки.Find(id);
            if (чеки == null)
            {
                return HttpNotFound();
            }
            return View(чеки);
        }

        // POST: Чеки/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Чеки чеки = db.Чеки.Find(id);
            db.Чеки.Remove(чеки);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

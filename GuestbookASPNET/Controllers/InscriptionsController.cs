using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Domain;
using GuestbookASPNET.ViewModels;

namespace GuestbookASPNET.Controllers
{
    public class InscriptionsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Inscriptions
        public ActionResult Index(InscriptionViewModel vm)
        {
            vm.Inscriptions = db.Inscriptions.Where(i => i.DateDeleted == null).ToList();
            return View(vm);
        }

        // GET: Inscriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inscription = db.Inscriptions.Find(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            return View(inscription);
        }

        // GET: Inscriptions/Create
        public ActionResult Create()
        {
            var vm = new InscriptionViewModel();
            return View(vm);
        }

        // POST: Inscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InscriptionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Inscription.DateAdded = DateTime.Now;
                db.Inscriptions.Add(vm.Inscription);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // GET: Inscriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new InscriptionViewModel {Inscription = db.Inscriptions.Find(id)};
            if (vm.Inscription == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Inscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InscriptionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vm.Inscription).State = EntityState.Modified;
                vm.Inscription.DateModified = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Inscriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscription inscription = db.Inscriptions.Find(id);
            if (inscription == null)
            {
                return HttpNotFound();
            }
            return View(inscription);
        }

        // POST: Inscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscription inscription = db.Inscriptions.Find(id);
            inscription.DateDeleted = DateTime.Now;
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjIntegrador.DataAccess;
using ProjIntegrador.Models;

namespace ProjIntegrador.Controllers
{
    public class InstaladorController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Instalador
        public ActionResult Index()
        {
            var instalador = db.Instalador.Include(i => i.Funcionario);
            return View(instalador.ToList());
        }

        // GET: Instalador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instalador instalador = db.Instalador.Find(id);
            if (instalador == null)
            {
                return HttpNotFound();
            }
            return View(instalador);
        }

        // GET: Instalador/Create
        public ActionResult Create()
        {
            ViewBag.FuncionarioId = new SelectList(db.Funcionario, "FuncionarioId", "CPF");
            return View();
        }

        // POST: Instalador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstaladorId,FuncionarioId")] Instalador instalador)
        {
            if (ModelState.IsValid)
            {
                db.Instalador.Add(instalador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioId = new SelectList(db.Funcionario, "FuncionarioId", "CPF", instalador.FuncionarioId);
            return View(instalador);
        }

        // GET: Instalador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instalador instalador = db.Instalador.Find(id);
            if (instalador == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioId = new SelectList(db.Funcionario, "FuncionarioId", "CPF", instalador.FuncionarioId);
            return View(instalador);
        }

        // POST: Instalador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstaladorId,FuncionarioId")] Instalador instalador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instalador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioId = new SelectList(db.Funcionario, "FuncionarioId", "CPF", instalador.FuncionarioId);
            return View(instalador);
        }

        // GET: Instalador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instalador instalador = db.Instalador.Find(id);
            if (instalador == null)
            {
                return HttpNotFound();
            }
            return View(instalador);
        }

        // POST: Instalador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instalador instalador = db.Instalador.Find(id);
            db.Instalador.Remove(instalador);
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

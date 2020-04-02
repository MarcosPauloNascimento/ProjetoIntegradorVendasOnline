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
    public class InteressadoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Interessado
        public ActionResult Index()
        {
            var interessado = db.Interessado.Include(i => i.Endereco);
            return View(interessado.ToList());
        }

        // GET: Interessado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interessado interessado = db.Interessado.Find(id);
            if (interessado == null)
            {
                return HttpNotFound();
            }
            return View(interessado);
        }

        // GET: Interessado/Create
        public ActionResult Create()
        {
            ViewBag.EnderecoId = new SelectList(db.Endereco, "EnderecoId", "Descricao");
            return View();
        }

        // POST: Interessado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InteressadoId,Nome,Telefone,Email,DataCadastro,DataAgendamento,DataVisita,Status,EnderecoId")] Interessado interessado)
        {
            if (ModelState.IsValid)
            {
                db.Interessado.Add(interessado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnderecoId = new SelectList(db.Endereco, "EnderecoId", "Descricao", interessado.EnderecoId);
            return View(interessado);
        }

        // GET: Interessado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interessado interessado = db.Interessado.Find(id);
            if (interessado == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnderecoId = new SelectList(db.Endereco, "EnderecoId", "Descricao", interessado.EnderecoId);
            return View(interessado);
        }

        // POST: Interessado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InteressadoId,Nome,Telefone,Email,DataCadastro,DataAgendamento,DataVisita,Status,EnderecoId")] Interessado interessado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interessado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnderecoId = new SelectList(db.Endereco, "EnderecoId", "Descricao", interessado.EnderecoId);
            return View(interessado);
        }

        // GET: Interessado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interessado interessado = db.Interessado.Find(id);
            if (interessado == null)
            {
                return HttpNotFound();
            }
            return View(interessado);
        }

        // POST: Interessado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Interessado interessado = db.Interessado.Find(id);
            db.Interessado.Remove(interessado);
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

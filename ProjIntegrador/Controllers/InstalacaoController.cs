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
    public class InstalacaoController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Instalacao
        public ActionResult Index()
        {
            var instalacao = db.Instalacao.Include(i => i.Endereco).Include(i => i.Instalador).Include(i => i.Venda);
            return View(instalacao.ToList());
        }

        // GET: Instalacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instalacao instalacao = db.Instalacao.Find(id);
            if (instalacao == null)
            {
                return HttpNotFound();
            }
            return View(instalacao);
        }

        // GET: Instalacao/Create
        public ActionResult Create()
        {
            ViewBag.EnderecoId = new SelectList(db.Endereco, "EnderecoId", "Descricao");
            ViewBag.InstaladorId = new SelectList(db.Instalador, "InstaladorId", "InstaladorId");
            ViewBag.VendaId = new SelectList(db.Venda, "VendaId", "VendaId");
            return View();
        }

        // POST: Instalacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstalacaoId,DataInstalacao,Observacao,EnderecoId,InstaladorId,VendaId")] Instalacao instalacao)
        {
            if (ModelState.IsValid)
            {
                db.Instalacao.Add(instalacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnderecoId = new SelectList(db.Endereco, "EnderecoId", "Descricao", instalacao.EnderecoId);
            ViewBag.InstaladorId = new SelectList(db.Instalador, "InstaladorId", "InstaladorId", instalacao.InstaladorId);
            ViewBag.VendaId = new SelectList(db.Venda, "VendaId", "VendaId", instalacao.VendaId);
            return View(instalacao);
        }

        // GET: Instalacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instalacao instalacao = db.Instalacao.Find(id);
            if (instalacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnderecoId = new SelectList(db.Endereco, "EnderecoId", "Descricao", instalacao.EnderecoId);
            ViewBag.InstaladorId = new SelectList(db.Instalador, "InstaladorId", "InstaladorId", instalacao.InstaladorId);
            ViewBag.VendaId = new SelectList(db.Venda, "VendaId", "VendaId", instalacao.VendaId);
            return View(instalacao);
        }

        // POST: Instalacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstalacaoId,DataInstalacao,Observacao,EnderecoId,InstaladorId,VendaId")] Instalacao instalacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instalacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnderecoId = new SelectList(db.Endereco, "EnderecoId", "Descricao", instalacao.EnderecoId);
            ViewBag.InstaladorId = new SelectList(db.Instalador, "InstaladorId", "InstaladorId", instalacao.InstaladorId);
            ViewBag.VendaId = new SelectList(db.Venda, "VendaId", "VendaId", instalacao.VendaId);
            return View(instalacao);
        }

        // GET: Instalacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instalacao instalacao = db.Instalacao.Find(id);
            if (instalacao == null)
            {
                return HttpNotFound();
            }
            return View(instalacao);
        }

        // POST: Instalacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instalacao instalacao = db.Instalacao.Find(id);
            db.Instalacao.Remove(instalacao);
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

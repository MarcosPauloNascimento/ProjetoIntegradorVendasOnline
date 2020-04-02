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
    public class VendaController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Venda
        public ActionResult Index()
        {
            var venda = db.Venda.Include(v => v.Cliente).Include(v => v.Vendedor);
            return View(venda.ToList());
        }

        // GET: Venda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Venda.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Venda/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome");
            ViewBag.VendedorId = new SelectList(db.Vendedor, "VendedorId", "VendedorId");
            return View();
        }

        // POST: Venda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendaId,TotalVenda,FormaPagamento,ValorDesconto,DataVenda,ClienteId,VendedorId")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Venda.Add(venda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", venda.ClienteId);
            ViewBag.VendedorId = new SelectList(db.Vendedor, "VendedorId", "VendedorId", venda.VendedorId);
            return View(venda);
        }

        // GET: Venda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Venda.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", venda.ClienteId);
            ViewBag.VendedorId = new SelectList(db.Vendedor, "VendedorId", "VendedorId", venda.VendedorId);
            return View(venda);
        }

        // POST: Venda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendaId,TotalVenda,FormaPagamento,ValorDesconto,DataVenda,ClienteId,VendedorId")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", venda.ClienteId);
            ViewBag.VendedorId = new SelectList(db.Vendedor, "VendedorId", "VendedorId", venda.VendedorId);
            return View(venda);
        }

        // GET: Venda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Venda.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.Venda.Find(id);
            db.Venda.Remove(venda);
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

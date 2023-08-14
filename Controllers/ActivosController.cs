using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenComercioElectronico.Models;

namespace ExamenComercioElectronico.Controllers
{
    public class ActivosController : Controller
    {
        private BdExamenComercioElectronico db = new BdExamenComercioElectronico();

        // GET: Activos
        public ActionResult Index()
        {
            var activos = db.Activos.Include(a => a.Departamentos).Include(a => a.Funcionarios);
            return View(activos.ToList());
        }

        // GET: Activos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos activos = db.Activos.Find(id);
            if (activos == null)
            {
                return HttpNotFound();
            }
            return View(activos);
        }

        // GET: Activos/Create
        public ActionResult Create()
        {
            ViewBag.codigo = new SelectList(db.Departamentos, "codigo", "nombre");
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nombre");
            return View();
        }

        // POST: Activos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numeroPlaca,idFuncionario,codigo,descripcion,marca")] Activos activos)
        {
            if (ModelState.IsValid)
            {
                db.Activos.Add(activos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo = new SelectList(db.Departamentos, "codigo", "nombre", activos.codigo);
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nombre", activos.idFuncionario);
            return View(activos);
        }

        // GET: Activos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos activos = db.Activos.Find(id);
            if (activos == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo = new SelectList(db.Departamentos, "codigo", "nombre", activos.codigo);
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nombre", activos.idFuncionario);
            return View(activos);
        }

        // POST: Activos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numeroPlaca,idFuncionario,codigo,descripcion,marca")] Activos activos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo = new SelectList(db.Departamentos, "codigo", "nombre", activos.codigo);
            ViewBag.idFuncionario = new SelectList(db.Funcionarios, "idFuncionario", "nombre", activos.idFuncionario);
            return View(activos);
        }

        // GET: Activos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activos activos = db.Activos.Find(id);
            if (activos == null)
            {
                return HttpNotFound();
            }
            return View(activos);
        }

        // POST: Activos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activos activos = db.Activos.Find(id);
            db.Activos.Remove(activos);
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

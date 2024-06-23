using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViaTecnicaWEB.Models;

namespace ViaTecnicaWEB.Views
{
    public class Turno_CabeceraController : Controller
    {
        private ViaTecnicaEntities db = new ViaTecnicaEntities();

        // GET: Turno_Cabecera
        public ActionResult Index()
        {
            var turno_Cabecera = db.Turno_Cabecera.Include(t => t.Cliente);
            return View(turno_Cabecera.ToList());
        }

        // GET: Turno_Cabecera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno_Cabecera turno_Cabecera = db.Turno_Cabecera.Find(id);
            if (turno_Cabecera == null)
            {
                return HttpNotFound();
            }
            return View(turno_Cabecera);
        }

        // GET: Turno_Cabecera/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id", "Nombre");
            return View();
        }

        // POST: Turno_Cabecera/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Cliente,Fecha_Turno,Fecha_Creacion_Turno,Direccion,Telefono_Principal,Telefono_Secundario,Email")] Turno_Cabecera turno_Cabecera)
        {
            if (ModelState.IsValid)
            {
                db.Turno_Cabecera.Add(turno_Cabecera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id", "Nombre", turno_Cabecera.Id_Cliente);
            return View(turno_Cabecera);
        }

        // GET: Turno_Cabecera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno_Cabecera turno_Cabecera = db.Turno_Cabecera.Find(id);
            if (turno_Cabecera == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id", "Nombre", turno_Cabecera.Id_Cliente);
            return View(turno_Cabecera);
        }

        // POST: Turno_Cabecera/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Cliente,Fecha_Turno,Fecha_Creacion_Turno,Direccion,Telefono_Principal,Telefono_Secundario,Email")] Turno_Cabecera turno_Cabecera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turno_Cabecera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id", "Nombre", turno_Cabecera.Id_Cliente);
            return View(turno_Cabecera);
        }

        // GET: Turno_Cabecera/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno_Cabecera turno_Cabecera = db.Turno_Cabecera.Find(id);
            if (turno_Cabecera == null)
            {
                return HttpNotFound();
            }
            return View(turno_Cabecera);
        }

        // POST: Turno_Cabecera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turno_Cabecera turno_Cabecera = db.Turno_Cabecera.Find(id);
            db.Turno_Cabecera.Remove(turno_Cabecera);
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

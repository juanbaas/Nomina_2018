using Nomina2018.DBLayer;
using Nomina2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nomina2018.Controllers
{
    public class SucursalesController : Controller
    {
        DbSucursales dbSucursal = new DbSucursales();
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(dbSucursal.ListarSucursales());
        }

        // GET: Sucursales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sucursales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sucursales/Create
        [HttpPost]
        public ActionResult Create(SucursalesModel Sucmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    if (dbSucursal.AgregarSucursal(Sucmodel))
                    {
                        ViewBag.Message = "Sucursal agregada correctamente";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursales/Edit/5
        public ActionResult Edit(int id)
        {
            return View(dbSucursal.ListarSucursales().Find(Sucmodel => Sucmodel.idSucursal == id));
        }

        // POST: Sucursales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SucursalesModel Sucmodel)
        {
            try
            {
                dbSucursal.ActualizarSucursal(Sucmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursales/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if (dbSucursal.BorrarSucursal(id))
                {
                    ViewBag.AlertMsg = "Sucursal eliminado correctamente";
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        
     
    }
}

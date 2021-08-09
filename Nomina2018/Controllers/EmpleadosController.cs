using Nomina2018.DBLayer;
using Nomina2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nomina2018.Controllers
{
    public class EmpleadosController : Controller
    {
        DbEmpleados dbEmpleados = new DbEmpleados();
        private Nomina2018Entities1 db = new Nomina2018Entities1();
        // GET: Empleados
        //public ActionResult Index()
        //{
        //    ModelState.Clear();
        //    return View(dbEmpleados.ListarEmpleados());
        //}
        public ActionResult Index(string searching)
        {
            return View(db.Empleados.Where(x => x.numEmpleado.Contains(searching)|| searching == null).ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        public ActionResult Create(EmpleadosModel Empmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (dbEmpleados.AgregarEmpleado(Empmodel))
                    {
                        ViewBag.Message = "Empleado agregado exitosamente";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int id)
        {
            return View(dbEmpleados.ListarEmpleados().Find(Empmodel => Empmodel.IdEmpleado == id));
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmpleadosModel Empmodel)
        {
            try
            {
                dbEmpleados.ActualizarEmpleado(Empmodel);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if (dbEmpleados.BorrarEmpleado(id))
                {
                    ViewBag.AlertMsg = "Empleado borrado exitosamente";
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

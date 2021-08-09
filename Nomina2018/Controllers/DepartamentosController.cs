using Nomina2018.DBLayer;
using Nomina2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nomina2018.Controllers
{
    public class DepartamentosController : Controller
    {
        DbDepartamentos dbDepartamentos = new DbDepartamentos();
        // GET: Departamentos
        public ActionResult Index()
        {

            ModelState.Clear();
            return View(dbDepartamentos.ListarDepartamentos());
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        [HttpPost]
        public ActionResult Create(DepartamentosModel Depmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //DbDepartamentos dbDepartamentos = new DbDepartamentos();
                    if (dbDepartamentos.AgregarDepartamento(Depmodel))
                    {
                        ViewBag.Message = "Departamento agregado correctamente";
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

        // GET: Departamentos/Edit/5
        public ActionResult Edit(int id)
        {
            //DbDepartamentos dbDepartamentos = new DbDepartamentos();

            return View(dbDepartamentos.ListarDepartamentos().Find(Depmodel => Depmodel.idDepartamentos == id));
        }

        // POST: Departamentos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DepartamentosModel Depmodel)
        {
            try
            {
                dbDepartamentos.ActualizarDepartamentos(Depmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Departamentos/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if (dbDepartamentos.BorrarDepartamentos(id))
                {
                    ViewBag.AlertMsg = "Registro borrado exitosamente";
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

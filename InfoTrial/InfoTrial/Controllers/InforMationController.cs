using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace InfoTrial.Controllers
{
    public class InforMationController : Controller
    {
       
       // GET: InforMation
        public ActionResult Index()
        {
            Models.InfoDBHandle dbhandle = new Models.InfoDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetInformation());
        }

        // GET: InforMation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InforMation/Create
        [HttpPost]
        // [ValidateAntiForgeryToken]
        //public ActionResult Create(Models.InforMation info)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Models.InfoDBHandle idb = new Models.InfoDBHandle();
        //            idb.AddInformation(info);

        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.Message = " Details Added Successfully";
        //        return View();
        //    }
        //    catch
        //    {

        //        return View();
        //    }
        //}

        // GET: InforMation/Edit/5
        public ActionResult Edit(int id)
        {
            Models.InfoDBHandle idb = new Models.InfoDBHandle();
            return View(idb.GetInformation().Find(info => info.Id == id));
        }

        // POST: InforMation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.InforMation info)
        {
            try
            {
                Models.InfoDBHandle idb = new Models.InfoDBHandle();
                idb.UpdateInformation(info);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InforMation/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Models.InfoDBHandle sdb = new Models.InfoDBHandle();
                if (sdb.DeleteInformation(id))
                {
                    ViewBag.AlertMsg = " Deleted Successfully";
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

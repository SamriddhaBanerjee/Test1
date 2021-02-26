using ApiConnectGetPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace ApiConnectGetPost.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //get from web api
            IEnumerable<InformationViewModel> info = null;

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49979/api/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("information");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<InformationViewModel>>();
                    readTask.Wait();

                    info = readTask.Result;
                }
                else
                {
                    //Error response received   
                    info = Enumerable.Empty<InformationViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
                return View(info);
        }

        public JsonResult View()
        {
            Info_DB idb = new Info_DB();
            return Json(idb.Show(), JsonRequestBehavior.AllowGet);
        }
        //public async Task<ActionResult> View(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    InformationViewModel info = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:49979/api/");

        //        var result = await client.GetAsync($"employees/details/{id}");

        //        if (result.IsSuccessStatusCode)
        //        {
        //            info = await result.Content.ReadAsAsync<InformationViewModel>();
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Server error try after some time.");
        //        }
        //    }

        //    if (info == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(info);
        //}

        [HttpPost]
        public async Task<JsonResult> Create(InformationViewModel info)
        {
            Info_DB idb = new Info_DB();
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:49979/api/");

                    var response = await client.PostAsJsonAsync("employees/Create", info);
                    if (response.IsSuccessStatusCode)
                    {
                        return Json(idb.Add(info), JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
            }
            return Json(idb.Add(info), JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult Create(InformationViewModel info)
        //{
        //    Info_DB idb = new Info_DB();
        //    using (var client = new System.Net.Http.HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:49979/api/");

        //        var postJob = client.PostAsJsonAsync<InformationViewModel>("information", info);
        //        postJob.Wait();

        //        //var postResult = postJob.Result;
        //        //if (postResult.IsSuccessStatusCode)
        //        //    return RedirectToAction("Index");
        //    }
        //    ModelState.AddModelError(string.Empty, "Server error try after some time.");
        //    return Json(idb.Add(info), JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public async Task<JsonResult> Update(InformationViewModel info)
        {
            Info_DB idb = new Info_DB();
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:49979/api/");
                    var response = await client.PostAsJsonAsync("employees/Edit", info);
                    if (response.IsSuccessStatusCode)
                    {
                      return Json(idb.Update(info), JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
                return Json(idb.Update(info), JsonRequestBehavior.AllowGet);
            }
            return Json(idb.Update(info), JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int Id)
        {
            InformationViewModel info = new InformationViewModel();
            Info_DB idb = new Info_DB();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49979/api/");

                var response = await client.DeleteAsync($"employees/Delete/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    return Json(idb.Delete(Id), JsonRequestBehavior.AllowGet);
                }
                else
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            //ModelState.AddModelError(string.Empty, "Server error try after some time.");
            return Json(idb.Delete(Id), JsonRequestBehavior.AllowGet);
        }


    }
}
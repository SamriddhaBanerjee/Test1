using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FirstWebApi.Controllers
{
    public class InformationController : ApiController
    {
        public InformationController()
        {
        }

        //Get Method
        public IHttpActionResult GetInformation()
        {
            IList<Models.InformationView> info = null;

            using (var ctx = new DemoEntities())
            {
                info = ctx.InforMation.Select(s => new Models.InformationView()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Mobile = s.Mobile,
                    Email = s.Email
                }).ToList<Models.InformationView>();
            }

            if (info.Count == 0)
            {
                return NotFound();
            }

            return Ok(info);
        }

        //Post Method
        public IHttpActionResult PostInformation(Models.InformationView info)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new DemoEntities())
            {
                ctx.InforMation.Add(new InforMation()
                {
                    Id = info.Id,
                    Name = info.Name,
                    Address = info.Address,
                    Mobile = info.Mobile,
                    Email = info.Email
                });
            }
            //    ctx.SaveChanges();
            //    IList<Models.InformationView> info1 = null;
            //    info1 = ctx.InforMation.Select(s => new Models.InformationView()
            //    {
            //        Id = s.Id,
            //        Name = s.Name,
            //        Address = s.Address,
            //        Mobile = s.Mobile,
            //        Email = s.Email
            //    }).ToList<Models.InformationView>();
            //}

            return Ok();
        }

        [HttpPost]
        [Route("api/Employees/Create")]
        public async Task CreateAsync([FromBody]InforMation employee)
        {
            if (ModelState.IsValid)
            {
                //await _iEmployeeRepository.Add(employee);
                using (var ctx = new DemoEntities())
                {
                    ctx.InforMation.Add(new InforMation()
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Address = employee.Address,
                        Mobile = employee.Mobile,
                        Email = employee.Email
                    });
                    await ctx.SaveChangesAsync();
                }
            }
        }
        //[HttpGet]
        //[Route("api/Employees/Details/{id}")]
        //public async Task<InforMation> Details(string id)
        //{
        //    // var result = await _iEmployeeRepository.GetEmployee(id);
        //    try
        //    {
        //        var ctx = new DemoEntities();
        //        InforMation info = await ctx.InforMation.FindAsync(id);
        //        if (info == null)
        //        {
        //            return null;
        //        }
        //        return info;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //  //  return result;
        //}
        [HttpPost]
        [Route("api/Employees/Edit")]
        public async Task UpdateAsync([FromBody]InforMation employee)
        {
            try
            {
                var db = new DemoEntities();
               db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("api/Employees/Delete/{id}")]
        public async Task DeleteAsync(string id)
        {
            try
            {
                var db = new DemoEntities();
                InforMation info = await db.InforMation.FindAsync(id);
                db.InforMation.Remove(info);
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            //await _iEmployeeRepository.Delete(id);
        }


        [HttpPost]
        [System.Web.Http.Route("Api/Information/SaveInformation")]
        public IHttpActionResult SaveInformation(Models.InformationView info)
        {
            IList<Models.InformationView> info1 = null;
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new DemoEntities())
            {
                ctx.InforMation.Add(new InforMation()
                {
                    Id = info.Id,
                    Name = info.Name,
                    Address = info.Address,
                    Mobile = info.Mobile,
                    Email = info.Email
                });

                ctx.SaveChanges();

                info1 = ctx.InforMation.Select(s => new Models.InformationView()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Mobile = s.Mobile,
                    Email = s.Email
                }).ToList<Models.InformationView>();
            }

            return Ok(info1);
        }

        //Put Method
        public IHttpActionResult Put(Models.InformationView info)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new DemoEntities())
            {
                var eInfo = ctx.InforMation.Where(s => s.Id == info.Id)
                                                        .FirstOrDefault<InforMation>();

                if (eInfo != null)
                {
                    eInfo.Name = info.Name;


                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        //Delete Method
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (var ctx = new DemoEntities())
            {
                var info = ctx.InforMation
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                ctx.Entry(info).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }
    }

}

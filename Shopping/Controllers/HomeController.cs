
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;
using Shopping.Filters;

namespace Shopping.Controllers
{
    [MyExcepction]
    public class HomeController : Controller
    {
        EcommerceEntities db = new EcommerceEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.sp_GetAllResult();
            var total = db.CollectionMasters.Count();
            ViewBag.TotalRecords = total;
            return View(data);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(from c in db.Categories select c, "Id", "Name");
            ViewBag.DistrictId = new SelectList(from c in db.DistrictMasters select c, "Id", "Name");
            ViewBag.Stateid = new SelectList(from c in db.StateMasters select c, "Id", "State");
            return View();
            
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(CollectionMaster collection)
        {
            ViewBag.CategoryId = new SelectList(from c in db.Categories select c, "Id", "Name");
            ViewBag.DistrictId = new SelectList(from c in db.DistrictMasters select c, "Id", "Name");
            ViewBag.Stateid = new SelectList(from c in db.StateMasters select c, "Id", "State");

            LocalCollectionMaster objforimageupload = new LocalCollectionMaster();

            string filename = Path.GetFileNameWithoutExtension(objforimageupload.ImageFile.FileName);
            string extention = Path.GetExtension(objforimageupload.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssff") + extention;
            objforimageupload.Image = "/Content/ImagesByUser/" + filename;
            filename = Path.Combine(Server.MapPath("/Content/ImagesByUser/"),filename);
            objforimageupload.ImageFile.SaveAs(filename);
            try
            {
                // TODO: Add insert logic here
                
                SqlParameter Name = new SqlParameter("@Name",collection.Name);
                SqlParameter CategoryId = new SqlParameter("@CategoryId",collection.CategoryId);
                SqlParameter DistrictId = new SqlParameter("@DistrictId ",collection.DistrictId);
                SqlParameter Stateid = new SqlParameter("@Stateid",collection.Stateid);
                SqlParameter IsActive = new SqlParameter("@IsActive",collection.IsActive);
                SqlParameter Lat = new SqlParameter("@Lat",collection.Lat);
                SqlParameter Lng = new SqlParameter("@Lng",collection.Lng);
                SqlParameter CollectionCode = new SqlParameter("@CollectionCode",collection.CollectionCode);
                SqlParameter Description = new SqlParameter("@Description",collection.Description);
                SqlParameter IsUserAvailable = new SqlParameter("@IsUserAvailable",collection.IsUserAvailable);
                SqlParameter PriceRange = new SqlParameter("@PriceRange",collection.PriceRange);
                SqlParameter PriceUnit = new SqlParameter("@PriceUnit",collection.@PriceUnit);
                SqlParameter MobileNumber = new SqlParameter("@MobileNumber",collection.MobileNumber);
                SqlParameter Email = new SqlParameter("@Email",collection.Email);
                SqlParameter Image = new SqlParameter("@Image", collection.Image);


                var sendtodb = db.Database.ExecuteSqlCommand("sp_insertCollectionByAdmin  @Name, @CategoryId, @DistrictId, @Stateid, @IsActive, @Lat, @Lng, @CollectionCode, @Description, @IsUserAvailable, @PriceRange, @PriceUnit, @MobileNumber, @Email, @Image", Name, CategoryId, DistrictId, Stateid, IsActive, Lat, Lng, CollectionCode, Description, IsUserAvailable, PriceRange, PriceUnit, MobileNumber, Email, Image);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {

                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var x = (from y in db.CollectionMasters
                         orderby y.id descending
                         select y).FirstOrDefault();
                db.CollectionMasters.Remove(x);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var x = (from y in db.CollectionMasters
                         orderby y.id descending
                         select y).FirstOrDefault();
                db.CollectionMasters.Remove(x);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
       
        public ActionResult GetAllSellerJquery()
        {
            ViewBag.ClickName = new SelectList(db.SellerMasters, "ID", "UserName");
            ViewBag.CategoryId = new SelectList(from c in db.Categories select c, "Id", "Name");
            ViewBag.DistrictId = new SelectList(from c in db.DistrictMasters select c, "Id", "Name");
            ViewBag.Stateid = new SelectList(from c in db.StateMasters select c, "Id", "State");
            //var data = db.SellerMasters.Where(x => x.ID == id).FirstOrDefault();
            return View();
        }

        public ActionResult GetAllSellerJqueryPost()
        {
            return View();
        }

      [HttpPost]
        public JsonResult GetAllSellerJqueryPost(int ids)
        {
            
                ViewBag.SellerName = new SelectList(db.SellerMasters, "ID", "UserName");
            var data = db.SellerMasters.Where(x => x.ID == ids).FirstOrDefault();
            return Json(new { success = true,mydatacollection=data},JsonRequestBehavior.AllowGet);


        }

   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models;
using System.Data.SqlClient;

namespace Shopping.Controllers
{
    public class DataController : Controller
    {
        EcommerceEntities db = new EcommerceEntities();
        // GET: Data
        public ActionResult GetTenRecords()
        {
            try
            {
                var data = db.CollectionMasters.SqlQuery("select  TOP 5 * from CollectionMaster order by ID Desc ").ToList();
            }
            catch (Exception ex)
            {

            }

                return View();
        }
    }
}
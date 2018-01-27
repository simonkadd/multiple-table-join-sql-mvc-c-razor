using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnboardingjQuery.Models;

namespace OnboardingjQuery.Controllers
{
    public class ProductSoldJoinController : Controller
    {
        private OnboardingTaskEntities db = new OnboardingTaskEntities();

        // GET: ProductSoldJoin
        
        public ActionResult Index()
        { 
            List<ProductSoldJoin> model = new List<ProductSoldJoin>();
            
            var q = (from s in db.SalesTables
                     join p in db.ProductTables on
                     s.salesProductId equals p.productID
                     join c in db.CustomerTables on
                     s.salesCustomerId equals c.customerId
                     join t in db.StoreTables on
                     s.salesStoreId equals t.storeId
                     select new
                     {
                         newsalesID = s.salesID,
                         newproductName = p.productName,
                         newcustomerName = c.customerName,
                         newstoreName = t.storeName
                     }).ToList();


            foreach (var item in q) //retrieve each item and assign to model
            {
                model.Add(new ProductSoldJoin()
                {

                    PSJsalesID = item.newsalesID,
                    PSJproductName = item.newproductName,
                    PSJcustomerName = item.newcustomerName,
                    PSJstoreName = item.newstoreName
                    
                });
            }
            return View(model);


           // return View();
        }
    }




}
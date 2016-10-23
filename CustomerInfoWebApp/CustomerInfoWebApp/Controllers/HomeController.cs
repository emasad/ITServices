using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerInfoWebApp.Context;
using CustomerInfoWebApp.Models;

namespace CustomerInfoWebApp.Controllers
{
    public class HomeController : Controller
    {
        CustomerContext db = new CustomerContext();
        // GET: Home
        public ActionResult Index()
        {
            //Designation dropdownlist
            Designation aDesignation = new Designation();
            var designationList = db.Designations.ToList();
            aDesignation.DesignaionList = new SelectList(designationList, "Id", "DesigName");
            ViewBag.ListOfDesig = aDesignation.DesignaionList;

            //Region Dropdownlist
            Region aRegion = new Region();
            var regionList = db.Regions.ToList();
            aRegion.RegionList = new SelectList(regionList, "Id", "RegionName");
            ViewBag.ListOfRegion = aRegion.RegionList;

            //Category Dropdownlist
            Category aCategory = new Category();
            var categoryList = db.Categories.ToList();
            aCategory.CategoryList = new SelectList(categoryList, "Id", "CatName");
            ViewBag.ListOfCat = aCategory.CategoryList;

            return View();
        }

        //Jason Insertion
        public ActionResult SaveUser(string code, string name, string address, int postCode, string telephone,
            string email, string contactPersonName, int contactPersonPositionId, int regionId, int categoryId)
        {
            if (ModelState.IsValid)
            {
                Customer aCustomer = new Customer();
                aCustomer = db.Customers.FirstOrDefault(x => x.Code == code);
                if (aCustomer == null)
                    {
                        aCustomer.Code = code;
                       
                    }
               

                aCustomer.Name = name;
                aCustomer.Address = address;
                aCustomer.PostCode = postCode;
                aCustomer.Telephone = telephone;
                aCustomer.Email = email;
                aCustomer.ContactPersonName = contactPersonName;
                aCustomer.ContactPersonPositionId = contactPersonPositionId;
                aCustomer.CategoryId = categoryId;
                aCustomer.RegionId = regionId;
                db.Customers.AddOrUpdate(aCustomer);
                db.SaveChanges();
                //ViewBag.Message = "Successfully Added.";
                return RedirectToAction("Index", "Home");

            }

            return RedirectToAction("Index");

        }

        //Get by Id
        public JsonResult GetUserByCode(string code)
        {
            Customer aCustomer = new Customer();

            if (code != null)
            {
                aCustomer = db.Customers.FirstOrDefault(x => x.Code == code);

            }
            return Json(aCustomer, JsonRequestBehavior.AllowGet);
        }

        //Delete by code
        public JsonResult DeleteByCode(string code)
        {
            Customer aCustomer = new Customer();

            if (code != null)
            {
                aCustomer = db.Customers.FirstOrDefault(x => x.Code == code);
                db.Customers.Remove(aCustomer);
                db.SaveChanges();

            }
            return Json(aCustomer, JsonRequestBehavior.AllowGet);
        }

        //
    }
}
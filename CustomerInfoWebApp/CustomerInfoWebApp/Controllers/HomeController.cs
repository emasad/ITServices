﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerInfoWebApp.Context;
using CustomerInfoWebApp.Models;

namespace CustomerInfoWebApp.Controllers
{
    public class HomeController : Controller
    {
        CustomerContext db=new CustomerContext();
        // GET: Home
        public ActionResult Index()
        {
            //Designation dropdownlist
            Designation aDesignation=new Designation();
            var designationList = db.Designations.ToList();
            aDesignation.DesignaionList = new SelectList(designationList, "Id", "DesigName");
            ViewBag.ListOfDesig = aDesignation.DesignaionList;


            //Region Dropdownlist
            Region aRegion = new Region();
            var regionList = db.Regions.ToList();
            aRegion.RegionList = new SelectList(regionList, "Id", "RegionName");
            ViewBag.ListOfRegion = aRegion.RegionList;

            //Category Dropdownlist
            Category aCategory= new Category();
            var categoryList = db.Categories.ToList();
            aCategory.CategoryList = new SelectList(categoryList, "Id", "CatName");
            ViewBag.ListOfCat = aCategory.CategoryList;



            return View();
        }

        //Jason Insertion
        public ActionResult SaveUser(string code, string name, string address, int postCode, string telephone, string email, string contactPersonName, int contactPersonPositionId, int regionId, int categoryId)
        {
            if (ModelState.IsValid)
            {
                Customer aCustomer= new Customer();

                aCustomer.Code = code;
                aCustomer.Name = name;
                aCustomer.Address = address;
                aCustomer.PostCode = postCode;
                aCustomer.Telephone = telephone;
                aCustomer.Email = email;
                aCustomer.ContactPersonName = contactPersonName;
                aCustomer.ContactPersonPositionId = contactPersonPositionId;
                aCustomer.CategoryId = categoryId;
                aCustomer.RegionId = regionId;


                db.Customers.Add(aCustomer);
                db.SaveChanges();
                //ViewBag.Message = "Successfully Added.";
                return RedirectToAction("Index", "Home");

            }

            return RedirectToAction("Index");
 
        }

    }
}
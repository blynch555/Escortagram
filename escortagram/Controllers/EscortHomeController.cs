﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using escortagram.Models;
using escortagram.Common;

namespace escortagram.Controllers
{
    public class EscortHomeController : Controller
    {
        EscortagramEntities db = new EscortagramEntities();
        // GET: EscortHome
        public ActionResult Index()
        {
            var HomeData= (from a in db.Employments join b in db.ModelImages on a.EmployeID equals b.ModelID where a.UserTypeID != 1 && b.BannerImageGuid==true
                           
                           select new 
                           {
                               a,b.OtherImages
                              
                           }).Take(9).ToList();
            var Testimonial = db.Testimonials.Where(x => x.Active == true).ToList();
            
            Escortsview Obj = new Escortsview();
            List<Escortsview> NewList = new List<Escortsview>();
            foreach (var item in HomeData)
            {
                Escortsview Dummy = new Escortsview();
                Dummy.FirstName = item.a.FirstName;
                Dummy.UserID = item.a.EmployeID;
                Dummy.BannerImageGuid = "/Upload/ModelImages/"+ item.a.UserID +"/" + item.OtherImages + ".jpg";
                
                NewList.Add(Dummy);
            }
            List<Escortsview> NewTesti = new List<Escortsview>();
            foreach (var item in Testimonial)
            {
                Escortsview Dummy = new Escortsview();
                Dummy.TestimonialDesc = item.TestimonialDesc;
                Dummy.TestimonialImage = "/Upload/TestimonialImages/" + item.TestimonialImage + ".jpg";
                NewTesti.Add(Dummy);
            }
            
            Obj.Testi = NewTesti;
            Obj.List = NewList;
            return View(Obj);
        }
        
        public ActionResult ViewModel(int? id)
        {
           // var Model = db.UserMasters.Where(x => x.UserID == ModelID).FirstOrDefault();
            return View();
        }
    }
}
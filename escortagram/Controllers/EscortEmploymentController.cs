using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using escortagram.Models;
using escortagram.Common;
namespace escortagram.Controllers
{

    public class EscortEmploymentController : Controller
    {
        EscortagramEntities db = new EscortagramEntities();
        // GET: EmpRegestration
        public ActionResult Index()
        {
            var countries = (from country in db.CountryTbs
                             select new
                             {
                                 name = country.CountryName,
                                 Id = country.CountryID

                             }).ToList();
            ViewBag.CountryDrp = new SelectList(countries, "Id", "name");

            return View();
        }
        public ActionResult Save(HttpPostedFileBase file, Employment obj)
        {
            Employment NewObj = new Employment();
            NewObj.FirstName = obj.FirstName;
            NewObj.LastName = obj.LastName;
            NewObj.CreatedDate = obj.CreatedDate;
            NewObj.Active = obj.Active;
            NewObj.Age = obj.Age;
            NewObj.MobileNo = obj.MobileNo;
            NewObj.Nationality = obj.Nationality;
            NewObj.Languages = obj.Languages;
            NewObj.Measurements = obj.Measurements;
            NewObj.DressSize = obj.DressSize;
            NewObj.Height = obj.Height;
            NewObj.HairColor = obj.HairColor;
            NewObj.EyeColor = obj.EyeColor;
            NewObj.Availability = obj.Availability;
            NewObj.Location = obj.Location;
            NewObj.Orientation = obj.Orientation;
            NewObj.FavouritePerfume = obj.FavouritePerfume;
            NewObj.FavouriteCuisine = obj.FavouriteCuisine;
            NewObj.UKtravel = obj.UKtravel;
            
            NewObj.Description = obj.Description;
            NewObj.services = obj.services;
            NewObj.MeetingTypes = obj.MeetingTypes;
            NewObj.MeetingAddress = obj.MeetingAddress;
            NewObj.Comments = obj.Comments;
            ModelRate rate = new ModelRate();
            rate.RateID = obj.RateID;
            rate.ModelID = obj.ModelID;
            rate.Rate30min = obj.Rate30min;
            rate.Rate1Hour = obj.Rate1Hour;
            rate.Rate2Hours = obj.Rate2Hours;
            rate.AdditionalHours = obj.AdditionalHours;
            rate.DinnerRate = obj.DinnerRate;
            rate.OverNight = obj.OverNight;
            rate.Incallperhour = obj.Incallperhour;
            rate.Outcallperhour = obj.Outcallperhour;
            rate.Incall90Minutes = obj.Incall90Minutes;
            rate.Outcall90minutes = obj.Outcall90minutes;
            string guid = Guid.NewGuid().ToString();
            string Type = "ProfilePicNew";
            CommonFunction cmn = new CommonFunction();
            cmn.SaveFile(file, guid, Type);
            NewObj.LogoGuid = guid;
            db.Employments.Add(NewObj);
            db.SaveChanges();
            db.ModelRates.Add(rate);
            db.SaveChanges();
            return View();
        }
    }
}
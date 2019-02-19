﻿using DoctorPortal.Web.AdminServices.Speciality;
using DoctorPortal.Web.Areas.Admin.Models;
using DoctorPortal.Web.Common;
using System;
using System.Web.Mvc;

namespace DoctorPortal.Web.Controllers
{
    public class DoctorController : BaseAdminController
    {
        private readonly ISpecialityService _SpecialityService;

        public DoctorController(ISpecialityService specialityService) 
        {
            _SpecialityService = specialityService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                if (ProjectSession.Hospital == null)
                    throw new Exception("Something went wrong");

                //var hospital = ProjectSession.Hospital;

                var facilitylist = _SpecialityService.GetAllSpeciality();
                return View(facilitylist);
            }
            catch (Exception e)
            {
                Logger.log.Error($"Controller: {nameof(DoctorController)} , Action: {nameof(Index)}. Error: {e.Message}");
                return View("Error");
            }
        }
    }
}
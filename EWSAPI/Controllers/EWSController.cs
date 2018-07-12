using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EWSAPI.Models;

namespace EWSAPI.Controllers
{
    public class EWSController : Controller
    {
        // GET: EWS
        public ActionResult Index([FromForm] EWSModel ewsmodel)
        {
            int RR = ewsmodel.RR;
            int RR_score = 0;
            if (RR < 9 || RR > 35)
            { RR_score = 3; }
            else if (RR >= 31 && RR <= 35)
            { RR_score = 2; }
            else if (RR >= 21 && RR <= 30)
            { RR_score = 1; }
            else { RR_score = 0; }

            int OxySat = ewsmodel.OxySat;
            int OxySat_score = 1;
            if (OxySat < 85) { OxySat_score = 3; }
            else if (OxySat >= 85 && OxySat < 90) { OxySat_score = 2; }
            else if (OxySat >= 90 && OxySat < 93) { OxySat_score = 1; }
            else { OxySat_score = 0; }

            var SuppOxy = ewsmodel.SuppOxy;
            int SuppOxy_score = 0;

            float Temp = ewsmodel.Temp;
            int Temp_score = 0;
            if (Temp > 38.9) { Temp_score = 2; }
            else if (Temp >= 38 && Temp <= 38.9) { Temp_score = 1; }
            else if (Temp >= 36 && Temp <= 37.9) { Temp_score = 0; }
            else if (Temp >= 35 && Temp <= 35.9) { Temp_score = 1; }
            else if (Temp >= 34 && Temp <= 34.9) { Temp_score = 2; }
            else { Temp_score = 3; }

            int SysBP = ewsmodel.SysBP;
            int SysBP_score = 1;
            if (SysBP > 199) { SysBP_score = 2; }
            else if (SysBP >= 100 && SysBP <= 199) { SysBP_score = 0; }
            else if (SysBP >= 80 && SysBP <= 99) { SysBP_score = 1; }
            else if (SysBP >= 70 && SysBP <= 79) { SysBP_score = 2; }
            else { SysBP_score = 3; }

            int HR = ewsmodel.HR;
            int HR_score = 1;
            if (HR > 129) { HR_score = 3; }
            else if (HR >= 110 && HR <= 129) { HR_score = 2; }
            else if (HR >= 100 && HR <= 109) { HR_score = 1; }
            else if (HR >= 50 && HR <= 99) { HR_score = 0; }
            else if (HR >= 40 && HR <= 49) { HR_score = 1; }
            else if (HR >= 30 && HR <= 39) { HR_score = 2; }
            else { HR_score = 3; }

            var AVPU = ewsmodel.AVPU;
            int AVPU_score = 0;
            if (AVPU == "A") { AVPU_score = 0; }
            else if (AVPU == "V") { AVPU_score = 1; }
            else if (AVPU == "P") { AVPU_score = 2; }
            else if (AVPU == "U") { AVPU_score = 3; }

            int EWS = RR_score + OxySat_score + SuppOxy_score + Temp_score + SysBP_score + HR_score + AVPU_score;

            var EWS_risk = "Normal Risk";
            if (EWS >= 5) { EWS_risk = "High Risk"; }


            ViewBag.Date = DateTime.Now;
            ViewBag.RR = RR;
            ViewBag.RR_score = RR_score;
            ViewBag.OxySat = OxySat;
            ViewBag.Oxysat_score = OxySat_score;
            ViewBag.SuppOxy = SuppOxy;
            ViewBag.Temp = Temp;
            ViewBag.Temp_score = Temp_score;
            ViewBag.SysBP = SysBP;
            ViewBag.SysBP_score = SysBP_score;
            ViewBag.HR = HR;
            ViewBag.HR_score = HR_score;
            ViewBag.AVPU = AVPU;
            ViewBag.AVPU_score = AVPU_score;
            ViewBag.ews = EWS;
            ViewBag.ews_risk = EWS_risk;

            return View();
        }

        // GET: EWS/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EWS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EWS/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EWS/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EWS/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EWS/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EWS/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
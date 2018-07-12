using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EWSAPI.Models;

namespace EWSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EWSAPIController : ControllerBase
    {
        // GET: api/EWSAPI
        [HttpGet]
        public string Get()
        {

            return"value 1";
        }

        // GET: api/EWSAPI/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {

            return "value";
        }

        // POST: api/EWSAPI
        [HttpPost]
        public EWSAPIResultModel Post([FromBody] EWSModel ewsmodel)
        {
            EWSAPIResultModel EWSAPIresult = new EWSAPIResultModel();

            int RR = ewsmodel.RR;
          
            if (RR < 9 || RR > 35)
            { EWSAPIresult.RR_score = 3; }
            else if (RR >= 31 && RR <= 35)
            { EWSAPIresult.RR_score = 2; }
            else if (RR >= 21 && RR <= 30)
            { EWSAPIresult.RR_score = 1; }
            else { EWSAPIresult.RR_score = 0; }

            int OxySat = ewsmodel.OxySat;
       
            if (OxySat < 85) { EWSAPIresult.OxySat_score = 3; }
            else if (OxySat >= 85 && OxySat < 90) { EWSAPIresult.OxySat_score = 2; }
            else if (OxySat >= 90 && OxySat < 93) { EWSAPIresult.OxySat_score = 1; }
            else { EWSAPIresult.OxySat_score = 0; }

            var SuppOxy = ewsmodel.SuppOxy;
            EWSAPIresult.SuppOxy_score = 0;

            float Temp = ewsmodel.Temp;
           
            if (Temp > 38.9) { EWSAPIresult.Temp_score = 2; }
            else if (Temp >= 38 && Temp <= 38.9) { EWSAPIresult.Temp_score = 1; }
            else if (Temp >= 36 && Temp <= 37.9) { EWSAPIresult.Temp_score = 0; }
            else if (Temp >= 35 && Temp <= 35.9) { EWSAPIresult.Temp_score = 1; }
            else if (Temp >= 34 && Temp <= 34.9) { EWSAPIresult.Temp_score = 2; }
            else { EWSAPIresult.Temp_score = 3; }

            int SysBP = ewsmodel.SysBP;
            
            if (SysBP > 199) { EWSAPIresult.SysBP_score = 2; }
            else if (SysBP >= 100 && SysBP <= 199) { EWSAPIresult.SysBP_score = 0; }
            else if (SysBP >= 80 && SysBP <= 99) { EWSAPIresult.SysBP_score = 1; }
            else if (SysBP >= 70 && SysBP <= 79) { EWSAPIresult.SysBP_score = 2; }
            else { EWSAPIresult.SysBP_score = 3; }

            int HR = ewsmodel.HR;
           
            if (HR > 129) { EWSAPIresult.HR_score = 3; }
            else if (HR >= 110 && HR <= 129) { EWSAPIresult.HR_score = 2; }
            else if (HR >= 100 && HR <= 109) { EWSAPIresult.HR_score = 1; }
            else if (HR >= 50 && HR <= 99) { EWSAPIresult.HR_score = 0; }
            else if (HR >= 40 && HR <= 49) { EWSAPIresult.HR_score = 1; }
            else if (HR >= 30 && HR <= 39) { EWSAPIresult.HR_score = 2; }
            else { EWSAPIresult.HR_score = 3; }

            var AVPU = ewsmodel.AVPU;
            
            if (AVPU == "A") { EWSAPIresult.AVPU_score = 0; }
            else if (AVPU == "V") { EWSAPIresult.AVPU_score = 1; }
            else if (AVPU == "P") { EWSAPIresult.AVPU_score = 2; }
            else if (AVPU == "U") { EWSAPIresult.AVPU_score = 3; }

            EWSAPIresult.EWS = EWSAPIresult.RR_score + EWSAPIresult.OxySat_score + EWSAPIresult.SuppOxy_score + EWSAPIresult.Temp_score + EWSAPIresult.SysBP_score + EWSAPIresult.HR_score + EWSAPIresult.AVPU_score;

            EWSAPIresult.EWS_risk = "Normal Risk";
            if (EWSAPIresult.EWS >= 5) { EWSAPIresult.EWS_risk = "High Risk"; }

            return EWSAPIresult;

        }

        // PUT: api/EWSAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

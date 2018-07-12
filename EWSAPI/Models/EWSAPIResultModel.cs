using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWSAPI.Models
{
    public class EWSAPIResultModel
    {
        public int RR_score { get; set; }
        public int OxySat_score { get; set; }
        public int SuppOxy_score { get; set; }
        public int Temp_score { get; set; }
        public int SysBP_score { get; set; }
        public int HR_score { get; set; }
        public int AVPU_score { get; set; }
        public int EWS { get; set; }
        public string EWS_risk { get; set; }
    }
}

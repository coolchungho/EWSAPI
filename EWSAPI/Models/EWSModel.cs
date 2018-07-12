using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EWSAPI.Models
{
    public class EWSModel
    {
        public Guid EWS_id { get; set; }
        public string ChartNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime RecordDateTime { get; set; }
        public int RR { get; set; }
        public int OxySat { get; set; }
        public bool SuppOxy { get; set; }
        public float Temp { get; set; }
        public int SysBP { get; set; }
        public int HR { get; set; }
        public string AVPU { get; set; }
        public int RR_score { get; set; }
        public int OxySat_score { get; set; }
        public int SuppOxy_score { get; set; }
        public int Temp_score { get; set; }
        public int SysBP_score { get; set; }
        public int HR_score { get; set; }
        public int AVPU_score { get; set; }
        public int EWS { get; set; }

    }
}

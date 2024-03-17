using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Tables.Helper
{
    public class TreatmentWithPatient : Treatment
    {
        public TreatmentWithPatient() { }
        public TreatmentWithPatient(TreatmentWithPatient treatment) : base(treatment)
        {
        }

        public string PatientName { get; set; }
    }
}

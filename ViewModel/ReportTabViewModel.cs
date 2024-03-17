using CMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.ViewModel
{
    public partial class ReportTabViewModel : BaseViewModel
    {
        public ReportTabViewModel(IDataBaseService dataBaseService) : base(dataBaseService)
        {
        }
    }
}

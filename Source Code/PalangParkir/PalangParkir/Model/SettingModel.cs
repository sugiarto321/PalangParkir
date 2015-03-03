using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalangParkir.Model
{
     class SettingModel
    {
       public String ipCamera1 { get; set; }
       public String ipCamera2 { get; set; }

       public String comPortPrinter { get; set; }
       public int baudRatePrinter { get; set; }

       public String comPortController { get; set; }
       public int baudRateController { get; set; }

        
       public String setJenisKendaraan { get; set; }
       public String setPlatNomor { get; set;}
    }
}

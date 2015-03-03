using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalangParkir.Model;
using PalangParkir.Dao;
using System.IO.Ports;
using PalangParkir.View;
using ThermalDotNet;
using PalangParkir.Dao;
using PalangParkir.Model;
//using PalangParkir.Model;

namespace PalangParkir.View
{
    public partial class PintuMasukView : Form
    {
        private SettingView settingView;
        private KendaraanDao kendaraanDao= null;
        private Connection conn = null;

        public PintuMasukView()
        {
            InitializeComponent();
        }

        public PintuMasukView(SettingView settingView)
        {
            // TODO: Complete member initialization
            this.settingView = settingView;
            InitializeComponent();
            conn = Connection.GetInstance();
            kendaraanDao = new KendaraanDao(conn.getConnection());
        }

        


        private void btnBarcode_Click(object sender, EventArgs e)
        {
            String portSerial = settingView.cmbPortController.SelectedItem.ToString();
            int baudRate = Convert.ToInt32(settingView.cmbBaudRatePrinter.SelectedItem.ToString());


            SerialPort portprinter = settingView.connectPortPrinter(portSerial, baudRate);
            
            ThermalPrinter printer = settingView.connectPrinter(portprinter);

            ThermalPrinter.BarcodeType myType = ThermalPrinter.BarcodeType.ean13;
            
            printer.Reset();
            
            DateTime timePrint = DateTime.Now;
            
            int year = timePrint.Year;
            int month = timePrint.Month;
            int day = timePrint.Day;
            int hours = timePrint.Hour;
            int minutes = timePrint.Minute;
            int second = timePrint.Second;

            String myData = ("" + year + "" + month + "" + day + "" + hours + "" + minutes + "" + second + "");
            printer.SetAlignCenter();
            printer.WriteLine("Palang Parkir", (byte)ThermalPrinter.PrintingStyle.DoubleHeight
            + (byte)ThermalPrinter.PrintingStyle.DoubleWidth);
            System.Threading.Thread.Sleep(50);
            printer.LineFeed();
            System.Threading.Thread.Sleep(50);
            printer.SetAlignLeft();
            printer.SetAlignCenter();
            printer.WriteLine(timePrint.ToString());
            System.Threading.Thread.Sleep(50);
            printer.WriteLine("ID : " + myData);
            System.Threading.Thread.Sleep(50);
            printer.SetLargeBarcode(true);
            System.Threading.Thread.Sleep(150);
            printer.LineFeed();
            System.Threading.Thread.Sleep(500);
            
            printer.PrintBarcode(myType, myData);
            printer.LineFeed();
            System.Threading.Thread.Sleep(50);
            printer.WriteLine("Jl Cimanggis Elok No 1");
            printer.LineFeed();
            System.Threading.Thread.Sleep(150);
            printer.LineFeed();
            System.Threading.Thread.Sleep(150);
            printer.CutPaper();

            Kendaraan kendaraan = new Kendaraan();
            kendaraan.barcode = myData;
            kendaraan.waktuMasuk = DateTime.Now;

            int result = kendaraanDao.Save(kendaraan);
            if (result > 0)
            {
                MessageBox.Show("Data berhasil di Input", "Data berhasil di Input");
            }

            settingView.closeConnectionPortPrinter(portprinter);
        }
    }
}

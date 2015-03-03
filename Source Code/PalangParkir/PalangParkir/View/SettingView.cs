using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using PalangParkir.Model;
using ThermalDotNet;

namespace PalangParkir.View
{
    public partial class SettingView : Form
    {
        private SettingModel settingModel = new SettingModel();
        public SettingView()
        {
            InitializeComponent();
            getPortController();
            getPortPrinter();
            

        }
        private void getPortController() {

            String[] arrayComPortController = null;
            int index = -1;
            String comPortControllerName = null;

            //Com Port Controller
            arrayComPortController = SerialPort.GetPortNames();

            do
            {
                index += 1;
                cmbPortController.Items.Add(arrayComPortController[index]);
            }
            while (!((arrayComPortController[index] == comPortControllerName) || (index == arrayComPortController.GetUpperBound(0))));
            Array.Sort(arrayComPortController);

            if (index == arrayComPortController.GetUpperBound(0)) {
                comPortControllerName = arrayComPortController[0];
            }
            //get First  item print in text ComPort Controller
            cmbPortController.Text = arrayComPortController[0];


            //BaudRate Controller
            cmbBaudRateController.Items.Add(300);
            cmbBaudRateController.Items.Add(600);
            cmbBaudRateController.Items.Add(1200);
            cmbBaudRateController.Items.Add(2400);
            cmbBaudRateController.Items.Add(9600);
            cmbBaudRateController.Items.Add(14400);
            cmbBaudRateController.Items.Add(19200);
            cmbBaudRateController.Items.Add(38400);
            cmbBaudRateController.Items.Add(57600);
            cmbBaudRateController.Items.Add(115200);
            cmbBaudRateController.Items.ToString();


            //get first item print in text
            cmbBaudRateController.Text = cmbBaudRateController.Items[0].ToString(); 
        }
        private void getPortPrinter()
        {

            String[] arrayComPortPrinter = null;
            int index = -1;
            String comPortPrinterName = null;

            //Com Port Printer
            arrayComPortPrinter = SerialPort.GetPortNames();

            do
            {
                index += 1;
                cmbPortPrinter.Items.Add(arrayComPortPrinter[index]);
            }
            while (!((arrayComPortPrinter[index] == comPortPrinterName) || (index == arrayComPortPrinter.GetUpperBound(0))));
            Array.Sort(arrayComPortPrinter);

            if (index == arrayComPortPrinter.GetUpperBound(0))
            {
                comPortPrinterName = arrayComPortPrinter[0];
            }
            //get First  item print in text ComPort Controller
            cmbPortPrinter.Text = arrayComPortPrinter[0];


            //BaudRate Controller
            cmbBaudRatePrinter.Items.Add(300);
            cmbBaudRatePrinter.Items.Add(600);
            cmbBaudRatePrinter.Items.Add(1200);
            cmbBaudRatePrinter.Items.Add(2400);
            cmbBaudRatePrinter.Items.Add(9600);
            cmbBaudRatePrinter.Items.Add(14400);
            cmbBaudRatePrinter.Items.Add(19200);
            cmbBaudRatePrinter.Items.Add(38400);
            cmbBaudRatePrinter.Items.Add(57600);
            cmbBaudRatePrinter.Items.Add(115200);
            cmbBaudRatePrinter.Items.ToString();


            //get first item print in text
            cmbBaudRatePrinter.Text = cmbBaudRatePrinter.Items[0].ToString();
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
           
              settingModel.comPortPrinter = cmbPortPrinter.SelectedItem.ToString();
              settingModel.baudRatePrinter = Convert.ToInt32(cmbBaudRatePrinter.SelectedItem.ToString());
              MessageBox.Show("Seting Port Berhasil", "Seting Port Berhasil");
        }

        
        // Membuka Koneksi Pada Port Printer
        public SerialPort connectPortPrinter(String portSerial, int baudRate)
        {

            SerialPort portPrinter = new SerialPort(portSerial, baudRate);
            portPrinter.Open();
            if (true)
            {
                return portPrinter;
            }
            else {
                //MessageBox.Show("Koneksi Telah digunakan", "Koneksi Telah digunakan");
            }
        }

        //Menutup Koneksi Port Printer
        public void closeConnectionPortPrinter(SerialPort portPrinter) {
             portPrinter.Close(); 
        }


        //Mengeset agar thermal langsung bisa digunakan
        public ThermalPrinter connectPrinter(SerialPort portPrinter){
            ThermalPrinter printer = new ThermalPrinter(portPrinter, 70, 100, 1);
            return printer;
    }
        private void btnSetPrinter_Click(object sender, EventArgs e)
        {
            String portSerial = settingModel.comPortPrinter;
            int baudRate = settingModel.baudRatePrinter;
            
            
          SerialPort portprinter = connectPortPrinter(portSerial,baudRate);
          
          ThermalPrinter printer = connectPrinter(portprinter);
          System.Threading.Thread.Sleep(50);
          printer.Reset();
          printer.LineFeed();
          printer.WriteLine("I'm ready");
          printer.LineFeed();
          printer.LineFeed();
          System.Threading.Thread.Sleep(50);
          printer.LineFeed();
          System.Threading.Thread.Sleep(50);
          
          printer.CutPaper();


          closeConnectionPortPrinter(portprinter);
          

        }
        

        private void btnSetController_Click(object sender, EventArgs e)
        {
            //SettingModel settingModel = new SettingModel();
            settingModel.comPortController = cmbPortController.SelectedItem.ToString();
            settingModel.baudRateController = Convert.ToInt32( cmbBaudRateController.SelectedItem.ToString());
            MessageBox.Show("Seting Port Berhasil", "Seting Port Berhasil");
        }

        private void btnSetGate_Click(object sender, EventArgs e)
        {
            String portSerial = settingModel.comPortController;
            int baudRate = settingModel.baudRateController;

            SerialPort portprinter = connectPortPrinter(portSerial, baudRate);
            portprinter.Write("tes");


        }

        private void bntGateIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            PintuMasukView viewPintuMasuk = new PintuMasukView(this);
            viewPintuMasuk.Show();
            
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
//using System.Runtime.InteropServices;
using System.IO;
using ThermalDotNet;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Parity parity = new Parity();
            //parity = 'o';

            PrintDocument print = new PrintDocument();

            SerialPort port = new SerialPort("COM19", 115200);
            port.Open();
            while (true)
            {
                
                ThermalPrinter printer = new ThermalPrinter(port,80,110,1);
                printer.WakeUp();

                testBarcode(printer);
                //testPrinter(printer);
                //printer.CutPaper();
                String s = Console.ReadLine();
                if (s.Equals("exit"))
                {
                    break;
                }
            }
            port.Close();
        }

        static void testBarcode(ThermalPrinter printer) {
            ThermalPrinter.BarcodeType myType = ThermalPrinter.BarcodeType.ean13;
            printer.Reset();
            DateTime timePrint = DateTime.Now;
            int year = timePrint.Year;
            int month = timePrint.Month;
            int day = timePrint.Day;
            int hours = timePrint.Hour;
            int minutes = timePrint.Minute;
            int second = timePrint.Second;

            String myData = (""+year +""+month+""+day+""+hours+""+minutes+""+second+"");
            //String myData = String.Format("33500301033{0:D2}", incNumber++);

            printer.WriteLine(myType.ToString() + ", data: " + myData);
            System.Threading.Thread.Sleep(50);
            printer.SetLargeBarcode(true);
            printer.LineFeed();
            System.Threading.Thread.Sleep(50);
            printer.PrintBarcode(myType, myData);
            printer.SetLargeBarcode(false);
            System.Threading.Thread.Sleep(50);
            printer.LineFeed();
            printer.PrintBarcode(myType, myData);
            printer.LineFeed();
            printer.LineFeed();
            System.Threading.Thread.Sleep(50);
            printer.LineFeed();
            System.Threading.Thread.Sleep(50);
            printer.CutPaper();
        }
        static void testPrinter(ThermalPrinter printer) {
            
            printer.LineFeed();
            printer.LineFeed();
            printer.LineFeed();
            printer.WriteLine("Palang Parkir",ThermalPrinter.PrintingStyle.Bold);
            printer.WriteLine("PrintingStyle.DoubleHeight", ThermalPrinter.PrintingStyle.DoubleHeight);
            printer.LineFeed();
            printer.WriteLine("PrintingStyle.DoubleWidth", ThermalPrinter.PrintingStyle.DoubleWidth);
            printer.LineFeed();
            printer.WriteLine("PrintingStyle.Reverse", ThermalPrinter.PrintingStyle.Reverse);
            printer.LineFeed();
            printer.SetAlignLeft();
            printer.LineFeed();
            printer.SetAlignCenter();
            printer.WriteLine("PrintingStyle.Reverse", ThermalPrinter.PrintingStyle.Reverse);
            printer.WriteLine("PrintingStyle.Reverse", ThermalPrinter.PrintingStyle.Reverse);
            printer.LineFeed();
            printer.LineFeed();
            printer.LineFeed();
            
        }

    }
    
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalangParkir.Model
{
    class Kendaraan
    {
        public int id { get; set; }
        public String barcode { get; set; }
        public String jenisKendaraan { get; set; }
        public DateTime waktuMasuk { get; set; }
        public DateTime waktuKeluar { get; set; }
        public int durasi { get; set; }
        public int pembayaran { get; set; } //Total Pembayaran seharusnya
        public int uangDiterima { get; set; } //Uang yang diterima Oleh Admin untuk pembayaran
        public int kembalian { get; set; } //Uang yang diterima oleh customer

    }
}

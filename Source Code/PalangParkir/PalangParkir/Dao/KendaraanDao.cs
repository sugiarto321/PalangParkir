using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PalangParkir.Model;

namespace PalangParkir.Dao
{
    class KendaraanDao
    {
        private MySqlConnection conn;
        private String strSql = string.Empty;

        public KendaraanDao(MySqlConnection conn) {
            this.conn = conn;
        }

        public int Save(Kendaraan kendaraan) {
            strSql = "INSERT INTO kendaraan (barcode, waktu_masuk) VALUES (@1, @2)";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", kendaraan.barcode);
                cmd.Parameters.AddWithValue("@2", kendaraan.waktuMasuk);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}

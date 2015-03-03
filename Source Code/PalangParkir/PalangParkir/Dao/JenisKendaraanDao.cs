using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PalangParkir.Model;

namespace PalangParkir.Dao
{
    class JenisKendaraanDao
    {

        private MySqlConnection conn;
        private String strSql = string.Empty;

        // Constructor
        public JenisKendaraanDao(MySqlConnection conn) {
            this.conn = conn;
        }

        public int Save(JenisKendaraan jenisKendaraan)
        {
            strSql = "INSERT INTO jenis_kendaraan (jenis_kendaraan, perjam,maksimal) VALUES (@1, @2, @3)";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", jenisKendaraan.jenisKendaraan);
                cmd.Parameters.AddWithValue("@2", jenisKendaraan.hargaperjam);
                cmd.Parameters.AddWithValue("@3", jenisKendaraan.hargamaksimal);
                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(JenisKendaraan jenisKendaraan)
        {
            strSql = "UPDATE jenis_kendaraan SET jenis_kendaraan = @1, perjam= @2 ,maksimal=@3 WHERE id = @4";
            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", jenisKendaraan.jenisKendaraan);
                cmd.Parameters.AddWithValue("@2", jenisKendaraan.hargaperjam);
                cmd.Parameters.AddWithValue("@3", jenisKendaraan.hargamaksimal);
                cmd.Parameters.AddWithValue("@4", jenisKendaraan.id);
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string jenisKendaraan)
        {
            strSql = "DELETE FROM jenis_kendaraan WHERE id = @1";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", jenisKendaraan);

                return cmd.ExecuteNonQuery();
            }
        }
        private JenisKendaraan MappingRowToObject(MySqlDataReader dtr)
        {
            JenisKendaraan jenisKendaraan = new JenisKendaraan();
            jenisKendaraan.id = dtr["id"] is Nullable? 0 : (int)dtr["id"];
            jenisKendaraan.jenisKendaraan = dtr["jenis_kendaraan"] is DBNull ? string.Empty : dtr["jenis_kendaraan"].ToString();
            jenisKendaraan.hargaperjam = dtr["perjam"] is Nullable ? 0 : (int)dtr["perjam"];
            jenisKendaraan.hargamaksimal = dtr["maksimal"] is Nullable ? 0 : (int)dtr["maksimal"];
            return jenisKendaraan;
        }

        public List<JenisKendaraan> GetAll()
        {
            List<JenisKendaraan> userInfo = new List<JenisKendaraan>();

            strSql = "SELECT id,jenis_kendaraan, perjam, maksimal FROM jenis_kendaraan " +
                     "ORDER BY id desc";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {

                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        userInfo.Add(MappingRowToObject(dtr));
                    }
                }
            }

            return userInfo;
        }

    }
}

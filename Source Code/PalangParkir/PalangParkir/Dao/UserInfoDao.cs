using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PalangParkir.Model;
using System.Data;

namespace PalangParkir.Dao
{
    class UserInfoDao
    {
        private MySqlConnection conn;
        private String strSql = string.Empty;

        //Consrtuctor
        public UserInfoDao(MySqlConnection conn) {
            this.conn = conn;
        }

        public int Save(UserInfoModel userInfo)
        {
            strSql = "INSERT INTO user_info (nama, level,pass,nik) VALUES (@1, @2, @3,@4)";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", userInfo.nama);
                cmd.Parameters.AddWithValue("@2", userInfo.level);
                cmd.Parameters.AddWithValue("@3", userInfo.pass);
                cmd.Parameters.AddWithValue("@4", userInfo.NIK);
                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(UserInfoModel userInfo)
        {
            strSql = "UPDATE user_info SET nama = @1, level = @2 ,pass=@3 ,nik=@4 WHERE id = @5";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", userInfo.nama);
                cmd.Parameters.AddWithValue("@2", userInfo.level);
                cmd.Parameters.AddWithValue("@3", userInfo.pass);
                cmd.Parameters.AddWithValue("@4", userInfo.NIK);
                cmd.Parameters.AddWithValue("@5", userInfo.id);


                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(string userInfo)
        {
            strSql = "DELETE FROM user_info WHERE id = @1";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", userInfo);

                return cmd.ExecuteNonQuery();
            }
        }
        private UserInfoModel MappingRowToObject(MySqlDataReader dtr)
        {
            UserInfoModel userinfo = new UserInfoModel();
            userinfo.id = dtr["id"] is Nullable ? 0 : (int)dtr["id"];
            userinfo.nama= dtr["nama"] is DBNull ? string.Empty : dtr["nama"].ToString();
            userinfo.level= dtr["level"] is DBNull ? string.Empty : dtr["level"].ToString();
            userinfo.NIK= dtr["nik"] is DBNull ? string.Empty : dtr["nik"].ToString();

            return userinfo;
        }

        public List<UserInfoModel> GetAll()
        {
            List<UserInfoModel> userInfo = new List<UserInfoModel>();

            strSql = "SELECT id,nama, level, nik,pass FROM user_info " +
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

        public List<UserInfoModel> GetByName(string nama)
        {
            List<UserInfoModel> userinfo = new List<UserInfoModel>();

            strSql = "SELECT nik, nama, level,pass FROM user_info " +
                     "WHERE nama LIKE @1 " +
                     "ORDER BY nama";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", "%" + nama + "%");

                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    while (dtr.Read())
                    {
                        userinfo.Add(MappingRowToObject(dtr));
                    }
                }
            }
            return userinfo;
        }

        public bool Login(string nama, String password)
        {
            List<UserInfoModel> userinfo = new List<UserInfoModel>();

            strSql = "SELECT nik, nama, level,pass FROM user_info " +
                     "WHERE nama = @1 and pass = @2 " +
                     "ORDER BY nama";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", nama );
                cmd.Parameters.AddWithValue("@2",  password );

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd); 
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }                 
            }
        }
    }
}

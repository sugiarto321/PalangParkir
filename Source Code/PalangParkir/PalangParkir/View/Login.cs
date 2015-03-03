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
using PalangParkir.View;

namespace PalangParkir
{
    public partial class Login : Form
    {
        private Connection conn = null;
        private UserInfoDao userInfoDao = null;
        public Login()
        {
            InitializeComponent();
            conn = Connection.GetInstance();

            userInfoDao = new UserInfoDao(conn.getConnection());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserInfoModel userInfo = new UserInfoModel();
            userInfo.nama = txtUser.Text;
            userInfo.pass = txtPasswd.Text;

            bool Login = userInfoDao.Login(userInfo.nama, userInfo.pass);
            if (Login == true)
            {
                this.Hide();
                //MessageBox.Show("Login Berhasil", "Login Berhasil");
                JenisKendaraanForm jenisKendaraaForm = new JenisKendaraanForm(conn);
                jenisKendaraaForm.Show();
                //Pegawai pegawaiForm = new Pegawai(conn);
                //pegawaiForm.Show();


            }else
            {
                MessageBox.Show("Login Gagal", "Login gagal");
            }


        }

        

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalangParkir.Model;
using PalangParkir.Dao;
using PalangParkir.View;
using MySql.Data.MySqlClient;

namespace PalangParkir.View
{
    public partial class Pegawai : Form
    {
        private UserInfoDao userinfoDao = null;
        private int result = 0;

        public Pegawai(Connection conn)
        {
            InitializeComponent();
            userinfoDao = new UserInfoDao(conn.getConnection());

            loadDataPegawai();
        }

        
        private void loadDataPegawai() {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet dataset = new DataSet();
            List<UserInfoModel> dataPegawai = userinfoDao.GetAll();
            dgvPegawai.DataSource = dataPegawai.ToArray();
            dgvPegawai.ReadOnly = true;
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserInfoModel userInfo = new UserInfoModel();
            userInfo.NIK = txtNIK.Text;
            userInfo.nama = txtNama.Text;
            userInfo.level = cmbLevel.SelectedItem.ToString();
            userInfo.pass = txtPassword.Text;

            int result = userinfoDao.Save(userInfo);
            if (result > 0)
            {
                MessageBox.Show("Data Berhasil ", "Data Berhasil");
            }
            else {
                MessageBox.Show("Data Gagal", "Data gagal");
            }
            loadDataPegawai();
            resetPegawai();
        }

        private void resetPegawai() {
            txtNama.Text = "";
            txtNIK.Text = "";
            txtPassword.Text = "";
            cmbLevel.SelectedIndex = 0;
        }
    }
}

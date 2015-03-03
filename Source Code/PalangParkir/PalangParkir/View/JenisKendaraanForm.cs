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

namespace PalangParkir.View
{
    public partial class JenisKendaraanForm : Form
    {
        private JenisKendaraanDao jenisKendaraandao = null;

        public JenisKendaraanForm(Connection conn)
        {
            InitializeComponent();
            jenisKendaraandao = new JenisKendaraanDao(conn.getConnection());


            
        }

        //public JenisKendaraanForm()
        //{
        //    // TODO: Complete member initialization
        //}

        
         
        private void loadJenisKendaraan() {
            List<JenisKendaraan> dataJenisKendaraan = jenisKendaraandao.GetAll();
            dgvJenisKendaraan.DataSource = dataJenisKendaraan.ToArray();
            dgvJenisKendaraan.ReadOnly = true;
            

        }

        //Pesan Eror
        private void msgInfo(String prompt) {
            MessageBox.Show(prompt, "Informasi ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool msgInfo2(String prompt) {
            if (MessageBox.Show(prompt, "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            else {
                return false; 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            JenisKendaraan jenisKendaraan = new JenisKendaraan();
            jenisKendaraan.jenisKendaraan = txtJenisKendaraan.Text;
            jenisKendaraan.hargaperjam = int.Parse(txtHargaPerJam.Text);
            jenisKendaraan.hargamaksimal = int.Parse(txtHargaMaksimal.Text);

            int result = jenisKendaraandao.Save(jenisKendaraan);
            if (result > 0) {
                MessageBox.Show("Data berhasil di Input", "Data berhasil di Input");
            }

            loadJenisKendaraan();

        }

        private void dgvJenisKendaraan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvJenisKendaraan.Rows[e.RowIndex];
                txtId.Text = row.Cells["id"].Value.ToString();
                txtJenisKendaraan.Text = row.Cells["jenisKendaraan"].Value.ToString();
                txtHargaPerJam.Text = row.Cells["hargaperjam"].Value.ToString();
                txtHargaMaksimal.Text = row.Cells["hargamaksimal"].Value.ToString();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            JenisKendaraan jenisKendaraan = new JenisKendaraan();
            jenisKendaraan.id = int.Parse(txtId.Text);
            jenisKendaraan.jenisKendaraan = txtJenisKendaraan.Text;
            jenisKendaraan.hargaperjam = int.Parse(txtHargaPerJam.Text);
            jenisKendaraan.hargamaksimal = int.Parse(txtHargaMaksimal.Text);

            int result = jenisKendaraandao.Update(jenisKendaraan);
            if (result > 0)
            {
                MessageBox.Show("Data berhasil di Update", "Data berhasil di Update");
            }

            loadJenisKendaraan();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            loadJenisKendaraan();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //JenisKendaraan jenisKendaraan = new JenisKendaraan();
            //jenisKendaraan.id = int.Parse(txtId.Text);
            String id = txtId.Text;

            int result = jenisKendaraandao.Delete(id);
            if (result > 0)
            {
                MessageBox.Show("Data berhasil di hapus", "Data berhasil di hapus");
            }

            loadJenisKendaraan();
        }

       
       
        

    }
}

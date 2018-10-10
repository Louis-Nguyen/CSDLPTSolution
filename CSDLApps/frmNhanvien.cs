using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLApps
{
    public partial class frmNhanvien : Form
    {
        int vitri = 0;
        string macn = "";
        public frmNhanvien()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLVTDataSet_CN1);

        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVTDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVTDataSet.V_DS_PHANMANH);
            // TODO: This line of code loads data into the 'qLVTDataSet_CN1.NhanVien' table. You can move, or remove it, as needed.
            //this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            //this.nhanVienTableAdapter.Fill(this.qLVTDataSet_CN1.NhanVien);
            qLVTDataSet_CN1.EnforceConstraints = false;
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.qLVTDataSet_CN1.NhanVien);
           

            macn = ((DataRowView)bdsNV[0])["MACN"].ToString().Trim();
            cmbChinhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            cmbChinhanh.DisplayMember = "TENCN";
            cmbChinhanh.ValueMember = "TENSERVER";
            cmbChinhanh.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "CONGTY")
            {
                cmbChinhanh.Enabled = true;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                btnUndo.Enabled = false;
                btnRefresh.Enabled = false;
                btnDSNV.Enabled = false;
                
            } // bật tắt theo phân quyền
            else
            {
                cmbChinhanh.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = true;
                btnXoa.Enabled = true;
                btnUndo.Enabled = true;
                btnRefresh.Enabled = true;
                btnDSNV.Enabled = true;

            }

        }
      
        private void gvNV_Click(object sender, EventArgs e)
        {

        }

        private void tENCNComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tENCNLabel_Click(object sender, EventArgs e)
        {

        }

        private void nGAYSINHDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lUONGTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbChinhanh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbChinhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Program.servername = cmbChinhanh.SelectedValue.ToString();

            if (cmbChinhanh.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            else
            {
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.qLVTDataSet_CN1.NhanVien);

                macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            }
        }
    }
}

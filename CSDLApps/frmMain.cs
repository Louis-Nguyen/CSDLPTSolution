using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSDLApps
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVTDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVTDataSet.V_DS_PHANMANH);

        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        private void btnDangnhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDangnhap));
            if (frm != null) frm.Show();
            else
            {
                frmDangnhap f = new frmDangnhap();
                f.MdiParent = this;
                f.Show();
               
            }

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmNV = this.CheckExists(typeof(frmNhanvien));
            if (frmNV != null) frmNV.Close();
            if (Program.checkLogin==false)
            {
                MessageBox.Show("Bạn chưa đăng nhập!Vui lòng đăng nhập.", "", MessageBoxButtons.OK);
                Form frm = this.CheckExists(typeof(frmDangnhap));
                if (frm != null) frm.Activate();
                else
                {
                    frmDangnhap f = new frmDangnhap();
                    f.MdiParent = this;
                    f.Show();

                }

            }
            else
            {
                Program.checkLogin = false;
                
                Form frm = this.CheckExists(typeof(frmDangnhap));
                if (frm != null) {
                    frm.Hide();
                    frmDangnhap f = new frmDangnhap();
                    f.txtLogin.Text = "";
                    f.txtPass.Text = "";
                    this.MANV.Text = "Mã Nhân Viên: ";
                    this.HOTEN.Text = "Họ Tên: ";
                    this.NHOM.Text = "Nhóm: ";
                    f.MdiParent = this;
                    f.Show();
                } 
                else
                {
                    frmDangnhap f = new frmDangnhap();
                    f.txtLogin.Text = "";
                    f.txtPass.Text = "";
                    this.MANV.Text = "Mã Nhân Viên: ";
                    this.HOTEN.Text = "Họ Tên: ";
                    this.NHOM.Text = "Nhóm: ";
                    f.MdiParent = this;
                    f.Show();
                }
            }
           
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNhanvien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmNhanvien));
            if (frm != null) frm.Activate();
            else
            {
                frmNhanvien f = new frmNhanvien();
                f.MdiParent = this;
                f.Show();
            }

        }

        private void btnKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmKho));
            if (frm != null) frm.Activate();
            else
            {
                frmKho f = new frmKho();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}

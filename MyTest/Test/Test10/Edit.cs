using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Test10
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }
        private OleDbConnection con;

        public OleDbConnection Con
        {
            get { return con; }
            set { con = value; }
        }
        private DataTable dt;

        public DataTable Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        string id;
        string name;
        string age;
        string phone;
        string sex;
        private void Edit_Load(object sender, EventArgs e)
        {
            this.tbxID.Text = dt.Rows[0]["id"].ToString();
            this.tbxName.Text = dt.Rows[0]["name"].ToString();
            this.tbxAge.Text = dt.Rows[0]["age"].ToString();
            this.tbxPhone.Text = dt.Rows[0]["phone"].ToString();
            this.tbxSex.Text = dt.Rows[0]["sex"].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                id = this.tbxID.Text.Trim();
                name = this.tbxName.Text.Trim();
                age = this.tbxAge.Text.Trim();
                phone = this.tbxPhone.Text.Trim();
                sex = this.tbxSex.Text.Trim();
                Update();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void Update()
        {
            try
            {
                string sql = "update  person set name='"+name+"',age='"+age+"',phone='"+phone+"',sex='"+sex+"' where id="+id ;
                OleDbCommand cmd = new OleDbCommand(sql,con);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("修改成功！");
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
                this.Close();
                Form1 form1 = new Form1();
                form1.Show();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}

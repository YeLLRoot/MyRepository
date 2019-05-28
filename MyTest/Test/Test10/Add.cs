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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }
        private OleDbConnection con;

        public OleDbConnection Con
        {
            get { return con; }
            set { con = value; }
        }
       
        string id;
        string name;
        string age;
        string phone;
        string sex;
        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                name = this.tbxName.Text.Trim();
                age = this.tbxAge.Text.Trim();
                phone = this.tbxPhone.Text.Trim();
                sex = this.tbxSex.Text.Trim();
                AddData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AddData()
        {
            try
            {
                string sql = "insert into person(name,age,phone,sex) values('" +name + "','" + age + "','" + phone + "','" + sex + "')";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("添加成功！");
                }
                else
                {
                    MessageBox.Show("添加失败！");
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

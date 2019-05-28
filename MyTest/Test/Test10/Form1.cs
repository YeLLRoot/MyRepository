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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection conn;

        private DataTable getInfo(string sql)
        {
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            dbDataAdapter.Fill(dt);
            return dt;
        }
        public DataTable Find()
        {
            try
            {
                string sql = "select * from person";
                return getInfo(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private DataTable FindById(int id)
        {
            try
            {
                string sql = "select * from person where id="+id;
                return getInfo(sql);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        

        private void SelectData()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            DataTable dt = Find();
            dvData.AutoGenerateColumns = false;
            dvData.DataSource = dt;
            dvData.Columns["id"].DataPropertyName = dt.Columns[0].ToString();
            dvData.Columns["name"].DataPropertyName = dt.Columns[1].ToString();
            dvData.Columns["age"].DataPropertyName = dt.Columns[2].ToString();
            dvData.Columns["phone"].DataPropertyName = dt.Columns[3].ToString();
            dvData.Columns["sex"].DataPropertyName = dt.Columns[4].ToString();
            DataGridViewLinkColumn dlink = new DataGridViewLinkColumn();
            dlink.Text = "编辑";
            dlink.Name = "linkEdit";
            dlink.HeaderText = "操作";
            dlink.UseColumnTextForLinkValue = true;
            dvData.Columns.Add(dlink);
        }
        private void dvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex;
            //按钮所在列为第五列，列下标从0开始的  
            if (CIndex == 6)
            {
                //获取在同一行第一列的单元格中的字段值  
                int _UID = Convert.ToInt32(dvData[1, e.RowIndex].Value);
                DataTable dt = FindById(_UID);
                Edit edit =new Edit();
                edit.Con = conn;
                edit.Dt = dt;
                edit.Show();
                this.Hide();
            }  

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\test.accdb");
                conn.Open();
                SelectData();
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Add add = new Add();
                add.Con = conn;
                add.Show();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                string str = "(";
                int num = dvData.Rows.Count;
                for (int i = 0; i < num; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dvData.Rows[i].Cells[0];
                    if (Convert.ToBoolean(checkCell.Value)==true)
                    {
                        count++;
                        
                        str += dvData.Rows[i].Cells[1].Value.ToString()+",";

                    }
                }
                if (str.Length > 0)
                {
                    str = str.Substring(0, str.Length - 1);
                    str += ")";
                    //MessageBox.Show(str);
                }
                if (count == 0)
                {
                    MessageBox.Show("请至少选择一条数据！", "提示");
                    return;
                }
                else 
                {
                    if (MessageBox.Show(this, "共选择" + count + "条,你确定要删除这些数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information).ToString() == "Yes")
                    {
                        
                        string sql = "delete from person where id in " + str;
                        OleDbCommand cmd = new OleDbCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("删除成功");
                        SelectData();
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkAll.Checked)
                {
                    int count = dvData.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dvData.Rows[i].Cells[0];
                        Boolean flag = Convert.ToBoolean(checkCell.Value);
                        if (flag == false)
                        {
                            checkCell.Value = true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    int count = dvData.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dvData.Rows[i].Cells[0];
                        Boolean flag = Convert.ToBoolean(checkCell.Value);
                        if (flag == true)
                        {
                            checkCell.Value = false;
                        }
                        else
                        {
                            continue;
                        }
                    }

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}

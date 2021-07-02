using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WFA_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = DateTime.Now.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnShow_v2_Click(object sender, EventArgs e)
        {
            string userAccount = txtAccount.Text;
            DateTime showTime = DateTime.Now;
            string saveTime = showTime.ToShortTimeString();
            if (txtAccount.Text == "") MessageBox.Show("請輸入帳戶名");
            else if(txtPassword.Text=="") MessageBox.Show("請輸入密碼");
            else MessageBox.Show($"Hi! {userAccount}"+$"\n現在時間:{saveTime}");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            linkLabel1.LinkVisited = true;
            linkLabel1.VisitedLinkColor = Color.Chocolate;
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
           
            /*
          Form frm = new Form();
          frm.Text = "新建表單 -- 對話方塊模式";
          Button btnCancle = new Button();
          btnCancle.Font = new Font("微軟正黑體", 12);
          btnCancle.AutoSize = true;
          btnCancle.Text = "取消";
          btnCancle.Location = new Point(70, 80);

          frm.FormBorderStyle = FormBorderStyle.FixedDialog;
          frm.Opacity = 0.85;
          frm.AutoSize = true;
          frm.AutoSizeMode = AutoSizeMode.GrowOnly;
          frm.MaximizeBox = false;  //不設定最大化
          frm.MinimizeBox = false;
          frm.CancelButton = btnCancle;
          frm.StartPosition = FormStartPosition.CenterScreen;
          frm.Controls.Add(btnCancle); 
          frm.ShowDialog(); //顯示表單*/


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cal_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "") MessageBox.Show("請輸入數值1");
            else if (textBox2.Text == "") MessageBox.Show("請輸入數值2");
            else
            {
                int res = 0, v1 = Convert.ToInt32(textBox1.Text), v2 = Convert.ToInt32(textBox2.Text);
                string op = "";

                if (radioButton1.Checked)
                {
                    op = "相加";
                    res = v1 + v2;
                }
                else if (radioButton2.Checked)
                {
                    op = "相減";
                    res = v1 - v2;
                }
                else if (radioButton3.Checked)
                {
                    op = "相除";
                    res = v1 / v2;
                }
                else if (radioButton4.Checked)
                {
                    op = "相乘";
                    res = v1 * v2;
                }
                else MessageBox.Show("請選擇運算方式");
                 

                if(op!="") MessageBox.Show($"兩數 {op}" + $" = {Convert.ToString(res)}");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("D:\\source\\repos\\WFA_v1\\bin\\Debug\\WFA_v1.exe");
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (txtNote.CanUndo == true)
            {
                txtNote.Undo();  //復原文字方塊
                txtNote.ClearUndo(); //清除緩衝區
                txtNote.Focus(); //取得文字方塊輸入焦點
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtNote.SelectionLength>0)
            {
                txtNote.Copy();
                IDataObject buff = Clipboard.GetDataObject();
                //檢查buff複製資料是否為原有格式
                if (buff.GetDataPresent(DataFormats.Text))
                {
                    txtBuffer.Text = (String)(buff.GetData(DataFormats.UnicodeText));
                }
            }
            else
            {
                MessageBox.Show("沒選取文字", "進行複製", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
               
            
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            txtBuffer.Clear();
            btnClear.Enabled = true;  //激活清除按鈕
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text)==true)
            {
                if (txtNote.SelectionLength > 0)
                {
                    if(MessageBox.Show("確定從目前位置貼上文字?", "貼上訊息", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //字元起點貼上文字
                        txtNote.SelectionStart = txtNote.SelectionStart + txtNote.SelectionLength;
                    }
                    else
                    {
                        Clipboard.Clear();
                    }
                }
                txtNote.Paste();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNote.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            if (txtNote.SelectionLength > 0)
            {
                txtNote.Cut();
                IDataObject buff = Clipboard.GetDataObject();
                //檢查buff複製資料是否為原有格式
                if (buff.GetDataPresent(DataFormats.Text))
                {
                    txtBuffer.Text = (String)(buff.GetData(DataFormats.UnicodeText));
                }
            }
            else
            {
                MessageBox.Show("沒選取文字", "進行剪下", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(5);//顯示進度列目前位置
            info.Text = String.Format($"{progressBar1.Value}% 已完成");
            if(progressBar1.Value== progressBar1.Maximum)
            {
                btnStrat.Enabled = true;
                btnLeave.Enabled = true;
                timer1.Stop();
            }
        }

        private void btnStrat_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComdShell
{
    public partial class Form1 : Form
    {
        class dg
        {
            public DataGridView name;
            public enum values { integer, floating };
            public int val_column = 0, val_row = 0;
            public void init(int max_column, int max_row, int begin_num = 0, int off_auto_zagolovok = 0)
            {
                name.Rows.Clear();
                name.Columns.Clear();
                int stro = 0;
                //if (off_auto_zagolovok == 0)
                    for (int i = begin_num; i <= max_column; i++) name.Columns.Add("Column", i.ToString());
                if (off_auto_zagolovok == 1) name.ColumnHeadersVisible = false;
                for (int i = begin_num; i < max_row; i++) name.Rows.Add();
                for (int i = begin_num; i <= max_row; i++) name.Rows[stro++].HeaderCell.Value = i.ToString();
                name.AutoResizeColumns();
            }
        }
            public Form1()
        {
            InitializeComponent();
        }
        
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            //   Button buttonCancel = new Button();
            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            buttonOk.Text = "OK";
            //   buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            //   buttonCancel.DialogResult = DialogResult.Cancel;
            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            // buttonCancel.SetBounds(309, 72, 75, 23);
            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            //form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            //   form.CancelButton = buttonCancel;
            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", " /K ping 8.8.8.8");
        }

        private void button10_Click(object sender, EventArgs e)
        {

            
            string msg="";
            if( InputBox("Введте сообщение", "Введте сообщение", ref msg) == DialogResult.OK)
             Process.Start("cmd.exe", @"/c C:\Windows\Sysnative\msg.exe * "+ msg);
        }
        dg a1 = new dg();
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a1.name = dataGridView1;
            a1.init(4, 9, 1,1);
            /*
            //описываем виртуальную таблицу 
            DataTable dt = new DataTable("tab0");
            DataColumn a0 = new DataColumn(i++.ToString(), typeof(String));
            DataColumn a1 = new DataColumn(i++.ToString(), typeof(String));
            DataColumn a2 = new DataColumn(i++.ToString(), typeof(String));
            DataColumn a3 = new DataColumn(i++.ToString(), typeof(String));
            DataColumn a4 = new DataColumn(i++.ToString(), typeof(String));
            DataColumn a5 = new DataColumn(i++.ToString(), typeof(String));
            DataColumn a6 = new DataColumn(i++.ToString(), typeof(String));
            DataColumn a7 = new DataColumn(i++.ToString(), typeof(String));
            DataColumn a8 = new DataColumn(i++.ToString(), typeof(String));
            DataColumn a9 = new DataColumn(i++.ToString(), typeof(String));
            DataColumn a10 = new DataColumn(i++.ToString(), typeof(String));
            dt.Columns.AddRange(new DataColumn[] { a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10 });


            //считываем файл
             string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\rozklad0.csv";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
              path = openFileDialog1.FileName;
            //иначе по умолчанию
            //else path = @Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\rozklad.csv";
            //else path = @"G:\project\excell_rozklad\rozklad.csv";
            //string path = @"rozklad.csv";
            string[] tab0 = File.ReadAllLines(path, Encoding.Default);

    string[] tab0Values = null;
            DataRow dr = null;
            //помещаем файл в виртуальную таблицу
            for (i = 0; i < tab0.Length; i++)
            {
                if (!String.IsNullOrEmpty(tab0[i]))
                {
                    tab0Values = tab0[i].Split(';');
                    //создаём новую строку
                    dr = dt.NewRow();
                    for (int j = 0; j < 8; j++)
                    {
                        string valp = tab0Values[j].ToUpper();
                        dr[j] = Regex.Replace(valp, " {2,}", " ");
                    }
                    dt.Rows.Add(dr);
                }
            }
             dataGridView2.DataSource = dt;
             */

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        string path = @"comdshell.txt";
        public void writeCSV(DataGridView gridIn, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(outputFile);

                //write header rows to csv
            /*    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(gridIn.Columns[i].HeaderText);
                }

                swOut.WriteLine();
*/
                //write DataGridView rows to csv
                for (int j = 0; j <= gridIn.Rows.Count - 2; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = gridIn.Rows[j];

                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        //value = dr.Cells[i].Value.ToString();
                        //value = dr.Cells[i].ToString();
                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();
            }
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
            //Process.Start("cmd.exe", " /K ping 8.8.8.8");
            run_pro(1);
        }

        private void button10_Click(object sender, EventArgs e)
        {

            
            string msg="";
            if( InputBox("Введте сообщение", "Введте сообщение", ref msg) == DialogResult.OK)
             Process.Start("cmd.exe", @"/c C:\Windows\Sysnative\msg.exe * "+ msg);
        }
        dg aa1 = new dg();
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void button11_Click(object sender, EventArgs e)
        {
            writeCSV(dataGridView1, @path);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            run_pro(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            run_pro(3);
            
        }
        void run_pro(int num_but)
        {
            num_but--;
            string comm = "\"" + dataGridView1.Rows[num_but].Cells[1].Value.ToString() + "\"";
            string atr = dataGridView1.Rows[num_but].Cells[2].Value.ToString();
            Process.Start(@comm, @atr);
            if (dataGridView1.Rows[num_but].Cells[3].Value.ToString() != "")
            {
                comm = "\"" + dataGridView1.Rows[num_but].Cells[3].Value.ToString() + "\"";
                atr = dataGridView1.Rows[2].Cells[num_but].Value.ToString();
                Process.Start(@comm, @atr);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            run_pro(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            run_pro(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            run_pro(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            run_pro(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            run_pro(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            run_pro(9);
        }
        void init_grid_button()
        {   //  aa1.name = dataGridView1;
            //    aa1.init(4, 9, 1,1);
            int i = 0;
            //описываем виртуальную таблицу 
            DataTable dt = new DataTable("tab0");
            DataColumn a0 = new DataColumn("название кнпк", typeof(String));
            DataColumn a1 = new DataColumn("команда_1", typeof(String));
            DataColumn a2 = new DataColumn("параметры_1", typeof(String));
            DataColumn a3 = new DataColumn("команда_2", typeof(String));
            DataColumn a4 = new DataColumn("параметры_2", typeof(String));
            DataColumn a5 = new DataColumn("примечание", typeof(String));
            //DataColumn a6 = new DataColumn(i++.ToString(), typeof(String));
            //DataColumn a7 = new DataColumn(i++.ToString(), typeof(String));
            //DataColumn a8 = new DataColumn(i++.ToString(), typeof(String));
            //DataColumn a9 = new DataColumn(i++.ToString(), typeof(String));
            //DataColumn a10 = new DataColumn(i++.ToString(), typeof(String));
            dt.Columns.AddRange(new DataColumn[] { a0, a1, a2, a3, a4, a5 });//, a6, a7, a8, a9, a10 


            //считываем файл
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\rozklad0.csv";
            //if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //path = openFileDialog1.FileName;
            //иначе по умолчанию
            //else path = @Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\rozklad.csv";
            //else path = @"G:\project\excell_rozklad\rozklad.csv";
            //string path = @"rozklad.csv";

            string[] tab0 = File.ReadAllLines(path, Encoding.UTF8);

            string[] tab0Values = null;
            DataRow dr = null;
            //помещаем файл в виртуальную таблицу
            for (i = 0; i < tab0.Length; i++)
            {
                if (!String.IsNullOrEmpty(tab0[i]))
                {
                    tab0Values = tab0[i].Split(',');
                    //создаём новую строку
                    dr = dt.NewRow();

                    for (int j = 0; j < 6; j++)
                    {
                        string valp = tab0Values[j];
                        // string valp = tab0Values[1].ToUpper();

                        // dr[j] = Regex.Replace(valp, " {2,}", " ");
                        dr[j] = valp;
                    }
                    dt.Rows.Add(dr);
                }
            }
            dataGridView1.DataSource = dt;
            /*    */
            if (dataGridView1.RowCount > 1) button1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            if (dataGridView1.RowCount > 2) button2.Text = dataGridView1.Rows[1].Cells[0].Value.ToString();
            if (dataGridView1.RowCount > 3) button3.Text = dataGridView1.Rows[2].Cells[0].Value.ToString();
            if (dataGridView1.RowCount > 4) button4.Text = dataGridView1.Rows[3].Cells[0].Value.ToString();
            if (dataGridView1.RowCount > 5) button5.Text = dataGridView1.Rows[4].Cells[0].Value.ToString();
            if (dataGridView1.RowCount > 6) button6.Text = dataGridView1.Rows[5].Cells[0].Value.ToString();
            if (dataGridView1.RowCount > 7) button7.Text = dataGridView1.Rows[6].Cells[0].Value.ToString();
            if (dataGridView1.RowCount > 8) button8.Text = dataGridView1.Rows[7].Cells[0].Value.ToString();
            if (dataGridView1.RowCount > 9) button9.Text = dataGridView1.Rows[8].Cells[0].Value.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            init_grid_button();          
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            writeCSV(dataGridView1, @path);
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            init_grid_button();
        }
    }
}

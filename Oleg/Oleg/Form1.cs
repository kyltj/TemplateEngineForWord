using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Web;
using System.Data.SqlClient;
using System.IO;

using System.Xml.Serialization;
using System.Reflection;

namespace Oleg
{
    public partial class ADDtextBox1 : Form
    {
        public ADDtextBox1()
        {
            InitializeComponent();
            
        }


        
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

            
            this.Size = new Size(448, this.Height);
            button1.Size = new Size(394, button1.Height);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            this.Size = new Size(656, this.Height);
            button1.Size = new Size(606, button1.Height);
        }


       
       
        public static List<Label> pct = new List<Label>();
        public static List<MyLabel> mypct = new List<MyLabel>();
        public static List<TextBox> tex = new List<TextBox>();
        public static List<MyText> mytex = new List<MyText>();
        public static List<Button> btn = new List<Button>();
        public static List<MyBtn> mybtn = new List<MyBtn>();
        public static List<CheckBox> check = new List<CheckBox>();
        public static MainForm mainForm = new MainForm();
        public static List<MyCheckBox> mycheck = new List<MyCheckBox>();
        public static List<String> type = new List<String>();
        public static List<String> title = new List<String>();

        
        
        private void button1_Click(object sender, EventArgs e)
        
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Заполните Название Поля!");
                }

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Заполните Подсказку Поля!");
                }

                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Заполните Тип Поля!");
                }

                
            }

            else
            {

                if (comboBox1.Text == "База данных" && textBox1.Text != "Адрес")
                {
                    MessageBox.Show("Такой Базы Данных НЕТ Увы =)!");
                }

                else
                {

                    type.Add(comboBox1.Text);
                    title.Add(textBox2.Text);

                    check.Add(new CheckBox());

                    if (comboBox1.Text == "Дата(Календарь)")
                    {


                        check[Settings1.Default.IndexComponent].Left = 220;
                        check[Settings1.Default.IndexComponent].Height = 20;
                        check[Settings1.Default.IndexComponent].Top = 50 * (Settings1.Default.IndexPoints + 1) + 3;
                        check[Settings1.Default.IndexComponent].Width = 20;
                        check[Settings1.Default.IndexComponent].Text = "Тип";
                        check[Settings1.Default.IndexComponent].Visible = true;
                        check[Settings1.Default.IndexComponent].Checked = false;
                        check[Settings1.Default.IndexComponent].Click += new EventHandler(check_Click);
                        check[Settings1.Default.IndexComponent].Name = Convert.ToString(Settings1.Default.IndexComponent);
                        mainForm.Controls.Add(check[Settings1.Default.IndexComponent]);
                        mycheck.Add(new MyCheckBox(false, true, 50 * (Settings1.Default.IndexPoints + 1) + 3, Convert.ToString(Settings1.Default.IndexComponent)));

                    }

                    else
                    {
                        check[Settings1.Default.IndexComponent].Visible = false;
                        mycheck.Add(new MyCheckBox(false, false, 50 * (Settings1.Default.IndexPoints + 1) + 3, Convert.ToString(Settings1.Default.IndexComponent)));
                    }


                    mypct.Add(new MyLabel(40, 250, 15, 50 * (Settings1.Default.IndexPoints + 1), textBox1.Text));
                    pct.Add(new Label());
                    pct[Settings1.Default.IndexComponent].Height = 40;
                    pct[Settings1.Default.IndexComponent].Width = 250;

                    pct[Settings1.Default.IndexComponent].Left = 15;

                    pct[Settings1.Default.IndexComponent].Font = new Font("times new rom", 16, FontStyle.Italic);
                    pct[Settings1.Default.IndexComponent].Top = 50 * (Settings1.Default.IndexPoints + 1);
                    pct[Settings1.Default.IndexComponent].Text = textBox1.Text;
                    mainForm.Controls.Add(pct[Settings1.Default.IndexComponent]);

                    mytex.Add(new MyText(40, 250, 275, 50 * (Settings1.Default.IndexPoints + 1), textBox2.Text, Convert.ToString(Settings1.Default.IndexComponent)));
                    tex.Add(new TextBox());
                    tex[Settings1.Default.IndexComponent].Height = 40;
                    tex[Settings1.Default.IndexComponent].Width = 250;

                    tex[Settings1.Default.IndexComponent].Left = 275;
                    tex[Settings1.Default.IndexComponent].MaxLength = 15;

                    tex[Settings1.Default.IndexComponent].Font = new Font("times new rom", 13, FontStyle.Italic);
                    tex[Settings1.Default.IndexComponent].ForeColor = Color.Gray;
                    tex[Settings1.Default.IndexComponent].KeyPress += new KeyPressEventHandler(tex_KeyPress);
                    tex[Settings1.Default.IndexComponent].Click += new EventHandler(tex_ClickPress);
                    tex[Settings1.Default.IndexComponent].Top = 50 * (Settings1.Default.IndexPoints + 1);
                    tex[Settings1.Default.IndexComponent].Name = Convert.ToString(Settings1.Default.IndexComponent);
                    tex[Settings1.Default.IndexComponent].Text = textBox2.Text;
                    mainForm.Controls.Add(tex[Settings1.Default.IndexComponent]);


                    mybtn.Add(new MyBtn(33, 40, 530, 50 * (Settings1.Default.IndexPoints + 1), Convert.ToString(Settings1.Default.IndexComponent)));
                    btn.Add(new Button());
                    btn[Settings1.Default.IndexComponent].Height = 33;
                    btn[Settings1.Default.IndexComponent].Width = 40;
                    btn[Settings1.Default.IndexComponent].Text = Convert.ToString(Settings1.Default.IndexComponent);
                    btn[Settings1.Default.IndexComponent].Name = Convert.ToString(Settings1.Default.IndexComponent);
                    btn[Settings1.Default.IndexComponent].Left = 530;
                    btn[Settings1.Default.IndexComponent].Image = ((System.Drawing.Image)(Properties.Resources._3));
                    btn[Settings1.Default.IndexComponent].Font = new Font("times new rom", 16, FontStyle.Italic);
                    btn[Settings1.Default.IndexComponent].Top = 50 * (Settings1.Default.IndexPoints + 1);
                    btn[Settings1.Default.IndexComponent].Click += new EventHandler(b_Click);
                    mainForm.Controls.Add(btn[Settings1.Default.IndexComponent]);






                    Settings1.Default.IndexComponent++;
                    Settings1.Default.IndexPoints++;



                    mainForm.Show();

                    this.Hide();
                }
            }

           

          
            
        }


        

        public static void tex_ClickPress(object sender, EventArgs e)
        {
            string ID = (sender as Control).Name;

            Settings1.Default.ID = Convert.ToInt32(ID);

            tex[Convert.ToInt32(ID)].Font = new Font("times new rom", 16, FontStyle.Italic);
            tex[Convert.ToInt32(ID)].ForeColor = Color.Black;
            tex[Convert.ToInt32(ID)].Text = "";

            if (type[Convert.ToInt32(ID)] == "Дата(Календарь)")
            {
                
                mainForm.monthCalendar1.Location = new Point((sender as Control).Location.X, (sender as Control).Location.Y + 40);
                mainForm.monthCalendar1.Visible = true;
            }

            

            if (type[Convert.ToInt32(ID)] == "База данных")
            {
                DataSet dataset = new DataSet();
                dataset.ShowDialog();
                
            }

           
        }

        public static void check_Click(object sender, EventArgs e)
        {
            string ID = (sender as Control).Name;

            if(mycheck[Convert.ToInt32(ID)].Checked==false)
            {
                mycheck[Convert.ToInt32(ID)].Checked = true;
            }

            else
            {
                mycheck[Convert.ToInt32(ID)].Checked = false;
            }
        }
        public static void b_Click(object sender, EventArgs e)
        {
            string ID = (sender as Control).Name;


            (btn[Convert.ToInt32(ID)] as Control).Dispose();
            mainForm.Controls.Remove(btn[Convert.ToInt32(ID)] as Control);

            (tex[Convert.ToInt32(ID)] as Control).Dispose();
            mainForm.Controls.Remove(tex[Convert.ToInt32(ID)] as Control);

            (pct[Convert.ToInt32(ID)] as Control).Dispose();
            mainForm.Controls.Remove(pct[Convert.ToInt32(ID)] as Control);

            (check[Convert.ToInt32(ID)] as Control).Dispose();
            mainForm.Controls.Remove(check[Convert.ToInt32(ID)] as Control);

            mypct[Convert.ToInt32(ID)] = null;
            mytex[Convert.ToInt32(ID)] = null;
            mybtn[Convert.ToInt32(ID)] = null;
            mycheck[Convert.ToInt32(ID)] = null;

            btn[Convert.ToInt32(ID)] = null;
            tex[Convert.ToInt32(ID)] = null;
            pct[Convert.ToInt32(ID)] = null;
            check[Convert.ToInt32(ID)] = null;

            for(int i=Convert.ToInt32(ID)+1;i<btn.Count;i++)
            {
                if (btn[i] != null)
                {
                    btn[i].Location = new Point(530, btn[i].Location.Y - 50);
                    tex[i].Location = new Point(275, tex[i].Location.Y - 50);
                    pct[i].Location = new Point(15, pct[i].Location.Y - 50);
                    check[i].Location = new Point(220,check[i].Location.Y-50);
                }
                
            }

            Settings1.Default.IndexPoints -= 1;

         
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ADDtextBox1_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Application.Exit();
        }

        private void ADDtextBox1_Activated(object sender, EventArgs e)
        {
            if (Settings2.Default.e==false)
            {
                try
                {
                    Settings2.Default.e = true;
                    mainForm.Show();
                    this.Hide();

                    if (Directory.Exists(Application.StartupPath.ToString() + @"\SaveSetting"))
                    { 


                    Settings1.Default.IndexComponent = Convert.ToInt32(File.ReadAllLines(Application.StartupPath.ToString() + @"\SaveSetting\SavaIni.xml")[0]);
                    Settings1.Default.IndexPoints = Convert.ToInt32(File.ReadAllLines(Application.StartupPath.ToString() + @"\SaveSetting\SavaIni.xml")[1]);
                    Settings1.Default.ID = Convert.ToInt32(File.ReadAllLines(Application.StartupPath.ToString() + @"\SaveSetting\SavaIni.xml")[1]);

                    if(Settings1.Default.IndexComponent>0)
                    {
                        // считываем с диска
                        XmlSerializer ser = new XmlSerializer(typeof(List<MyLabel>));
                        FileStream file = new FileStream(Application.StartupPath.ToString() + @"\SaveSetting\MyLabel.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                        mypct = (List<MyLabel>)ser.Deserialize(file);
                        // в списке 3 элемента
                        file.Close();


                        // считываем с диска
                        XmlSerializer ser2 = new XmlSerializer(typeof(List<MyText>));
                        FileStream file2 = new FileStream(Application.StartupPath.ToString() + @"\SaveSetting\MyText.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                        mytex = (List<MyText>)ser2.Deserialize(file2);
                        // в списке 3 элемента
                        file2.Close();

                        // считываем с диска
                        XmlSerializer ser3 = new XmlSerializer(typeof(List<MyBtn>));
                        FileStream file3 = new FileStream(Application.StartupPath.ToString() + @"\SaveSetting\MyBtn.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                        mybtn = (List<MyBtn>)ser3.Deserialize(file3);
                        // в списке 3 элемента
                        file3.Close();

                        // считываем с диска
                        XmlSerializer ser4 = new XmlSerializer(typeof(List<String>));
                        FileStream file4 = new FileStream(Application.StartupPath.ToString() + @"\SaveSetting\MyType.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                        type = (List<String>)ser4.Deserialize(file4);
                        // в списке 3 элемента
                        file4.Close();

                        // считываем с диска
                        XmlSerializer ser5 = new XmlSerializer(typeof(List<MyCheckBox>));
                        FileStream file5 = new FileStream(Application.StartupPath.ToString() + @"\SaveSetting\MyCheck.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                        mycheck = (List<MyCheckBox>)ser5.Deserialize(file5);
                        // в списке 3 элемента
                        file5.Close();

                        // считываем с диска
                        XmlSerializer ser6 = new XmlSerializer(typeof(List<String>));
                        FileStream file6 = new FileStream(Application.StartupPath.ToString() + @"\SaveSetting\MyTitle.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                        title = (List<String>)ser6.Deserialize(file6);
                        // в списке 3 элемента
                        file6.Close();

                        
        

                        for (int i = 0; i <= Settings1.Default.IndexComponent - 1; i++)
                        {
                            pct.Add(new Label());
                            tex.Add(new TextBox());
                            btn.Add(new Button());
                            check.Add(new CheckBox());

                        }

                        for (int i = 0; i <= Settings1.Default.IndexComponent - 1; i++)
                        {

                            if(mycheck[i]!=null)
                            {
                                check.Add(new CheckBox());
                                check[i].Height = 20;
                                check[i].Width = 20;
                                check[i].Top = mycheck[i].Top;
                                check[i].Left = 220;
                                check[i].Visible = mycheck[i].Visible;
                                check[i].Checked = mycheck[i].Checked;
                                check[i].Name = mycheck[i].Name;
                                check[i].Click += new EventHandler(check_Click);
                                mainForm.Controls.Add(check[i]);
                                
                            }

                            if (mypct[i] != null)
                            {
                                pct.Add(new Label());
                                pct[i].Height = 40;
                                pct[i].Width = 250;

                                pct[i].Left = 15;

                                pct[i].Font = new Font("times new rom", 16, FontStyle.Italic);
                                pct[i].Top = mypct[i].Top;
                                pct[i].Text = mypct[i].Text;
                                mainForm.Controls.Add(pct[i]);
                            }


                            if (mytex[i] != null)
                            {
                                tex.Add(new TextBox()); tex[i].Height = 40;
                                tex[i].Width = 250;

                                tex[i].Left = 275;
                                tex[i].MaxLength = 15;

                                tex[i].Font = new Font("times new rom", 16, FontStyle.Italic);
                                tex[i].ForeColor = Color.Black;
                                tex[i].KeyPress += new KeyPressEventHandler(tex_KeyPress);
                                tex[i].Click += new EventHandler(tex_ClickPress);
                                tex[i].Top = mytex[i].Top;
                                tex[i].Name = mytex[i].Name;
                                tex[i].Text = mytex[i].Text;
                                mainForm.Controls.Add(tex[i]);
                            }


                            if (mybtn[i] != null)
                            {

                                btn.Add(new Button());
                                btn[i].Height = 33;
                                btn[i].Width = 40;
                                btn[i].Text = mybtn[i].Name;
                                btn[i].Name = mybtn[i].Name;
                                btn[i].Left = 530;
                                btn[i].Image = ((System.Drawing.Image)(Properties.Resources._3));
                                btn[i].Font = new Font("times new rom", 16, FontStyle.Italic);
                                btn[i].Top = mybtn[i].Top;
                                btn[i].Click += new EventHandler(b_Click);


                                mainForm.Controls.Add(btn[i]);
                            }

                        }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка Загрузки"+e);
                }
            }
        }



        public static void tex_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ID = (sender as Control).Name;
            if (type[Convert.ToInt32(ID)] == "Числовое")
            {
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8) e.Handled = true;

            }

            if (type[Convert.ToInt32(ID)] == "База данных")
            {
                e.Handled = true;
            }

            if (type[Convert.ToInt32(ID)] == "Дата(Календарь)")
            {
                e.Handled = true;
            }
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            


        }


        public  class MyLabel
        {
            public int Height { get; set; }

            public int Width { get; set; }

            public int Left { get; set; }


            public int Top { get; set; }


            public string Text { get; set; }

           public  MyLabel(int height, int width, int left, int top, string text)
            {
                Height = height;
                Width = width;
                Left = left;
                Top = top;
                Text = text;
            }

            public  MyLabel()
           {

           }
        }

        public class MyText
        {
            public int Height { get; set; }

            public int Width { get; set; }

            public int Left { get; set; }


            public int Top { get; set; }


            public string Text { get; set; }

            public string Name { get; set; }

            public MyText(int height, int width, int left, int top, string text,string name)
            {
                Height = height;
                Width = width;
                Left = left;
                Top = top;
                Text = text;
                Name = name;
            }

            public MyText()
            {

            }
        }

        public class MyCheckBox
        {
            public bool Checked { get; set; }

            public bool Visible { get; set; }

            public int Top { get; set; }
            public string Name { get; set; }
            public MyCheckBox(bool checkedq,bool visible,int top,string name)
            {
                Checked = checkedq;
                Visible = visible;
                Top = top;
                Name = name;
            }
            public  MyCheckBox()
            {

            }
        }
        public class MyBtn
        {
            public int Height { get; set; }

            public int Width { get; set; }

            public int Left { get; set; }


            public int Top { get; set; }


            

            public string Name { get; set; }

            public MyBtn(int height, int width, int left, int top,  string name)
            {
                Height = height;
                Width = width;
                Left = left;
                Top = top;
                
                Name = name;
            }

            public MyBtn()
            {

            }
        }
    }
}

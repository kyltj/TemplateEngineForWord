using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;

using word = Microsoft.Office.Interop.Word;

namespace Oleg
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
       
        
        private void MainForm_Load(object sender, EventArgs e)
        {
          

           
        }

        

        
        
       

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Console.WriteLine(ADDtextBox1.tex.Count);
        }

        private void toolStripContainer1_BottomToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ADDtextBox1 form1 = new ADDtextBox1();
            form1.Show();
            this.Hide();
        }

        public static Identytay identytay = new Identytay();
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int countGrid = 0;
            string[] result = new string[Settings1.Default.IndexComponent];
            for (int i = 0; i < Settings1.Default.IndexComponent; i++)
            {
                if (ADDtextBox1.pct[i] != null)
                {
                    result[i] = ADDtextBox1.pct[i].Text + ":" + ADDtextBox1.tex[i].Text + ":" + "[KOD" + i + "]";
                    countGrid += 1;
                }

            }
            identytay.dataGridView1.RowCount = countGrid;
            int countInc=-1;

            for (int i = 0; i < Settings1.Default.IndexComponent; i++)
            {
                if (result[i] != null)
                {
                    countInc++;
                    identytay.dataGridView1.Rows[countInc].Cells[0].Value = ADDtextBox1.pct[i].Text;
                    identytay.dataGridView1.Rows[countInc].Cells[1].Value = ADDtextBox1.tex[i].Text;
                    identytay.dataGridView1.Rows[countInc].Cells[2].Value = "[KOD" + i + "]";
                }
            }

          
                

            identytay.ShowDialog();
        }

        Object _missingObj = System.Reflection.Missing.Value;
        Object trueObj = true;
        Object falseObj = false;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            /*string pathToTemplate="";


            // выход, если была нажата кнопка Отмена и прочие (кроме ОК)
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                pathToTemplate = openFileDialog1.FileName;
            }

            WordDocument wordDoc = null;

            wordDoc = new WordDocument(pathToTemplate);

            string[] toFindStrTextBox = new string[identytay.dataGridView1.RowCount];
            string[] replaceStrTextBox = new string[identytay.dataGridView1.RowCount];

            for(int i=0;i<identytay.dataGridView1.RowCount;i++)
            {
                toFindStrTextBox[i] = (string)identytay.dataGridView1.Rows[i].Cells[2].Value;
                replaceStrTextBox[i] = (string)identytay.dataGridView1.Rows[i].Cells[1].Value;
                wordDoc.ReplaceAllStrings(toFindStrTextBox[i], replaceStrTextBox[i]);
            }

            wordDoc.Visible = true;*/
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                        try
                        {               
                            object[] strToFind = new object[identytay.dataGridView1.RowCount];
                            object[] replaceStr = new object[identytay.dataGridView1.RowCount];

                            for (int i = 0; i < identytay.dataGridView1.RowCount; i++)
                            {
                                strToFind[i]=identytay.dataGridView1.Rows[i].Cells[2].Value;
                                replaceStr[i] = identytay.dataGridView1.Rows[i].Cells[1].Value;
                            }


                            dynamic app = new word.Application();
                            dynamic doc = app.Documents.Add(openFileDialog1.FileName, false);

                            // обьектные строки для Word
                            object strToFindObj = "3";
                            object replaceStrObj = "4";
                            // диапазон документа Word
                            word.Range wordRange;
                            //тип поиска и замены
                            object replaceTypeObj;
                            replaceTypeObj = word.WdReplace.wdReplaceAll;
                            // обходим все разделы документа
                            for (int j = 0; j < identytay.dataGridView1.RowCount;j++ )
                            {
                                for (int i = 1; i <= doc.Sections.Count; i++)
                                {
                                    // берем всю секцию диапазоном
                                    wordRange = doc.Sections[i].Range;

                                    /*
                                    Обходим редкий глюк в Find, ПРИЗНАННЫЙ MICROSOFT, метод Execute на некоторых машинах вылетает с ошибкой "Заглушке переданы неправильные данные / Stub received bad data"  Подробности: http://support.microsoft.com/default.aspx?scid=kb;en-us;313104
                                    // выполняем метод поиска и  замены обьекта диапазона ворд
                                    wordRange.Find.Execute(ref strToFindObj, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing, ref replaceStrObj, ref replaceTypeObj, ref wordMissing, ref wordMissing, ref wordMissing, ref wordMissing);
                                    */

                                    word.Find wordFindObj = wordRange.Find;
                                    object[] wordFindParameters = new object[15] { strToFind[j], _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, _missingObj, replaceStr[j], replaceTypeObj, _missingObj, _missingObj, _missingObj, _missingObj };

                                    wordFindObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, wordFindObj, wordFindParameters);
                                }

                                    
                                }

                            doc.Save();
                            doc.Close();

                        }

                        catch 
                        {
                            MessageBox.Show("Допустимая Ошибка Документа");
                        }
        }

            
        }

       

       
        string month;
      

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Settings1.Default.IndexComponent;i++ )
            {
                if (ADDtextBox1.pct[i] != null)
                {
                    try
                    {
                        ADDtextBox1.mytex[i].Text = ADDtextBox1.tex[i].Text;


                        ADDtextBox1.mytex[i].Top = ADDtextBox1.tex[i].Top;
                        ADDtextBox1.mycheck[i].Top = ADDtextBox1.check[i].Top;
                        ADDtextBox1.mypct[i].Top = ADDtextBox1.pct[i].Top;
                        ADDtextBox1.mybtn[i].Top = ADDtextBox1.btn[i].Top;
                    }
                    catch { }
                }

            }

                if (!Directory.Exists(Application.StartupPath.ToString() + @"\SaveSetting"))
                {
                    Directory.CreateDirectory(Application.StartupPath.ToString() + @"\SaveSetting");

                    // сохраняем на диске
                    XmlSerializer ser = new XmlSerializer(typeof(List<ADDtextBox1.MyLabel>));
                    string path = Application.StartupPath.ToString() + @"\SaveSetting\MyLabel.xml";
                    FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                    ser.Serialize(file, ADDtextBox1.mypct);
                    file.Close();

                    // сохраняем на диске
                    XmlSerializer ser2 = new XmlSerializer(typeof(List<ADDtextBox1.MyText>));
                    string path2 = Application.StartupPath.ToString() + @"\SaveSetting\MyText.xml";
                    FileStream file2 = new FileStream(path2, FileMode.Create, FileAccess.Write, FileShare.None);
                    ser2.Serialize(file2, ADDtextBox1.mytex);
                    file2.Close();

                    // сохраняем на диске
                    XmlSerializer ser3 = new XmlSerializer(typeof(List<ADDtextBox1.MyBtn>));
                    string path3 = Application.StartupPath.ToString() + @"\SaveSetting\MyBtn.xml"; ;
                    FileStream file3 = new FileStream(path3, FileMode.Create, FileAccess.Write, FileShare.None);
                    ser3.Serialize(file3, ADDtextBox1.mybtn);
                    file3.Close();

                    // сохраняем на диске
                    XmlSerializer ser4 = new XmlSerializer(typeof(List<String>));
                    string path4 = Application.StartupPath.ToString() + @"\SaveSetting\MyType.xml"; ;
                    FileStream file4 = new FileStream(path4, FileMode.Create, FileAccess.Write, FileShare.None);
                    ser4.Serialize(file4, ADDtextBox1.type);
                    file4.Close();

                    // сохраняем на диске
                    XmlSerializer ser5 = new XmlSerializer(typeof(List<ADDtextBox1.MyCheckBox>));
                    string path5 = Application.StartupPath.ToString() + @"\SaveSetting\MyCheck.xml"; ;
                    FileStream file5 = new FileStream(path5, FileMode.Create, FileAccess.Write, FileShare.None);
                    ser5.Serialize(file5, ADDtextBox1.mycheck);
                    file5.Close();

                    // сохраняем на диске
                    XmlSerializer ser6 = new XmlSerializer(typeof(List<String>));
                    string path6 = Application.StartupPath.ToString() + @"\SaveSetting\MyTitle.xml"; ;
                    FileStream file6 = new FileStream(path6, FileMode.Create, FileAccess.Write, FileShare.None);
                    ser6.Serialize(file6, ADDtextBox1.title);
                    file6.Close();

                    try
                    {

                        File.WriteAllLines(Application.StartupPath.ToString() + @"\SaveSetting\SavaIni.xml", new string[] { Settings1.Default.IndexComponent.ToString(), Settings1.Default.IndexPoints.ToString(), Settings1.Default.ID.ToString() });
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }

                else
                {
                    // сохраняем на диске
                    XmlSerializer ser = new XmlSerializer(typeof(List<ADDtextBox1.MyLabel>));
                    string path = Application.StartupPath.ToString() + @"\SaveSetting\MyLabel.xml";
                    FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                    ser.Serialize(file, ADDtextBox1.mypct);
                    file.Close();

                    // сохраняем на диске
                    XmlSerializer ser2 = new XmlSerializer(typeof(List<ADDtextBox1.MyText>));
                    string path2 = Application.StartupPath.ToString() + @"\SaveSetting\MyText.xml";
                    FileStream file2 = new FileStream(path2, FileMode.Create, FileAccess.Write, FileShare.None);
                    ser2.Serialize(file2, ADDtextBox1.mytex);
                    file2.Close();

                    // сохраняем на диске
                    XmlSerializer ser3 = new XmlSerializer(typeof(List<ADDtextBox1.MyBtn>));
                    string path3 = Application.StartupPath.ToString() + @"\SaveSetting\MyBtn.xml"; ;
                    FileStream file3 = new FileStream(path3, FileMode.Create, FileAccess.Write, FileShare.None);
                    ser3.Serialize(file3, ADDtextBox1.mybtn);
                    file3.Close();

                    // сохраняем на диске
                    XmlSerializer ser4 = new XmlSerializer(typeof(List<String>));
                    string path4 = Application.StartupPath.ToString() + @"\SaveSetting\MyType.xml"; ;
                    FileStream file4 = new FileStream(path4, FileMode.Create, FileAccess.Write, FileShare.None);
                    ser4.Serialize(file4, ADDtextBox1.type);
                    file4.Close();

                    // сохраняем на диске
                    XmlSerializer ser5 = new XmlSerializer(typeof(List<ADDtextBox1.MyCheckBox>));
                    string path5 = Application.StartupPath.ToString() + @"\SaveSetting\MyCheck.xml"; ;
                    FileStream file5 = new FileStream(path5, FileMode.Create, FileAccess.Write, FileShare.None);
                    ser5.Serialize(file5, ADDtextBox1.mycheck);
                    file5.Close();

                    // сохраняем на диске
                    XmlSerializer ser6 = new XmlSerializer(typeof(List<String>));
                    string path6 = Application.StartupPath.ToString() + @"\SaveSetting\MyTitle.xml"; ;
                    FileStream file6 = new FileStream(path6, FileMode.Create, FileAccess.Write, FileShare.None);
                    ser6.Serialize(file6, ADDtextBox1.title);
                    file6.Close();

                    try
                    {

                        File.WriteAllLines(Application.StartupPath.ToString() + @"\SaveSetting\SavaIni.xml", new string[] { Settings1.Default.IndexComponent.ToString(), Settings1.Default.IndexPoints.ToString(), Settings1.Default.ID.ToString() });
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
           
        }

        public class User : Label
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Settings1.Default.ID = 0;
            Settings1.Default.IndexComponent = 0;
            Settings1.Default.IndexPoints = 0;
            Settings1.Default.e = false;
            Settings1.Default.Save();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (ADDtextBox1.check[Settings1.Default.ID].Checked == false)
            {
                ADDtextBox1.tex[Settings1.Default.ID].Text = e.Start.ToShortDateString();
                monthCalendar1.Visible = false;
            }
            else
            {
                string[] result = e.Start.ToShortDateString().Split('.');

                switch (Convert.ToInt32(result[1]))
                {
                    case 1: month = "Января";
                        break;

                    case 2: month = "Февраля";
                        break;

                    case 3: month = "Марта";
                        break;

                    case 4: month = "Апреля";
                        break;

                    case 5: month = "Мая";
                        break;

                    case 6: month = "Июня";
                        break;

                    case 7: month = "Июля";
                        break;

                    case 8: month = "Августа";
                        break;

                    case 9: month = "Сентября";
                        break;

                    case 10: month = "Октября";
                        break;

                    case 11: month = "Ноября";
                        break;
                    case 12: month = "Декабря";
                        break;

                    default:
                        Console.WriteLine("Default case");
                        break;

                }





                ADDtextBox1.tex[Settings1.Default.ID].Text = result[0] + "." + month + "." + result[2];
                monthCalendar1.Visible = false;
            }
        }

        

    }
}

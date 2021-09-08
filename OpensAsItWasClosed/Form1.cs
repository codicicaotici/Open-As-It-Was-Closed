using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OpensAsItWasClosed
{
    public partial class Form1 : Form
    {
        ini myIni = new ini();
        public string  CurrentDirectory = Directory.GetCurrentDirectory();

        public Form1()
        {
            InitializeComponent();
            //leggi le impostazioni in entrata
            string iniFile = CurrentDirectory + "form1.ini";
            string settingTitle = "main_setting";
            if (myIni.getIniValue(iniFile, settingTitle, "FormWindowState", "") == "Maximized") { this.WindowState = System.Windows.Forms.FormWindowState.Maximized; }
            if (myIni.getIniValue(iniFile, settingTitle, "FormWindowState", "") == "Minimized") { this.WindowState = System.Windows.Forms.FormWindowState.Minimized; }
            if (myIni.getIniValue(iniFile, settingTitle, "FormWindowState", "") == "Normal")
            {   
                this.Left = Int32.Parse(myIni.getIniValue(iniFile, settingTitle, "MainLeft", ""));
                this.Top = Int32.Parse(myIni.getIniValue(iniFile, settingTitle, "MainTop", ""));
                this.Width = Int32.Parse(myIni.getIniValue(iniFile, settingTitle, "MainWidth", ""));
                this.Height = Int32.Parse(myIni.getIniValue(iniFile, settingTitle, "MainHeight", ""));
                this.StartPosition = FormStartPosition.Manual;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Salva le impostazioni in uscita
            string iniFile = CurrentDirectory + "form1.ini";
            string settingTitle = "main_setting";
            string winstate = "";
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                winstate = "Maximized";
                myIni.setIniValue(iniFile, settingTitle, "FormWindowState", winstate);
            }
            if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                winstate = "Minimized";
                myIni.setIniValue(iniFile, settingTitle, "FormWindowState", winstate);
            }
            if (this.WindowState == System.Windows.Forms.FormWindowState.Normal)
            {
                winstate = "Normal";
                myIni.setIniValue(iniFile, settingTitle, "FormWindowState", winstate);
                myIni.setIniValue(iniFile, settingTitle, "MainLeft", this.Left.ToString());
                myIni.setIniValue(iniFile, settingTitle, "MainTop", this.Top.ToString());
                myIni.setIniValue(iniFile, settingTitle, "MainWidth", this.Width.ToString());
                myIni.setIniValue(iniFile, settingTitle, "MainHeight", this.Height.ToString());
            }
            Close();
        }

        /* ****************************************** */

    }//public partial class Form1 : Form
}//namespace OpensAsItWasClosed

﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AgeOfQualcossaFitScreenLauncher
{
    public partial class Form1 : Form
    {
        private string AOQresparm = "";
        private string AO2resparm = "";
        private static string AOMX = "C:\\Program Files (x86)\\Microsoft Games\\Age of Mythology\\aomx.exe";
        private static string AOM = "C:\\Program Files (x86)\\Microsoft Games\\Age of Mythology\\aom.exe";
        private static string AOE2Conquer = "C:\\Program Files (x86)\\Microsoft Games\\Age of Empires II\\Age2_X1\\age2_x1.Exe";
        private static string AOE2 = "C:\\Program Files (x86)\\Microsoft Games\\Age of Empires II\\EMPIRES2.EXE";
        private StringCollection gamepath = new StringCollection();
        private StringCollection gamearg = new StringCollection();
        private int dx;
        private int dy;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             dx = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
             dy = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            // Checking screen resolution and set AOQresparm
            AOQresparm = " xres=" + dx.ToString()+ " yres="+ dy.ToString();
            labelres.Text = "SIZE:" + AOQresparm;
            if ((dx > 1279) && (dy > 1023))
            { AO2resparm = " 1280"; }
            else if ((dx > 1023) && (dy > 767))
            {    AO2resparm = " 1024";   }
            else if ((dx > 799) && (dy > 599))
            // 800x600
            // 1024x768
            // 1280x1024
            { AO2resparm = " 800"; }

            // Inspecting filesystem
            CheckAOGame("Age of Mythology", AOM, AOQresparm);
            CheckAOGame("Age of Mythology Titan Expansion", AOMX, AOQresparm);
            CheckAOGame("Age of Empires II", AOE2, AO2resparm);
            CheckAOGame("Age of Empires II The Conquer", AOE2Conquer, AO2resparm);

        }
        private void CheckAOGame(string Title, string Path, string Arg)
        {
            //If the game exist I add it to the Listbox on the form
            try

            { 
            FileInfo sFile = new FileInfo(AOMX);
            if (sFile.Exists)
            {
                listBox1.Items.Add(Title);
                gamepath.Add(Path);
                gamearg.Add(Arg);
            }
            }
            catch (Exception exception)

             {
                System.Diagnostics.Debug.Print(exception.Message + " but I don't care \n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >0)
                {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = gamepath[listBox1.SelectedIndex];
                startInfo.WorkingDirectory = new FileInfo(gamepath[listBox1.SelectedIndex]).Directory.FullName;

                startInfo.Arguments = gamearg[listBox1.SelectedIndex];
                Process.Start(startInfo);
            }
            else
            {
                labelres.Text = "Seesiona un zugo soea lista!";
            }
        }
    }
}

﻿using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{

   
    public partial class Form5 : MetroFramework.Forms.MetroForm
    {
        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        public Form5(){g.Clear(); InitializeComponent();}

        protected override void OnFormClosing(FormClosingEventArgs e) {Environment.Exit(0);}

        private void Form5_Load(object sender, EventArgs e) { var cx = new Form8(); cx.Movable = false; var gx = new Form14(); gx.Movable = false; }     
        private void metroLabel2_Click(object sender, EventArgs e){}
        private void metroLabel4_Click(object sender, EventArgs e){} 
        private void metroLabel5_Click(object sender, EventArgs e){}

        private void metroButton4_Click(object sender, EventArgs e)
        {
            var t = new IntegrateOS.selection_os();
            t.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var t = new WindowsSetup.Form9();
            t.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = new WindowsFormsApplication2.Form8();
            t.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var t = new WindowsFormsApplication2.Form14();
            t.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var t = new WindowsSetup.Form6();
            t.Show();
            this.Hide();
        }
    }
}

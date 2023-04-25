using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;
using System.Threading;
using System.Diagnostics;
using System.Reflection.Emit;

namespace konumü
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        private GeoCoordinateWatcher Watcher = null;
        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                if (Watcher.Position.Location.IsUnknown)
                {
                    button1.BackColor = Color.Red;
                    Watcher.Stop();
                }
                else
                {
                    button1.BackColor= Color.Green;
                    label2.Text = ("Latitude : " + (Watcher.Position.Location.Latitude).ToString());
                    label3.Text = ("Longitude : " + (Watcher.Position.Location.Longitude).ToString());
                    Watcher.Stop();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Watcher = new GeoCoordinateWatcher();
            Watcher.Stop();
            Watcher.StatusChanged += Watcher_StatusChanged;
            Watcher.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
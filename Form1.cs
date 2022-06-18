using Memory;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDEJ.Properties;
using System.Collections.Generic;

namespace PDEJ
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("KERNEL32.DLL")]
        public static extern IntPtr CreateToolhelp32Snapshot(uint flags, uint processid);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32First(IntPtr handle, ref ProcessEntry32 pe);
        [DllImport("KERNEL32.DLL")]
        public static extern int Process32Next(IntPtr handle, ref ProcessEntry32 pe);

        private async Task PutTaskDelay(int Time)
        {
            await Task.Delay(Time);
        }
        
        
        public long enumerable = new long();

        private int x;
       
        private static string string_0;
        private IContainer icontainer_0;

        public struct ProcessEntry32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        }

        public Mem MemLib = new Mem();
        public static bool bool_0 = false;

        public async void EasyHeadON()
        {
            bool_0 = true;
            if (!MemLib.OpenProcess("HD-Player.exe"))
            {

                return;
            }

            IEnumerable<long>  enumerable = await MemLib.AoBScan(0L, 2533274790395904L, "62 6F 6E 65 5F 48 69 70 73", writable: true, executable: true, string.Empty);
            if (enumerable.Count() != 0)
            {
                for (int i = 0; i < enumerable.Count(); i++)
                {
                    MemLib.WriteMemory(enumerable.ElementAt(i).ToString("X"), "bytes", "62 6f 6e 65 5f 48 65 61 64", string.Empty);
                }
            }
            else
            {
            }
            MemLib.CloseProcess();
            bool_0 = false;
        }


        public async void EasyHeadOFF()
        {
            bool_0 = true;
            if (!MemLib.OpenProcess("HD-Player.exe"))
            {

                return;
            }

            IEnumerable<long> source = await MemLib.AoBScan(67108864L, 4294967295L, "00 00 70 41 00 00 0C 42 00 00 20 41 00 00 A0 41", writable: true, executable: true, string.Empty);
            if (source.Count() != 0)
            {
                for (int i = 0; i < source.Count(); i++)
                {
                    MemLib.WriteMemory(source.ElementAt(i).ToString("X"), "bytes", "00 00 71 41 00 00 0F 38 00 00 72 41 00 00 47 45", string.Empty);
                }
            }
            else
            {
            }
            MemLib.CloseProcess();
            bool_0 = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private bool mouseDown;
        private Point lastLocation;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            

        }
        private void guna2Button1(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/c/PMTDVA");
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.buymeacoffee.com/pmtdva");
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Cheatinfo.aimbot.EnableCheat();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            infopopup popup = new infopopup();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                Console.WriteLine("You clicked OK");
            }
            else if (dialogresult == DialogResult.Abort)
            {
                Process[] _proceses = null;
                _proceses = Process.GetProcessesByName("Aimbot_Tutorial.exe");
                foreach (Process proces in _proceses)
                {
                    proces.Kill();
                }
            }
            popup.Dispose();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://pmtdvaofficial.000webhostapp.com/logar.php");
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

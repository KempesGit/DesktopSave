using System;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;

namespace DesktopSave
{
    public partial class FormMain : Form
    {
        #region PublicConst
        public const uint LVM_FIRST = 0x1000;
        public const uint LVM_GETITEMCOUNT = LVM_FIRST + 4;
        public const uint LVM_GETITEMW = LVM_FIRST + 75;
        public const uint LVM_SETITEMPOSITION = (LVM_FIRST + 15);
        public const uint LVM_GETITEMPOSITION = LVM_FIRST + 16;
        public const uint LVM_ARRANGE = LVM_FIRST + 22;
        public const uint PROCESS_VM_OPERATION = 0x0008;
        public const uint PROCESS_VM_READ = 0x0010;
        public const uint PROCESS_VM_WRITE = 0x0020;
        public const uint MEM_COMMIT = 0x1000;
        public const uint MEM_RELEASE = 0x8000;
        public const uint MEM_RESERVE = 0x2000;
        public const uint PAGE_READWRITE = 4;
        public const int LVIF_TEXT = 0x0001;
        public const int LVM_SETEXTENDEDLISTVIEWSTYLE = (int)LVM_FIRST + 54;
        public const int LVM_GETEXTENDEDLISTVIEWSTYLE = (int)LVM_FIRST + 55;
        public const int LVA_SNAPTOGRID = 0x0005;
        #endregion

        #region ImportDll
        [DllImport("kernel32.dll")]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll")]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint dwFreeType);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr handle);
        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, out uint vNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint dwProcessId);
        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);
        public delegate bool EnumWindowsProc(int hWnd, int lParam);
        #endregion

        private const string FILE_NAME = "DesktopSave";
        private const string FILE_EXT = "dsd";
        private const string regSubKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        private RegistryKey regKey = Registry.CurrentUser;
        private WindowsRegistryEditor winRegEditor;
        private string initDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private Point loc = Properties.Settings.Default.Location;
        private bool appStarted = false;
        Structs.DesktopIconStruct[] dsNewIcons;
        private Structs.DesktopLayoutFile dsLayoutFileStruct = new Structs.DesktopLayoutFile();
        private string dsFileName;
        private List<Structs.DesktopIconStruct> newIconsList;

        public FormMain()
        {
            this.Visible = false;
            InitializeComponent();

            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            //new
            dsLayoutFileStruct.desktopIcons = new List<Structs.DesktopIcons>();
            //end new

            SetMainFormSizeAndLocation();
            LoadAppliactionSettings();
            EnableMenuOptionStartWithWindows();
            SystemEvents_DisplaySettingsChanged(this, null);

            appStarted = true;
        }

        private void LoadAppliactionSettings()
        {
            this.tscbAutoRestore.SelectedIndex = Properties.Settings.Default.Autorestore;
            this.tscbRestore.SelectedIndex = Properties.Settings.Default.RestoreOnStartup;
            this.tscbStartWithWindows.SelectedIndex = Properties.Settings.Default.StartWithWindows;
            this.tscbDoubleClick.SelectedIndex = Properties.Settings.Default.DoubleClick;
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            this.tsslRezolution.Text = SystemInformation.VirtualScreen.Width.ToString() + "x" + SystemInformation.VirtualScreen.Height.ToString();

            dsFileName = initDirectory + @"\" + FILE_NAME + "_" +
                SystemInformation.VirtualScreen.Width.ToString() + "x" + SystemInformation.VirtualScreen.Height.ToString() + "." + FILE_EXT;

            if ((!appStarted) && (this.tscbRestore.SelectedIndex == 1))
            { return; }

            if (!File.Exists(dsFileName))
            { return; }

            LoadFile(dsFileName);
            FillListView();
            if (this.tscbAutoRestore.SelectedIndex == 0)
            {
                Thread.Sleep(250);
                btRestore_Click(sender, e); 
            }
        }

        private void EnableMenuOptionStartWithWindows()
        {
            //winRegEditor = new WindowsRegistryEditor();
            //tscbStartWithWindows.Enabled = winRegEditor.IsAnAdministrator();
            if (!tscbStartWithWindows.Enabled)
            { tscbStartWithWindows.SelectedIndex = 1; }
        }

        private void fmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                if (this.Visible)
                { MessageBoxHelper.PrepToCenterMessageBoxOnForm(this); }

                if (MessageBox.Show("Do you want to exit DesktopSave?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { e.Cancel = false; }
                else
                { e.Cancel = true; }
            }
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

            //Event 'SystemEvents.DisplaySettingsChanged' is static and you will need to detach your handlers before exiting from your program.
            SystemEvents.DisplaySettingsChanged -= SystemEvents_DisplaySettingsChanged;
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("Id");
            this.listView1.Columns.Add("Icon Name");
            this.listView1.Columns.Add("Icon Location");
            this.listView1.View = View.Details;

            this.listView2.ItemChecked -= this.listView2_ItemChecked;
            this.listView2.CheckBoxes = true;
            this.listView2.Columns.Add("Layout name");
            this.listView2.Columns.Add("Data");
            this.listView2.View = View.Details;
            this.listView2.ItemChecked += this.listView2_ItemChecked;

            HideWindow();
        }

        private void fmMain_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(dsFileName))
            { return; }

            LoadFile(dsFileName);
            FillListView();
            btRestore_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(dsFileName);
        }

        private void showWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }
        
        private void hideWIndowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideWindow();
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowWindow()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void HideWindow()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (this.tscbDoubleClick.SelectedIndex)
            {
                case 0:
                    if (listView2.CheckedIndices.Count > 0)
                    { listView2.Items[listView2.CheckedIndices[0]].Selected = true; }

                    if (listView2.SelectedIndices.Count > 0)
                    { btRestore_Click(sender, e); }
                    break;
                case 1:
                    if (this.WindowState == FormWindowState.Minimized)
                    { ShowWindow(); }
                    else
                    { HideWindow(); }
                    break;
            }
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            showWindowToolStripMenuItem.Enabled = (!this.Visible);
            hideWIndowToolStripMenuItem.Enabled = (this.Visible);
        }

        private void fmMain_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                Properties.Settings.Default.Width = this.Width;
                Properties.Settings.Default.Height = this.Height;
                Properties.Settings.Default.Save();
            }
        }

        private void fmMain_LocationChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (((this.Location.X >= 0) && (this.Location.X <= SystemInformation.VirtualScreen.Width)) &&
                    ((this.Location.Y >= 0) && (this.Location.Y <= SystemInformation.VirtualScreen.Height)))
                { Properties.Settings.Default.Location = this.Location; }
            }
        }

        private void fmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            { this.Hide(); }
        }

        private void restoreWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow();
            ResetMainWindowPosition();
        }

        private void tscbRestore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                Properties.Settings.Default.Autorestore = this.tscbAutoRestore.SelectedIndex;
                Properties.Settings.Default.RestoreOnStartup = this.tscbRestore.SelectedIndex;
                Properties.Settings.Default.StartWithWindows = this.tscbStartWithWindows.SelectedIndex;
                Properties.Settings.Default.DoubleClick = this.tscbDoubleClick.SelectedIndex;
                Properties.Settings.Default.Save();

                switch (this.tscbStartWithWindows.SelectedIndex)
                {
                    case 0:
                        StartApplicationWithWindowsOn();
                        break;
                    case 1:
                        StartApplicationWithWindowsOff();
                        break;
                }
            }
        }

        private void StartApplicationWithWindowsOn()
        {
            winRegEditor = new WindowsRegistryEditor();
            winRegEditor.baseRegistryKey = regKey;
            winRegEditor.subKey = regSubKey;
            winRegEditor.Write("DesktopSave", Application.ExecutablePath);
        }

        private void StartApplicationWithWindowsOff()
        {
            winRegEditor = new WindowsRegistryEditor();
            winRegEditor.baseRegistryKey = regKey;
            winRegEditor.subKey = regSubKey;
            winRegEditor.DeleteKey("DesktopSave");
        }

        private void LoadFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                dsLayoutFileStruct = (Structs.DesktopLayoutFile)formatter.Deserialize(fs);
            }
            catch (SerializationException error)
            {
                MessageBoxHelper.PrepToCenterMessageBoxOnForm(this);
                MessageBox.Show("Failed to deserialize. Reason: " + error.Message, "DesktopSave error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        private void SaveFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, dsLayoutFileStruct);
            }
            catch (SerializationException error)
            {
                MessageBoxHelper.PrepToCenterMessageBoxOnForm(this);
                MessageBox.Show("Failed to serialize. Reason: " + error.Message, "DesktopSave error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        private void FillListView()
        {
            try
            {
                if (this.listView2.Items.Count > 0)
                { this.listView2.Items.Clear(); }

                this.listView2.ItemChecked -= this.listView2_ItemChecked;
                this.listView2.SelectedIndexChanged -= this.listView2_SelectedIndexChanged;

                foreach (Structs.DesktopIcons itemValue in dsLayoutFileStruct.desktopIcons)
                { this.listView2.Items.Add(new ListViewItem(new string[] { itemValue.layoutName, itemValue.dateTime.ToString() })); }

                this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                if (dsLayoutFileStruct.defaultLayout > -1)
                {
                    this.listView2.Items[dsLayoutFileStruct.defaultLayout].Selected = true;
                    this.listView2.Items[dsLayoutFileStruct.defaultLayout].Checked = true;
                }

                EnableButtons();
                FillListViewIcons();
            }
            finally
            {
                this.listView2.ItemChecked += this.listView2_ItemChecked;
                this.listView2.SelectedIndexChanged += this.listView2_SelectedIndexChanged;
            }
        }

        private void FillListViewIcons()
        {
            if (this.listView1.Items.Count > 0)
            { this.listView1.Items.Clear(); }

            if (this.listView2.SelectedItems.Count == 0)
            {
                this.tsslIcons.Text = "0";
                return;
            }

            Structs.DesktopIcons desktopIcons = dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]];

            for (int i = 0; i < desktopIcons.desktopIconsStruct.Length; i++)
            {
                this.listView1.Items.Add(new ListViewItem(new string[] { i.ToString(), desktopIcons.desktopIconsStruct[i].iconName,
                    "{X=" + desktopIcons.desktopIconsStruct[i].iconPosX.ToString() + ",Y=" + desktopIcons.desktopIconsStruct[i].iconPosY.ToString() + "}"}));
            }
            
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            this.tsslIcons.Text = desktopIcons.desktopIconsStruct.Length.ToString();
        }

        private void SetMainFormSizeAndLocation()
        {
            this.Width = Properties.Settings.Default.Width;
            this.Height = Properties.Settings.Default.Height;
            this.Location = MiddleOfScreen();
        }

        private Point MiddleOfScreen()
        {
            if (((loc.X > SystemInformation.VirtualScreen.Width) || (loc.X <= 0)) ||
                ((loc.Y > SystemInformation.VirtualScreen.Height) || (loc.Y <= 0)))
            {
                loc.X = (SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2; 
                loc.Y = (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2;
            }

            return loc;
        }

        private void ResetMainWindowPosition()
        {
            loc.X = (SystemInformation.PrimaryMonitorSize.Width - this.Width) / 2;
            loc.Y = (SystemInformation.PrimaryMonitorSize.Height - this.Height) / 2;

            this.Location = loc;
        }

        private IntPtr vDesktopHandle, vHandle;
        private uint vProcessId;
        private int vItemCount;

        private void GetIconsPosition(string layoutName)
        {
            //Get the handle of the desktop listview
            vDesktopHandle = FindWindow("Progman", "Program Manager");
            vHandle = FindWindowEx(vDesktopHandle, IntPtr.Zero, "SHELLDLL_DefView", null);
            //for Vista/Win7/Win8
            if (vHandle == IntPtr.Zero)
            {
                EnumWindowsProc ewp = new EnumWindowsProc(EvalWindow);
                EnumWindows(ewp, 0);
            }
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "SysListView32", "FolderView");

            //Get total count of the icons on the desktop
            vItemCount = SendMessage(vHandle, LVM_GETITEMCOUNT, 0, 0);
            //this.tsslIcons.Text = vItemCount.ToString();

            int[][,] icons = new int[vItemCount][,];

            Structs.DesktopIcons dsIcons = new Structs.DesktopIcons();
            dsIcons.layoutName = layoutName;
            dsIcons.dateTime = DateTime.Now;
            dsIcons.desktopIconsStruct = new Structs.DesktopIconStruct[vItemCount];

            dsLayoutFileStruct.rezScreenX = SystemInformation.VirtualScreen.Width;
            dsLayoutFileStruct.rezScreenY = SystemInformation.VirtualScreen.Height;

            GetWindowThreadProcessId(vHandle, out vProcessId);

            IntPtr vProcess = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, vProcessId);
            IntPtr vPointer = VirtualAllocEx(vProcess, IntPtr.Zero, 4096, MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
            try
            {
                for (int j = 0; j < vItemCount; j++)
                {
                    byte[] vBuffer = new byte[256];
                    Structs.LVITEM[] vItem = new Structs.LVITEM[1];
                    vItem[0].mask = LVIF_TEXT;
                    vItem[0].iItem = j;
                    vItem[0].iSubItem = 0;
                    vItem[0].cchTextMax = vBuffer.Length;
                    vItem[0].pszText = (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(Structs.LVITEM)));

                    uint vNumberOfBytesRead = 0;
                    WriteProcessMemory(vProcess, vPointer, Marshal.UnsafeAddrOfPinnedArrayElement(vItem, 0), Marshal.SizeOf(typeof(Structs.LVITEM)), ref vNumberOfBytesRead);
                    SendMessage(vHandle, LVM_GETITEMW, j, (int)vPointer);
                    ReadProcessMemory(vProcess, (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(Structs.LVITEM))), Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0), vBuffer.Length, out vNumberOfBytesRead);
                    string vText = Encoding.Unicode.GetString(vBuffer, 0, (int)vNumberOfBytesRead);
                    string iconName = IconName(vText);

                    dsIcons.desktopIconsStruct[j].iconName = iconName;

                    //Get icon location
                    SendMessage(vHandle, LVM_GETITEMPOSITION, j, vPointer.ToInt32());
                    Point[] vPoint = new Point[1];
                    ReadProcessMemory(vProcess, vPointer, Marshal.UnsafeAddrOfPinnedArrayElement(vPoint, 0), Marshal.SizeOf(typeof(Point)), out vNumberOfBytesRead);
                    string iconLocation = vPoint[0].ToString();

                    dsIcons.desktopIconsStruct[j].iconPosX = vPoint[0].X;
                    dsIcons.desktopIconsStruct[j].iconPosY = vPoint[0].Y;
                }

                dsLayoutFileStruct.rezScreenX = SystemInformation.VirtualScreen.Width;
                dsLayoutFileStruct.rezScreenY = SystemInformation.VirtualScreen.Height;
                dsLayoutFileStruct.desktopIcons.Add(dsIcons);
            }
            finally
            {
                VirtualFreeEx(vProcess, vPointer, 0, MEM_RELEASE);
                CloseHandle(vProcess);
            }
        }

        private void GetNewIconsPosition()
        {
            //Get the handle of the desktop listview
            vDesktopHandle = FindWindow("Progman", "Program Manager");
            vHandle = FindWindowEx(vDesktopHandle, IntPtr.Zero, "SHELLDLL_DefView", null);
            //for Vista/Win7/Win8
            if (vHandle == IntPtr.Zero)
            {
                EnumWindowsProc ewp = new EnumWindowsProc(EvalWindow);
                EnumWindows(ewp, 0);
            }
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "SysListView32", "FolderView");

            //Get total count of the icons on the desktop
            vItemCount = SendMessage(vHandle, LVM_GETITEMCOUNT, 0, 0);

            int[][,] icons = new int[vItemCount][,];

            dsNewIcons = new Structs.DesktopIconStruct[vItemCount];

            GetWindowThreadProcessId(vHandle, out vProcessId);

            IntPtr vProcess = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, vProcessId);
            IntPtr vPointer = VirtualAllocEx(vProcess, IntPtr.Zero, 4096, MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
            try
            {
                for (int i = 0; i < vItemCount; i++)
                {
                    byte[] vBuffer = new byte[256];
                    DesktopSave.Structs.LVITEM[] vItem = new DesktopSave.Structs.LVITEM[1];
                    vItem[0].mask = LVIF_TEXT;
                    vItem[0].iItem = i;
                    vItem[0].iSubItem = 0;
                    vItem[0].cchTextMax = vBuffer.Length;
                    vItem[0].pszText = (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(DesktopSave.Structs.LVITEM)));

                    uint vNumberOfBytesRead = 0;
                    WriteProcessMemory(vProcess, vPointer, Marshal.UnsafeAddrOfPinnedArrayElement(vItem, 0), Marshal.SizeOf(typeof(DesktopSave.Structs.LVITEM)), ref vNumberOfBytesRead);
                    SendMessage(vHandle, LVM_GETITEMW, i, (int)vPointer);
                    ReadProcessMemory(vProcess, (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(DesktopSave.Structs.LVITEM))), Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0), vBuffer.Length, out vNumberOfBytesRead);
                    string vText = Encoding.Unicode.GetString(vBuffer, 0, (int)vNumberOfBytesRead);
                    string iconName = IconName(vText);

                    dsNewIcons[i].iconName = iconName;

                    //Get icon location
                    SendMessage(vHandle, LVM_GETITEMPOSITION, i, vPointer.ToInt32());
                    Point[] vPoint = new Point[1];
                    ReadProcessMemory(vProcess, vPointer, Marshal.UnsafeAddrOfPinnedArrayElement(vPoint, 0), Marshal.SizeOf(typeof(Point)), out vNumberOfBytesRead);
                    string iconLocation = vPoint[0].ToString();

                    dsNewIcons[i].iconPosX = vPoint[0].X;
                    dsNewIcons[i].iconPosY = vPoint[0].Y;
                }
            }
            finally
            {
                VirtualFreeEx(vProcess, vPointer, 0, MEM_RELEASE);
                CloseHandle(vProcess);
            }
        }
        
        private void RestoreIconsPosition()
        {
            //Get the handle of the desktop listview
            vDesktopHandle = FindWindow("Progman", "Program Manager");
            vHandle = FindWindowEx(vDesktopHandle, IntPtr.Zero, "SHELLDLL_DefView", null);
            //for Vista/Win7/Win8
            if (vHandle == IntPtr.Zero)
            {
                EnumWindowsProc ewp = new EnumWindowsProc(EvalWindow);
                EnumWindows(ewp, 0);
            }
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "SysListView32", "FolderView");

            int val = SendMessage(vHandle, LVM_GETEXTENDEDLISTVIEWSTYLE, 0, 0);
            //turn off 'align to grid'
            SendMessage(vHandle, LVM_SETEXTENDEDLISTVIEWSTYLE, 0x00080000, 0);

            //Get total count of the icons on the desktop
            vItemCount = SendMessage(vHandle, LVM_GETITEMCOUNT, 0, 0);

            GetWindowThreadProcessId(vHandle, out vProcessId);

            IntPtr vProcess = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, vProcessId);
            IntPtr vPointer = VirtualAllocEx(vProcess, IntPtr.Zero, 4096, MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
            try
            {
                for (int i = 0; i < dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct.Length; i++)
                {
                    for (int j = 0; j < vItemCount; j++)
                    {
                        byte[] vBuffer = new byte[256];
                        DesktopSave.Structs.LVITEM[] vItem = new DesktopSave.Structs.LVITEM[1];
                        vItem[0].mask = LVIF_TEXT;
                        vItem[0].iItem = j;
                        vItem[0].iSubItem = 0;
                        vItem[0].cchTextMax = vBuffer.Length;
                        vItem[0].pszText = (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(DesktopSave.Structs.LVITEM)));

                        uint vNumberOfBytesRead = 0;
                        WriteProcessMemory(vProcess, vPointer, Marshal.UnsafeAddrOfPinnedArrayElement(vItem, 0), Marshal.SizeOf(typeof(DesktopSave.Structs.LVITEM)), ref vNumberOfBytesRead);
                        SendMessage(vHandle, LVM_GETITEMW, j, vPointer.ToInt32());
                        ReadProcessMemory(vProcess, (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(DesktopSave.Structs.LVITEM))), Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0), vBuffer.Length, out vNumberOfBytesRead);
                        string vText = Encoding.Unicode.GetString(vBuffer, 0, (int)vNumberOfBytesRead);
                        string iconName = IconName(vText);

                        if (iconName == dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct[i].iconName)
                        {
                            //Get icon location
                            SendMessage(vHandle, LVM_GETITEMPOSITION, j, vPointer.ToInt32());
                            Point[] vPoint = new Point[1];
                            ReadProcessMemory(vProcess, vPointer, Marshal.UnsafeAddrOfPinnedArrayElement(vPoint, 0), Marshal.SizeOf(typeof(Point)), out vNumberOfBytesRead);
                            if ((vPoint[0].X != dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct[i].iconPosX) ||
                                (vPoint[0].Y != dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct[i].iconPosY))
                            {
                                vPoint[0].X = dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct[i].iconPosX;
                                vPoint[0].Y = dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct[i].iconPosY;
                                SendMessage(vHandle, LVM_SETITEMPOSITION, j, (int)MakeLParam(vPoint[0].X, vPoint[0].Y));
                            }

                            break;
                        }
                    }
                }
            }
            finally
            {
                //turn on 'align to grid'
                SendMessage(vHandle, LVM_SETEXTENDEDLISTVIEWSTYLE, 0, val);

                VirtualFreeEx(vProcess, vPointer, 0, MEM_RELEASE);
                CloseHandle(vProcess);
            }
        }

        private void RestoreNewIconsPosition()
        {
            //Get the handle of the desktop listview
            vDesktopHandle = FindWindow("Progman", "Program Manager");
            vHandle = FindWindowEx(vDesktopHandle, IntPtr.Zero, "SHELLDLL_DefView", null);
            //for Vista/Win7/Win8
            if (vHandle == IntPtr.Zero)
            {
                EnumWindowsProc ewp = new EnumWindowsProc(EvalWindow);
                EnumWindows(ewp, 0);
            }
            vHandle = FindWindowEx(vHandle, IntPtr.Zero, "SysListView32", "FolderView");

            int val = SendMessage(vHandle, LVM_GETEXTENDEDLISTVIEWSTYLE, 0, 0);
            //turn off 'align to grid'
            SendMessage(vHandle, LVM_SETEXTENDEDLISTVIEWSTYLE, 0x00080000, 0);

            //Get total count of the icons on the desktop
            vItemCount = SendMessage(vHandle, LVM_GETITEMCOUNT, 0, 0);

            GetWindowThreadProcessId(vHandle, out vProcessId);

            IntPtr vProcess = OpenProcess(PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, false, vProcessId);
            IntPtr vPointer = VirtualAllocEx(vProcess, IntPtr.Zero, 4096, MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
            try
            {
                for (int i = 0; i < dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct.Length; i++)
                {
                    for (int j = 0; j < vItemCount; j++)
                    {
                        byte[] vBuffer = new byte[256];
                        DesktopSave.Structs.LVITEM[] vItem = new DesktopSave.Structs.LVITEM[1];
                        vItem[0].mask = LVIF_TEXT;
                        vItem[0].iItem = j;
                        vItem[0].iSubItem = 0;
                        vItem[0].cchTextMax = vBuffer.Length;
                        vItem[0].pszText = (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(DesktopSave.Structs.LVITEM)));

                        uint vNumberOfBytesRead = 0;
                        WriteProcessMemory(vProcess, vPointer, Marshal.UnsafeAddrOfPinnedArrayElement(vItem, 0), Marshal.SizeOf(typeof(DesktopSave.Structs.LVITEM)), ref vNumberOfBytesRead);
                        SendMessage(vHandle, LVM_GETITEMW, j, vPointer.ToInt32());
                        ReadProcessMemory(vProcess, (IntPtr)((int)vPointer + Marshal.SizeOf(typeof(DesktopSave.Structs.LVITEM))), Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0), vBuffer.Length, out vNumberOfBytesRead);
                        string vText = Encoding.Unicode.GetString(vBuffer, 0, (int)vNumberOfBytesRead);
                        string iconName = IconName(vText);

                        if (iconName == dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct[i].iconName)
                        {
                            //Get icon location
                            SendMessage(vHandle, LVM_GETITEMPOSITION, j, vPointer.ToInt32());
                            Point[] vPoint = new Point[1];
                            ReadProcessMemory(vProcess, vPointer, Marshal.UnsafeAddrOfPinnedArrayElement(vPoint, 0), Marshal.SizeOf(typeof(Point)), out vNumberOfBytesRead);
                            if ((vPoint[0].X != dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct[i].iconPosX) ||
                                (vPoint[0].Y != dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct[i].iconPosY))
                            {
                                vPoint[0].X = dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct[i].iconPosX;
                                vPoint[0].Y = dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct[i].iconPosY;
                                SendMessage(vHandle, LVM_SETITEMPOSITION, j, (int)MakeLParam(vPoint[0].X, vPoint[0].Y));
                            }

                            break;
                        }
                    }
                }
            }
            finally
            {
                //turn on 'align to grid'
                SendMessage(vHandle, LVM_SETEXTENDEDLISTVIEWSTYLE, 0, val);

                VirtualFreeEx(vProcess, vPointer, 0, MEM_RELEASE);
                CloseHandle(vProcess);
            }
        }

        private bool EvalWindow(int hWnd, int lParam)
        {
            vHandle = FindWindowEx((IntPtr)hWnd, IntPtr.Zero, "SHELLDLL_DefView", null);
            if (vHandle == IntPtr.Zero)
                return true;
            else
                return false;
        }

        private long MakeLParam(int loWord, int hiWord)
        {
            return (long)((hiWord << 16) | (loWord & 0xffff));
        }

        private string IconName(string name)
        {
            return name.Substring(0, name.IndexOf("\0"));
        }

        private void NewIconsFinder()
        {
            bool newIcon;
            newIconsList = new List<Structs.DesktopIconStruct>();

            for (int i = 0; i < dsNewIcons.Length; i++)
            {
                newIcon = true;

                for (int j = 0; j < dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct.Length; j++)
                {
                    if (dsNewIcons[i].iconName == dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct[j].iconName)
                    {
                        newIcon = false;
                        break;
                    }
                }

                if (newIcon)
                { newIconsList.Add(dsNewIcons[i]); }
            }
        }

        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (this.Visible)
            {
                this.listView2.ItemChecked -= this.listView2_ItemChecked;

                foreach (ListViewItem item in this.listView2.Items)
                {
                    if (item != e.Item)
                    { item.Checked = false; }
                    else
                    { item.Selected = true; }
                }

                dsLayoutFileStruct.defaultLayout = -1;
                if (e.Item.Checked)
                { dsLayoutFileStruct.defaultLayout = e.Item.Index; }

                this.listView2.ItemChecked += this.listView2_ItemChecked;
            }
        }

        private void btAddLayout_Click(object sender, EventArgs e)
        {
            FormLayoutName fmLayoutName = new FormLayoutName();
            try
            {
                fmLayoutName.ShowDialog(this);
                if (fmLayoutName.DialogResult == DialogResult.OK)
                {
                    GetIconsPosition(fmLayoutName.tbLayoutName.Text.Trim());
                    FillListView();
                    FillListViewIcons();
                    EnableButtons();

                    saveToolStripMenuItem_Click(sender, e);
                }
            }
            finally
            {
                fmLayoutName.Dispose();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            MessageBoxHelper.PrepToCenterMessageBoxOnForm(this);
            if (MessageBox.Show("Do you want to delete selected layout?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            { return; }

            if (listView2.SelectedIndices[0] > -1)
            {
                dsLayoutFileStruct.desktopIcons.RemoveAt(listView2.SelectedIndices[0]);
                if (listView2.SelectedIndices[0] == dsLayoutFileStruct.defaultLayout)
                { dsLayoutFileStruct.defaultLayout = -1; }
                if (listView2.SelectedIndices[0] < dsLayoutFileStruct.defaultLayout)
                { dsLayoutFileStruct.defaultLayout = dsLayoutFileStruct.defaultLayout - 1; }
            }

            FillListView();
            FillListViewIcons();
            EnableButtons();

            saveToolStripMenuItem_Click(sender, e);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.tsmiDelete.Enabled = this.listView2.SelectedItems.Count > 0;
            this.tsmiRestore.Enabled = this.listView2.SelectedItems.Count > 0;
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            this.btAddLayout_Click(sender, e);
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            this.btDelete_Click(sender, e);
        }

        private void tsmiRestore_Click(object sender, EventArgs e)
        {
            this.btRestore_Click(sender, e);
        }

        private void btRestore_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count == 0)
            { return; }
            if (dsLayoutFileStruct.desktopIcons[listView2.SelectedIndices[0]].desktopIconsStruct.Length == 0)
            { return; }
            if ((dsLayoutFileStruct.rezScreenX != SystemInformation.VirtualScreen.Width) || (dsLayoutFileStruct.rezScreenY != SystemInformation.VirtualScreen.Height))
            { return; }
            if (!appStarted && (this.tscbRestore.SelectedIndex == 1))
            { return; }

            RestoreIconsPosition();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
            FillListViewIcons();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitApplicationToolStripMenuItem_Click(sender, e);
        }

        private void EnableButtons()
        {
            this.btDelete.Enabled = this.listView2.SelectedItems.Count > 0;
            this.btRestore.Enabled = this.listView2.SelectedItems.Count > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetNewIconsPosition();
            NewIconsFinder();
            RestoreNewIconsPosition();
        }
    }
}

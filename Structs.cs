using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DesktopSave
{
    public class Structs
    {
        [Serializable()]
        [StructLayout(LayoutKind.Sequential)]
        public struct LVITEM
        {
            public int mask;
            public int iItem;
            public int iSubItem;
            public int state;
            public int stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
            public int iIndent;
            public int iGroupId;
            public int cColumns;
            public IntPtr puColumns;
        }

        [Serializable()]
        [StructLayout(LayoutKind.Sequential)]
        public struct DesktopIconStruct
        {
            public string iconName;
            public int iconPosX;
            public int iconPosY;
        }

        [Serializable()]
        [StructLayout(LayoutKind.Sequential)]
        public struct RezSaverData
        {
            public int rezScreenX;
            public int rezScreenY;
            public DesktopIconStruct[] desktopIcons;
        }

        [Serializable()]
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        [Serializable()]
        [StructLayout(LayoutKind.Sequential)]
        public struct DesktopIcons
        {
            public string layoutName;
            public DateTime dateTime;
            public DesktopIconStruct[] desktopIconsStruct;
        }

        [Serializable()]
        [StructLayout(LayoutKind.Sequential)]
        public struct DesktopLayoutFile
        {
            public int rezScreenX;
            public int rezScreenY;
            public int defaultLayout;
            public List<DesktopIcons> desktopIcons;
        }
    }
}

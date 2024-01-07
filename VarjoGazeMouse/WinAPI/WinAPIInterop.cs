using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VarjoGazeMouse.WinAPI
{
    public static class WinAPIInterop
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static Rectangle GetActiveWindowBounds()
        {
            IntPtr handle = GetForegroundWindow();
            RECT rect;
            GetWindowRect(handle, out rect);
            return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        const int MOUSEEVENTF_MOVE = 0x0001;
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        public static void MoveMouse(double x, double y)
        {
            INPUT input = new INPUT();
            input.type = 0; // INPUT_MOUSE
            input.mi.dx = (int)(65535 * x);
            input.mi.dy = (int)(65535 * y);
            input.mi.mouseData = 0;
            input.mi.dwFlags = MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE;
            input.mi.time = 0;
            input.mi.dwExtraInfo = IntPtr.Zero;

            if (SendInput(1, ref input, Marshal.SizeOf(typeof(INPUT))) == 0)
                throw new Exception();
        }

    }
}

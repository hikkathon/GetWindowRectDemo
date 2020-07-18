using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace GetWindowRectDemo
{
    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        static void Main(string[] args)
        {
            Process process = Process.GetProcessesByName("wotblitz")[0];

            uint handle = (uint)process.MainWindowHandle; // хендл окна

            Rect r = new Rect();

            while (true)
            {
                if (GetWindowRect((IntPtr)handle, ref r))
                {
                    Console.Clear();
                    Console.WriteLine("Координата угла: " + r.left + " " + r.top + "\nРазмеры: " + (r.right - r.left) + " " + (r.bottom - r.top));
                    Thread.Sleep(100);
                }
            }
        }
    }
}

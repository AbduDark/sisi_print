using System.Runtime.InteropServices;
using System.Text;

namespace sisi_print
{
    public class RawPrinterHelper
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct DOCINFOW
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string? pOutputFile;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string? pDataType;
        }

        [DllImport("winspool.drv", EntryPoint = "OpenPrinterW", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

        [DllImport("winspool.drv", EntryPoint = "ClosePrinter", SetLastError = true)]
        private static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "StartDocPrinterW", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool StartDocPrinter(IntPtr hPrinter, int level, ref DOCINFOW pDocInfo);

        [DllImport("winspool.drv", EntryPoint = "EndDocPrinter", SetLastError = true)]
        private static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "StartPagePrinter", SetLastError = true)]
        private static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "EndPagePrinter", SetLastError = true)]
        private static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "WritePrinter", SetLastError = true)]
        private static extern bool WritePrinter(IntPtr hPrinter, byte[] pBytes, int dwCount, out int dwWritten);

        public static bool SendStringToPrinter(string printerName, string dataToSend)
        {
            IntPtr hPrinter = IntPtr.Zero;
            DOCINFOW docInfo = new DOCINFOW
            {
                pDocName = "Sisi Print Label",
                pOutputFile = null,
                pDataType = "RAW"
            };

            try
            {
                // Open printer
                if (!OpenPrinter(printerName, out hPrinter, IntPtr.Zero))
                {
                    return false;
                }

                // Start document
                if (!StartDocPrinter(hPrinter, 1, ref docInfo))
                {
                    return false;
                }

                // Start page
                if (!StartPagePrinter(hPrinter))
                {
                    return false;
                }

                // Convert string to bytes
                byte[] bytes = Encoding.UTF8.GetBytes(dataToSend);

                // Write to printer
                if (!WritePrinter(hPrinter, bytes, bytes.Length, out int written))
                {
                    return false;
                }

                // End page
                EndPagePrinter(hPrinter);

                // End document
                EndDocPrinter(hPrinter);

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (hPrinter != IntPtr.Zero)
                {
                    ClosePrinter(hPrinter);
                }
            }
        }
    }
}

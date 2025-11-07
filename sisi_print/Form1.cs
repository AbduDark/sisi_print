using System.Drawing.Printing;
using System.Text;
using System.Text.Json;

namespace sisi_print
{
    public partial class Form1 : Form
    {
        private AppSettings settings;
        private readonly string settingsFile = "settings.json";

        public Form1()
        {
            InitializeComponent();
            settings = new AppSettings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPrinters();
            LoadSettings();
            cmbFontSize.SelectedIndex = settings.FontSizeIndex;
        }

        private void LoadPrinters()
        {
            cmbPrinters.Items.Clear();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cmbPrinters.Items.Add(printer);
            }

            if (cmbPrinters.Items.Count > 0)
            {
                cmbPrinters.SelectedIndex = 0;
            }
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists(settingsFile))
                {
                    string json = File.ReadAllText(settingsFile);
                    var loadedSettings = JsonSerializer.Deserialize<AppSettings>(json);
                    if (loadedSettings is not null)
                    {
                        settings = loadedSettings;
                        ApplySettings();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatus($"خطأ في تحميل الإعدادات: {ex.Message}", true);
            }
        }

        private void ApplySettings()
        {
            txtFromNumber.Text = settings.FromNumber.ToString();
            txtToNumber.Text = settings.ToNumber.ToString();
            txtWidth.Text = settings.PaperWidth.ToString();
            txtHeight.Text = settings.PaperHeight.ToString();
            txtGap.Text = settings.Gap.ToString();
            cmbFontSize.SelectedIndex = settings.FontSizeIndex;
            chkPrintBarcode.Checked = settings.PrintBarcode;

            if (!string.IsNullOrEmpty(settings.PrinterName))
            {
                int index = cmbPrinters.FindStringExact(settings.PrinterName);
                if (index >= 0)
                {
                    cmbPrinters.SelectedIndex = index;
                }
            }
        }

        private void SaveSettings()
        {
            try
            {
                settings.FromNumber = int.TryParse(txtFromNumber.Text, out int from) ? from : 1;
                settings.ToNumber = int.TryParse(txtToNumber.Text, out int to) ? to : 10;
                settings.PaperWidth = int.TryParse(txtWidth.Text, out int width) ? width : 40;
                settings.PaperHeight = int.TryParse(txtHeight.Text, out int height) ? height : 30;
                settings.Gap = int.TryParse(txtGap.Text, out int gap) ? gap : 2;
                settings.FontSizeIndex = cmbFontSize.SelectedIndex;
                settings.PrintBarcode = chkPrintBarcode.Checked;
                settings.PrinterName = cmbPrinters.SelectedItem?.ToString() ?? "";

                string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(settingsFile, json);
            }
            catch (Exception ex)
            {
                ShowStatus($"خطأ في حفظ الإعدادات: {ex.Message}", true);
            }
        }

        private void btnTestPrint_Click(object sender, EventArgs e)
        {
            SaveSettings();
            PrintNumber(999);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveSettings();

            if (!ValidateInputs(out int from, out int to))
            {
                return;
            }

            if (MessageBox.Show($"هل تريد طباعة {to - from + 1} ورقة من {from} إلى {to}؟",
                "تأكيد الطباعة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            PrintRange(from, to);
        }

        private bool ValidateInputs(out int from, out int to)
        {
            from = 0;
            to = 0;

            if (!int.TryParse(txtFromNumber.Text, out from) || from < 0)
            {
                ShowStatus("الرجاء إدخال رقم بداية صحيح", true);
                return false;
            }

            if (!int.TryParse(txtToNumber.Text, out to) || to < 0)
            {
                ShowStatus("الرجاء إدخال رقم نهاية صحيح", true);
                return false;
            }

            if (to < from)
            {
                ShowStatus("رقم النهاية يجب أن يكون أكبر من أو يساوي رقم البداية", true);
                return false;
            }

            if (cmbPrinters.SelectedItem == null)
            {
                ShowStatus("الرجاء اختيار طابعة", true);
                return false;
            }

            return true;
        }

        private void PrintRange(int from, int to)
        {
            try
            {
                for (int i = from; i <= to; i++)
                {
                    PrintNumber(i);
                    ShowStatus($"جاري الطباعة: {i} من {to}", false);
                    Application.DoEvents();
                }

                ShowStatus($"تمت طباعة {to - from + 1} ورقة بنجاح", false);
            }
            catch (Exception ex)
            {
                ShowStatus($"خطأ في الطباعة: {ex.Message}", true);
            }
        }

        private void PrintNumber(int number)
        {
            try
            {
                string printerName = cmbPrinters.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(printerName))
                {
                    ShowStatus("الرجاء اختيار طابعة", true);
                    return;
                }

                int width = int.TryParse(txtWidth.Text, out int w) ? w : 40;
                int height = int.TryParse(txtHeight.Text, out int h) ? h : 30;
                int gap = int.TryParse(txtGap.Text, out int g) ? g : 2;

                // Get font size multiplier
                int fontMul = GetFontMultiplier();

                // Build TSPL commands
                string tsplCommands = BuildTSPLCommands(number, width, height, gap, fontMul);

                // Send to printer
                RawPrinterHelper.SendStringToPrinter(printerName, tsplCommands);
            }
            catch (Exception ex)
            {
                ShowStatus($"خطأ: {ex.Message}", true);
            }
        }

        private int GetFontMultiplier()
        {
            return cmbFontSize.SelectedIndex switch
            {
                0 => 2,  // صغير
                1 => 3,  // متوسط
                2 => 4,  // كبير
                _ => 3
            };
        }

        private string BuildTSPLCommands(int number, int width, int height, int gap, int fontMul)
        {
            StringBuilder sb = new();

            // Setup label size and gap
            sb.AppendLine($"SIZE {width} mm, {height} mm");
            sb.AppendLine($"GAP {gap} mm, 0 mm");
            sb.AppendLine("DIRECTION 0, 0");
            sb.AppendLine("SPEED 4");
            sb.AppendLine("DENSITY 10");
            sb.AppendLine("CODEPAGE 1252");
            sb.AppendLine("CLS");

            // Calculate positions (centered)
            int centerX = (width * 8) / 2; // Convert mm to dots (8 dots/mm at 203 DPI)
            int textY = 40;

            // Print number text (centered)
            string numberText = number.ToString();
            int textOffset = (numberText.Length * fontMul * 12) / 2; // Approximate centering
            sb.AppendLine($"TEXT {centerX - textOffset}, {textY}, \"4\", 0, {fontMul}, {fontMul}, \"{numberText}\"");

            // Print barcode if enabled
            if (chkPrintBarcode.Checked)
            {
                int barcodeY = textY + (fontMul * 30) + 10;
                int barcodeHeight = 50;
                int barcodeX = centerX - 60; // Center barcode

                sb.AppendLine($"BARCODE {barcodeX}, {barcodeY}, \"128\", {barcodeHeight}, 1, 0, 2, 2, \"{numberText}\"");
            }

            // Print the label
            sb.AppendLine("PRINT 1");

            return sb.ToString();
        }

        private void ShowStatus(string message, bool isError)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = isError ? Color.Red : Color.Green;
        }
    }

    public class AppSettings
    {
        public int FromNumber { get; set; } = 1;
        public int ToNumber { get; set; } = 10;
        public int PaperWidth { get; set; } = 40;
        public int PaperHeight { get; set; } = 30;
        public int Gap { get; set; } = 2;
        public int FontSizeIndex { get; set; } = 1;
        public bool PrintBarcode { get; set; } = true;
        public string PrinterName { get; set; } = "";
    }
}

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
            PrintTwoNumbers(999, 1000);
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
                int sheetsCount = 0;
                for (int i = from; i <= to; i += 2)
                {
                    int number1 = i;
                    int number2 = (i + 1 <= to) ? i + 1 : i;
                    
                    PrintTwoNumbers(number1, number2);
                    sheetsCount++;
                    ShowStatus($"جاري الطباعة: ورقة {sheetsCount} (أرقام {number1}-{number2})", false);
                    Application.DoEvents();
                }

                ShowStatus($"تمت طباعة {sheetsCount} ورقة بنجاح (أرقام {from}-{to})", false);
            }
            catch (Exception ex)
            {
                ShowStatus($"خطأ في الطباعة: {ex.Message}", true);
            }
        }

        private void PrintTwoNumbers(int number1, int number2)
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

                // Build TSPL commands for two numbers
                string tsplCommands = BuildTSPLCommandsForTwo(number1, number2, width, height, gap, fontMul);

                // Send to printer
                bool success = RawPrinterHelper.SendStringToPrinter(printerName, tsplCommands);
                
                if (!success)
                {
                    ShowStatus($"فشل إرسال الأرقام {number1}, {number2} إلى الطابعة. تأكد من تشغيل الطابعة واتصالها.", true);
                }
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

        private string BuildTSPLCommandsForTwo(int number1, int number2, int width, int height, int gap, int fontMul)
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

            // Convert mm to dots (8 dots/mm at 203 DPI)
            int dotsPerMm = 8;
            int centerX = (width * dotsPerMm) / 2;
            int heightInDots = height * dotsPerMm;

            // Position for first number (upper half)
            int upperSectionY = heightInDots / 4;
            PrintNumberSection(sb, number1, centerX, upperSectionY, fontMul);

            // Position for second number (lower half)
            int lowerSectionY = (heightInDots * 3) / 4;
            PrintNumberSection(sb, number2, centerX, lowerSectionY, fontMul);

            // Print the label
            sb.AppendLine("PRINT 1");

            return sb.ToString();
        }

        private void PrintNumberSection(StringBuilder sb, int number, int centerX, int positionY, int fontMul)
        {
            // Print number text (centered)
            string numberText = number.ToString();
            int textWidth = numberText.Length * fontMul * 12;
            int textX = centerX - (textWidth / 2);
            
            sb.AppendLine($"TEXT {textX}, {positionY}, \"4\", 0, {fontMul}, {fontMul}, \"{numberText}\"");

            // Print barcode if enabled (below the text)
            if (chkPrintBarcode.Checked)
            {
                int barcodeY = positionY + (fontMul * 25) + 5;
                int barcodeHeight = 35;
                int barcodeWidth = numberText.Length * 15;
                int barcodeX = centerX - (barcodeWidth / 2);

                sb.AppendLine($"BARCODE {barcodeX}, {barcodeY}, \"128\", {barcodeHeight}, 1, 0, 2, 2, \"{numberText}\"");
            }
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

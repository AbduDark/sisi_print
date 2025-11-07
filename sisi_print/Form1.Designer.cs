namespace sisi_print
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.lblFromNumber = new System.Windows.Forms.Label();
            this.txtFromNumber = new System.Windows.Forms.TextBox();
            this.lblToNumber = new System.Windows.Forms.Label();
            this.txtToNumber = new System.Windows.Forms.TextBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblGap = new System.Windows.Forms.Label();
            this.txtGap = new System.Windows.Forms.TextBox();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.cmbFontSize = new System.Windows.Forms.ComboBox();
            this.chkPrintBarcode = new System.Windows.Forms.CheckBox();
            this.btnTestPrint = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(140, 20);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(300, 25);
            this.cmbPrinters.TabIndex = 0;
            // 
            // lblPrinter
            // 
            this.lblPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrinter.Location = new System.Drawing.Point(460, 23);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(56, 19);
            this.lblPrinter.TabIndex = 1;
            this.lblPrinter.Text = "الطابعة:";
            // 
            // lblFromNumber
            // 
            this.lblFromNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromNumber.AutoSize = true;
            this.lblFromNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFromNumber.Location = new System.Drawing.Point(460, 63);
            this.lblFromNumber.Name = "lblFromNumber";
            this.lblFromNumber.Size = new System.Drawing.Size(50, 19);
            this.lblFromNumber.TabIndex = 2;
            this.lblFromNumber.Text = "من رقم:";
            // 
            // txtFromNumber
            // 
            this.txtFromNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFromNumber.Location = new System.Drawing.Point(290, 60);
            this.txtFromNumber.Name = "txtFromNumber";
            this.txtFromNumber.Size = new System.Drawing.Size(150, 25);
            this.txtFromNumber.TabIndex = 3;
            this.txtFromNumber.Text = "1";
            this.txtFromNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblToNumber
            // 
            this.lblToNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToNumber.AutoSize = true;
            this.lblToNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblToNumber.Location = new System.Drawing.Point(460, 103);
            this.lblToNumber.Name = "lblToNumber";
            this.lblToNumber.Size = new System.Drawing.Size(50, 19);
            this.lblToNumber.TabIndex = 4;
            this.lblToNumber.Text = "إلى رقم:";
            // 
            // txtToNumber
            // 
            this.txtToNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtToNumber.Location = new System.Drawing.Point(290, 100);
            this.txtToNumber.Name = "txtToNumber";
            this.txtToNumber.Size = new System.Drawing.Size(150, 25);
            this.txtToNumber.TabIndex = 5;
            this.txtToNumber.Text = "10";
            this.txtToNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblWidth
            // 
            this.lblWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWidth.Location = new System.Drawing.Point(460, 143);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(79, 19);
            this.lblWidth.TabIndex = 6;
            this.lblWidth.Text = "عرض الورقة (مم):";
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWidth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtWidth.Location = new System.Drawing.Point(290, 140);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(150, 25);
            this.txtWidth.TabIndex = 7;
            this.txtWidth.Text = "40";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHeight
            // 
            this.lblHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHeight.Location = new System.Drawing.Point(460, 183);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(93, 19);
            this.lblHeight.TabIndex = 8;
            this.lblHeight.Text = "ارتفاع الورقة (مم):";
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHeight.Location = new System.Drawing.Point(290, 180);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(150, 25);
            this.txtHeight.TabIndex = 9;
            this.txtHeight.Text = "30";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGap
            // 
            this.lblGap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGap.AutoSize = true;
            this.lblGap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGap.Location = new System.Drawing.Point(460, 223);
            this.lblGap.Name = "lblGap";
            this.lblGap.Size = new System.Drawing.Size(62, 19);
            this.lblGap.TabIndex = 10;
            this.lblGap.Text = "Gap (مم):";
            // 
            // txtGap
            // 
            this.txtGap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGap.Location = new System.Drawing.Point(290, 220);
            this.txtGap.Name = "txtGap";
            this.txtGap.Size = new System.Drawing.Size(150, 25);
            this.txtGap.TabIndex = 11;
            this.txtGap.Text = "2";
            this.txtGap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblFontSize
            // 
            this.lblFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFontSize.Location = new System.Drawing.Point(460, 263);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(62, 19);
            this.lblFontSize.TabIndex = 12;
            this.lblFontSize.Text = "حجم الخط:";
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontSize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFontSize.FormattingEnabled = true;
            this.cmbFontSize.Items.AddRange(new object[] {
            "صغير",
            "متوسط",
            "كبير"});
            this.cmbFontSize.Location = new System.Drawing.Point(290, 260);
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(150, 25);
            this.cmbFontSize.TabIndex = 13;
            // 
            // chkPrintBarcode
            // 
            this.chkPrintBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPrintBarcode.AutoSize = true;
            this.chkPrintBarcode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPrintBarcode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkPrintBarcode.Location = new System.Drawing.Point(290, 305);
            this.chkPrintBarcode.Name = "chkPrintBarcode";
            this.chkPrintBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPrintBarcode.Size = new System.Drawing.Size(223, 23);
            this.chkPrintBarcode.TabIndex = 14;
            this.chkPrintBarcode.Text = "طباعة باركود Code128 تحت الرقم";
            this.chkPrintBarcode.UseVisualStyleBackColor = true;
            // 
            // btnTestPrint
            // 
            this.btnTestPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestPrint.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTestPrint.Location = new System.Drawing.Point(310, 350);
            this.btnTestPrint.Name = "btnTestPrint";
            this.btnTestPrint.Size = new System.Drawing.Size(130, 40);
            this.btnTestPrint.TabIndex = 15;
            this.btnTestPrint.Text = "طباعة اختبار";
            this.btnTestPrint.UseVisualStyleBackColor = true;
            this.btnTestPrint.Click += new System.EventHandler(this.btnTestPrint_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Location = new System.Drawing.Point(160, 350);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(130, 40);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Text = "طباعة";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(140, 410);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStatus.Size = new System.Drawing.Size(373, 40);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "جاهز";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnTestPrint);
            this.Controls.Add(this.chkPrintBarcode);
            this.Controls.Add(this.cmbFontSize);
            this.Controls.Add(this.lblFontSize);
            this.Controls.Add(this.txtGap);
            this.Controls.Add(this.lblGap);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.txtToNumber);
            this.Controls.Add(this.lblToNumber);
            this.Controls.Add(this.txtFromNumber);
            this.Controls.Add(this.lblFromNumber);
            this.Controls.Add(this.lblPrinter);
            this.Controls.Add(this.cmbPrinters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "طباعة الأرقام - Sisi Print";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPrinters;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.Label lblFromNumber;
        private System.Windows.Forms.TextBox txtFromNumber;
        private System.Windows.Forms.Label lblToNumber;
        private System.Windows.Forms.TextBox txtToNumber;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label lblGap;
        private System.Windows.Forms.TextBox txtGap;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.ComboBox cmbFontSize;
        private System.Windows.Forms.CheckBox chkPrintBarcode;
        private System.Windows.Forms.Button btnTestPrint;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblStatus;
    }
}

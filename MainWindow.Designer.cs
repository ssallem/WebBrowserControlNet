namespace WebBrowserControlNet
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnFindSearchText = new System.Windows.Forms.Button();
            this.txtSearchBrowser = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtSearchAddress = new System.Windows.Forms.TextBox();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFindSearchText
            // 
            this.btnFindSearchText.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFindSearchText.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFindSearchText.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnFindSearchText.Location = new System.Drawing.Point(10, 10);
            this.btnFindSearchText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFindSearchText.Name = "btnFindSearchText";
            this.btnFindSearchText.Size = new System.Drawing.Size(696, 32);
            this.btnFindSearchText.TabIndex = 0;
            this.btnFindSearchText.Text = "Search Text";
            this.btnFindSearchText.UseVisualStyleBackColor = true;
            this.btnFindSearchText.Click += new System.EventHandler(this.btnFindSearchText_Click);
            // 
            // txtSearchBrowser
            // 
            this.txtSearchBrowser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchBrowser.Location = new System.Drawing.Point(0, 0);
            this.txtSearchBrowser.Multiline = true;
            this.txtSearchBrowser.Name = "txtSearchBrowser";
            this.txtSearchBrowser.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSearchBrowser.Size = new System.Drawing.Size(696, 213);
            this.txtSearchBrowser.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(10, 57);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtSearchBrowser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtSearchAddress);
            this.splitContainer1.Size = new System.Drawing.Size(696, 481);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtSearchAddress
            // 
            this.txtSearchAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchAddress.Location = new System.Drawing.Point(0, 0);
            this.txtSearchAddress.Multiline = true;
            this.txtSearchAddress.Name = "txtSearchAddress";
            this.txtSearchAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSearchAddress.Size = new System.Drawing.Size(696, 258);
            this.txtSearchAddress.TabIndex = 2;
            // 
            // pnlSpacer
            // 
            this.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpacer.Location = new System.Drawing.Point(10, 42);
            this.pnlSpacer.Name = "pnlSpacer";
            this.pnlSpacer.Size = new System.Drawing.Size(696, 15);
            this.pnlSpacer.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(716, 548);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlSpacer);
            this.Controls.Add(this.btnFindSearchText);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Chrome Search Text";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFindSearchText;
        private System.Windows.Forms.TextBox txtSearchBrowser;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtSearchAddress;
        private System.Windows.Forms.Panel pnlSpacer;
    }
}
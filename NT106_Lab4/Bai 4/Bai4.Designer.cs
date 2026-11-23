namespace NT106_Lab4.Bai_4
{
    partial class Bai4
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
            label1 = new Label();
            txtURL = new TextBox();
            btnFetch = new Button();
            btnOpenBooking = new Button();
            pnlHeader = new Panel();
            panel1 = new Panel();
            pnlProgress = new Panel();
            progressBar = new ProgressBar();
            lblStatus = new Label();
            flpMovies = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlProgress.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text Semibold", 25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(245, 9);
            label1.Name = "label1";
            label1.Size = new Size(342, 49);
            label1.TabIndex = 0;
            label1.Text = "PHIM ĐANG CHIẾU";
            // 
            // txtURL
            // 
            txtURL.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtURL.Location = new Point(12, 73);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(516, 29);
            txtURL.TabIndex = 1;
            txtURL.Text = "https://betacinemas.vn/phim.htm";
            // 
            // btnFetch
            // 
            btnFetch.BackColor = SystemColors.ScrollBar;
            btnFetch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFetch.Location = new Point(551, 64);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(128, 39);
            btnFetch.TabIndex = 2;
            btnFetch.Text = "Tải phim";
            btnFetch.UseVisualStyleBackColor = false;
            btnFetch.Click += btnFetch_Click;
            // 
            // btnOpenBooking
            // 
            btnOpenBooking.BackColor = SystemColors.ScrollBar;
            btnOpenBooking.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenBooking.Location = new Point(700, 64);
            btnOpenBooking.Name = "btnOpenBooking";
            btnOpenBooking.Size = new Size(128, 39);
            btnOpenBooking.TabIndex = 3;
            btnOpenBooking.Text = "Đặt vé";
            btnOpenBooking.UseVisualStyleBackColor = false;
            btnOpenBooking.Click += btnOpenBooking_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(panel1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(840, 139);
            pnlHeader.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(840, 139);
            panel1.TabIndex = 5;
            // 
            // pnlProgress
            // 
            pnlProgress.Controls.Add(lblStatus);
            pnlProgress.Controls.Add(progressBar);
            pnlProgress.Dock = DockStyle.Top;
            pnlProgress.Location = new Point(0, 139);
            pnlProgress.Name = "pnlProgress";
            pnlProgress.Size = new Size(840, 100);
            pnlProgress.TabIndex = 5;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 7);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(816, 32);
            progressBar.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(12, 57);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(321, 25);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Nhấn Tải phim để trích xuất dữ liệu.";
            // 
            // flpMovies
            // 
            flpMovies.AutoScroll = true;
            flpMovies.Dock = DockStyle.Fill;
            flpMovies.FlowDirection = FlowDirection.TopDown;
            flpMovies.Location = new Point(0, 239);
            flpMovies.Name = "flpMovies";
            flpMovies.Padding = new Padding(12);
            flpMovies.Size = new Size(840, 277);
            flpMovies.TabIndex = 6;
            flpMovies.WrapContents = false;
            flpMovies.Resize += flpMovies_Resize;
            // 
            // Bai4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(840, 516);
            Controls.Add(flpMovies);
            Controls.Add(btnOpenBooking);
            Controls.Add(btnFetch);
            Controls.Add(txtURL);
            Controls.Add(label1);
            Controls.Add(pnlProgress);
            Controls.Add(pnlHeader);
            Name = "Bai4";
            Text = "Bai4";
            Load += Bai4_Load;
            pnlHeader.ResumeLayout(false);
            pnlProgress.ResumeLayout(false);
            pnlProgress.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtURL;
        private Button btnFetch;
        private Button btnOpenBooking;
        private Panel pnlHeader;
        private Panel panel1;
        private Panel pnlProgress;
        private Label lblStatus;
        private ProgressBar progressBar;
        private FlowLayoutPanel flpMovies;
    }
}
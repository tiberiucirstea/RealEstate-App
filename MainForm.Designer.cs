namespace RealEstateAgency
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnProperties = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnRequests = new System.Windows.Forms.Button();
            this.btnOffers = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlProperties = new System.Windows.Forms.Panel();
            this.pnlClients = new System.Windows.Forms.Panel();
            this.pnlRequests = new System.Windows.Forms.Panel();
            this.pnlOffers = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.pnlSidebar.Controls.Add(this.lblTitle);
            this.pnlSidebar.Controls.Add(this.btnProperties);
            this.pnlSidebar.Controls.Add(this.btnClients);
            this.pnlSidebar.Controls.Add(this.btnRequests);
            this.pnlSidebar.Controls.Add(this.btnOffers);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Size = new System.Drawing.Size(200, 750);

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Size = new System.Drawing.Size(200, 90);
            this.lblTitle.Text = "REAL ESTATE\r\nAGENCY";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnProperties
            this.btnProperties.BackColor = System.Drawing.Color.FromArgb(38, 50, 56);
            this.btnProperties.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProperties.FlatAppearance.BorderSize = 0;
            this.btnProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProperties.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProperties.ForeColor = System.Drawing.Color.White;
            this.btnProperties.Location = new System.Drawing.Point(0, 110);
            this.btnProperties.Size = new System.Drawing.Size(200, 50);
            this.btnProperties.Text = "Properties";
            this.btnProperties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProperties.UseVisualStyleBackColor = false;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);

            // btnClients
            this.btnClients.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Location = new System.Drawing.Point(0, 160);
            this.btnClients.Size = new System.Drawing.Size(200, 50);
            this.btnClients.Text = "Clients";
            this.btnClients.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);

            // btnRequests
            this.btnRequests.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequests.FlatAppearance.BorderSize = 0;
            this.btnRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRequests.ForeColor = System.Drawing.Color.White;
            this.btnRequests.Location = new System.Drawing.Point(0, 210);
            this.btnRequests.Size = new System.Drawing.Size(200, 50);
            this.btnRequests.Text = "Requests";
            this.btnRequests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRequests.UseVisualStyleBackColor = false;
            this.btnRequests.Click += new System.EventHandler(this.btnRequests_Click);

            // btnOffers
            this.btnOffers.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnOffers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOffers.FlatAppearance.BorderSize = 0;
            this.btnOffers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOffers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOffers.ForeColor = System.Drawing.Color.White;
            this.btnOffers.Location = new System.Drawing.Point(0, 260);
            this.btnOffers.Size = new System.Drawing.Size(200, 50);
            this.btnOffers.Text = "Offers";
            this.btnOffers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOffers.UseVisualStyleBackColor = false;
            this.btnOffers.Click += new System.EventHandler(this.btnOffers_Click);

            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.pnlProperties);
            this.pnlContent.Controls.Add(this.pnlClients);
            this.pnlContent.Controls.Add(this.pnlRequests);
            this.pnlContent.Controls.Add(this.pnlOffers);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;

            // pnlProperties
            this.pnlProperties.BackColor = System.Drawing.Color.White;
            this.pnlProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProperties.Visible = true;

            // pnlClients
            this.pnlClients.BackColor = System.Drawing.Color.White;
            this.pnlClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClients.Visible = false;

            // pnlRequests
            this.pnlRequests.BackColor = System.Drawing.Color.White;
            this.pnlRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRequests.Visible = false;

            // pnlOffers
            this.pnlOffers.BackColor = System.Drawing.Color.White;
            this.pnlOffers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOffers.Visible = false;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Real Estate Agency";
            this.Load += new System.EventHandler(this.MainForm_Load);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnRequests;
        private System.Windows.Forms.Button btnOffers;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlProperties;
        private System.Windows.Forms.Panel pnlClients;
        private System.Windows.Forms.Panel pnlRequests;
        private System.Windows.Forms.Panel pnlOffers;
    }
}

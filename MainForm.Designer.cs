namespace RealEstateAgency
{
    partial class MainForm
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnProperties = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnRequests = new System.Windows.Forms.Button();
            this.btnOffers = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlProperties = new System.Windows.Forms.Panel();
            this.btnAddProperty = new System.Windows.Forms.Button();
            this.btnEditProperty = new System.Windows.Forms.Button();
            this.btnDeleteProperty = new System.Windows.Forms.Button();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.dgvProperties = new System.Windows.Forms.DataGridView();
            this.pnlPropertyForm = new System.Windows.Forms.Panel();
            this.lblPropType = new System.Windows.Forms.Label();
            this.cmbPropType = new System.Windows.Forms.ComboBox();
            this.lblPropAddress = new System.Windows.Forms.Label();
            this.txtPropAddress = new System.Windows.Forms.TextBox();
            this.lblPropCity = new System.Windows.Forms.Label();
            this.txtPropCity = new System.Windows.Forms.TextBox();
            this.lblPropArea = new System.Windows.Forms.Label();
            this.numPropArea = new System.Windows.Forms.NumericUpDown();
            this.lblPropPrice = new System.Windows.Forms.Label();
            this.numPropPrice = new System.Windows.Forms.NumericUpDown();
            this.lblPropTransaction = new System.Windows.Forms.Label();
            this.cmbPropTransaction = new System.Windows.Forms.ComboBox();
            this.btnSaveProperty = new System.Windows.Forms.Button();
            this.btnCancelProperty = new System.Windows.Forms.Button();
            this.pnlClients = new System.Windows.Forms.Panel();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.pnlClientForm = new System.Windows.Forms.Panel();
            this.lblClientLastName = new System.Windows.Forms.Label();
            this.txtClientLastName = new System.Windows.Forms.TextBox();
            this.lblClientFirstName = new System.Windows.Forms.Label();
            this.txtClientFirstName = new System.Windows.Forms.TextBox();
            this.lblClientPhone = new System.Windows.Forms.Label();
            this.txtClientPhone = new System.Windows.Forms.TextBox();
            this.lblClientEmail = new System.Windows.Forms.Label();
            this.txtClientEmail = new System.Windows.Forms.TextBox();
            this.btnSaveClient = new System.Windows.Forms.Button();
            this.btnCancelClient = new System.Windows.Forms.Button();
            this.pnlRequests = new System.Windows.Forms.Panel();
            this.pnlOffers = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlProperties.SuspendLayout();
            this.pnlPropertyForm.SuspendLayout();
            this.pnlClients.SuspendLayout();
            this.pnlClientForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPropArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPropPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();
            //
            // pnlSidebar
            //
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.pnlSidebar.Controls.Add(this.lblTitle);
            this.pnlSidebar.Controls.Add(this.btnProperties);
            this.pnlSidebar.Controls.Add(this.btnClients);
            this.pnlSidebar.Controls.Add(this.btnRequests);
            this.pnlSidebar.Controls.Add(this.btnOffers);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 700);
            this.pnlSidebar.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 90);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "REAL ESTATE\r\nAGENCY";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnProperties
            //
            this.btnProperties.BackColor = System.Drawing.Color.FromArgb(38, 50, 56);
            this.btnProperties.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProperties.FlatAppearance.BorderSize = 0;
            this.btnProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProperties.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProperties.ForeColor = System.Drawing.Color.White;
            this.btnProperties.Location = new System.Drawing.Point(0, 110);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(200, 50);
            this.btnProperties.TabIndex = 1;
            this.btnProperties.Text = "Properties";
            this.btnProperties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProperties.UseVisualStyleBackColor = false;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            //
            // btnClients
            //
            this.btnClients.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Location = new System.Drawing.Point(0, 160);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(200, 50);
            this.btnClients.TabIndex = 2;
            this.btnClients.Text = "Clients";
            this.btnClients.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            //
            // btnRequests
            //
            this.btnRequests.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequests.FlatAppearance.BorderSize = 0;
            this.btnRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRequests.ForeColor = System.Drawing.Color.White;
            this.btnRequests.Location = new System.Drawing.Point(0, 210);
            this.btnRequests.Name = "btnRequests";
            this.btnRequests.Size = new System.Drawing.Size(200, 50);
            this.btnRequests.TabIndex = 3;
            this.btnRequests.Text = "Requests";
            this.btnRequests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRequests.UseVisualStyleBackColor = false;
            this.btnRequests.Click += new System.EventHandler(this.btnRequests_Click);
            //
            // btnOffers
            //
            this.btnOffers.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnOffers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOffers.FlatAppearance.BorderSize = 0;
            this.btnOffers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOffers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOffers.ForeColor = System.Drawing.Color.White;
            this.btnOffers.Location = new System.Drawing.Point(0, 260);
            this.btnOffers.Name = "btnOffers";
            this.btnOffers.Size = new System.Drawing.Size(200, 50);
            this.btnOffers.TabIndex = 4;
            this.btnOffers.Text = "Offers";
            this.btnOffers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOffers.UseVisualStyleBackColor = false;
            this.btnOffers.Click += new System.EventHandler(this.btnOffers_Click);
            //
            // pnlContent
            //
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.pnlProperties);
            this.pnlContent.Controls.Add(this.pnlClients);
            this.pnlContent.Controls.Add(this.pnlRequests);
            this.pnlContent.Controls.Add(this.pnlOffers);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1000, 700);
            this.pnlContent.TabIndex = 1;
            //
            // pnlProperties
            //
            this.pnlProperties.BackColor = System.Drawing.Color.White;
            this.pnlProperties.Controls.Add(this.dgvProperties);
            this.pnlProperties.Controls.Add(this.pnlPropertyForm);
            this.pnlProperties.Controls.Add(this.cmbFilterType);
            this.pnlProperties.Controls.Add(this.btnDeleteProperty);
            this.pnlProperties.Controls.Add(this.btnEditProperty);
            this.pnlProperties.Controls.Add(this.btnAddProperty);
            this.pnlProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProperties.Location = new System.Drawing.Point(0, 0);
            this.pnlProperties.Name = "pnlProperties";
            this.pnlProperties.Size = new System.Drawing.Size(1000, 700);
            this.pnlProperties.TabIndex = 0;
            this.pnlProperties.Visible = true;
            //
            // btnAddProperty
            //
            this.btnAddProperty.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnAddProperty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProperty.FlatAppearance.BorderSize = 0;
            this.btnAddProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProperty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddProperty.ForeColor = System.Drawing.Color.White;
            this.btnAddProperty.Location = new System.Drawing.Point(15, 15);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(110, 38);
            this.btnAddProperty.TabIndex = 0;
            this.btnAddProperty.Text = "Add";
            this.btnAddProperty.UseVisualStyleBackColor = false;
            this.btnAddProperty.Click += new System.EventHandler(this.btnAddProperty_Click);
            //
            // btnEditProperty
            //
            this.btnEditProperty.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnEditProperty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditProperty.Enabled = false;
            this.btnEditProperty.FlatAppearance.BorderSize = 0;
            this.btnEditProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProperty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditProperty.ForeColor = System.Drawing.Color.White;
            this.btnEditProperty.Location = new System.Drawing.Point(135, 15);
            this.btnEditProperty.Name = "btnEditProperty";
            this.btnEditProperty.Size = new System.Drawing.Size(110, 38);
            this.btnEditProperty.TabIndex = 1;
            this.btnEditProperty.Text = "Edit";
            this.btnEditProperty.UseVisualStyleBackColor = false;
            this.btnEditProperty.Click += new System.EventHandler(this.btnEditProperty_Click);
            //
            // btnDeleteProperty
            //
            this.btnDeleteProperty.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnDeleteProperty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteProperty.Enabled = false;
            this.btnDeleteProperty.FlatAppearance.BorderSize = 0;
            this.btnDeleteProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteProperty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteProperty.ForeColor = System.Drawing.Color.White;
            this.btnDeleteProperty.Location = new System.Drawing.Point(255, 15);
            this.btnDeleteProperty.Name = "btnDeleteProperty";
            this.btnDeleteProperty.Size = new System.Drawing.Size(110, 38);
            this.btnDeleteProperty.TabIndex = 2;
            this.btnDeleteProperty.Text = "Delete";
            this.btnDeleteProperty.UseVisualStyleBackColor = false;
            this.btnDeleteProperty.Click += new System.EventHandler(this.btnDeleteProperty_Click);
            //
            // cmbFilterType
            //
            this.cmbFilterType.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterType.Location = new System.Drawing.Point(780, 22);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(200, 23);
            this.cmbFilterType.TabIndex = 3;
            this.cmbFilterType.SelectedIndexChanged += new System.EventHandler(this.cmbFilterType_SelectedIndexChanged);
            //
            // dgvProperties
            //
            this.dgvProperties.AllowUserToAddRows = false;
            this.dgvProperties.AllowUserToDeleteRows = false;
            this.dgvProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProperties.BackgroundColor = System.Drawing.Color.White;
            this.dgvProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProperties.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.dgvProperties.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProperties.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProperties.Location = new System.Drawing.Point(10, 65);
            this.dgvProperties.MultiSelect = false;
            this.dgvProperties.Name = "dgvProperties";
            this.dgvProperties.ReadOnly = true;
            this.dgvProperties.RowHeadersVisible = false;
            this.dgvProperties.RowTemplate.Height = 28;
            this.dgvProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProperties.Size = new System.Drawing.Size(975, 455);
            this.dgvProperties.TabIndex = 4;
            this.dgvProperties.SelectionChanged += new System.EventHandler(this.dgvProperties_SelectionChanged);
            //
            // pnlPropertyForm
            //
            this.pnlPropertyForm.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlPropertyForm.Controls.Add(this.lblPropType);
            this.pnlPropertyForm.Controls.Add(this.cmbPropType);
            this.pnlPropertyForm.Controls.Add(this.lblPropAddress);
            this.pnlPropertyForm.Controls.Add(this.txtPropAddress);
            this.pnlPropertyForm.Controls.Add(this.lblPropCity);
            this.pnlPropertyForm.Controls.Add(this.txtPropCity);
            this.pnlPropertyForm.Controls.Add(this.lblPropArea);
            this.pnlPropertyForm.Controls.Add(this.numPropArea);
            this.pnlPropertyForm.Controls.Add(this.lblPropPrice);
            this.pnlPropertyForm.Controls.Add(this.numPropPrice);
            this.pnlPropertyForm.Controls.Add(this.lblPropTransaction);
            this.pnlPropertyForm.Controls.Add(this.cmbPropTransaction);
            this.pnlPropertyForm.Controls.Add(this.btnSaveProperty);
            this.pnlPropertyForm.Controls.Add(this.btnCancelProperty);
            this.pnlPropertyForm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPropertyForm.Location = new System.Drawing.Point(0, 530);
            this.pnlPropertyForm.Name = "pnlPropertyForm";
            this.pnlPropertyForm.Size = new System.Drawing.Size(1000, 170);
            this.pnlPropertyForm.TabIndex = 5;
            this.pnlPropertyForm.Visible = false;
            //
            // lblPropType
            //
            this.lblPropType.AutoSize = true;
            this.lblPropType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropType.Location = new System.Drawing.Point(15, 15);
            this.lblPropType.Name = "lblPropType";
            this.lblPropType.TabIndex = 0;
            this.lblPropType.Text = "Type:";
            //
            // cmbPropType
            //
            this.cmbPropType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPropType.Location = new System.Drawing.Point(15, 35);
            this.cmbPropType.Name = "cmbPropType";
            this.cmbPropType.Size = new System.Drawing.Size(140, 23);
            this.cmbPropType.TabIndex = 1;
            //
            // lblPropAddress
            //
            this.lblPropAddress.AutoSize = true;
            this.lblPropAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropAddress.Location = new System.Drawing.Point(170, 15);
            this.lblPropAddress.Name = "lblPropAddress";
            this.lblPropAddress.TabIndex = 2;
            this.lblPropAddress.Text = "Address:";
            //
            // txtPropAddress
            //
            this.txtPropAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPropAddress.Location = new System.Drawing.Point(170, 35);
            this.txtPropAddress.Name = "txtPropAddress";
            this.txtPropAddress.Size = new System.Drawing.Size(200, 23);
            this.txtPropAddress.TabIndex = 3;
            //
            // lblPropCity
            //
            this.lblPropCity.AutoSize = true;
            this.lblPropCity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropCity.Location = new System.Drawing.Point(385, 15);
            this.lblPropCity.Name = "lblPropCity";
            this.lblPropCity.TabIndex = 4;
            this.lblPropCity.Text = "City:";
            //
            // txtPropCity
            //
            this.txtPropCity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPropCity.Location = new System.Drawing.Point(385, 35);
            this.txtPropCity.Name = "txtPropCity";
            this.txtPropCity.Size = new System.Drawing.Size(150, 23);
            this.txtPropCity.TabIndex = 5;
            //
            // lblPropArea
            //
            this.lblPropArea.AutoSize = true;
            this.lblPropArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropArea.Location = new System.Drawing.Point(550, 15);
            this.lblPropArea.Name = "lblPropArea";
            this.lblPropArea.TabIndex = 6;
            this.lblPropArea.Text = "Area (sqm):";
            //
            // numPropArea
            //
            this.numPropArea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numPropArea.Location = new System.Drawing.Point(550, 35);
            this.numPropArea.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.numPropArea.Name = "numPropArea";
            this.numPropArea.Size = new System.Drawing.Size(110, 23);
            this.numPropArea.TabIndex = 7;
            //
            // lblPropPrice
            //
            this.lblPropPrice.AutoSize = true;
            this.lblPropPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropPrice.Location = new System.Drawing.Point(675, 15);
            this.lblPropPrice.Name = "lblPropPrice";
            this.lblPropPrice.TabIndex = 8;
            this.lblPropPrice.Text = "Price (EUR):";
            //
            // numPropPrice
            //
            this.numPropPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numPropPrice.Location = new System.Drawing.Point(675, 35);
            this.numPropPrice.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.numPropPrice.Name = "numPropPrice";
            this.numPropPrice.Size = new System.Drawing.Size(130, 23);
            this.numPropPrice.TabIndex = 9;
            //
            // lblPropTransaction
            //
            this.lblPropTransaction.AutoSize = true;
            this.lblPropTransaction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPropTransaction.Location = new System.Drawing.Point(820, 15);
            this.lblPropTransaction.Name = "lblPropTransaction";
            this.lblPropTransaction.TabIndex = 10;
            this.lblPropTransaction.Text = "Transaction type:";
            //
            // cmbPropTransaction
            //
            this.cmbPropTransaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPropTransaction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPropTransaction.Location = new System.Drawing.Point(820, 35);
            this.cmbPropTransaction.Name = "cmbPropTransaction";
            this.cmbPropTransaction.Size = new System.Drawing.Size(150, 23);
            this.cmbPropTransaction.TabIndex = 11;
            //
            // btnSaveProperty
            //
            this.btnSaveProperty.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnSaveProperty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveProperty.FlatAppearance.BorderSize = 0;
            this.btnSaveProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProperty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaveProperty.ForeColor = System.Drawing.Color.White;
            this.btnSaveProperty.Location = new System.Drawing.Point(820, 100);
            this.btnSaveProperty.Name = "btnSaveProperty";
            this.btnSaveProperty.Size = new System.Drawing.Size(110, 35);
            this.btnSaveProperty.TabIndex = 13;
            this.btnSaveProperty.Text = "Save";
            this.btnSaveProperty.UseVisualStyleBackColor = false;
            this.btnSaveProperty.Click += new System.EventHandler(this.btnSaveProperty_Click);
            //
            // btnCancelProperty
            //
            this.btnCancelProperty.BackColor = System.Drawing.Color.FromArgb(120, 144, 156);
            this.btnCancelProperty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelProperty.FlatAppearance.BorderSize = 0;
            this.btnCancelProperty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelProperty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelProperty.ForeColor = System.Drawing.Color.White;
            this.btnCancelProperty.Location = new System.Drawing.Point(700, 100);
            this.btnCancelProperty.Name = "btnCancelProperty";
            this.btnCancelProperty.Size = new System.Drawing.Size(110, 35);
            this.btnCancelProperty.TabIndex = 12;
            this.btnCancelProperty.Text = "Cancel";
            this.btnCancelProperty.UseVisualStyleBackColor = false;
            this.btnCancelProperty.Click += new System.EventHandler(this.btnCancelProperty_Click);
            //
            // pnlClients
            //
            this.pnlClients.BackColor = System.Drawing.Color.White;
            this.pnlClients.Controls.Add(this.dgvClients);
            this.pnlClients.Controls.Add(this.pnlClientForm);
            this.pnlClients.Controls.Add(this.btnDeleteClient);
            this.pnlClients.Controls.Add(this.btnEditClient);
            this.pnlClients.Controls.Add(this.btnAddClient);
            this.pnlClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClients.Location = new System.Drawing.Point(0, 0);
            this.pnlClients.Name = "pnlClients";
            this.pnlClients.Size = new System.Drawing.Size(1000, 700);
            this.pnlClients.TabIndex = 1;
            this.pnlClients.Visible = false;
            //
            // btnAddClient
            //
            this.btnAddClient.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnAddClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddClient.FlatAppearance.BorderSize = 0;
            this.btnAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddClient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddClient.ForeColor = System.Drawing.Color.White;
            this.btnAddClient.Location = new System.Drawing.Point(15, 15);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(110, 38);
            this.btnAddClient.TabIndex = 0;
            this.btnAddClient.Text = "Add";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            //
            // btnEditClient
            //
            this.btnEditClient.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnEditClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditClient.Enabled = false;
            this.btnEditClient.FlatAppearance.BorderSize = 0;
            this.btnEditClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditClient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditClient.ForeColor = System.Drawing.Color.White;
            this.btnEditClient.Location = new System.Drawing.Point(135, 15);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(110, 38);
            this.btnEditClient.TabIndex = 1;
            this.btnEditClient.Text = "Edit";
            this.btnEditClient.UseVisualStyleBackColor = false;
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);
            //
            // btnDeleteClient
            //
            this.btnDeleteClient.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnDeleteClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteClient.Enabled = false;
            this.btnDeleteClient.FlatAppearance.BorderSize = 0;
            this.btnDeleteClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteClient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteClient.ForeColor = System.Drawing.Color.White;
            this.btnDeleteClient.Location = new System.Drawing.Point(255, 15);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(110, 38);
            this.btnDeleteClient.TabIndex = 2;
            this.btnDeleteClient.Text = "Delete";
            this.btnDeleteClient.UseVisualStyleBackColor = false;
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click);
            //
            // dgvClients
            //
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.BackgroundColor = System.Drawing.Color.White;
            this.dgvClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClients.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.dgvClients.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(10, 65);
            this.dgvClients.MultiSelect = false;
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.RowTemplate.Height = 28;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(975, 490);
            this.dgvClients.TabIndex = 3;
            this.dgvClients.SelectionChanged += new System.EventHandler(this.dgvClients_SelectionChanged);
            //
            // pnlClientForm
            //
            this.pnlClientForm.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlClientForm.Controls.Add(this.lblClientLastName);
            this.pnlClientForm.Controls.Add(this.txtClientLastName);
            this.pnlClientForm.Controls.Add(this.lblClientFirstName);
            this.pnlClientForm.Controls.Add(this.txtClientFirstName);
            this.pnlClientForm.Controls.Add(this.lblClientPhone);
            this.pnlClientForm.Controls.Add(this.txtClientPhone);
            this.pnlClientForm.Controls.Add(this.lblClientEmail);
            this.pnlClientForm.Controls.Add(this.txtClientEmail);
            this.pnlClientForm.Controls.Add(this.btnSaveClient);
            this.pnlClientForm.Controls.Add(this.btnCancelClient);
            this.pnlClientForm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlClientForm.Location = new System.Drawing.Point(0, 570);
            this.pnlClientForm.Name = "pnlClientForm";
            this.pnlClientForm.Size = new System.Drawing.Size(1000, 130);
            this.pnlClientForm.TabIndex = 4;
            this.pnlClientForm.Visible = false;
            //
            // lblClientLastName
            //
            this.lblClientLastName.AutoSize = true;
            this.lblClientLastName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClientLastName.Location = new System.Drawing.Point(15, 15);
            this.lblClientLastName.Name = "lblClientLastName";
            this.lblClientLastName.TabIndex = 0;
            this.lblClientLastName.Text = "Last name:";
            //
            // txtClientLastName
            //
            this.txtClientLastName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClientLastName.Location = new System.Drawing.Point(15, 35);
            this.txtClientLastName.Name = "txtClientLastName";
            this.txtClientLastName.Size = new System.Drawing.Size(180, 23);
            this.txtClientLastName.TabIndex = 1;
            //
            // lblClientFirstName
            //
            this.lblClientFirstName.AutoSize = true;
            this.lblClientFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClientFirstName.Location = new System.Drawing.Point(210, 15);
            this.lblClientFirstName.Name = "lblClientFirstName";
            this.lblClientFirstName.TabIndex = 2;
            this.lblClientFirstName.Text = "First name:";
            //
            // txtClientFirstName
            //
            this.txtClientFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClientFirstName.Location = new System.Drawing.Point(210, 35);
            this.txtClientFirstName.Name = "txtClientFirstName";
            this.txtClientFirstName.Size = new System.Drawing.Size(180, 23);
            this.txtClientFirstName.TabIndex = 3;
            //
            // lblClientPhone
            //
            this.lblClientPhone.AutoSize = true;
            this.lblClientPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClientPhone.Location = new System.Drawing.Point(405, 15);
            this.lblClientPhone.Name = "lblClientPhone";
            this.lblClientPhone.TabIndex = 4;
            this.lblClientPhone.Text = "Phone:";
            //
            // txtClientPhone
            //
            this.txtClientPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClientPhone.Location = new System.Drawing.Point(405, 35);
            this.txtClientPhone.Name = "txtClientPhone";
            this.txtClientPhone.Size = new System.Drawing.Size(180, 23);
            this.txtClientPhone.TabIndex = 5;
            //
            // lblClientEmail
            //
            this.lblClientEmail.AutoSize = true;
            this.lblClientEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClientEmail.Location = new System.Drawing.Point(600, 15);
            this.lblClientEmail.Name = "lblClientEmail";
            this.lblClientEmail.TabIndex = 6;
            this.lblClientEmail.Text = "Email:";
            //
            // txtClientEmail
            //
            this.txtClientEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClientEmail.Location = new System.Drawing.Point(600, 35);
            this.txtClientEmail.Name = "txtClientEmail";
            this.txtClientEmail.Size = new System.Drawing.Size(220, 23);
            this.txtClientEmail.TabIndex = 7;
            //
            // btnSaveClient
            //
            this.btnSaveClient.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            this.btnSaveClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveClient.FlatAppearance.BorderSize = 0;
            this.btnSaveClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveClient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaveClient.ForeColor = System.Drawing.Color.White;
            this.btnSaveClient.Location = new System.Drawing.Point(840, 75);
            this.btnSaveClient.Name = "btnSaveClient";
            this.btnSaveClient.Size = new System.Drawing.Size(110, 35);
            this.btnSaveClient.TabIndex = 9;
            this.btnSaveClient.Text = "Save";
            this.btnSaveClient.UseVisualStyleBackColor = false;
            this.btnSaveClient.Click += new System.EventHandler(this.btnSaveClient_Click);
            //
            // btnCancelClient
            //
            this.btnCancelClient.BackColor = System.Drawing.Color.FromArgb(120, 144, 156);
            this.btnCancelClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelClient.FlatAppearance.BorderSize = 0;
            this.btnCancelClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelClient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelClient.ForeColor = System.Drawing.Color.White;
            this.btnCancelClient.Location = new System.Drawing.Point(720, 75);
            this.btnCancelClient.Name = "btnCancelClient";
            this.btnCancelClient.Size = new System.Drawing.Size(110, 35);
            this.btnCancelClient.TabIndex = 8;
            this.btnCancelClient.Text = "Cancel";
            this.btnCancelClient.UseVisualStyleBackColor = false;
            this.btnCancelClient.Click += new System.EventHandler(this.btnCancelClient_Click);
            //
            // pnlRequests
            //
            this.pnlRequests.BackColor = System.Drawing.Color.White;
            this.pnlRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRequests.Location = new System.Drawing.Point(0, 0);
            this.pnlRequests.Name = "pnlRequests";
            this.pnlRequests.Size = new System.Drawing.Size(1000, 700);
            this.pnlRequests.TabIndex = 2;
            this.pnlRequests.Visible = false;
            //
            // pnlOffers
            //
            this.pnlOffers.BackColor = System.Drawing.Color.White;
            this.pnlOffers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOffers.Location = new System.Drawing.Point(0, 0);
            this.pnlOffers.Name = "pnlOffers";
            this.pnlOffers.Size = new System.Drawing.Size(1000, 700);
            this.pnlOffers.TabIndex = 3;
            this.pnlOffers.Visible = false;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Real Estate Agency";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPropArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPropPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.pnlPropertyForm.ResumeLayout(false);
            this.pnlPropertyForm.PerformLayout();
            this.pnlClientForm.ResumeLayout(false);
            this.pnlClientForm.PerformLayout();
            this.pnlProperties.ResumeLayout(false);
            this.pnlClients.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnAddProperty;
        private System.Windows.Forms.Button btnEditProperty;
        private System.Windows.Forms.Button btnDeleteProperty;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.DataGridView dgvProperties;
        private System.Windows.Forms.Panel pnlPropertyForm;
        private System.Windows.Forms.Label lblPropType;
        private System.Windows.Forms.ComboBox cmbPropType;
        private System.Windows.Forms.Label lblPropAddress;
        private System.Windows.Forms.TextBox txtPropAddress;
        private System.Windows.Forms.Label lblPropCity;
        private System.Windows.Forms.TextBox txtPropCity;
        private System.Windows.Forms.Label lblPropArea;
        private System.Windows.Forms.NumericUpDown numPropArea;
        private System.Windows.Forms.Label lblPropPrice;
        private System.Windows.Forms.NumericUpDown numPropPrice;
        private System.Windows.Forms.Label lblPropTransaction;
        private System.Windows.Forms.ComboBox cmbPropTransaction;
        private System.Windows.Forms.Button btnSaveProperty;
        private System.Windows.Forms.Button btnCancelProperty;
        private System.Windows.Forms.Panel pnlClients;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Panel pnlClientForm;
        private System.Windows.Forms.Label lblClientLastName;
        private System.Windows.Forms.TextBox txtClientLastName;
        private System.Windows.Forms.Label lblClientFirstName;
        private System.Windows.Forms.TextBox txtClientFirstName;
        private System.Windows.Forms.Label lblClientPhone;
        private System.Windows.Forms.TextBox txtClientPhone;
        private System.Windows.Forms.Label lblClientEmail;
        private System.Windows.Forms.TextBox txtClientEmail;
        private System.Windows.Forms.Button btnSaveClient;
        private System.Windows.Forms.Button btnCancelClient;
        private System.Windows.Forms.Panel pnlRequests;
        private System.Windows.Forms.Panel pnlOffers;
    }
}

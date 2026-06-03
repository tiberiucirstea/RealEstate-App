using RealEstateAgency.Models;
using RealEstateAgency.Repositories;
using System;
using System.Windows.Forms;

namespace RealEstateAgency
{
    public partial class MainForm : Form
    {
        private readonly PropertyRepository _propertyRepository = new PropertyRepository();
        private readonly ClientRepository   _clientRepository   = new ClientRepository();

        private Property _selectedProperty = null;
        private bool _isAddingProperty = false;

        private Client _selectedClient = null;
        private bool _isAddingClient = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cmbFilterType.Items.Add("All");
            foreach (var type in Enum.GetValues(typeof(PropertyType)))
                cmbFilterType.Items.Add(type);
            cmbFilterType.SelectedIndex = 0;

            foreach (var type in Enum.GetValues(typeof(PropertyType)))
                cmbPropType.Items.Add(type);
            foreach (var type in Enum.GetValues(typeof(TransactionType)))
                cmbPropTransaction.Items.Add(type);

            ShowPanel(pnlProperties);
            SetActiveButton(btnProperties);
            RefreshProperties();
            RefreshClients();
        }

        // ── NAVIGATION ────────────────────────────────────────────────

        private void SetActiveButton(Button active)
        {
            foreach (Control ctrl in pnlSidebar.Controls)
                if (ctrl is Button btn)
                    btn.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            active.BackColor = System.Drawing.Color.FromArgb(38, 50, 56);
        }

        private void ShowPanel(Panel panel)
        {
            pnlProperties.Visible = false;
            pnlClients.Visible = false;
            pnlRequests.Visible = false;
            pnlOffers.Visible = false;
            panel.Visible = true;
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlProperties);
            SetActiveButton(btnProperties);
            pnlPropertyForm.Visible = false;
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlClients);
            SetActiveButton(btnClients);
            pnlClientForm.Visible = false;
        }

        private void btnRequests_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlRequests);
            SetActiveButton(btnRequests);
        }

        private void btnOffers_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlOffers);
            SetActiveButton(btnOffers);
        }

        // ── PROPERTIES ────────────────────────────────────────────────

        private void RefreshProperties()
        {
            var properties = _propertyRepository.GetAll();

            if (cmbFilterType.SelectedItem != null && cmbFilterType.SelectedItem.ToString() != "All")
            {
                var selected = (PropertyType)cmbFilterType.SelectedItem;
                properties = properties.FindAll(p => p.Type == selected);
            }

            dgvProperties.DataSource = properties;

            if (dgvProperties.Columns.Contains("Id"))
                dgvProperties.Columns["Id"].Visible = false;

            btnEditProperty.Enabled = dgvProperties.SelectedRows.Count > 0;
            btnDeleteProperty.Enabled = dgvProperties.SelectedRows.Count > 0;
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshProperties();
        }

        private void dgvProperties_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvProperties.SelectedRows.Count > 0;
            btnEditProperty.Enabled = hasSelection;
            btnDeleteProperty.Enabled = hasSelection;
        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            _isAddingProperty = true;
            _selectedProperty = null;
            ClearPropertyForm();
            pnlPropertyForm.Visible = true;
        }

        private void btnEditProperty_Click(object sender, EventArgs e)
        {
            _isAddingProperty = false;
            _selectedProperty = dgvProperties.SelectedRows[0].DataBoundItem as Property;
            PopulatePropertyForm(_selectedProperty);
            pnlPropertyForm.Visible = true;
        }

        private void btnDeleteProperty_Click(object sender, EventArgs e)
        {
            var property = dgvProperties.SelectedRows[0].DataBoundItem as Property;
            if (MessageBox.Show(
                $"Are you sure you want to delete the property at {property.Address}, {property.City}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _propertyRepository.Delete(property.Id);
                RefreshProperties();
            }
        }

        private void btnSaveProperty_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPropAddress.Text))
            {
                MessageBox.Show("Address is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPropCity.Text))
            {
                MessageBox.Show("City is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numPropArea.Value <= 0)
            {
                MessageBox.Show("Area must be greater than 0!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numPropPrice.Value <= 0)
            {
                MessageBox.Show("Price must be greater than 0!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var property = new Property
            {
                Type = (PropertyType)cmbPropType.SelectedItem,
                Address = txtPropAddress.Text.Trim(),
                City = txtPropCity.Text.Trim(),
                Area = (double)numPropArea.Value,
                Price = numPropPrice.Value,
                TransactionType = (TransactionType)cmbPropTransaction.SelectedItem,
                Status = PropertyStatus.Available
            };

            if (_isAddingProperty)
            {
                property.Id = Guid.NewGuid();
                _propertyRepository.Add(property);
            }
            else
            {
                property.Id = _selectedProperty.Id;
                _propertyRepository.Update(property);
            }

            pnlPropertyForm.Visible = false;
            RefreshProperties();
        }

        private void btnCancelProperty_Click(object sender, EventArgs e)
        {
            pnlPropertyForm.Visible = false;
            ClearPropertyForm();
        }

        private void ClearPropertyForm()
        {
            if (cmbPropType.Items.Count > 0) cmbPropType.SelectedIndex = 0;
            txtPropAddress.Clear();
            txtPropCity.Clear();
            numPropArea.Value = 0;
            numPropPrice.Value = 0;
            if (cmbPropTransaction.Items.Count > 0) cmbPropTransaction.SelectedIndex = 0;
        }

        private void PopulatePropertyForm(Property property)
        {
            cmbPropType.SelectedItem = property.Type;
            txtPropAddress.Text = property.Address;
            txtPropCity.Text = property.City;
            numPropArea.Value = (decimal)property.Area;
            numPropPrice.Value = property.Price;
            cmbPropTransaction.SelectedItem = property.TransactionType;
        }

        // ── CLIENTS ────────────────────────────────────────────────

        private void RefreshClients()
        {
            dgvClients.DataSource = _clientRepository.GetAll();

            if (dgvClients.Columns.Contains("Id"))
                dgvClients.Columns["Id"].Visible = false;
            if (dgvClients.Columns.Contains("FullName"))
                dgvClients.Columns["FullName"].Visible = false;

            btnEditClient.Enabled = dgvClients.SelectedRows.Count > 0;
            btnDeleteClient.Enabled = dgvClients.SelectedRows.Count > 0;
        }

        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvClients.SelectedRows.Count > 0;
            btnEditClient.Enabled = hasSelection;
            btnDeleteClient.Enabled = hasSelection;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            _isAddingClient = true;
            _selectedClient = null;
            ClearClientForm();
            pnlClientForm.Visible = true;
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            _isAddingClient = false;
            _selectedClient = dgvClients.SelectedRows[0].DataBoundItem as Client;
            PopulateClientForm(_selectedClient);
            pnlClientForm.Visible = true;
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            var client = dgvClients.SelectedRows[0].DataBoundItem as Client;
            if (MessageBox.Show(
                $"Are you sure you want to delete client {client.LastName} {client.FirstName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _clientRepository.Delete(client.Id);
                RefreshClients();
            }
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClientLastName.Text))
            {
                MessageBox.Show("Last name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtClientFirstName.Text))
            {
                MessageBox.Show("First name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtClientPhone.Text))
            {
                MessageBox.Show("Phone is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtClientPhone.Text.Trim().Length < 10)
            {
                MessageBox.Show("Phone must be at least 10 characters!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!txtClientEmail.Text.Contains("@") || !txtClientEmail.Text.Contains("."))
            {
                MessageBox.Show("Invalid email address!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var client = new Client
            {
                LastName = txtClientLastName.Text.Trim(),
                FirstName = txtClientFirstName.Text.Trim(),
                Phone = txtClientPhone.Text.Trim(),
                Email = txtClientEmail.Text.Trim()
            };

            if (_isAddingClient)
            {
                client.Id = Guid.NewGuid();
                _clientRepository.Add(client);
            }
            else
            {
                client.Id = _selectedClient.Id;
                _clientRepository.Update(client);
            }

            pnlClientForm.Visible = false;
            RefreshClients();
        }

        private void btnCancelClient_Click(object sender, EventArgs e)
        {
            pnlClientForm.Visible = false;
            ClearClientForm();
        }

        private void ClearClientForm()
        {
            txtClientLastName.Clear();
            txtClientFirstName.Clear();
            txtClientPhone.Clear();
            txtClientEmail.Clear();
        }

        private void PopulateClientForm(Client client)
        {
            txtClientLastName.Text = client.LastName;
            txtClientFirstName.Text = client.FirstName;
            txtClientPhone.Text = client.Phone;
            txtClientEmail.Text = client.Email;
        }
    }
}

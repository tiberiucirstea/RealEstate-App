using RealEstateAgency.Models;
using RealEstateAgency.Repositories;
using System;
using System.Windows.Forms;

namespace RealEstateAgency
{
    public partial class MainForm : Form
    {
        private readonly PropertyRepository _propertyRepository = new PropertyRepository();
        private readonly ClientRepository _clientRepository = new ClientRepository();
        private readonly RequestRepository _requestRepository = new RequestRepository();
        private readonly OfferRepository _offerRepository = new OfferRepository();

        private Property _selectedProperty = null;
        private bool _isAddingProperty = false;

        private Client _selectedClient = null;
        private bool _isAddingClient = false;

        private Request _selectedRequest = null;
        private bool _isAddingRequest = false;
        private Client _requestClient = null;

        private Offer _selectedOffer = null;
        private bool _isAddingOffer = false;
        private Client _offerClient = null;

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

            cmbFilterStatus.Items.Add("All");
            foreach (var status in Enum.GetValues(typeof(RequestStatus)))
                cmbFilterStatus.Items.Add(status);
            cmbFilterStatus.SelectedIndex = 0;

            foreach (var type in Enum.GetValues(typeof(PropertyType)))
                cmbReqPropType.Items.Add(type);
            foreach (var type in Enum.GetValues(typeof(TransactionType)))
                cmbReqTransaction.Items.Add(type);
            foreach (var status in Enum.GetValues(typeof(RequestStatus)))
                cmbReqStatus.Items.Add(status);

            cmbFilterOfferStatus.Items.Add("All");
            foreach (var status in Enum.GetValues(typeof(OfferStatus)))
                cmbFilterOfferStatus.Items.Add(status);
            cmbFilterOfferStatus.SelectedIndex = 0;

            foreach (var status in Enum.GetValues(typeof(OfferStatus)))
                cmbOfferStatus.Items.Add(status);

            ShowPanel(pnlProperties);
            SetActiveButton(btnProperties);
            RefreshProperties();
            RefreshClients();
            RefreshRequests();
            RefreshOffers();
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
            pnlRequestForm.Visible = false;
        }

        private void btnOffers_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlOffers);
            SetActiveButton(btnOffers);
            pnlOfferForm.Visible = false;
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
                $"Are you sure you want to delete the property at {property.Address}, {property.City}?\nAll associated offers will also be deleted!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var offers = _offerRepository.GetAll()
                    .FindAll(o => o.PropertyId == property.Id);
                foreach (var offer in offers)
                    _offerRepository.Delete(offer.Id);

                _propertyRepository.Delete(property.Id);
                RefreshProperties();
                RefreshOffers();
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
            if (cmbPropType.Items.Count > 0)
                cmbPropType.SelectedIndex = 0;
            txtPropAddress.Clear();
            txtPropCity.Clear();
            numPropArea.Value = 0;
            numPropPrice.Value = 0;
            if (cmbPropTransaction.Items.Count > 0)
                cmbPropTransaction.SelectedIndex = 0;
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
                $"Are you sure you want to delete client {client.LastName} {client.FirstName}?\nAll associated requests and offers will also be deleted!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var offers = _offerRepository.GetAll()
                    .FindAll(o => o.ClientId == client.Id);
                foreach (var offer in offers)
                    _offerRepository.Delete(offer.Id);

                var requests = _requestRepository.GetAll()
                    .FindAll(r => r.ClientId == client.Id);
                foreach (var request in requests)
                    _requestRepository.Delete(request.Id);

                _clientRepository.Delete(client.Id);
                RefreshClients();
                RefreshOffers();
                RefreshRequests();
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

            var excludeId = _isAddingClient ? (Guid?)null : _selectedClient.Id;
            if (_clientRepository.ExistsByEmailOrPhone(txtClientEmail.Text.Trim(), txtClientPhone.Text.Trim(), excludeId))
            {
                MessageBox.Show("A client with this email or phone number already exists!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // ── REQUESTS ────────────────────────────────────────────────

        private void RefreshRequests()
        {
            var requests = _requestRepository.GetAll();

            if (cmbFilterStatus.SelectedItem != null && cmbFilterStatus.SelectedItem.ToString() != "All")
            {
                var selectedStatus = (RequestStatus)cmbFilterStatus.SelectedItem;
                requests = requests.FindAll(r => r.Status == selectedStatus);
            }

            dgvRequests.DataSource = requests;

            if (dgvRequests.Columns.Contains("Id"))
                dgvRequests.Columns["Id"].Visible = false;
            if (dgvRequests.Columns.Contains("ClientId"))
                dgvRequests.Columns["ClientId"].Visible = false;
            if (dgvRequests.Columns.Contains("Client"))
                dgvRequests.Columns["Client"].Visible = false;

            btnEditRequest.Enabled = dgvRequests.SelectedRows.Count > 0;
            btnDeleteRequest.Enabled = dgvRequests.SelectedRows.Count > 0;
        }

        private void dgvRequests_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvRequests.SelectedRows.Count > 0;
            btnEditRequest.Enabled = hasSelection;
            btnDeleteRequest.Enabled = hasSelection;
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshRequests();
        }

        private void ShowClientsForRequest(string filter)
        {
            lstRequestClients.Items.Clear();
            var clients = _clientRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.Trim().ToLower();
                clients = clients.FindAll(c =>
                    c.LastName.ToLower().Contains(filter) ||
                    c.FirstName.ToLower().Contains(filter) ||
                    (c.LastName + " " + c.FirstName).ToLower().Contains(filter));
            }

            foreach (var client in clients)
            {
                lstRequestClients.Items.Add(new ClientListItem
                {
                    Display = client.LastName + " " + client.FirstName,
                    Client = client
                });
            }
            lstRequestClients.DisplayMember = "Display";
        }

        private void txtSearchClient_TextChanged(object sender, EventArgs e)
        {
            ShowClientsForRequest(txtSearchClient.Text);
        }

        private void lstRequestClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRequestClients.SelectedItem == null) return;
            _requestClient = ((ClientListItem)lstRequestClients.SelectedItem).Client;
        }

        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            _isAddingRequest = true;
            _selectedRequest = null;
            _requestClient = null;
            ClearRequestForm();
            ShowClientsForRequest("");
            pnlRequestForm.Visible = true;
        }

        private void btnEditRequest_Click(object sender, EventArgs e)
        {
            _isAddingRequest = false;
            _selectedRequest = dgvRequests.SelectedRows[0].DataBoundItem as Request;
            _requestClient = _selectedRequest.Client;
            PopulateRequestForm(_selectedRequest);
            pnlRequestForm.Visible = true;
        }

        private void btnDeleteRequest_Click(object sender, EventArgs e)
        {
            var request = dgvRequests.SelectedRows[0].DataBoundItem as Request;
            if (MessageBox.Show(
                $"Are you sure you want to delete the request from {request.Client.LastName} {request.Client.FirstName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _requestRepository.Delete(request.Id);
                RefreshRequests();
            }
        }

        private void btnSaveRequest_Click(object sender, EventArgs e)
        {
            if (_requestClient == null)
            {
                MessageBox.Show("Please select a client from the list!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtReqCity.Text))
            {
                MessageBox.Show("City is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numReqMaxBudget.Value <= 0)
            {
                MessageBox.Show("Max budget must be greater than 0!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var request = new Request
            {
                ClientId = _requestClient.Id,
                Client = _requestClient,
                PropertyType = (PropertyType)cmbReqPropType.SelectedItem,
                TransactionType = (TransactionType)cmbReqTransaction.SelectedItem,
                MaxBudget = numReqMaxBudget.Value,
                City = txtReqCity.Text.Trim(),
                Status = (RequestStatus)cmbReqStatus.SelectedItem,
                RequestDate = dtpReqDate.Value
            };

            if (_isAddingRequest)
            {
                request.Id = Guid.NewGuid();
                _requestRepository.Add(request);
            }
            else
            {
                request.Id = _selectedRequest.Id;
                _requestRepository.Update(request);
            }

            pnlRequestForm.Visible = false;
            RefreshRequests();
        }

        private void btnCancelRequest_Click(object sender, EventArgs e)
        {
            pnlRequestForm.Visible = false;
            ClearRequestForm();
        }

        private void ClearRequestForm()
        {
            txtSearchClient.Clear();
            lstRequestClients.Items.Clear();
            if (cmbReqPropType.Items.Count > 0)
                cmbReqPropType.SelectedIndex = 0;
            if (cmbReqTransaction.Items.Count > 0)
                cmbReqTransaction.SelectedIndex = 0;
            numReqMaxBudget.Value = 0;
            txtReqCity.Clear();
            if (cmbReqStatus.Items.Count > 0)
                cmbReqStatus.SelectedIndex = 0;
            dtpReqDate.Value = DateTime.Now;
            _requestClient = null;
        }

        private void PopulateRequestForm(Request request)
        {
            txtSearchClient.Text = request.Client.LastName + " " + request.Client.FirstName;
            _requestClient = request.Client;
            cmbReqPropType.SelectedItem = request.PropertyType;
            cmbReqTransaction.SelectedItem = request.TransactionType;
            numReqMaxBudget.Value = request.MaxBudget;
            txtReqCity.Text = request.City;
            cmbReqStatus.SelectedItem = request.Status;
            dtpReqDate.Value = request.RequestDate;
        }

        // ── OFFERS ────────────────────────────────────────────────

        private void RefreshOffers()
        {
            var offers = _offerRepository.GetAll();

            if (cmbFilterOfferStatus.SelectedItem != null && cmbFilterOfferStatus.SelectedItem.ToString() != "All")
            {
                var selectedStatus = (OfferStatus)cmbFilterOfferStatus.SelectedItem;
                offers = offers.FindAll(o => o.Status == selectedStatus);
            }

            dgvOffers.DataSource = offers;

            if (dgvOffers.Columns.Contains("Id"))
                dgvOffers.Columns["Id"].Visible = false;
            if (dgvOffers.Columns.Contains("ClientId"))
                dgvOffers.Columns["ClientId"].Visible = false;
            if (dgvOffers.Columns.Contains("PropertyId"))
                dgvOffers.Columns["PropertyId"].Visible = false;
            if (dgvOffers.Columns.Contains("Client"))
                dgvOffers.Columns["Client"].Visible = false;
            if (dgvOffers.Columns.Contains("Property"))
                dgvOffers.Columns["Property"].Visible = false;

            btnEditOffer.Enabled = dgvOffers.SelectedRows.Count > 0;
            btnDeleteOffer.Enabled = dgvOffers.SelectedRows.Count > 0;
        }

        private void dgvOffers_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvOffers.SelectedRows.Count > 0;
            btnEditOffer.Enabled = hasSelection;
            btnDeleteOffer.Enabled = hasSelection;
        }

        private void cmbFilterOfferStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshOffers();
        }

        private void ShowClientsForOffer(string filter)
        {
            lstOfferClients.Items.Clear();
            var clients = _clientRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.Trim().ToLower();
                clients = clients.FindAll(c =>
                    c.LastName.ToLower().Contains(filter) ||
                    c.FirstName.ToLower().Contains(filter) ||
                    (c.LastName + " " + c.FirstName).ToLower().Contains(filter));
            }

            foreach (var client in clients)
            {
                lstOfferClients.Items.Add(new ClientListItem
                {
                    Display = client.LastName + " " + client.FirstName,
                    Client = client
                });
            }
            lstOfferClients.DisplayMember = "Display";
        }

        private void txtSearchClientOffer_TextChanged(object sender, EventArgs e)
        {
            ShowClientsForOffer(txtSearchClientOffer.Text);
        }

        private void lstOfferClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOfferClients.SelectedItem == null) return;
            _offerClient = ((ClientListItem)lstOfferClients.SelectedItem).Client;
        }

        private void btnAddOffer_Click(object sender, EventArgs e)
        {
            _isAddingOffer = true;
            _selectedOffer = null;
            _offerClient = null;
            ClearOfferForm();
            ShowClientsForOffer("");
            cmbOfferProperty.Items.Clear();
            foreach (var property in _propertyRepository.GetAll())
            {
                cmbOfferProperty.Items.Add(new PropertyListItem
                {
                    Display = property.Address + ", " + property.City,
                    Property = property
                });
            }
            cmbOfferProperty.DisplayMember = "Display";
            if (cmbOfferProperty.Items.Count > 0)
                cmbOfferProperty.SelectedIndex = 0;
            pnlOfferForm.Visible = true;
        }

        private void btnEditOffer_Click(object sender, EventArgs e)
        {
            _isAddingOffer = false;
            _selectedOffer = dgvOffers.SelectedRows[0].DataBoundItem as Offer;
            _offerClient = _selectedOffer.Client;

            cmbOfferProperty.Items.Clear();
            foreach (var property in _propertyRepository.GetAll())
            {
                cmbOfferProperty.Items.Add(new PropertyListItem
                {
                    Display = property.Address + ", " + property.City,
                    Property = property
                });
            }
            cmbOfferProperty.DisplayMember = "Display";

            PopulateOfferForm(_selectedOffer);
            pnlOfferForm.Visible = true;
        }

        private void btnDeleteOffer_Click(object sender, EventArgs e)
        {
            var offer = dgvOffers.SelectedRows[0].DataBoundItem as Offer;
            if (MessageBox.Show(
                $"Are you sure you want to delete the offer for client {offer.Client.LastName} {offer.Client.FirstName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _offerRepository.Delete(offer.Id);
                RefreshOffers();
            }
        }

        private void btnSaveOffer_Click(object sender, EventArgs e)
        {
            if (_offerClient == null)
            {
                MessageBox.Show("Please select a client from the list!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbOfferProperty.SelectedItem == null)
            {
                MessageBox.Show("Please select a property!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProperty = ((PropertyListItem)cmbOfferProperty.SelectedItem).Property;
            var newStatus = (OfferStatus)cmbOfferStatus.SelectedItem;

            var offer = new Offer
            {
                ClientId = _offerClient.Id,
                Client = _offerClient,
                PropertyId = selectedProperty.Id,
                Property = selectedProperty,
                OfferDate = dtpOfferDate.Value,
                Status = newStatus
            };

            if (_isAddingOffer)
            {
                offer.Id = Guid.NewGuid();
                _offerRepository.Add(offer);
            }
            else
            {
                offer.Id = _selectedOffer.Id;
                _offerRepository.Update(offer);
            }

            if (newStatus == OfferStatus.Accepted)
            {
                var propertyStatus = selectedProperty.TransactionType == TransactionType.Sale
                    ? PropertyStatus.Sold
                    : PropertyStatus.Rented;
                _propertyRepository.UpdateStatus(selectedProperty.Id, propertyStatus);

                var activeRequests = _requestRepository.GetAll()
                    .FindAll(r => r.ClientId == _offerClient.Id && r.Status == RequestStatus.Active);
                foreach (var request in activeRequests)
                {
                    request.Status = RequestStatus.Resolved;
                    _requestRepository.Update(request);
                }

                MessageBox.Show(
                    $"Offer accepted!\nProperty has been marked as {propertyStatus}.\nClient's active requests have been resolved.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            pnlOfferForm.Visible = false;
            RefreshOffers();
            RefreshProperties();
            RefreshRequests();
        }

        private void btnCancelOffer_Click(object sender, EventArgs e)
        {
            pnlOfferForm.Visible = false;
            ClearOfferForm();
        }

        private void ClearOfferForm()
        {
            txtSearchClientOffer.Clear();
            lstOfferClients.Items.Clear();
            dtpOfferDate.Value = DateTime.Now;
            if (cmbOfferStatus.Items.Count > 0)
                cmbOfferStatus.SelectedIndex = 0;
            _offerClient = null;
        }

        private void PopulateOfferForm(Offer offer)
        {
            txtSearchClientOffer.Text = offer.Client.LastName + " " + offer.Client.FirstName;
            _offerClient = offer.Client;

            for (int i = 0; i < cmbOfferProperty.Items.Count; i++)
            {
                var item = (PropertyListItem)cmbOfferProperty.Items[i];
                if (item.Property.Id == offer.PropertyId)
                {
                    cmbOfferProperty.SelectedIndex = i;
                    break;
                }
            }

            dtpOfferDate.Value = offer.OfferDate;
            cmbOfferStatus.SelectedItem = offer.Status;
        }
    }

    public class ClientListItem
    {
        public string Display { get; set; }
        public Client Client { get; set; }
        public override string ToString() => Display;
    }

    public class PropertyListItem
    {
        public string Display { get; set; }
        public Property Property { get; set; }
        public override string ToString() => Display;
    }
}

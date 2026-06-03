using System;
using System.Windows.Forms;

namespace RealEstateAgency
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SetActiveButton(Button active)
        {
            foreach (Control ctrl in pnlSidebar.Controls)
            {
                if (ctrl is Button btn)
                    btn.BackColor = System.Drawing.Color.FromArgb(55, 71, 79);
            }
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
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlClients);
            SetActiveButton(btnClients);
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowPanel(pnlProperties);
            SetActiveButton(btnProperties);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressRegister
{
    public partial class Form1 : Form
    {
        RegisterV model = new RegisterV();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        void Clear()

        {

            txtBoxFName.Text = txtBoxLName.Text = txtBoxCity.Text = txtBoxAddress.Text = "";

            btnSave.Text = "Save";

            btnDelete.Enabled = false;

            model.id = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clear();
            PopulateDataGridView();
        }
        void PopulateDataGridView()

        {

            dgvCustomer.AutoGenerateColumns = false;

            using (RegisterVEntities db = new RegisterVEntities())

            {

                dgvCustomer.DataSource = db.RegisterVs.ToList<RegisterV>();

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            model.FirstName = txtBoxFName.Text.Trim();

            model.LastName = txtBoxLName.Text.Trim();

            model.City = txtBoxCity.Text.Trim();

            model.Address = txtBoxAddress.Text.Trim();

            using (RegisterVEntities db = new RegisterVEntities())

            {

                if (model.id == 0)//Insert

                    db.RegisterVs.Add(model);

                else //Update

                    db.Entry(model).State=System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

            }

            Clear();

            PopulateDataGridView();

            MessageBox.Show("Submitted Successfully");
        }
    }
}

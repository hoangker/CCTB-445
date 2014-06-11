using NorthwindSystem.BLL;
using NorthwindSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class ViewShippers : Form
    {
        public ViewShippers()
        {
            InitializeComponent();
        }

        private void lblShipperID_Click(object sender, EventArgs e)
        {

        }

      

        private void ViewShippers_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateShippersComboBox();
            }
            catch (Exception ex)
            { 
                //TODO: Log the exception
                MessageBox.Show("Error: " + ex.Message);
            
            }
        }

        private void PopulateShippersComboBox()
        {
            NorthwindManager manager = new NorthwindManager();
            var data = manager.ListShippers();
            data.Insert(0, new Shipper()
            {
                ShipperID = -1,
                CompanyName = "[Select a shipper]"
            });
            cboShippers.DataSource = data;
            cboShippers.DisplayMember = "CompanyName"; // CompanyName is a property of the Shipper class
            cboShippers.ValueMember = "ShipperID"; // ShipperID is the property that represents the Primary Key (uniquely distinguishes each shipper in the database)
            //cboShippers.Items.Insert(0, "[Select a shipper]");
            cboShippers.SelectedIndex = 0;
        }

        private void cboShippers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboShippers.SelectedIndex != 0)
                {
                    lblShipperID.Text = cboShippers.SelectedValue.ToString();
                    //txtCompanyName.Text = cboShippers.SelectedItem.ToString();
                }

            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LookupBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboShippers.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select a shipper before clicking [Lookup Shipper]");
                }
                else 
                {
                    int shipperId = Convert.ToInt32(cboShippers.SelectedValue);
                    NorthwindManager mgr = new NorthwindManager();
                    var shipper = mgr.GetShipper(shipperId);
                    if (shipper != null)
                    {
                        lblShipperID.Text = shipper.ShipperID.ToString();
                        txtCompanyName.Text = shipper.CompanyName;
                        txtPhone.Text = shipper.Phone;
                    }
                }
            }
            catch(Exception ex)
            {
                //TODO: Log the exception
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                NorthwindManager mgr = new NorthwindManager();

               int shipperId =  mgr.AddShipper(new Shipper()
                                {
                                    CompanyName=txtCompanyName.Text,
                                    Phone=txtPhone.Text
                                });

                //update the combobox
               PopulateShippersComboBox();
                //has right shipper selected
               cboShippers.SelectedValue = shipperId;
                //display id of added shipper
               lblShipperID.Text = shipperId.ToString();
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        
    }
}

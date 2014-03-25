using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FatimasSystem
{
	/// <summary>
	/// Interaction logic for AddUserWindow.xaml
	/// </summary>
	public partial class AddUserWindow : Window
	{
        private SqlConnection _sqlConn;

		public AddUserWindow(SqlConnection sqlConn)
		{
			this.InitializeComponent();

            MainWindow.CenterWindowOnScreen(this);

            _sqlConn = sqlConn;

            FillComboCountry(comboCountry, false);
			
			// Insert code required on object creation below this point.
		}

        public static void FillComboCountry(ComboBox combo, bool emptyFirst)
        {
            if (emptyFirst) combo.Items.Add("");

            List<string> countryList = GetCountryList();
            foreach (string country in countryList)
            {
                combo.Items.Add(country);
            }

            combo.SelectedIndex = 0;
        }

        // fill country combobox with countries
        public static List<string> GetCountryList()
        {
            List<string> cultureList = new List<string>();

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (!(cultureList.Contains(region.DisplayName)))
                {
                    cultureList.Add(region.DisplayName);
                }
            }

            cultureList.Sort();

            return cultureList;
        }

		private void btnAddClient_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            using (new WaitCursor())
            {
                string errorFields = "";
                if (!AreFillRequiredFields(ref errorFields))
                {
                    MessageBox.Show(errorFields);
                }
                else
                {
                    string sqlError = "";
                    List<ParamValue> paramList = new List<ParamValue>();
                    paramList.Add(new ParamValue("@id_guest", txtCurp.Text.Trim()));
                    paramList.Add(new ParamValue("@name", txtName.Text.Trim()));
                    paramList.Add(new ParamValue("@lastName", txtLastName.Text.Trim()));
                    paramList.Add(new ParamValue("@slastName", txtSLastName.Text.Trim()));
                    paramList.Add(new ParamValue("@country", comboCountry.SelectedItem.ToString()));
                    paramList.Add(new ParamValue("@state", txtState.Text.Trim()));
                    paramList.Add(new ParamValue("@city", txtCity.Text.Trim()));
                    paramList.Add(new ParamValue("@telephone", txtTelephone.Text.Trim()));
                    paramList.Add(new ParamValue("@email", txtEmail.Text.Trim()));
                    paramList.Add(new ParamValue("@address", txtAddress.Text.Trim()));

                    if (_sqlConn.UpdateInsert(ref sqlError, Query.insertGuest, paramList))
                    {
                        foreach (TextBox txtBox in gridClientFields.Children)
                        {
                            txtBox.Text = "";
                        }

                        MessageBox.Show("Cliente agregado.");
                    }
                    else
                    {
                        MessageBox.Show(sqlError, "Error al agregar al cliente");
                    }
                }
            }
		}

        private bool AreFillRequiredFields(ref string errorFields)
        {
            errorFields = "";

            foreach (TextBox txtBox in gridClientFields.Children)   
            {
                if ((txtBox.Tag != null) && (String.IsNullOrEmpty(txtBox.Text)))
                {
                    errorFields += txtBox.Tag.ToString() + "\n";
                }
            }

            if (errorFields != "")
            {
                errorFields = "Campos faltantes: \n" + errorFields;
                return false;
            }

            return true;
        }

		private void txtCurp_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			//Checar en la base de datos si ya existe ese cliente
            if (!String.IsNullOrEmpty(txtCurp.Text))
            {
                string sqlError = "";
                List<ParamValue> paramList = new List<ParamValue>();
                paramList.Add(new ParamValue("@id_guest", txtCurp.Text.Trim()));

                DataTable sqlResult =_sqlConn.Select(ref sqlError, Query.getGuest, paramList);

                if (sqlResult == null)
                {
		            MessageBox.Show(sqlError, "Error al obtener el cliente");
                }
                else if (sqlResult.Rows.Count != 0)
                {
                    MessageBox.Show("Ya existe un cliente con esa CURP o ID", "Advertencia");   
                }
            }
		}
	}
}
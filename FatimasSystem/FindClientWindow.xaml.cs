using System;
using System.Collections.Generic;
using System.Data;
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
	/// Interaction logic for FindClientWindow.xaml
	/// </summary>
	public partial class FindClientWindow : Window
	{
        private SqlConnection _sqlConn;
        private AddReservation _addReservWnd;

        public FindClientWindow(SqlConnection sqlConn, AddReservation addReservWnd)
        {
            this.InitializeComponent();

            MainWindow.CenterWindowOnScreen(this);

            _sqlConn = sqlConn;
            _addReservWnd = addReservWnd;

            if (_addReservWnd == null)
            {
                btnSelectClient.Visibility = System.Windows.Visibility.Hidden;
                btnCancel.Visibility = System.Windows.Visibility.Hidden;
                this.Title = "Administrar clientes";
            }
            else
            {
                btnAddClient.Visibility = System.Windows.Visibility.Hidden;
                btnDeleteClient.Visibility = System.Windows.Visibility.Hidden;
            }

            AddUserWindow.FillComboCountry(comboCountry, true);

            // Insert code required on object creation below this point.
        }

		private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnSelectClient_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            try
            {
                _addReservWnd.GuestId = ((Guest)dgGuests.SelectedItem).IdGuest;
                this.Close();
            }
            catch (NullReferenceException)
            {
                //Esta excepción sucede si no se selecciona algún elemento en el DataGrid.
                MessageBox.Show("Seleccione un cliente");
            }
		}

		private void btnFindClient_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            if (AllFildsAreEmpty())
            {
                MessageBox.Show("Proporcione al menos un criterio de búsqueda");
                return;
            }

            List<Guest> guestList = new List<Guest>();

            if (!GetGuestsLike(guestList, String.Format(Query.getClientsLike, "id_guest", txtCurp.Text.Trim()), String.IsNullOrEmpty(txtCurp.Text.Trim()))) return;
            if (!GetGuestsLike(guestList, String.Format(Query.getClientsLike, "name", txtName.Text.Trim()), String.IsNullOrEmpty(txtName.Text.Trim()))) return;
            if (!GetGuestsLike(guestList, String.Format(Query.getClientsLike, "lastName", txtLastName.Text.Trim()), String.IsNullOrEmpty(txtLastName.Text.Trim()))) return;
            if (!GetGuestsLike(guestList, String.Format(Query.getClientsLike, "sLastName", txtSLastName.Text.Trim()), String.IsNullOrEmpty(txtSLastName.Text.Trim()))) return;
            if (!GetGuestsLike(guestList, String.Format(Query.getClientsLike, "country", comboCountry.SelectedItem.ToString().Trim()), String.IsNullOrEmpty(comboCountry.SelectedItem.ToString().Trim()))) return;
            if (!GetGuestsLike(guestList, String.Format(Query.getClientsLike, "state", txtState.Text.Trim()), String.IsNullOrEmpty(txtState.Text.Trim()))) return;
            if (!GetGuestsLike(guestList, String.Format(Query.getClientsLike, "city", txtCity.Text.Trim()), String.IsNullOrEmpty(txtCity.Text.Trim()))) return;
            if (!GetGuestsLike(guestList, String.Format(Query.getClientsLike, "telephone", txtTelephone.Text.Trim()), String.IsNullOrEmpty(txtTelephone.Text.Trim()))) return;
            if (!GetGuestsLike(guestList, String.Format(Query.getClientsLike, "email", txtEmail.Text.Trim()), String.IsNullOrEmpty(txtEmail.Text.Trim()))) return;
            if (!GetGuestsLike(guestList, String.Format(Query.getClientsLike, "address", txtAddress.Text.Trim()), String.IsNullOrEmpty(txtAddress.Text.Trim()))) return;

            dgGuests.Items.Clear();
            foreach (Guest guest in guestList)
            {
                dgGuests.Items.Add(guest);
            }

            if (guestList.Count == 0)
            {
                MessageBox.Show("No se encontraron clientes con la información proporcionada");
            }

		}

        private bool AllFildsAreEmpty()
        {
            foreach (var field in gridTxts.Children)
            {
                if ((field is TextBox) && !String.IsNullOrEmpty(((TextBox)field).Text.Trim()))
                {
                    return false;
                }
                else if ((field is ComboBox) && !String.IsNullOrEmpty(((ComboBox)field).SelectedItem.ToString().Trim()))
                {
                    return false;
                }
            }

            return true;
        }

        private bool GetGuestsLike(List<Guest> guestList, string query, bool emptyQuery)
        {
            using (new WaitCursor())
            {
                if (emptyQuery) return true;

                string sqlError = "";

                DataTable queryResult = _sqlConn.Select(ref sqlError, query, null);

                if (queryResult == null)
                {
                    MessageBox.Show(sqlError, "Error al hacer la búsqueda de clientes");
                    return false;
                }
                else
                {
                    Guest guestToAdd;
                    foreach (DataRow row in queryResult.Rows)
                    {
                        guestToAdd = RowToGuestObject(row);
                        if (!guestList.Contains(guestToAdd))
                        {
                            guestList.Add(guestToAdd);
                        }
                    }

                    return true;
                }
            }
        }

        private Guest RowToGuestObject(DataRow row)
        {
            return new Guest()
            {
                IdGuest = row[0].ToString(),
                Name = row[1].ToString(),
                LastName = row[2].ToString(),
                SLastName = row[3].ToString(),
                Country = row[4].ToString(),
                State = row[5].ToString(),
                City = row[6].ToString(),
                Telephone = row[7].ToString(),
                Email = row[8].ToString(),
                Address = row[9].ToString()
            };
        }

        private void btnAddClient_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	new AddUserWindow(_sqlConn).ShowDialog();
        }

        private void btnDeleteClient_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            using (new WaitCursor())
            {
                try
                {
                    string guestId = ((Guest)dgGuests.SelectedItem).IdGuest.ToString();

                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¡SI ELIMINA UN CLIENTE SE PIERDEN TAMBIÉN SUS RESERVACIONES Y PAGOS!\n\n¿Está seguro de eliminar este cliente?", "Confirmación", System.Windows.MessageBoxButton.YesNo);

                    if (messageBoxResult == MessageBoxResult.Yes)
                    {

                        //Obtenemos todas las reservaciones de este cliente
                        List<string> reservationsIdList = new List<string>();

                        string sqlError = "";
                        List<ParamValue> paramList = new List<ParamValue>();
                        paramList.Add(new ParamValue("@id_guest", guestId));

                        DataTable queryResult = _sqlConn.Select(ref sqlError, Query.getReservations, paramList);

                        if (queryResult == null)
                        {
                            MessageBox.Show(sqlError, "Ocurrio un error al tratar de eliminar a este cliente");
                            return;
                        }

                        foreach (DataRow row in queryResult.Rows)
                        {
                            reservationsIdList.Add(row[0].ToString());
                        }

                        //Eliminamos todos los pagos de cada reservación
                        foreach (string reservationId in reservationsIdList)
                        {
                            paramList.Clear();
                            paramList.Add(new ParamValue("@id_reservations", reservationId));

                            if (!_sqlConn.UpdateInsert(ref sqlError, Query.deletePayments, paramList))
                            {
                                MessageBox.Show(sqlError, "Ocurrio un error al tratar de eliminar a este cliente");
                                return;
                            }
                        }

                        //Eliminamos todas las reservaciones de este cliente
                        paramList.Clear();
                        paramList.Add(new ParamValue("@id_guest", guestId));

                        if (!_sqlConn.UpdateInsert(ref sqlError, Query.deleteReservations, paramList))
                        {
                            MessageBox.Show(sqlError, "Ocurrio un error al tratar de eliminar a este cliente");
                            return;
                        }

                        //Eliminamos el cliente
                        if (!_sqlConn.UpdateInsert(ref sqlError, Query.deleteClient, paramList))
                        {
                            MessageBox.Show(sqlError, "Ocurrio un error al tratar de eliminar a este cliente");
                            return;
                        }

                        dgGuests.Items.RemoveAt(dgGuests.SelectedIndex);
                        MessageBox.Show("Cliente eliminado exitosamente");
                    }
                }
                catch (NullReferenceException)
                {
                    //Esta excepción sucede si no se selecciona algún elemento en el DataGrid.
                    MessageBox.Show("Seleccione un cliente");
                }
            }
        }
	}
}
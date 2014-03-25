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
	/// Interaction logic for AddReservation.xaml
	/// </summary>
	public partial class AddReservation : Window
	{
        private ReservationRequest _reservationRequest;
        private SqlConnection _sqlConn;
        private string _guestId;

        public AddReservation(ReservationRequest reservationRequest, SqlConnection sqlConn)
		{
			this.InitializeComponent();

            _reservationRequest = reservationRequest;
            _sqlConn = sqlConn;

            lblDep.Content = _reservationRequest.Department;
            lblFromDate.Content = new DateTime(_reservationRequest.Ev.Year, _reservationRequest.Ev.Month, _reservationRequest.Ev.Day).ToString("D", CultureInfo.CreateSpecificCulture("es-MX"));

            MainWindow.CenterWindowOnScreen(this);
			// Insert code required on object creation below this point.
		}
		
		private void txtNumKids_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key < Key.D0 || e.Key > Key.D9)
            {
				if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
					e.Handled = true;
				}
			}
		}

		private void btnFindGuest_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            _guestId = "";

            new FindClientWindow(_sqlConn, this).ShowDialog();

            if (!_guestId.Equals(""))
            {
                txtCurp.Text = _guestId;
                txtCurp.IsEnabled = false;
                txtCurp.BorderBrush = Brushes.Green;
                txtCurp.BorderThickness = new Thickness(2, 2, 2, 2);
                btnAddReservation.IsEnabled = true;
            }
		}

		private void btnAddClient_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			AddUserWindow addUserWnd = new AddUserWindow(_sqlConn);
			addUserWnd.ShowDialog();
		}

		private void btnAddReservation_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            using (new WaitCursor())
            {
                //Validamos los campos requeridos
                string errorFields = "";
                if (!AreFillRequiredFields(ref errorFields))
                {
                    MessageBox.Show(errorFields);
                }
                else if ((Convert.ToInt32(txtNumKids.Text.Trim()) + Convert.ToInt32(txtNumAdults.Text.Trim())) > 10)
                {
                    MessageBox.Show("No se debe exceder de 10 personas por departamento");
                }
                else if ((toDatePicker.SelectedDate.Value < new DateTime(_reservationRequest.Ev.Year, _reservationRequest.Ev.Month, _reservationRequest.Ev.Day)))
                {
                    MessageBox.Show("La fecha de fin debe ser mayor o igual a la fecha de inicio", "Fecha incorrecta");
                }
                else
                {
                    using (new WaitCursor())
                    {
                        //Checamos si no se sobrepone el rango de fechas con alguna reservación actual
                        string sqlError = "";
                        List<ParamValue> paramList = new List<ParamValue>();
                        paramList.Add(new ParamValue("@date1", _reservationRequest.Ev.Year + "-" + _reservationRequest.Ev.Month + "-" + _reservationRequest.Ev.Day));
                        paramList.Add(new ParamValue("@date2", toDatePicker.SelectedDate.Value.ToString("yyyy-MM-dd")));
                        paramList.Add(new ParamValue("@id_departments", _reservationRequest.Department.ToString()));

                        DataTable queryResult = _sqlConn.Select(ref sqlError, Query.checkOverlappingReservations, paramList);

                        if (queryResult == null)
                        {
                            MessageBox.Show(sqlError, "Error en la conexión con la Base de datos");
                        }
                        else if (queryResult.Rows.Count == 0)
                        {
                            sqlError = "";
                            paramList.Clear();
                            paramList.Add(new ParamValue("@id_guest", txtCurp.Text.Trim()));
                            paramList.Add(new ParamValue("@id_departments", lblDep.Content.ToString().Trim()));
                            paramList.Add(new ParamValue("@from_Date", _reservationRequest.Ev.Year + "-" + _reservationRequest.Ev.Month + "-" + _reservationRequest.Ev.Day));
                            paramList.Add(new ParamValue("@to_Date", toDatePicker.SelectedDate.Value.Year + "-" + toDatePicker.SelectedDate.Value.Month + "-" + toDatePicker.SelectedDate.Value.Day));
                            paramList.Add(new ParamValue("@num_kids", txtNumKids.Text.Trim()));
                            paramList.Add(new ParamValue("@num_adult", txtNumAdults.Text.Trim()));
                            paramList.Add(new ParamValue("@comment", new TextRange(txtComment.Document.ContentStart, txtComment.Document.ContentEnd).Text));

                            if (_sqlConn.UpdateInsert(ref sqlError, Query.insertReservation, paramList))
                            {
                                MessageBox.Show("Reservación agregada");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(sqlError, "Error al agregar la reservación");
                            }
                        }
                        else
                        {
                            string overlappingDates = "Las fechas seleccionadas para esta reservación se traslapan con las siguientes reservaciones:\n";
                            for (int i = 0; i < queryResult.Rows.Count; i++)
                            {
                                overlappingDates += queryResult.Rows[i][0].ToString();
                                overlappingDates += (i == (queryResult.Rows.Count - 1)) ? "" : ", ";
                            }

                            MessageBox.Show(overlappingDates, "Error");
                        }
                    }
                }
            }
		}

        private bool AreFillRequiredFields(ref string errorFields)
        {
            errorFields = "";

            if (toDatePicker.SelectedDate == null)
            {
                errorFields = "Fecha de fin\n";
            }

            if (String.IsNullOrEmpty(txtNumKids.Text.Trim()))
            {
                errorFields += "Número de niños\n";
            }

            if (String.IsNullOrEmpty(txtNumAdults.Text.Trim()))
            {
                errorFields += "Número de adultos";
            }

            if (errorFields != "")
            {
                errorFields = "Campos faltantes: \n" + errorFields;
                return false;
            }

            return true;
        }

        public string GuestId
        {
            get { return _guestId; }
            set { _guestId = value; }
        }
	}
}
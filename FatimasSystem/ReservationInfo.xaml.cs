using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
	/// Interaction logic for ReservationInfo.xaml
	/// </summary>
	public partial class ReservationInfo : Window
	{
        private int _reservationId;
        private SqlConnection _sqlConn;

		public ReservationInfo(int reservationId, SqlConnection sqlConn)
		{
			this.InitializeComponent();

            MainWindow.CenterWindowOnScreen(this);

            _reservationId = reservationId;
            _sqlConn = sqlConn;
			// Insert code required on object creation below this point.
		}

		private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
            FillReservationAndClientInfo();
		}

        private void FillReservationAndClientInfo()
        {
            using (new WaitCursor())
            {
                string sqlError = "";
                List<ParamValue> paramList = new List<ParamValue>();
                paramList.Add(new ParamValue("@id_reservations", _reservationId.ToString()));

                DataTable queryResult = _sqlConn.Select(ref sqlError, Query.reservationInfo, paramList);

                if (queryResult == null)
                {
                    MessageBox.Show(sqlError, "Error al obtener la información de esta reservación");
                    this.Close();
                }
                else
                {
                    string[] fromDate = queryResult.Rows[0][2].ToString().Split('-');
                    string[] toDate = queryResult.Rows[0][3].ToString().Split('-');

                    lblNumRes.Content = queryResult.Rows[0][0].ToString();
                    lblDep.Content = queryResult.Rows[0][1].ToString();
                    lblFromDate.Content = new DateTime(Convert.ToInt32(fromDate[0]), Convert.ToInt32(fromDate[1]), Convert.ToInt32(fromDate[2])).ToString("D", CultureInfo.CreateSpecificCulture("es-MX"));
                    lblToDate.Content = new DateTime(Convert.ToInt32(toDate[0]), Convert.ToInt32(toDate[1]), Convert.ToInt32(toDate[2])).ToString("D", CultureInfo.CreateSpecificCulture("es-MX"));
                    lblNumKids.Content = queryResult.Rows[0][4].ToString();
                    lblNumAdults.Content = queryResult.Rows[0][5].ToString();
                    txtComment.Text = queryResult.Rows[0][6].ToString();

                    lblCurp.Content = queryResult.Rows[0][7].ToString();
                    lblFullName.Content = queryResult.Rows[0][8].ToString() + " " + (String.IsNullOrEmpty(queryResult.Rows[0][9].ToString()) ? "" : queryResult.Rows[0][9].ToString() + " ") + queryResult.Rows[0][10].ToString();
                    lblCountry.Content = queryResult.Rows[0][11].ToString();
                    lblState.Content = queryResult.Rows[0][12].ToString();
                    lblCity.Content = queryResult.Rows[0][13].ToString();
                    lblTelephone.Content = queryResult.Rows[0][14].ToString();
                    lblEmail.Content = queryResult.Rows[0][15].ToString();
                    lblAddress.Content = queryResult.Rows[0][16].ToString();

                }
            }
        }

        private void btnVerAgregarPagos_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	new PaymentsWindow(_reservationId, _sqlConn).ShowDialog();
        }

        private void btnDeleteReservatio_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Está seguro de eliminar la reservación?", "Confirmación", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using (new WaitCursor())
                {
                    string sqlError = "";
                    List<ParamValue> paramList = new List<ParamValue>();
                    paramList.Add(new ParamValue("@id_reservations", _reservationId.ToString()));

                    if (_sqlConn.UpdateInsert(ref sqlError, Query.deletePayments, paramList) &&
                        _sqlConn.UpdateInsert(ref sqlError, Query.deleteReservation, paramList))
                    {
                        MessageBox.Show("Reservación eliminada");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(sqlError, "Error al intentar borrar esta reservación");
                    }
                }
            }
        }
	}
}
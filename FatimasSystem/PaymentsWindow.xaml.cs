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
	/// Interaction logic for PaymentsWindow.xaml
	/// </summary>
	public partial class PaymentsWindow : Window
	{
        private int _reservationId;
        private SqlConnection _sqlConn;

		public PaymentsWindow(int reservationId, SqlConnection sqlConn)
		{
			this.InitializeComponent();

            MainWindow.CenterWindowOnScreen(this);

            _reservationId = reservationId;
            _sqlConn = sqlConn;

			// Insert code required on object creation below this point.
		}

		private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
            UpdateDataGrid();
		}

        private void UpdateDataGrid()
        {
            string sqlError = "";
            List<ParamValue> paramList = new List<ParamValue>();
            paramList.Add(new ParamValue("@id_reservations", _reservationId.ToString()));

            DataTable queryResult = _sqlConn.Select(ref sqlError, Query.getPayments, paramList);

            if (queryResult == null)
            {
                MessageBox.Show(sqlError, "Error al obtener los pagos de esta reservación");
                this.Close();
            }
            else
            {
                dgPagos.Items.Clear();

                foreach (DataRow row in queryResult.Rows)
                {
                    string[] date = row[2].ToString().Split('-');

                    dgPagos.Items.Add(
                        new Payment
                        {
                            PaymentId = Convert.ToInt32(row[0].ToString()),
                            Amount = row[1].ToString(),
                            Date = row[2].ToString()
                        });
                }
            }

            UpdateTotal();
        }

        private void UpdateTotal()
        {
            float total = 0f;
            foreach (var item in dgPagos.Items)
            {
                total += (float)Convert.ToDouble(((Payment)item).Amount);
            }

            lblTotal.Content = "$" + total;
        }

        private void btnDeletePayment_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Está seguro de eliminar este pago?", "Confirmación", System.Windows.MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    using (new WaitCursor())
                    {
                        string sqlError = "";
                        List<ParamValue> paramList = new List<ParamValue>();
                        paramList.Add(new ParamValue("@id_payments", ((Payment)dgPagos.SelectedItem).PaymentId.ToString()));

                        if (_sqlConn.UpdateInsert(ref sqlError, Query.deletePayment, paramList))
                        {
                            MessageBox.Show("Pago eliminado");
                            UpdateDataGrid();
                        }
                        else
                        {
                            MessageBox.Show(sqlError, "Error al tratar de eliminar el pago");
                            UpdateDataGrid();
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                //Esta excepción sucede si no se selecciona algún elemento en el DataGrid.
                MessageBox.Show("Seleccione un pago para eliminar");
            }
        }
		
		private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            using (new WaitCursor())
            {
                // Do something with the Input
                string input = InputTextBox.Text;

                if (IsDecimalNumber(input))
                {
                    // Clear InputBox.
                    InputTextBox.Text = String.Empty;

                    // YesButton Clicked! Let's hide our InputBox and handle the input text.
                    InputBox.Visibility = System.Windows.Visibility.Collapsed;

                    string sqlError = "";
                    List<ParamValue> paramList = new List<ParamValue>();
                    paramList.Add(new ParamValue("@id_reservations", _reservationId.ToString()));
                    paramList.Add(new ParamValue("@amount", input));
                    paramList.Add(new ParamValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                    if (_sqlConn.UpdateInsert(ref sqlError, Query.insertPayment, paramList))
                    {
                        MessageBox.Show("Pago agregado");
                        UpdateDataGrid();
                    }
                    else
                    {
                        MessageBox.Show(sqlError, "Error al tratar de agregar un pago");
                        UpdateDataGrid();
                    }
                }
                else
                {
                    MessageBox.Show("Valor incorrecto");
                }
            }
        }

        private bool IsDecimalNumber(string num)
        {
            try
            {
                Convert.ToDouble(num);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            // NoButton Clicked! Let's hide our InputBox.
            InputBox.Visibility = System.Windows.Visibility.Collapsed;

            // Clear InputBox.
            InputTextBox.Text = String.Empty;
        }

        private void btnAddPayment_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	InputBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnUpdatePayment_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	UpdateDataGrid();
        }
	}
}
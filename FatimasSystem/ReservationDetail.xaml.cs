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
	/// Interaction logic for ReservationDetail.xaml
	/// </summary>
	public partial class ReservationDetail : Window
	{
        private Event _ev;
        private int _totalDepartamentos;
        private SqlConnection _sqlConn;

		public ReservationDetail(Event ev, int totalDepartamentos, SqlConnection sqlConn)
		{
			this.InitializeComponent();

            _ev = ev;
            _totalDepartamentos = totalDepartamentos;
            _sqlConn = sqlConn;

            this.Title = "Reservaciones para el día " + new DateTime(_ev.Year, _ev.Month, _ev.Day).ToString("D", CultureInfo.CreateSpecificCulture("es-MX"));

            MainWindow.CenterWindowOnScreen(this);
		}
		
		private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
            UpdateReservations();
		}

        private void UpdateReservations()
        {
            using (new WaitCursor())
            {
                List<Reservation> reservationList = GetReservationsOfDay();
                List<Reservation> reservationListAux = new List<Reservation>();

                reservationStackP.Children.Clear();
                //Agregamos cada departamento
                for (int i = 1; i <= _totalDepartamentos; i++)
                {
                    reservationListAux = (from res in reservationList
                                          where res.IdDepartment == i
                                          select res).ToList<Reservation>();

                    Border br = new Border
                    {
                        BorderThickness = new Thickness(0.5, 0.5, 0.5, 0.5),
                        BorderBrush = Brushes.Black
                    };

                    StackPanel sp = new StackPanel
                    {
                        Width = Double.NaN,
                        Height = 60,
                        Orientation = Orientation.Horizontal
                    };

                    sp.Children.Add(new Label
                    {
                        Width = Double.NaN,
                        Height = Double.NaN,
                        BorderThickness = new Thickness(0.5, 0.5, 0.5, 0.5),
                        BorderBrush = Brushes.Black,
                        FontSize = 30.0,
                        FontWeight = FontWeights.Bold,
                        Content = i
                    });

                    sp.Children.Add(new Image
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/FatimasSystem;component/Images/departments.jpg")),
                        Width = Double.NaN,
                        Height = Double.NaN
                    });

                    if (reservationListAux.Count == 0)
                    {
                        AddImageToStackPanel(sp, i);
                    }
                    else if (reservationListAux.Count == 1)
                    {
                        AddReservationToStackPanel(sp, reservationListAux[0]);

                        //Checamos si la reservación termina este día para permitir hacer otra
                        if ((reservationListAux[0].ToDate.Year == _ev.Year) &&
                             (reservationListAux[0].ToDate.Month == _ev.Month) &&
                              (reservationListAux[0].ToDate.Day == _ev.Day))
                        {
                            AddImageToStackPanel(sp, i);
                        }
                    }
                    else if (reservationListAux.Count == 2)
                    {
                        AddReservationToStackPanel(sp, reservationListAux[0]);
                        AddReservationToStackPanel(sp, reservationListAux[1]);
                    }

                    br.Child = sp;

                    reservationStackP.Children.Add(br);

                }
            }
        }

        private void AddImageToStackPanel(StackPanel sp, int department)
        {
            Image img = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/FatimasSystem;component/Images/add_date.png")),
                Cursor = Cursors.Hand,
                Tag = new ReservationRequest() { Ev = _ev, Department = department }
            };
            img.MouseDown += img_MouseDown;

            sp.Children.Add(img);
        }

        private void AddReservationToStackPanel(StackPanel sp, Reservation reservation)
        {
            Label reservationLbl = new Label
            {
                Width = Double.NaN,
                Height = Double.NaN,
                BorderThickness = new Thickness(0.5, 0.5, 0.5, 0.5),
                BorderBrush = Brushes.Black,
                Content = "Reservación número: " + reservation.IdReservation.ToString() +
                            "\nDesde: " + reservation.FromDate.ToString("D", CultureInfo.CreateSpecificCulture("es-MX")) + 
                            "\nHasta: " + reservation.ToDate.ToString("D", CultureInfo.CreateSpecificCulture("es-MX")),
                Tag = reservation.IdReservation,
                Cursor = Cursors.Hand
            };

            reservationLbl.MouseDown += reservationLbl_MouseDown;

            sp.Children.Add(reservationLbl);
        }

        void reservationLbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new ReservationInfo(Convert.ToInt32(((Label)sender).Tag.ToString()), _sqlConn).ShowDialog();
            UpdateReservations();
        }

        void img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("Abrimos la ventana para hacer reservaciones " + ((ReservationRequest)((Image)sender).Tag).ToString());
            AddReservation addReservWnd = new AddReservation((ReservationRequest)((Image)sender).Tag, _sqlConn);
            addReservWnd.ShowDialog();

            UpdateReservations();
        }

        private List<Reservation> GetReservationsOfDay()
        {
            using (new WaitCursor())
            {
                List<Reservation> reservationList = new List<Reservation>();

                string sqlError = "";
                List<ParamValue> paramList = new List<ParamValue>();
                paramList.Add(new ParamValue("@date", _ev.Year + "-" + _ev.Month + "-" + _ev.Day));

                DataTable queryResult = _sqlConn.Select(ref sqlError, Query.dayReservations, paramList);

                if (queryResult == null)
                {
                    MessageBox.Show(sqlError, "Error al obtener las reservaciones de este día");
                    this.Close();
                    return reservationList;
                }

                foreach (DataRow row in queryResult.Rows)
                {
                    string[] fromDate = row[3].ToString().Split('-');
                    string[] toDate = row[4].ToString().Split('-');

                    reservationList.Add(new Reservation()
                    {
                        IdReservation = Convert.ToInt32(row[0].ToString()),
                        IdGuest = row[1].ToString(),
                        IdDepartment = Convert.ToInt32(row[2].ToString()),
                        FromDate = new DateTime(Convert.ToInt32(fromDate[0]), Convert.ToInt32(fromDate[1]), Convert.ToInt32(fromDate[2])),
                        ToDate = new DateTime(Convert.ToInt32(toDate[0]), Convert.ToInt32(toDate[1]), Convert.ToInt32(toDate[2])),
                        NumKids = Convert.ToInt32(row[5].ToString()),
                        NumAdult = Convert.ToInt32(row[6].ToString()),
                        Comment = row[7].ToString()
                    });
                }

                return reservationList;
            }
        }
	}
}
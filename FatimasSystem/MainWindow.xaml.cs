using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Globalization;
using System.Threading;
using System.Data;
using System.Reflection;

namespace FatimasSystem
{
    /*
        (Cuadrito blanco) Ninguna reservación/hospedaje -> RectangleStyle2
        (Cuadrito morado) Departamentos llenos -> RectangleStyle3
        (Cuadrito azul chicle) mayor o igual a 5 reservaciones -> RectangleStyle4
        (Cuadrito morado bajito) menor a 5 reservaciones -> RectangleStyle5
     */
    public partial class MainWindow : Window
    {
        private DateTime _currentDate;
        private int _totalDepartamentos;
        private SqlConnection _sqlConn = new SqlConnection("fatimasparadisekino.com", "3306", "fatimasp_cal", "fatimasp_rootCal", "Fatima.01");
        //private SqlConnection _sqlConn = new SqlConnection("localhost", "3306", "fatimasp_cal", "root", "root");
        private string _sqlError = "";

        public MainWindow()
        {
            InitializeComponent();

            //CenterWindowOnScreen(this);
        }

        private void FillMonthsAndYear()
        {
            comboMes.Items.Clear();

            string[] months = DateTimeFormatInfo.CurrentInfo.MonthNames;
            foreach (string month in months)
            {
                comboMes.Items.Add(month);
            }

            comboMes.Items.RemoveAt(comboMes.Items.Count - 1);

            comboMes.SelectedIndex = _currentDate.Month - 1;

            txtYear.Text = _currentDate.Year.ToString();
        }

        private int getDayOfWeek(DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Friday:
                    return 5;
                case DayOfWeek.Monday:
                    return 1;
                case DayOfWeek.Saturday:
                    return 6;
                case DayOfWeek.Sunday:
                    return 0;
                case DayOfWeek.Thursday:
                    return 4;
                case DayOfWeek.Tuesday:
                    return 2;
                case DayOfWeek.Wednesday:
                    return 3;
                default:
                    return -1;
            }
        }

        private int GetTotalDepartamentos()
        {
 	        _sqlError = "";
            DataTable queryResult = _sqlConn.Select(ref _sqlError, Query.departmentsCount, null);

            if (queryResult == null)
            {
                MessageBox.Show(_sqlError, "Error al obtener el número de departamentos");
                this.Close();

                return 0;
            }

            return Convert.ToInt32(queryResult.Rows[0][0].ToString());
        }

        private void UpdateCalendar()
        {
            using (new WaitCursor())
            {
                //Obtenemos el número de departamentos
                _totalDepartamentos = GetTotalDepartamentos();

                //Hacemos la consulta para obtener todas las reservaciones del mes
                List<FromToDate> reservationsList = GetReservationsPerMonth();

                int dayOfWeek = getDayOfWeek(_currentDate.DayOfWeek);
                int currentDay = 1;
                int lastDay = _currentDate.AddMonths(1).AddDays(-1).Day;
                DateTime now = DateTime.Now;

                //Iteramos llenando el calendario
                foreach (UniformGrid uGrid in daysGrid.Children)
                {
                    foreach (Grid grid in uGrid.Children)
                    {
                        //Ponemos vacíos los días hasta llegar al primero del mes
                        if (dayOfWeek > 0)
                        {
                            UpdateDay(grid, "RectangleStyle2", "", "", null, false);

                            dayOfWeek--;
                        }
                        //Ponemos vacíos los ultimos grids porque ya se rellenaron todos los días
                        else if (currentDay > lastDay)
                        {
                            UpdateDay(grid, "RectangleStyle2", "", "", null, false);
                        }
                        //Colocamos el día en el grid y el color correspondiente
                        else
                        {
                            int reservationsForThisDay = GetCountOfDepartmentsBusy((from res in reservationsList
                                                                                    where IsDateBetween(res.FromDate, res.ToDate, new DateTime(_currentDate.Year, _currentDate.Month, currentDay))
                                                                                    select res).ToList<FromToDate>());

                            int leftDepartments = _totalDepartamentos - reservationsForThisDay;

                            //Seleccionar el Style correspondiente
                            string style = GetStyle(reservationsForThisDay);

                            UpdateDay(grid, style, currentDay.ToString(),
                                leftDepartments + " Departamento(s)\ndisponible(s)",
                                new Event() { Year = _currentDate.Year, Month = _currentDate.Month, Day = currentDay },
                                (_currentDate.Year == now.Year) && (_currentDate.Month == now.Month) && (currentDay == now.Day));
                            currentDay++;
                        }
                    }
                }

                //Actualizamos el encabezado del calendario
                CultureInfo ci = Thread.CurrentThread.CurrentCulture;

                currentMonthAndYear.Text = String.Format("{0}, {1}",
                                    ci.DateTimeFormat.GetMonthName(_currentDate.Month), _currentDate.Year);

                //Actualizamos el pie de pagina del calendario
                lblCurrDate.Content = now.ToString("D", CultureInfo.CreateSpecificCulture("es-MX"));

            }
        }

        private int GetCountOfDepartmentsBusy(List<FromToDate> listDepartmentDates)
        {
            List<int> departmentList = new List<int>();

            foreach (FromToDate reservation in listDepartmentDates)
            {
                if (!departmentList.Contains(reservation.Department))
                {
                    departmentList.Add(reservation.Department);
                }
            }

            return departmentList.Count();
        }

        private string GetStyle(int reservationsForThisDay)
        {
            //(Cuadrito blanco) Ninguna reservación/hospedaje -> RectangleStyle2
            //(Cuadrito morado) Departamentos llenos -> RectangleStyle3
            //(Cuadrito azul chicle) mayor o igual a 5 reservaciones -> RectangleStyle4
            //(Cuadrito morado bajito) menor a 5 reservaciones -> RectangleStyle5

            if (reservationsForThisDay == 0)
            {
                return "RectangleStyle2";
            }

            if (reservationsForThisDay == _totalDepartamentos)
            {
                return "RectangleStyle3";
            }

            if (reservationsForThisDay >= 5)
            {
                return "RectangleStyle3";
            }

            return "RectangleStyle5";
        }

        private bool IsDateBetween(DateTime fromDate, DateTime toDate, DateTime dateToCompare)
        {
            //> -1
            //== 0
            //< 1
            int compareResult = DateTime.Compare(fromDate, dateToCompare);

            int compareResult2 = DateTime.Compare(toDate, dateToCompare);

            return ((compareResult <= 0) && (compareResult2 >= 0));
        }

        private List<FromToDate> GetReservationsPerMonth()
        {
            List<FromToDate> reservations = new List<FromToDate>();

            int lastDay = _currentDate.AddMonths(1).AddDays(-1).Day;
            List<ParamValue> paramList = new List<ParamValue>();
            paramList.Add(new ParamValue("@date1", _currentDate.Year + "-" + _currentDate.Month + "-1"));
            paramList.Add(new ParamValue("@date2", _currentDate.Year + "-" + _currentDate.Month + "-" + lastDay));

            _sqlError = "";
            DataTable queryResult = _sqlConn.Select(ref _sqlError, Query.monthReservations, paramList);

            if (queryResult == null)
            {
                MessageBox.Show(_sqlError, "Error al obtener las reservaciones del mes");
                return reservations;
            }

            foreach (DataRow row in queryResult.Rows)
            {
                string[] fromDateSplit = row[0].ToString().Split('-');
                string[] toDateSplit = row[1].ToString().Split('-');

                DateTime date1 = new DateTime(Convert.ToInt32(fromDateSplit[0]), Convert.ToInt32(fromDateSplit[1]), Convert.ToInt32(fromDateSplit[2]));
                DateTime date2 = new DateTime(Convert.ToInt32(toDateSplit[0]), Convert.ToInt32(toDateSplit[1]), Convert.ToInt32(toDateSplit[2]));

                reservations.Add(new FromToDate(date1, date2, Convert.ToInt32(row[2].ToString())));
            }

            return reservations;
        }

        private void UpdateDay(Grid grid, string style, string txt1, string txt2, Event ev, bool isNow)
        {
            Rectangle rect = (Rectangle) grid.Children[0];
            rect.Style = Application.Current.Resources[style] as Style;
            rect.StrokeThickness = isNow ? 3.0 : 0.5;

            ((TextBlock)grid.Children[1]).Text = txt2;
            ((TextBlock)grid.Children[2]).Text = txt1;


            grid.Tag = ev;
        }
		
		void Grid_MouseLeftButtonDown(object sender, MouseEventArgs e)
		{
            Grid gridDay = ((Grid)sender);
            if (gridDay.Tag != null)
            {
                ReservationDetail rdWindow = new ReservationDetail((Event)gridDay.Tag, _totalDepartamentos, _sqlConn);
				rdWindow.ShowDialog();

                UpdateCalendar();
            }
		}

		private void nextMonthBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _currentDate = _currentDate.AddMonths(1);
            UpdateCalendar();
		}

		private void previousMonthBtn_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            _currentDate = _currentDate.AddMonths(-1);
            UpdateCalendar();
		}

        public static void CenterWindowOnScreen(Window window)
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = window.Width;
            double windowHeight = window.Height;
            window.Left = (screenWidth / 2) - (windowWidth / 2);
            window.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void btnUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	UpdateCalendar();
        }

        private void txtYear_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
        	if (e.Key < Key.D0 || e.Key > Key.D9)
            {
				if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
					e.Handled = true;
				}
			}
        }

        private void btnGo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                _currentDate = new DateTime(Convert.ToInt32(txtYear.Text), comboMes.SelectedIndex + 1, 1);
                UpdateCalendar();
            }
            catch(FormatException)
            {
                MessageBox.Show("Introduzca un año válido");
            }
        }

        private void lblCurrDate_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	_currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        	UpdateCalendar();
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _sqlError = "";

            if (!_sqlConn.IsConnSuccessful(ref _sqlError))
            {
                MessageBox.Show(_sqlError, "Error en la conexión con la Base de datos");
                this.Close();

                return;
            }

            _currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            FillMonthsAndYear();
            
            UpdateCalendar();
        }

        private void btnClientManage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	new FindClientWindow(_sqlConn, null).ShowDialog();
            UpdateCalendar();
        }
    }
}

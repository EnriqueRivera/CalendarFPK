using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Clase que almacena las querys.
/// </summary>
public class Query
{
    #region QueryStrings
        
    //public static string UpdateAvailableSheets = "UPDATE users SET HojasDisponibles = @Sheets WHERE idUser = @idUser";
    public static string insertGuest = "INSERT INTO guests (id_guest, name, lastName, sLastName, country, state, city, telephone, email, address) VALUES (@id_guest, @name, @lastName, @sLastName, @country, @state, @city, @telephone, @email, @address);";
    public static string monthReservations = "SELECT DATE_FORMAT(from_date, '%Y-%m-%d'), DATE_FORMAT(to_date, '%Y-%m-%d'), id_departments FROM reservations WHERE (from_date BETWEEN @date1 AND @date2) OR (to_date BETWEEN @date1 AND @date2);";
    public static string dayReservations = "SELECT id_reservations, id_guest, id_departments, DATE_FORMAT(from_date, '%Y-%m-%d'), DATE_FORMAT(to_date, '%Y-%m-%d'), num_kids, num_adult, comment FROM reservations WHERE (@date BETWEEN from_date AND to_date);";
    public static string departmentsCount = "SELECT count(*) FROM departments;";
    public static string getGuest = "SELECT * FROM guests WHERE id_guest = @id_guest;";
    public static string checkOverlappingReservations = "SELECT id_reservations FROM reservations WHERE (from_date > @date1) AND (from_date < @date2) AND (id_departments = @id_departments);";
    public static string insertReservation = "INSERT INTO reservations (id_guest, id_departments, from_Date, to_Date, num_kids, num_adult, comment) VALUES (@id_guest, @id_departments, @from_Date, @to_Date, @num_kids, @num_adult, @comment);";
    public static string reservationInfo = "SELECT id_reservations, id_departments, DATE_FORMAT(from_date, '%Y-%m-%d'), DATE_FORMAT(to_date, '%Y-%m-%d'), num_kids, num_adult, comment, id_guest, name, lastName, sLastName, country, state, city, telephone, email, address FROM reservations NATURAL JOIN guests WHERE id_reservations = @id_reservations;";
    public static string getPayments = "SELECT id_payments, amount, date FROM payments WHERE id_reservations = @id_reservations;";
    public static string deletePayment = "DELETE FROM payments WHERE id_payments = @id_payments;";
    public static string deletePayments = "DELETE FROM payments WHERE id_reservations = @id_reservations;";
    public static string deleteReservation = "DELETE FROM reservations WHERE id_reservations = @id_reservations;";
    public static string deleteReservations = "DELETE FROM reservations WHERE id_guest = @id_guest;";
    public static string deleteClient = "DELETE FROM guests WHERE id_guest = @id_guest;";
    public static string insertPayment = "INSERT INTO payments (id_reservations, amount, date) VALUES (@id_reservations, @amount, @date);";
    public static string getClientsLike = "SELECT * FROM guests WHERE {0} LIKE '%{1}%';";
    public static string getReservations = "SELECT id_reservations FROM reservations WHERE id_guest = @id_guest;";

    #endregion
}

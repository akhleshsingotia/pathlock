using BuildingManagementApp;
using System;
using System.Data;
using System.Data.SqlClient;
public class BMApp 
{
    private const string connectionString = "Server=.;Database=TestDB;user id=sa;password=Raj@2010;MultipleActiveResultSets=True;";

    public static void Main(string[] args)
    {
        // Create tables
        CreateTable("Tenants", "TenantId INT PRIMARY KEY, Building VARCHAR(100), StartDate DATE, EndDate DATE");
        CreateTable("Guests", "GuestId INT PRIMARY KEY, ApartmentId INT, Date DATE, NumberOfGuests INT");

        // Insert example data
        InsertTenant(new Tenant { TenantId = 1, Building = "Building A", StartDate = DateTime.Now.AddDays(-30), EndDate = DateTime.Now.AddDays(30) });
        InsertTenant(new Tenant { TenantId = 2, Building = "Building B", StartDate = DateTime.Now.AddDays(-15), EndDate = DateTime.Now.AddDays(45) });

        InsertGuest(new Guest { GuestId = 1, ApartmentId = 1, Date = DateTime.Now, NumberOfGuests = 2 });
        InsertGuest(new Guest { GuestId = 2, ApartmentId = 2, Date = DateTime.Now.AddDays(-2), NumberOfGuests = -1 });

        // Get number of tenants and guests
        int numberOfTenants = GetNumberOfTenants();
        int numberOfGuests = GetNumberOfGuests();

        Console.WriteLine($"Number of tenants: {numberOfTenants}");
        Console.WriteLine($"Number of guests: {numberOfGuests}");

        Console.ReadLine();
    }

    public static void CreateTable(string tableName, string columns)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = $"CREATE TABLE {tableName} ({columns})";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }

    public static void InsertTenant(Tenant tenant)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = $"INSERT INTO Tenants (TenantId, Building, StartDate, EndDate) VALUES (@TenantId, @Building, @StartDate, @EndDate)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TenantId", tenant.TenantId);
            command.Parameters.AddWithValue("@Building", tenant.Building);
            command.Parameters.AddWithValue("@StartDate", tenant.StartDate);
            command.Parameters.AddWithValue("@EndDate", tenant.EndDate);

            command.ExecuteNonQuery();
        }
    }

    public static void InsertGuest(Guest guest)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = $"INSERT INTO Guests (GuestId, ApartmentId, Date, NumberOfGuests) VALUES (@GuestId, @ApartmentId, @Date, @NumberOfGuests)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@GuestId", guest.GuestId);
            command.Parameters.AddWithValue("@ApartmentId", guest.ApartmentId);
            command.Parameters.AddWithValue("@Date", guest.Date);
            command.Parameters.AddWithValue("@NumberOfGuests", guest.NumberOfGuests);

            command.ExecuteNonQuery();
        }
    }

    public static int GetNumberOfTenants()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT COUNT(*) FROM Tenants WHERE StartDate <= GETDATE() AND EndDate >= GETDATE()";
            SqlCommand command = new SqlCommand(query, connection);

            int numberOfTenants = Convert.ToInt32(command.ExecuteScalar());
            return numberOfTenants;
        }
    }

    public static int GetNumberOfGuests()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT SUM(NumberOfGuests) FROM Guests";
            SqlCommand command = new SqlCommand(query, connection);

            int numberOfGuests = Convert.ToInt32(command.ExecuteScalar());
            return numberOfGuests;
        }
    }
}
 
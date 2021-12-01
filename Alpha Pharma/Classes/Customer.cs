﻿using System.Data;
using System.Data.SqlClient;

namespace Alpha_Pharma
{
    class Customer
    {
        private static string myConn = Properties.Settings.Default.Pharmacy_dbConnectionString;

        public string ID { get; set; }
        public string CuFirstName { get; set; }
        public string CuLastName { get; set; }
        public string CuNumber { get; set; }
        public string Gender { get; set; }
        public string Date { get; set; }
        private const string SelectQuery = "Select cus_id as ID, cus_fname as CuFirstName, cus_lname as CuLastName, cus_number as CuNumber, cus_gender as Gender, cus_date as Date from Customers";
        private const string InsertQuery = "Insert Into Customers(cus_fname,cus_lname,cus_number,cus_gender,cus_date) Values (@CuFirstName,@CuLastName,@CuNumber,@Gender,@Date)";
        private const string UpdateQuery = "Update Customers set cus_fname=@CuFirstName, cus_lname=@CuLastName, cus_number=@CuNumber, cus_gender=@Gender, cus_date=@Date where cus_id=@ID";
        private const string DeleteQuery = "Delete from Customers where cus_id=@ID";

        public static DataTable GetCustomers()
        {
            DataTable datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SelectQuery, con))
                {
                    using (SqlDataAdapter adpater = new SqlDataAdapter(com))
                    {
                        adpater.Fill(datatable);
                    }
                }
            }
            return datatable;
        }
        public bool InsertCustomer(Customer customer)
        {
            int row;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@CuFirstName", customer.CuFirstName);
                    com.Parameters.AddWithValue("@CuLastName", customer.CuLastName);
                    com.Parameters.AddWithValue("@CuNumber", customer.CuNumber);
                    com.Parameters.AddWithValue("@Gender", customer.Gender);
                    com.Parameters.AddWithValue("@Date", customer.Date);
                    row = com.ExecuteNonQuery();
                }
            }
            return (row > 0) ? true : false;

        }
        public bool UpdateCustomer(Customer customer)
        {
            int row;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@ID", customer.ID);
                    com.Parameters.AddWithValue("@CuFirstName", customer.CuFirstName);
                    com.Parameters.AddWithValue("@CuLastName", customer.CuLastName);
                    com.Parameters.AddWithValue("@CuNumber", customer.CuNumber);
                    com.Parameters.AddWithValue("@Gender", customer.Gender);
                    com.Parameters.AddWithValue("@Date", customer.Date);
                    row = com.ExecuteNonQuery();

                }
            }
            return (row > 0) ? true : false;

        }
        public bool DeleteCustomer(Customer customer)
        {
            int row;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                {
                    com.Parameters.AddWithValue("@ID", customer.ID);

                    row = com.ExecuteNonQuery();

                }
            }
            return (row > 0) ? true : false;
        }

    }
}
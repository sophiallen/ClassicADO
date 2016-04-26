using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; //generic data tools
using System.Data.SqlClient; //sql-specific data tools libraries. 
using System.Configuration; //things to help in c# code to read config file. 

/// <summary>
/// This class will connect to the DB, will have methods
/// to retrieve the author, and to retrieve books written by that author. 
/// Sophia Allen 2016-4-19
/// </summary>
public class AuthorBooks
{
    SqlConnection connect;

    public AuthorBooks() //constructors: set up the initial conditions of the class. 
    {
        connect = new SqlConnection(ConfigurationManager.
            ConnectionStrings["AuthorBooklistConnectionString"].ToString());
    } // end constructor

    public DataTable GetAuthors()
    {       
        string sql = "SELECT AuthorKey, AuthorName from Author";
        SqlCommand cmd = new SqlCommand(sql,connect);
        DataTable tbl = ProcessQuery(cmd);
        return tbl;
    }

    public DataTable GetBooks(int authorKey)
    {
        string sql = "SELECT  Book.BookTitle, Book.BookEntryDate, Book.BookISBN FROM book INNER JOIN AuthorBook ON Book.BookKey = AuthorBook.BookKey WHERE AuthorKey = @authorKey";
        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.AddWithValue("@authorKey", authorKey);        
        DataTable tbl;
        tbl = ProcessQuery(cmd);
        return tbl;
    }
    
    private DataTable ProcessQuery(SqlCommand cmd)
    {
        DataTable table = new DataTable();
        SqlDataReader reader;
        connect.Open();
        reader = cmd.ExecuteReader();
        table.Load(reader);
        connect.Close();
        return table;
    }

}//end class
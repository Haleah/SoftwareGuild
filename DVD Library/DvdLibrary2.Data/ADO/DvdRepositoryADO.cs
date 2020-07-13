using DvdLibrary2.Data.Interfaces;
using DvdLibrary2.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary2.Data.ADO
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public List<Dvd> ReadAllDvd()
        {
            //Creates the list for the SQL commands
            List<Dvd> Dvds = new List<Dvd>();

            //Setting up the connection string as in the settings file
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                //Setting up the stored procedure command
                SqlCommand cmd = new SqlCommand("ReadAllDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Opens the connection to the database
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentDvd = new Dvd();
                        currentDvd.DvdId = (int)dr["DvdId"];
                        currentDvd.Title = dr["Title"].ToString();
                        currentDvd.ReleaseYear = dr["ReleaseYear"].ToString();
                        currentDvd.Director = dr["Director"].ToString();
                        currentDvd.Rating = dr["Rating"].ToString();
                        currentDvd.Notes = dr["Notes"].ToString();

                        //Load the object into the list

                        Dvds.Add(currentDvd);
                    }
                }
                cn.Close();
            }
            return Dvds;
        }

        public Dvd ReadDvdById(int DvdId)
        {
            //Creates the list for the SQL commands
            Dvd Dvds = new Dvd();

            //Setting up the connection string as in the settings file
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                //Setting up the stored procedure command
                SqlCommand cmd = new SqlCommand("ReadDvdById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", DvdId);

                //Opens the connection to the database
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentDvd = new Dvd();
                        currentDvd.DvdId = (int)dr["DvdId"];
                        currentDvd.Title = dr["Title"].ToString();
                        currentDvd.ReleaseYear = dr["ReleaseYear"].ToString();
                        currentDvd.Director = dr["Director"].ToString();
                        currentDvd.Rating = dr["Rating"].ToString();
                        currentDvd.Notes = dr["Notes"].ToString();

                        //Load the object into the obj
                        Dvds = currentDvd;
                    }
                }
                cn.Close();
            }
            return Dvds;
        }
        public List<Dvd> ReadDvdByTitle(string Title)
        {
            //Creates the list for the SQL commands
            List<Dvd> Dvds = new List<Dvd>();

            //Setting up the connection string as in the settings file
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                //Setting up the stored procedure command
                SqlCommand cmd = new SqlCommand("ReadDvdByTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", Title);

                //Opens the connection to the database
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentDvd = new Dvd();
                        currentDvd.DvdId = (int)dr["DvdId"];
                        currentDvd.Title = dr["Title"].ToString();
                        currentDvd.ReleaseYear = dr["ReleaseYear"].ToString();
                        currentDvd.Director = dr["Director"].ToString();
                        currentDvd.Rating = dr["Rating"].ToString();
                        currentDvd.Notes = dr["Notes"].ToString();

                        //Load the object into the list

                        Dvds.Add(currentDvd);
                    }
                }
                cn.Close();
            }
            return Dvds;
        }
        public List<Dvd> ReadDvdByReleaseYear(string ReleaseYear)
        {
            //Creates the list for the SQL commands
            List<Dvd> Dvds = new List<Dvd>();

            //Setting up the connection string as in the settings file
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                //Setting up the stored procedure command
                SqlCommand cmd = new SqlCommand("ReadDvdByReleaseYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ReleaseYear", ReleaseYear);

                //Opens the connection to the database
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentDvd = new Dvd();
                        currentDvd.DvdId = (int)dr["DvdId"];
                        currentDvd.Title = dr["Title"].ToString();
                        currentDvd.ReleaseYear = dr["ReleaseYear"].ToString();
                        currentDvd.Director = dr["Director"].ToString();
                        currentDvd.Rating = dr["Rating"].ToString();
                        currentDvd.Notes = dr["Notes"].ToString();

                        //Load the object into the list

                        Dvds.Add(currentDvd);
                    }
                }
                cn.Close();
            }
            return Dvds;
        }
        public List<Dvd> ReadDvdByDirector(string Director)
        {
            //Creates the list for the SQL commands
            List<Dvd> Dvds = new List<Dvd>();

            //Setting up the connection string as in the settings file
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                //Setting up the stored procedure command
                SqlCommand cmd = new SqlCommand("ReadDvdByDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Director", Director);

                //Opens the connection to the database
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentDvd = new Dvd();
                        currentDvd.DvdId = (int)dr["DvdId"];
                        currentDvd.Title = dr["Title"].ToString();
                        currentDvd.ReleaseYear = dr["ReleaseYear"].ToString();
                        currentDvd.Director = dr["Director"].ToString();
                        currentDvd.Rating = dr["Rating"].ToString();
                        currentDvd.Notes = dr["Notes"].ToString();

                        //Load the object into the list

                        Dvds.Add(currentDvd);
                    }
                }
                cn.Close();
            }
            return Dvds;
        }
        public List<Dvd> ReadDvdByRating(string Rating)
        {
            //Creates the list for the SQL commands
            List<Dvd> Dvds = new List<Dvd>();

            //Setting up the connection string as in the settings file
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                //Setting up the stored procedure command
                SqlCommand cmd = new SqlCommand("ReadDvdByRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Rating", Rating);

                //Opens the connection to the database
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentDvd = new Dvd();
                        currentDvd.DvdId = (int)dr["DvdId"];
                        currentDvd.Title = dr["Title"].ToString();
                        currentDvd.ReleaseYear = dr["ReleaseYear"].ToString();
                        currentDvd.Director = dr["Director"].ToString();
                        currentDvd.Rating = dr["Rating"].ToString();
                        currentDvd.Notes = dr["Notes"].ToString();

                        //Load the object into the list

                        Dvds.Add(currentDvd);
                    }
                }
                cn.Close();
            }
            return Dvds;
        }

        public void CreateDvd(Dvd dvd)
        {
            //Setting up the connection string as in the settings file
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                //Setting up the stored procedure command
                SqlCommand cmd = new SqlCommand("CreateDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                //Opens the connection to the database
                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public void UpdateDvd(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public void DeleteDvd(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }
    }
}

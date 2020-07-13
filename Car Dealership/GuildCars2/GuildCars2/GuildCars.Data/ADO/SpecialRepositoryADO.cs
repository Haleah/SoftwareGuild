using GuildCars.Data.Interface;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class SpecialRepositoryADO : ISpecialRepository
    {
        public void CreateSpecial(Specials special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateSpecials", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@title", special.Title);
                cmd.Parameters.AddWithValue("@description", special.Description);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public void DeleteSpecial(Specials special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteSpecials", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@specialId", special.SpecialId);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public List<Specials> ReadAllSpecials()
        {
            List<Specials> Special = new List<Specials>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReadAllSpecials", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials currentSpecial = new Specials();
                        currentSpecial.SpecialId = (int)dr["SpecialId"];
                        currentSpecial.Title = dr["Title"].ToString();
                        currentSpecial.Description = dr["Description"].ToString();


                        Special.Add(currentSpecial);
                    }
                }
                cn.Close();
            }
            return Special;
        }

        public Specials ReadBySpecialId(int SpecialId)
        {
            Specials Special = new Specials();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReadBySpecialId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials currentSpecial = new Specials();
                        currentSpecial.SpecialId = (int)dr["SpecialId"];
                        currentSpecial.Title = dr["Title"].ToString();
                        currentSpecial.Description = dr["Description"].ToString();


                        Special = currentSpecial;
                    }
                }
                cn.Close();
            }
            return Special;
        }

        public void UpdateSpecial(Specials special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateSpecial", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@makeId", special.SpecialId);
                cmd.Parameters.AddWithValue("@title", special.Title);
                cmd.Parameters.AddWithValue("@description", special.Description);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }
    }
}

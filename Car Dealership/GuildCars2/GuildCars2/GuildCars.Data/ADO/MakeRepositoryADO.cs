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
    public class MakeRepositoryADO : IMakeRepository
    {
        public void CreateMake(Makes make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateMake", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@make", make.Make);
                cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);
                //cmd.Parameters.AddWithValue("@makeId", make.MakeId);
                cmd.Parameters.AddWithValue("@employeeId", "1");//make.EmployeeId

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public List<Makes> ReadAllMakes()
        {
            List<Makes> Make = new List<Makes>();
            
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReadAllMake", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Makes currentMake = new Makes();
                        currentMake.MakeId = (int)dr["MakeId"];
                        currentMake.Make = dr["Make"].ToString();
                        currentMake.DateAdded = (DateTime)dr["DateAdded"];
                        //currentMake.ModelId = (VehicleModels)dr["ModelId"];
                        currentMake.EmployeeId = (int)dr["EmployeeId"];


                        Make.Add(currentMake);
                    }
                }
                cn.Close();
            }
            return Make;
        }

        public Makes ReadByMakeId(int makeId)
        {
            Makes Make = new Makes();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReadByMakeId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Makes currentMake = new Makes();
                        currentMake.MakeId = (int)dr["MakeId"];
                        currentMake.Make = dr["Make"].ToString();
                        currentMake.DateAdded = (DateTime)dr["DateAdded"];
                        //currentMake.ModelId = (VehicleModels)dr["ModelId"];
                        currentMake.EmployeeId = (int)dr["EmployeeId"];


                        Make = currentMake;
                    }
                }
                cn.Close();
            }
            return Make;
        }

        public void UpdateMake(Makes make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateMake", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@makeId", make.MakeId);
                cmd.Parameters.AddWithValue("@make", make.Make);
                //cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);
                //cmd.Parameters.AddWithValue("@makeId", make.ModelId);
                cmd.Parameters.AddWithValue("@employeeId", make.EmployeeId);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }
    }
}

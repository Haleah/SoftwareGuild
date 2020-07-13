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
    public class VehicleModelRepositoryADO : IModelRepository
    {
        public void CreateModel(VehicleModels model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateModel", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@model", model.Model);
                cmd.Parameters.AddWithValue("@dateAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@employeeId", model.EmployeeId);
                cmd.Parameters.AddWithValue("@makeId", model.MakeId);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public List<VehicleModels> ReadAllModel()
        {
            List<VehicleModels> Model = new List<VehicleModels>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReadAllModel", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleModels currentModel = new VehicleModels();
                        currentModel.ModelId = (int)dr["ModelId"];
                        currentModel.Model = dr["Model"].ToString();
                        currentModel.MakeId = (int)dr["MakeId"];
                        currentModel.DateAdded = (DateTime)dr["DateAdded"];
                        currentModel.EmployeeId = (int)dr["EmployeeId"];//add make


                        Model.Add(currentModel);
                    }
                }
                cn.Close();
            }
            return Model;
        }

        public VehicleModels ReadByModelId(int makeId)
        {
            VehicleModels Model = new VehicleModels();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ReadByModelId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleModels currentModel = new VehicleModels();
                        currentModel.ModelId = (int)dr["ModelId"];
                        currentModel.Model = dr["Model"].ToString();
                        currentModel.DateAdded = (DateTime)dr["DateAdded"];
                        currentModel.EmployeeId = (int)dr["EmployeeId"];


                        Model = currentModel;
                    }
                }
                cn.Close();
            }
            return Model;
        }

        public void UpdateModel(VehicleModels model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateModel", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@modelId", model.ModelId);
                cmd.Parameters.AddWithValue("@model", model.Model);
                //cmd.Parameters.AddWithValue("@dateAdded", model.DateAdded);
                cmd.Parameters.AddWithValue("@employeeId", model.EmployeeId);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }
    }
}

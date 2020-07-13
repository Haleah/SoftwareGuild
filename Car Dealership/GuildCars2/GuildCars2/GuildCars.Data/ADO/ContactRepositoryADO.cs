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
    public class ContactRepositoryADO : IContactRepository
    {
        public void CreateContact(Contact contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateContact", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", contact.Name);
                cmd.Parameters.AddWithValue("@phoneNumber", contact.PhoneNumber);
                cmd.Parameters.AddWithValue("@email", contact.Email);
                cmd.Parameters.AddWithValue("@message", contact.Message);

                cn.Open();

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }
    }
}

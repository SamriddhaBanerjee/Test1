using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace InfoTrial.Models
{
    public class InfoDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["InforMation"].ToString();
            con = new SqlConnection(constring);
        }

        //add Information
        public bool AddInformation(InforMation info)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddInformation", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", info.Name);
            cmd.Parameters.AddWithValue("@Address", info.Address);
            cmd.Parameters.AddWithValue("@Mobile", info.Mobile_Num);
            cmd.Parameters.AddWithValue("@Email", info.Email);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //view details
        public List<InforMation> GetInformation()
        {
            connection();
            List<InforMation> infolist = new List<InforMation>();

            SqlCommand cmd = new SqlCommand("GetInformation", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (System.Data.DataRow dr in dt.Rows)
            {
                infolist.Add(
                    new InforMation
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Address = Convert.ToString(dr["Address"]),
                        Mobile_Num = Convert.ToString(dr["Mobile"]),
                        Email = Convert.ToString(dr["Email"])
                    });
            }
            return infolist;
        }

        //update details
        public bool UpdateInformation(InforMation info)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateInformation", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@StdId", info.Id);
            cmd.Parameters.AddWithValue("@Name", info.Name);
            cmd.Parameters.AddWithValue("@Address", info.Address);
            cmd.Parameters.AddWithValue("@Mobile", info.Mobile_Num);
            cmd.Parameters.AddWithValue("@Email", info.Email);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //delete details
        public bool DeleteInformation(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteInformation", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StdId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
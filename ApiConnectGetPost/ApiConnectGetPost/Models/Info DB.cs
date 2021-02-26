using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;

namespace ApiConnectGetPost.Models
{
    public class Info_DB
    {
        public List<InformationViewModel> Show()
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataSet dsReturn = new DataSet();
            List<InformationViewModel> info = new List<InformationViewModel>();
            //InformationViewModel info = new InformationViewModel();
            SqlParameter[] parameters = new SqlParameter[]
           {
               // new SqlParameter("@Name", info.Id),
               //new SqlParameter("@Name", info.Name),
               // new SqlParameter("@Address", info.Address),
               // new SqlParameter("@Mobile", info.Mobile),
               // new SqlParameter("@Email", info.Email)
           };
            string cString = string.Empty;
            cString = con;
            using (DataSet ds = SqlHelper.ExecuteDataset(cString, "GetInformation", parameters))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    InformationViewModel lst = new InformationViewModel()
                    {
                        Id= Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Address = dr["Address"].ToString(),
                        Mobile = dr["Mobile"].ToString(),
                        Email = dr["Email"].ToString()
                    };
                    info.Add(lst);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dsReturn = ds;
                }
            }

            return info;
        }
        public DataSet Add(InformationViewModel info)
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataSet dsReturn = new DataSet();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", info.Name),
                new SqlParameter("@Address", info.Address),
                new SqlParameter("@Mobile", info.Mobile),
                new SqlParameter("@Email", info.Email)
            };
            string conString = string.Empty;
            conString = cs;
            using (DataSet ds = SqlHelper.ExecuteDataset(conString, "AddInformation", parameters))
            {
                //check if any record exist or not
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dsReturn = ds;
                }
            }

            return dsReturn;
        }

        public DataSet Update(InformationViewModel info)
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataSet dsReturn = new DataSet();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", info.Id),
                new SqlParameter("@Name", info.Name),
                new SqlParameter("@Address", info.Address),
                new SqlParameter("@Mobile", info.Mobile),
                new SqlParameter("@Email", info.Email)
            };
            string conString = string.Empty;
            conString = cs;
            using (DataSet ds = SqlHelper.ExecuteDataset(conString, "UpdateInformation", parameters))
            {
                //check if any record exist or not
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dsReturn = ds;
                }
            }

            return dsReturn;
        }
        public DataSet Delete(int ID)
        {
            DataSet dsReturn = new DataSet();
            InformationViewModel info = new InformationViewModel();
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StdId", ID)
            };
            string conString = string.Empty;
            conString = cs;
            using (DataSet ds = SqlHelper.ExecuteDataset(conString, "DeleteInformation", parameters))
            {
                //check if any record exist or not
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dsReturn = ds;
                }
            }
            return dsReturn;
        }

    }
}
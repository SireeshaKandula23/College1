using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISTS1.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult method1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult method2(string FirstName=null,string LastName = null, int Rank=0,string Email = null, string AreaCode = null, string PhoneNo = null, string Branch = null)
        {
            SqlParameter[] _sqlP; //1

            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@name",FirstName+LastName),
                    new SqlParameter("@branchCode",Branch),
                    new SqlParameter("@branch",Branch),
                    new SqlParameter("@rank",Rank),
                    new SqlParameter("@phoneno",PhoneNo),
                    new SqlParameter("@Email",Email),

                };
                //string connection = "Data Source=DESKTOP-M5Q4UP6;Initial Catalog=IstsRegistration;User ID=sa;Password=123";
                SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-M5Q4UP6;Initial Catalog=IstsRegistration;User ID=sa;Password=123");

                using (cnn)
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();

                    cnn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("InsertData_Freshers2022", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (_sqlP != null)
                    {
                        cmd.Parameters.AddRange(_sqlP);
                    }

                    //
                    //SqlDataAdapter da = new SqlDataAdapter();
                    //DataSet ds = new DataSet();
                    //da = new SqlDataAdapter(cmd);
                    //da.Fill(dt);

                    cmd.ExecuteScalar();

                    cnn.Close();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

                    return View();
        }

        
    }
}
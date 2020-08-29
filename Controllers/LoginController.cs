using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using MultiplexBookingWebAPI.Models;
using System.Security.Cryptography;
using System.Web.Http.Cors;
using System.Text;
using System.Web.UI.WebControls;

namespace MultiplexBookingWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/account")]
    public class LoginController : ApiController
    {
        string connectionString = @"database=MOVIEDB;server=IN-PF26Z3WV\SQLEXPRESS;user id=sa;pwd=P@ssw0rd";
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Authenticate(USER model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(
                cmdText: $"SELECT * FROM [USER] where UserName=@username and Password=@pwd",
                connection: connection
                );
            cmd.Parameters.AddWithValue("@username", model.UserName);
            cmd.Parameters.AddWithValue("@pwd", model.Password);


            try
            {
                connection.Open();
                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (!reader.HasRows)
                    return Unauthorized();
                while (reader.Read())
                {
                    model.UserID = Convert.ToInt32("0" + reader["UserID"].ToString());
                    var usernameBytes = Encoding.UTF8.GetBytes(model.UserName);
                    var hash = SHA256.Create().ComputeHash(usernameBytes);
                    var hashString = Encoding.UTF8.GetString(hash);
                   // model.Token = hashString.ToString();



                }
                reader.Close();
                //update the token in the db too
                //skipped for now
                return Ok(model);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }



        }
    }
}

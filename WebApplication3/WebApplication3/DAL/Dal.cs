using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
namespace WebApplication3.DAL
{
    public class Dal
    {


        SqlConnection con;
        SqlCommand cmd;
        public Dal()
        {
            string conStr = "Server=USHYD4KSHIVAN7\\SQLEXPRESS;Database=SupplyDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
            con = new SqlConnection(conStr);
        }

        public List<user> getUsers()
        {
            List<user> users = new List<user>();
            try
            {
                cmd = new SqlCommand(" select ut.username,ut.password,r.RoleName from users ut join UserDetails ur on ut.user_id=ur.UserId join RoleDetails r on r.RoleId = ur.RoleId\r\n\r\n", con);
                cmd.CommandType = CommandType.Text;

                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    user user = new user
                    {
                        username = sdr.GetString(0),
                        password = sdr.GetString(1),
                        role= sdr.GetString(2),
                    };
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return users;

        }
    }
}


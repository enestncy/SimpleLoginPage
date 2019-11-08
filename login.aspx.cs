using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

public partial class login : System.Web.UI.Page
{
    //Mysql bağlantısı
    MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=db;User Id=root;password=''");


    protected void Page_Load(object sender, EventArgs e)
    {}

    //Login butonu
    protected void b1_Click(object sender, EventArgs e)
    {
        //Girilen kullanıcı adı ve parolası(SHA1 algoritması ile hash yapılarak sorgular) veri tabanında sorgulanarak kullanıcı girişinin sağlanması
        con.Open();
        SHA1 sha = new SHA1CryptoServiceProvider();
        String pw = t2.Text;
        String hashpw = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(pw)));

        MySqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from users where customerId='" + t1.Text + "' and password='" + hashpw + "'";
        cmd.ExecuteNonQuery();

        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        da.Fill(dt);

        foreach (DataRow dr in dt.Rows)
        {
            Session["customerId"] = dr["customerId"].ToString();
            Response.Redirect("index.aspx");
        }
        con.Close();
       

        //Geçersiz kullanıcı durumunda uyarı
        Label1.Text = "Invalid username or password";
        
    }

    //Register butonu ile register sayfasına yönlendirme
    protected void b2_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
}
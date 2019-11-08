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

public partial class register : System.Web.UI.Page
{

    //Mysql bağlantısı
    MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=db;User Id=root;password=''");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Register butonu
    protected void b4_Click(object sender, EventArgs e)
    {

        //Kullanıcı adı veya parola kısmı boş bırakılamaz uyarısı
        if (t3.Text == "" || t4.Text == "")
        {
            Label2.Text = "username or password must be filled";
            return;
        }

        //Aynı isimde birden fazla kullanıcı kaydedilemez uyarısı
        con.Open();
        MySqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from users where customerId='" + t3.Text + "'";
        cmd.ExecuteNonQuery();

        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        da.Fill(dt);

        foreach (DataRow dr in dt.Rows)
        {
            if (dr["customerId"].ToString() == t3.Text)
            {
                Label2.Text = "the username exists";
                con.Close();
                return;
            }
        
        }

        //Kullanıcı adı ve parolanın(SHA1 algoritması ile hash yapılarak) veri tabanına kaydedilmesi
        SHA1 sha = new SHA1CryptoServiceProvider();
        String pw = t4.Text;
        String hashpw = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(pw)));

        MySqlCommand reg = con.CreateCommand();
        reg.CommandType = CommandType.Text;
        reg.CommandText = "insert into users (customerId , password , HashType ) values ('" + t3.Text + "' , '" + hashpw + "' , 'SHA1')";
        reg.ExecuteNonQuery();

        con.Close();
        Response.Redirect("login.aspx");

   
                
    }

    //Back to Login butonuna tıklandığında login sayfasına geri döner
    protected void b5_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
   

    protected void t3_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void t4_TextChanged(object sender, EventArgs e)
    {

    }
}
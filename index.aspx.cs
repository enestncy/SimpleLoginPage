using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class index : System.Web.UI.Page
{

    //Anlık zamanı tutan DateTime nesnesi
    DateTime dt = DateTime.Now;
    //Mysql bağlantısı
    MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=db;User Id=root;password=''");

    static int c = 0;

    //Sayfa yüklendiğinde yapılacak işlemler
    protected void Page_Load(object sender, EventArgs e)
    {
        //Kullanıcı oturum açmadı ise sayfayı login sayfasına yönlendir, böylece adres çubugundan index sayfasına erişim engellenmiş olur.
        if (Session["customerId"] == null)
        {
            Response.Redirect("login.aspx");
            return;
        }
      
        //Oturum açmış olan kullanıcının oturum açtığı tarih bilgisinin veri tabanına kaydedilmesi
        con.Open();
        c++;
        MySqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update users set lastLogintime='" + dt + "' where customerId='" + Session["customerId"].ToString() + "'";
        if (c != 0) { cmd.ExecuteNonQuery(); }
        con.Close();
        c = -1;

        //Kullanıcı oturum açtığında kullanıcıyı karşılayan yazı
        Label3.Text = "Welcome " + Session["customerId"].ToString() + "";
        
      
        
     
    }

    //Logout butonu ile kullanıcının oturumu kapatması , sayfa tekrar login sayfasına yönlendirilir
    protected void b3_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("login.aspx");
        return;
    }

    //Tıklandığında kullanıcının işlem yaptığını temsil eden Trade butonu, tıklandığı zaman kullanıcının işlem yaptığı tarih biligisini veritabanına kaydeder. 
    protected void b4_Click(object sender, EventArgs e)
    {
        con.Open();
        MySqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update users set lastUpdateDate ='" + dt + "' where customerId='" + Session["customerId"].ToString() + "'";
        cmd.ExecuteNonQuery();
        con.Close();
    }
}
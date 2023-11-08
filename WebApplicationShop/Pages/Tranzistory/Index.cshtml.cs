using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApplicationShop.Pages.Tranzistory
{
    public class IndexModel : PageModel
    {
        public List<Zoznam> listTranzistory = new List<Zoznam>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=webshop;Persist Security Info=True;User ID=sa;Password=*******";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM tranzistory";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Zoznam zoznam = new Zoznam();
                                zoznam.id = "" + reader.GetInt32(0);
                                zoznam.oznacenie = reader.GetString(1);
                                zoznam.puzdro = reader.GetString(2);
                                zoznam.typ = reader.GetString(3);
                                zoznam.mnozstvo = "" + reader.GetInt32(4);
                                zoznam.vytvorene = reader.GetDateTime(5).ToString();

                                listTranzistory.Add(zoznam);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
    public class Zoznam
    {
        public String id;
        public String oznacenie;
        public String puzdro;
        public String typ;
        public String mnozstvo;
        public String vytvorene;
    }
}

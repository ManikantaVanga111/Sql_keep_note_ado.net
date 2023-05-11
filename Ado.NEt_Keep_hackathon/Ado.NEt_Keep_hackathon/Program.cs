using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace Ado.NEt_Keep_hackathon
{
    class Note
    {
        public static void CreateNote(SqlConnection conn)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from notetable", conn);
            DataSet ds = new DataSet();
            adp.Fill(ds,"table1");
            var row = ds.Tables["table1"].NewRow();
            Console.WriteLine("Enter the title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter description");
            string description = Console.ReadLine();
            DateTime date = DateTime.Now;
            row["title"] = title;
            row["descri"] = description;
            row["da_te"] = date;
            ds.Tables["table1"].Rows.Add(row);
            SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
            adp.Update(ds, "table1");
            Console.WriteLine("successfully inserted");
            

        }
        public static void ViewNote(SqlConnection conn)
        {
            Console.WriteLine("Enter the id");
            int id=Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from notetable where id={id}", conn);
            DataSet ds=new DataSet();
            adp.Fill(ds, "table1");
            for (int i = 0; i < ds.Tables["table1"].Rows.Count; i++)
            {
                Console.WriteLine("Id\tTitle\tDescription\tDate");
                for (int j = 0; j < ds.Tables["table1"].Columns.Count; j++)
                {
                    
                    Console.Write($"{ds.Tables["table1"].Rows[i][j]}\t");
                }
                Console.WriteLine();
            }

        }
        public static void ViewAllNotes(SqlConnection conn)
        {
             int c=0;
            SqlDataAdapter adp = new SqlDataAdapter($"select * from notetable ", conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "table1");
            Console.WriteLine("Id\tTitle\tDescription\tDate");
            for (int i = 0; i < ds.Tables["table1"].Rows.Count; i++)
            {
               c++;
                for (int j = 0; j < ds.Tables["table1"].Columns.Count; j++)
                {

                    Console.Write($"{ds.Tables["table1"].Rows[i][j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Total notes {c}") ;
        }
        public static void UpdateNote(SqlConnection conn)
        {
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from notetable where id={id}", conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            var row = ds.Tables[0].Rows[0];
            Console.WriteLine("Enter the update title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter update description");
            string description = Console.ReadLine();
            DateTime date = DateTime.Now;
            row["title"] = title;
            row["descri"] = description;
            row["da_te"] = date;
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Successfully updated");


        }
        public static void DeleteNote(SqlConnection conn)
        {
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from notetable where id = {id}", conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            ds.Tables[0].Rows[0].Delete();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Successfully deleted");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                SqlConnection conn = new SqlConnection("Server=US-1C4R8S3;Database=keepnote;Integrated security=true");
                Console.WriteLine("1 for createnote");
                Console.WriteLine("2 for viewnote");
                Console.WriteLine("3 for viewallnotes");
                Console.WriteLine("4 for updatenote");
                Console.WriteLine("5 for Deletenote");
                Console.WriteLine("Select option");
                int ch=Convert.ToInt32(Console.ReadLine());
                switch(ch)
                {
                    case 1:
                        {
                            Note.CreateNote(conn);
                            break;
                        }
                    case 2:
                        {
                            Note.ViewNote(conn);
                            break;
                        }
                    case 3:
                        {
                            Note.ViewAllNotes(conn);
                            break;
                        }
                    case 4:
                        {
                            Note.UpdateNote(conn);
                            break;
                        }
                    case 5:
                        {
                            Note.DeleteNote(conn);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong choice");
                            break;
                        }
                }
            }
        }
    }
}
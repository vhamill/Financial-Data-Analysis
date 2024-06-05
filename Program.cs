// See https://aka.ms/new-console-template for more information

// 1: Get files from these two links
// TICKERS: [https://www.alphaforge.net/A0B1C3/TICKERS.zip]
// PRICES: [https://www.alphaforge.net/A0B1C3/PRICES.zip]
// import data into the db

// 2: Design Database and import the data from these files in db
// Analyze tickers and prices files to determine tables and schema
// Design database tables to **EFFICIENTLY** store the data
// Create and keep the SQL Scripts to generate the necessary tables indexes and relationships

// 3: Create stored proc: for given ticker calculate:
// 52-day moving average price
// 52-week high price
// 52-week low price

// 4: post to new github repo

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using PzenaProject;
using System.Data;
using System.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Net;

namespace PzenaProject 
{ 
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=VINCE_PC;Initial Catalog=PzenaProject;Integrated Security=True;TrustServerCertificate=True"))
            {
                conn.Open();
                Program.writeTickers(conn);
                Program.writePrices(conn);
                
                conn.Close();

            }
            Console.WriteLine("Done");
        }

        private static void writeTickers(SqlConnection conn)
        {
            Program.getFile("https://www.alphaforge.net/A0B1C3/TICKERS.zip");
            using (StreamReader reader = new StreamReader(@"C:\Users\Vince\Documents\Pzena Project\TICKERS.csv"))
            {
                var lineNumber = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (lineNumber != 0)
                    {

                        var values = line.Split(',');

                        var sql = @"INSERT INTO PzenaProject.dbo.Tickers([table],permaticker,ticker,name,exchange,isdelisted,category,cusips,siccode,sicsector,sicindustry,famasector,famaindustry,sector,industry,scalemarketcap,scalerevenue,relatedtickers,currency,location,lastupdated,firstadded,firstpricedate,lastpricedate,firstquarter,lastquarter,secfilings,companysite) 
                                    VALUES (@table,@permaticker,@ticker,@name,@exchange,@isdelisted,@category,@cusips,@siccode,@sicsector,@sicindustry,@famasector,@famaindustry,@sector,@industry,@scalemarketcap,@scalerevenue,@relatedtickers,@currency,@location,@lastupdated,@firstadded,@firstpricedate,@lastpricedate,@firstquarter,@lastquarter,@secfilings,@companysite)";


                        var cmd = new SqlCommand();
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@table", values[0]);
                        cmd.Parameters.AddWithValue("@permaticker", (values[1] != "" ? values[1] : DBNull.Value));
                        cmd.Parameters.AddWithValue("@ticker", values[2]);
                        cmd.Parameters.AddWithValue("@name", values[3]);
                        cmd.Parameters.AddWithValue("@exchange", values[4]);
                        cmd.Parameters.AddWithValue("@isdelisted", values[5]);
                        cmd.Parameters.AddWithValue("@category", values[6]);
                        cmd.Parameters.AddWithValue("@cusips", values[7]);
                        cmd.Parameters.AddWithValue("@siccode", (values[8] != "" ? values[8] : DBNull.Value));
                        cmd.Parameters.AddWithValue("@sicsector", values[9]);
                        cmd.Parameters.AddWithValue("@sicindustry", values[10]);
                        cmd.Parameters.AddWithValue("@famasector", values[11]);
                        cmd.Parameters.AddWithValue("@famaindustry", values[12]);
                        cmd.Parameters.AddWithValue("@sector", values[13]);
                        cmd.Parameters.AddWithValue("@industry", values[14]);
                        cmd.Parameters.AddWithValue("@scalemarketcap", values[15]);
                        cmd.Parameters.AddWithValue("@scalerevenue", values[16]);
                        cmd.Parameters.AddWithValue("@relatedtickers", values[17]);
                        cmd.Parameters.AddWithValue("@currency", values[18]);
                        cmd.Parameters.AddWithValue("@location", values[19]);
                        cmd.Parameters.AddWithValue("@lastupdated", values[20]);
                        cmd.Parameters.AddWithValue("@firstadded", values[21]);
                        cmd.Parameters.AddWithValue("@firstpricedate", values[22]);
                        cmd.Parameters.AddWithValue("@lastpricedate", values[23]);
                        cmd.Parameters.AddWithValue("@firstquarter", values[24]);
                        cmd.Parameters.AddWithValue("@lastquarter", values[25]);
                        cmd.Parameters.AddWithValue("@secfilings", values[26]);
                        cmd.Parameters.AddWithValue("@companysite", values[27]);
                        cmd.ExecuteNonQuery();
                    }
                    lineNumber++;

                }

            }
        }

        private static void writePrices(SqlConnection conn) 
        {
            Program.getFile("https://www.alphaforge.net/A0B1C3/PRICES.zip");
            using (StreamReader reader = new StreamReader(@"C:\Users\Vince\Documents\Pzena Project\PRICES.csv"))
            {
                var lineNumber = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (lineNumber != 0)
                    {

                        var values = line.Split(',');

                        var sql = @"INSERT INTO PzenaProject.dbo.Prices(ticker,date,[open],high,low,[close],volume,closeadj,closeunadj,lastupdated) 
                                    VALUES (@ticker,@date,@open,@high,@low,@close,@volume,@closeadj,@closeunadj,@lastupdated)";

                        var cmd = new SqlCommand();
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@ticker", values[0]);
                        cmd.Parameters.AddWithValue("@date", values[1]);
                        cmd.Parameters.AddWithValue("@open", (values[2] != "" ? decimal.Parse(values[2], System.Globalization.NumberStyles.Float) : DBNull.Value));
                        cmd.Parameters.AddWithValue("@high", (values[3] != "" ? decimal.Parse(values[3], System.Globalization.NumberStyles.Float) : DBNull.Value));
                        cmd.Parameters.AddWithValue("@low", (values[4] != "" ? decimal.Parse(values[4], System.Globalization.NumberStyles.Float) : DBNull.Value));
                        cmd.Parameters.AddWithValue("@close", (values[5] != "" ? values[5] : DBNull.Value));
                        cmd.Parameters.AddWithValue("@volume", (values[6] != "" ? decimal.Parse(values[6], System.Globalization.NumberStyles.Float) : DBNull.Value));
                        cmd.Parameters.AddWithValue("@closeadj", (values[7] != "" ? values[7] : DBNull.Value));
                        cmd.Parameters.AddWithValue("@closeunadj", (values[8] != "" ? values[8] : DBNull.Value));
                        cmd.Parameters.AddWithValue("@lastupdated", values[9]);
                         cmd.ExecuteNonQuery();
                    }
                    lineNumber++;

                }

            }
        }
        private static void getFile(string url)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
            webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
            webClient.DownloadFile(new Uri(url), "file.zip");
            System.IO.Compression.ZipFile.ExtractToDirectory("file.zip", "C:\\Users\\Vince\\Documents\\Pzena Project", null, true);
        }
    }

    
}

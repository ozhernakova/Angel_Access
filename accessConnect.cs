using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angel_Access
{
    public class dataToDisplay
    { 
        public List <string> horizons;
        public List <string> regions;
        public DataSet hor;
    
    }
    class accessConnect
    {
        string strConPosition = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\\OLYA\\mulev\\PEZ\\ПЭЗ_И.accdb"; 
        string strConAngel; // строка соединения с базой, из которой читаем и пишем данные прибора
        string qGetHor; // срока запроса
        public dataToDisplay dtd = new dataToDisplay();

        public accessConnect ()
        {
        LoadPosition();
        }

         private void LoadPosition()
        {
             // строка соединения с базой из которой берем горизонты и пр - и ничего не пишем
            string strCon = strConPosition; //Settings.Default.PID2dbConnectionString;

            try
            {
                using (OleDbConnection conn = new OleDbConnection(strCon))
                {
                    conn.Open();
                    string strSql = "SELECT * from Горизонт"; //WHERE [customerID] ='" + txtName.Text + "'";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                    dtd.hor = new DataSet();
                    adapter.Fill(dtd.hor);
                    
                }     
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
        }
    }

  /// <summary>
  /// проверка, доступна ли база
  /// </summary>
  /// <param name="strCon">connection string</param>
  /// <returns></returns>
        //bool checkConnection(string strCon) 
        //{

           
        //    return false;
        //}
    }


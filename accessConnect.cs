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

        public DataTable horizons;
        public DataTable regions;
        public DataTable virabotki;
    
    }
    class accessConnect
    {
        string strConPosition ; 
        string strConAngel; // строка соединения с базой, из которой читаем и пишем данные прибора
        
        public dataToDisplay dtd = new dataToDisplay();

        public accessConnect (string path)
        {
            strConPosition = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path; //   H:\\OLYA\\mulev\\PEZ\\PEZ_tbl.accdb
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
                    dtd.horizons = new DataTable();
                    adapter.Fill(dtd.horizons);

                    strSql = "SELECT * from Участок";
                    adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                    dtd.regions = new DataTable();
                    adapter.Fill(dtd.regions);
                    
                }     
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
        }

         public int virabotka(string hor, string reg) 
         {
             string strSql = "SELECT Выработка.[id], Выработка.[Выработка], Блок.[Блок], Подэтаж.[Подэтаж] FROM (Подэтаж INNER JOIN (Блок INNER JOIN Выработка ON Блок.id = Выработка.Блок) ON Подэтаж.id = Выработка.Подэтаж) where Выработка.[Горизонт] =" + hor + " AND Выработка.[Участок] =" + reg; //WHERE [customerID] ='" + txtName.Text + "'";
 //  SELECT ЗАМЕР.id, ЗАМЕР.Дата, Горизонт.Горизонт, Участок.Участок, Блок.Блок, Подэтаж.Подэтаж, Выработка.Выработка FROM (Участок INNER JOIN (Подэтаж INNER JOIN (Горизонт INNER JOIN ((Блок INNER JOIN Выработка ON Блок.id=Выработка.Блок) INNER JOIN Центр ON Выработка.id=Центр.Выработка) ON Горизонт.id=Выработка.Горизонт) ON Подэтаж.id=Выработка.Подэтаж) ON Участок.id=Выработка.Участок) INNER JOIN   
             string strCon = strConPosition; //Settings.Default.PID2dbConnectionString;

             try
             {
                 using (OleDbConnection conn = new OleDbConnection(strCon))
                 {
                     conn.Open();
                     OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                     dtd.virabotki = new DataTable("Virabotki");

                     adapter.Fill(dtd.virabotki);
                     return dtd.virabotki.Rows.Count;
                 }
             }
             catch (Exception ex)
             {

                 Console.WriteLine(ex.Message);
                 return -1;
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


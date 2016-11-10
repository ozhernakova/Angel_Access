using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Angel_Access
{
  
    public class AccessConnect
    {
       // string strConMainTbl; // строка соединения с базой, в которой лежат таблицы с выработками, горизонтами и пр
        string connectionString;    // строка соединения с базой, из которой читаем и пишем данные прибора
        DataToDisplay dtd; // данные для отображения
        
        //public const string MAINTABLE = @"\PEZ_tbl.accdb";
        public const string TABLETOADD = @"\ПЭЗ_И.accdb";
        public const string TABLES = @"\PEZ-angel.accdb";
        

        public AccessConnect (string path, DataToDisplay dtd)
        {
           // strConMainTbl = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + MAINTABLE;
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + TABLES;
            this.dtd = dtd;
            
        }

       public bool SaveAngelData(List <AngelData> adl, string [] param) 
        {
           bool result = false;
           
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {   
                    conn.Open();
                    // либо находим, либо дописываем запись в таблицу Центр
                    int idCenter = get_centre(conn, dtd.idVirabotka, param[6], dtd.idNapravlenie); // породу нужно спрашивать..
                    if (idCenter == -1) return result; 
                        // todo - генерируем ошибку;
                    int idZamer = get_zamer(conn, idCenter, adl[0].Dt, dtd.idPribor, 1); 
                    if (idZamer  == -1) return result;
                    String angelZamer = @"Insert Into Angel_ЗАМЕРЫ ([ЗамерПЭЗ], [Участок],[Горизонт], [Выработка], [Блок], [Привязка], [Порода]) Values (" + idZamer + ",'" + param[2] + "','" + param[1] + "','" + param[3] + "','" + param[4] + "','" + param[6] + "','" + dtd.Poroda + "')";
                    OleDbCommand cmd = new OleDbCommand(angelZamer, conn);
                    cmd.ExecuteNonQuery();  
 
                    foreach (AngelData ad in adl)
                    {
                        String my_query1 = @"INSERT INTO Angel_ПОКАЗАНИЯ (Замер,Line, Picket, [Comp],[Time], t, A, Lmin, Lmax, VarA, B, L1, L2, L3, L4, L5, L6,L7,L8,L9,L10) Values (" + idZamer+ ","+ ad.getAllAsString()+")";
                        cmd = new OleDbCommand(my_query1, conn);
                        cmd.ExecuteNonQuery();   
                    }
                    result = true;       
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); MessageBox.Show(ex.Message); }
                
           return result;
        }

        /// <summary>
        /// Программа для создания нового замера в табл Замеры.
        /// </summary>
        /// <param name="conn">соединение</param>
        /// <param name="idCenter">ид номер записи табл Центр (определяющей место замера)</param>
        /// <param name="dt">время замера - берем по времени первой записи в данных</param>
        /// <param name="pribor">id прибора (считали при загрузке)</param>
        /// <param name="method">метод измерений. свой не называем, используем первый попавшийся(потому что там к методу привязаны доп параметры)</param>
        /// <returns>ид номер записи в таблице Замер</returns>
        private int get_zamer(OleDbConnection conn, int idCenter, DateTime dt, int pribor, int method = 1) 
        {
            int idZamer = -1;
            String insertZamer = @"Insert into Замер ([Дата],[Центр],[Прибор],[Метод]) Values ('"+dt+"',"+idCenter+","+ pribor+","+method+")";

            try
            {
                OleDbCommand cmd = new OleDbCommand(insertZamer, conn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("SELECT @@IDENTITY", conn);  //http://www.mikesdotnetting.com/article/54/getting-the-identity-of-the-most-recently-added-record
                idZamer = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message);
            MessageBox.Show(ex.Message);
            }

            return idZamer;
        }


        /// <summary>
        /// Программа определяет строку в таблице Центр, если измерения проводятся в том же месте, направлении и с тем же описанием, или создает новую запись
        /// </summary>
        /// <param name="conn">cоединение с базой</param>
        /// <param name="idVirabotka">ид номер выработки</param>
        /// <param name="Priviazka">Привязка - текстовое описание места измерения</param>
        /// <param name="idNapravlenie">направление -?</param>
        /// <param name="Poroda">Порода в месте измерения</param>
        /// <returns>идентификатор записи в базе Центр, соответствующий данным параметрам</returns>
        private int get_centre(OleDbConnection conn, int idVirabotka, string Priviazka, int idNapravlenie) 
        {

            String checkCenter = @"SELECT Центр.id FROM Центр where Центр.Выработка = " + idVirabotka + " AND Центр.Привязка ='" + Priviazka + "' AND Центр.Направление =" + idNapravlenie;
            int idCenter = -1;

            try
            {

                OleDbCommand cmdCheckCenter = new OleDbCommand(checkCenter, conn);
                object tmp = cmdCheckCenter.ExecuteScalar();
                if (tmp == null) //  не нашли такую запись
                {

                    String insertCenter = @"Insert into Центр ([Выработка], [Привязка], [Направление], [Порода]) Values ('" + idVirabotka + "', '" + Priviazka + "','" + idNapravlenie + "','" + dtd.idPoroda + "')";

                    OleDbCommand cmdInsertCenter = new OleDbCommand(insertCenter, conn);
                    cmdInsertCenter.ExecuteNonQuery();
                    cmdCheckCenter = new OleDbCommand("SELECT @@IDENTITY", conn);  //http://www.mikesdotnetting.com/article/54/getting-the-identity-of-the-most-recently-added-record
                    idCenter = (int)cmdCheckCenter.ExecuteScalar();
                    
                }
                else idCenter = (int)tmp;

            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message);
            MessageBox.Show(ex.Message);
            }

            return idCenter;
         
        }

        public int selectPorodaid(string Priviazka)
        {
            int res = -1;
            // проверяем, есть ли такая запись в таблице Центр
            String checkPoroda = @"SELECT Центр.Порода FROM Центр where Центр.Выработка = " + dtd.idVirabotka + " AND Центр.Привязка ='" + Priviazka + "' AND Центр.Направление =" + dtd.idNapravlenie;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                try
                {
                    OleDbCommand cmd = new OleDbCommand(checkPoroda, conn);
                    object tmp = cmd.ExecuteScalar();
                    if (tmp != null) //  нашли такую запись
                           res = (int)tmp;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
            return res;
        }

/// <summary>
/// начальная загрузка - читаем из базы нужные таблицы и переменные
/// </summary>
        public void fillAllDataTables()
        {

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    dtd.fillDataTables(conn);
                    dtd.selectPriborid(conn);
                }     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

/// <summary>
/// по названию горизонта и участка находим все выработки в базе
/// </summary>
/// <param name="hor">название горизонта</param>
/// <param name="reg">название участка</param>
/// <returns></returns>
         public int readVirabotki(string hor, string reg) 
         {

// запрос без привязок - с уникальными выработками
             string strSql = @"SELECT Выработка.id, Выработка.Выработка, Горизонт.id, Горизонт.Горизонт, Подэтаж.id, Подэтаж.Подэтаж, Участок.id, Участок.Участок, Блок.id, Блок.Блок , Диаметр.Диаметр
FROM Диаметр INNER JOIN (Горизонт INNER JOIN (Участок INNER JOIN (Блок INNER JOIN (Подэтаж INNER JOIN Выработка ON Подэтаж.id = Выработка.Подэтаж) ON Блок.id = Выработка.Блок) ON Участок.id = Выработка.Участок) ON Горизонт.id = Выработка.Горизонт) ON  Выработка.Диаметр = Диаметр.id
WHERE (((Горизонт.Горизонт)=" + hor+") AND ((Участок.Участок)='"+reg+"'))";

             string strCon = connectionString; 

             try
             {
                 using (OleDbConnection conn = new OleDbConnection(strCon))
                 {
                     conn.Open();
                     OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                     dtd.virabotki = new DataTable("Virabotki");

                     adapter.Fill(dtd.virabotki);
                  //   dtd.virabotki.RowChanged += DataToDisplay.setIdVirabotka;
                     return dtd.virabotki.Rows.Count;
                 }
             }
             catch (Exception ex)
             {

                 Console.WriteLine(ex.Message);
                 MessageBox.Show(ex.Message);
                 return -1;
             }
        
         }
    }

  
    }


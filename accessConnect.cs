using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Angel_Access
{
    public class dataToDisplay
    {

        public DataTable horizons;
        public DataTable regions;
        public DataTable virabotki;
        public DataTable priviazki;
        public DataTable napravlenie;
        public DataTable porodi;
        public int idPribor; 
        public int idVirabotka;
        public int idHorizont;
        public int idNapravlenie;
        public int idPoroda;
        //public int idCenter;

        public void setVirabotkaHorizont(string Virabotka, string Block, string Podetag, string Napravlenie)
        {
             // определяем номер выработки и горизонта по имени 
            EnumerableRowCollection<DataRow> query1 = from order in virabotki.AsEnumerable()
                                                      where order.Field<String>("Выработка") == Virabotka && order.Field<String>("Подэтаж") == Podetag && order.Field<String>("Блок") == Block
                                                      select order;
            List<DataRow> res = query1.ToList();
            idVirabotka = res[0].Field<int>("Выработка.id");
            idHorizont = res[0].Field<int>("Горизонт.id");

            // определяем номер направления
            EnumerableRowCollection<DataRow> query2 = from order in napravlenie.AsEnumerable()
                                                      where order.Field<String>("Направление") == Napravlenie
                                                      select order;
            res = query2.ToList();
            idNapravlenie = res[0].Field<Byte>("id"); 
        }
        public void setidPoroda(string Poroda) 
        {
            EnumerableRowCollection<DataRow> query1 = from order in porodi.AsEnumerable()
                                                      where order.Field<String>("Порода") == Poroda
                                                      select order;
            List<DataRow> res = query1.ToList();
            idPoroda = res[0].Field<int>("id");
        }
   
    }
    class accessConnect
    {
        string strConPosition; // строка соединения с базой, в которой лежат таблицы с выработками, горизонтами и пр
        string strConAngel;    // строка соединения с базой, из которой читаем и пишем данные прибора
        public dataToDisplay dtd = new dataToDisplay();
        

        public accessConnect (string path)
        {
            strConPosition = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path; //   H:\\OLYA\\mulev\\PEZ\\PEZ_tbl.accdb
            strConAngel = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.IO.Path.GetDirectoryName(path) + "\\PEZ-angel.accdb"; 
            
            LoadPosition();
        }

       public bool SaveAngel(List <AngelData> adl, string [] param) 
        {
          string strCon = strConAngel;
          bool result = false;
            // определяем id параметров места по их именам 
           dtd.setVirabotkaHorizont(param[3],param[4],param[5],param[7] );
           

            try
            {
                using (OleDbConnection conn = new OleDbConnection(strCon))
                {   
                    conn.Open();
                    // либо находим, либо дописываем запись в таблицу Центр
                    int idCenter = get_centre(conn, param[3], dtd.idVirabotka, param[6], param[7], dtd.idNapravlenie); // породу нужно спрашивать..
                    if (idCenter == -1) return result; 
                        // todo - генерируем ошибку;
                    int idZamer = get_zamer(conn, idCenter, adl[0].Dt, dtd.idPribor, 1); 
                    if (idZamer  == -1) return result; 
                    
                    foreach (AngelData ad in adl)
                    {
                        String my_query1 = @"INSERT INTO Angel_ПОКАЗАНИЯ (Замер,Line, Picket, [Comp],[Time], t, A, Lmin, Lmax, VarA, B, L1, L2, L3, L4, L5, L6,L7,L8,L9,L10) Values (" + idZamer+ ","+ ad.getAsString()+")";
                        OleDbCommand cmd = new OleDbCommand(my_query1, conn);
                        cmd.ExecuteNonQuery();   
                    }
                    result = true;       
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); MessageBox.Show(ex.Message); }
                // todo генерируем ошибку;}
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

        public void setAllids(string [] param)
        {
            // определяем id параметров места по их именам 
            dtd.setVirabotkaHorizont(param[3], param[4], param[5], param[7]);
            // щпределяем id pf
        
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
        private int get_centre(OleDbConnection conn, string Virabotka, int idVirabotka, string Priviazka, string Napravlenie, int idNapravlenie) 
        {
            // нужно записать данные в таблицу Центр и Замер        
            // проверяем, есть ли такая запись в таблице Центр

            String checkCenter = @"SELECT Центр.id FROM Центр where Центр.Выработка = " + idVirabotka + " AND Центр.Привязка ='" + Priviazka + "' AND Центр.Направление =" + idNapravlenie;
            int idCenter = -1;

            try
            {

                OleDbCommand cmdCheckCenter = new OleDbCommand(checkCenter, conn);
                object tmp = cmdCheckCenter.ExecuteScalar();
                if (tmp == null) //  не нашли такую запись
                {
                    // и нужно запустить окно для выбора породы
                    askPoroda Cdialog = new askPoroda(Virabotka, Priviazka, Napravlenie, dtd);
                    Cdialog.ShowDialog();
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

/// <summary>
/// начальная загрузка - читаем из базы нужные таблицы и переменные
/// </summary>
         private void LoadPosition()
        {
             // строка соединения с базой из которой берем горизонты и пр - и ничего не пишем
            string strCon = strConPosition; //Settings.Default.PID2dbConnectionString;

            try
            {
                using (OleDbConnection conn = new OleDbConnection(strCon))
                {
                    conn.Open();

                    // все горизонты
                    string strSql = "SELECT * from Горизонт"; //WHERE [customerID] ='" + txtName.Text + "'";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                    dtd.horizons = new DataTable();
                    adapter.Fill(dtd.horizons);

                    // все участки
                    strSql = "SELECT * from Участок";
                    adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                    dtd.regions = new DataTable();
                    adapter.Fill(dtd.regions);

                    // все направления
                    strSql = @"SELECT * from Направление";
                    adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                    dtd.napravlenie = new DataTable();
                    adapter.Fill(dtd.napravlenie);

                    // все варианты пар Выборка-Привязка
                    strSql = @"SELECT DISTINCT Выработка.Выработка, Центр.Привязка 
                    FROM Выработка INNER JOIN Центр ON Выработка.id = Центр.Выработка
                    ORDER BY Выработка.Выработка";
                    adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                    dtd.priviazki = new DataTable();
                    adapter.Fill(dtd.priviazki);

                    // проверяем, есть ли Ангел-М в списках приборов. Если есть, узнаем id соотв звписи
                    // если нет, добавляем запись и тоже проверяем ее id
                    strSql = @"SELECT Прибор.id from Прибор where Прибор.Прибор = 'Ангел-М'";
                    OleDbCommand cmd = new OleDbCommand(strSql, conn);
                    object tmp = cmd.ExecuteScalar();
                    if (tmp != null)
                        dtd.idPribor = (int)tmp;
                    else 
                    {
                        cmd = new OleDbCommand("Insert into Прибор ([Прибор]) Values ('Ангел-М')", conn);
                        cmd.ExecuteNonQuery();
                        cmd = new OleDbCommand("SELECT @@IDENTITY", conn);  //http://www.mikesdotnetting.com/article/54/getting-the-identity-of-the-most-recently-added-record
                        dtd.idPribor = (int)cmd.ExecuteScalar();
                    }

                    // создаем список Породы - нужен, если добавляем новую запись в таблицу Центр (те новое место измерений)
                    strSql = @"SELECT * from Порода";
                    adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                    dtd.porodi = new DataTable();
                    adapter.Fill(dtd.porodi);
                    
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
         public int virabotka(string hor, string reg) 
         {

// запрос без привязок - с уникальными выработками
             string strSql = @"SELECT Выработка.id, Выработка.Выработка, Горизонт.id, Горизонт.Горизонт, Подэтаж.id, Подэтаж.Подэтаж, Участок.id, Участок.Участок, Блок.id, Блок.Блок
FROM Горизонт INNER JOIN (Участок INNER JOIN (Блок INNER JOIN (Подэтаж INNER JOIN Выработка ON Подэтаж.id = Выработка.Подэтаж) ON Блок.id = Выработка.Блок) ON Участок.id = Выработка.Участок) ON Горизонт.id = Выработка.Горизонт
WHERE (((Горизонт.Горизонт)=" +hor+") AND ((Участок.Участок)='"+reg+"'))";           

             string strCon = strConPosition; 

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
                 MessageBox.Show(ex.Message);
                 return -1;
             }
        
         }
    }

  
    }


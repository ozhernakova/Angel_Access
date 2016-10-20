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
        public DataTable priviazki;
        public DataTable napravlenie;

    
    }
    class accessConnect
    {
        string strConPosition ; 
        string strConAngel; // строка соединения с базой, из которой читаем и пишем данные прибора
        
        public dataToDisplay dtd = new dataToDisplay();

        public accessConnect (string path)
        {
            strConPosition = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path; //   H:\\OLYA\\mulev\\PEZ\\PEZ_tbl.accdb
           // string tmp = path.
            strConAngel = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\\OLYA\\mulev\\PEZ\\PEZ-angel.accdb";//
            LoadPosition();
        }

        public void SaveAngel(List <AngelData> adl, string [] param) 
        {
            string strCon = strConAngel;
            //                   String my_querry =    @"INSERT INTO Angel_ПОКАЗАНИЯ(Замер,Comp,[DateTime],t, A, Lmin, Lmax, VarA,B,L1,L2,L3,L4,L5,L6,L7,L8,L9,L10 )VALUES('" + z + "','" + ad.Comp + "','" +ad.Dt+ "','" +ad.Dt+"','"+ad.t+"','"+ad.A+"','"+ad.Lmin+"','"+ad.Lmax +"','"+ad.VarA+"','" +ad.B+"','" +ad.L1+"','" +ad.L2+"','" +ad.L3+"','" +ad.L4+"','" +ad.L5+"','" +ad.L6+"','" +ad.L7+"','" +ad.L8+"','" +ad.L9+"','" +ad.L10+"')";

            String my_query = @"INSERT INTO Angel_ПОКАЗАНИЯ Values(@id,@Замер,@Comp,@Time, @t, @A, @Lmin, @Lmax, @VarA,@B,@L1,@L2,@L3,@L4,@L5,@L6,@L7,@L8,@L9,@L10 )";
            String my_query1 = @"INSERT INTO Angel_ПОКАЗАНИЯ Values(@id,@Замер,@Comp,@Time, @t, @A, @Lmin, @Lmax, @VarA,@B,@L1,@L2,@L3,@L4,@L5,@L6,@L7,@L8,@L9,@L10 )";
            
            try
            {
                using (OleDbConnection conn = new OleDbConnection(strCon))
                {
                    OleDbCommand cmd = new OleDbCommand(my_query,conn);
                    conn.Open();
                    int i=10;
                    
                    foreach (AngelData ad in adl)
                    {
                        cmd.Parameters.AddWithValue("@id", i);
                        cmd.Parameters.AddWithValue("@Замер", 7);
                        i = i + 1;
                        cmd.Parameters.AddWithValue("@Comp", ad.Comp);
                        cmd.Parameters.AddWithValue("@Time", ad.Dt);
                        cmd.Parameters.AddWithValue("@t", ad.t);
                      
                        cmd.Parameters.AddWithValue("@A",ad.A);
                        cmd.Parameters.AddWithValue("@Lmin", ad.Lmin);
                        cmd.Parameters.AddWithValue("@Lmax", ad.Lmax);
                        cmd.Parameters.AddWithValue("@VarA", ad.VarA);
                        cmd.Parameters.AddWithValue("@B", ad.B);
                        cmd.Parameters.AddWithValue("@L1",ad.L1);
                        cmd.Parameters.AddWithValue("@L2", ad.L2);
                        cmd.Parameters.AddWithValue("@L3", ad.L3);
                        cmd.Parameters.AddWithValue("@L4", ad.L4);
                        cmd.Parameters.AddWithValue("@L5", ad.L5);
                        cmd.Parameters.AddWithValue("@L6", ad.L6);
                        cmd.Parameters.AddWithValue("@L7", ad.L7);
                        cmd.Parameters.AddWithValue("@L8", ad.L8);
                        cmd.Parameters.AddWithValue("@L9", ad.L9);
                        cmd.Parameters.AddWithValue("@L10", ad.L10);
                        cmd.ExecuteNonQuery();   
                    }
                                    
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message);}
            
        
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

                    strSql = @"SELECT * from Направление";
                    adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                    dtd.napravlenie = new DataTable();
                    adapter.Fill(dtd.napravlenie);

                    strSql = @"SELECT DISTINCT Выработка.Выработка, Центр.Привязка
                    FROM Выработка INNER JOIN Центр ON Выработка.id = Центр.Выработка
                    ORDER BY Выработка.Выработка";
                    adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
                    dtd.priviazki = new DataTable();
                    adapter.Fill(dtd.priviazki);
                    
                }     
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
        }

         public int virabotka(string hor, string reg) 
         {
// запрос с учетом вариантов привязок

//string strSqlAll = @"SELECT Выработка.id, Выработка.Выработка, Горизонт.Горизонт, Подэтаж.Подэтаж, Участок.Участок, Блок.Блок, Центр.Привязка 
//FROM (Горизонт INNER JOIN (Участок INNER JOIN (Блок INNER JOIN (Подэтаж INNER JOIN Выработка ON Подэтаж.id = Выработка.Подэтаж) ON Блок.id = Выработка.Блок) ON Участок.id = Выработка.Участок) ON Горизонт.id = Выработка.Горизонт) 
//INNER JOIN (Центр INNER JOIN ЗАМЕР ON Центр.id = ЗАМЕР.Центр) ON Выработка.id = Центр.Выработка 
//WHERE (([Горизонт].[Горизонт]=" + hor + ") AND ([Участок].[Участок]='" + reg + "'))";          

// запрос без привязок - с уникальными выработками
string strSql = @"SELECT Выработка.id, Выработка.Выработка, Горизонт.Горизонт, Подэтаж.Подэтаж, Участок.Участок, Блок.Блок
FROM Горизонт INNER JOIN (Участок INNER JOIN (Блок INNER JOIN (Подэтаж INNER JOIN Выработка ON Подэтаж.id = Выработка.Подэтаж) ON Блок.id = Выработка.Блок) ON Участок.id = Выработка.Участок) ON Горизонт.id = Выработка.Горизонт
WHERE (((Горизонт.Горизонт)="+hor+") AND ((Участок.Участок)='"+reg+"'))";           

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
                 return -1;
             }

         
         }
    }

  
    }


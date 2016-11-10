using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Angel_Access
{
    public class DataToDisplay
    {
        AccessConnect baseConnection;

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
        public int idPoroda = -1;  // TODO при каждой смене данных (добавления нового центра!!!) нужно породу тереть..
        public string Poroda { get { return ( (idPoroda>=0) ? (string)porodi.Select("[id] = '" + idPoroda + "'")[0][1]:""); } }
        public string Soprotivlenie { get { return ((idPoroda >= 0) ? porodi.Select("[id] = '" + idPoroda + "'")[0][2].ToString() : "____"); } }

        

        public void ConnectToBase(string path) 
        {
            baseConnection = new AccessConnect(path,this);
            if (baseConnection != null) baseConnection.fillAllDataTables();
        }
      

        public void save() 
        { 
        }

        public void fillDataTables(OleDbConnection conn) 
        {
            readHorizons(conn);
            readPorodi(conn);
            readNapravlenia(conn);
            readPriviazki(conn);
            readRegions(conn);
        }
        private void readHorizons(OleDbConnection conn) 
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand("SELECT * from Горизонт", conn));
            horizons = new DataTable();
            adapter.Fill(horizons);
        }
        private void readPorodi(OleDbConnection conn)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand(@"SELECT * from Порода", conn));
            porodi = new DataTable();
            adapter.Fill(porodi);
        }

        private void readNapravlenia(OleDbConnection conn)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand(@"SELECT * from Направление", conn));
            napravlenie = new DataTable();
            adapter.Fill(napravlenie);
        }

        private void readPriviazki(OleDbConnection conn) 
        {
            // все варианты пар Выработка-Привязка
            String strSql = @"SELECT DISTINCT Выработка.Выработка, Центр.Привязка 
                    FROM Выработка INNER JOIN Центр ON Выработка.id = Центр.Выработка
                    ORDER BY Выработка.Выработка";
            OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand(strSql, conn));
            priviazki = new DataTable();
            adapter.Fill(priviazki);
        }
        private void readRegions(OleDbConnection conn)
        { 
        // все участки
             OleDbDataAdapter adapter = new OleDbDataAdapter(new OleDbCommand("SELECT * from Участок", conn));
             regions = new DataTable();
             adapter.Fill(regions);
        }
        public int readVirabotki(string hor, string reg) // выработки для данного горизонта и участка!
        {
            return baseConnection.readVirabotki(hor, reg);
        }

        public void setAllids(string[] param)
        {
            // выставляем id параметров места по их именам 
            idVirabotka = selectHorizontid(param[3], param[4], param[5]);
            idNapravlenie = (Byte)napravlenie.Select("[Направление] = '" + param[7] + "'")[0][0];
            idHorizont = (int)horizons.Select("[Горизонт] = '" + param[1] + "'")[0][0];
            idPoroda = baseConnection.selectPorodaid(param[6]);
 
        }
        public void selectPriborid(OleDbConnection conn) 
        {
            // проверяем, есть ли Ангел-М в списках приборов. Если есть, узнаем id соотв звписи
            // если нет, добавляем запись и тоже проверяем ее id
            string strSql = @"SELECT Прибор.id from Прибор where Прибор.Прибор = 'Ангел-М'";
            OleDbCommand cmd = new OleDbCommand(strSql, conn);
            object tmp = cmd.ExecuteScalar();
            if (tmp != null)
                idPribor = (int)tmp;
            else
            {
                cmd = new OleDbCommand("Insert into Прибор ([Прибор]) Values ('Ангел-М')", conn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("SELECT @@IDENTITY", conn);  //http://www.mikesdotnetting.com/article/54/getting-the-identity-of-the-most-recently-added-record
                idPribor = (int)cmd.ExecuteScalar();
            }
        
        }
        private int selectHorizontid(string Virabotka, string Block, string Podetag)
        {
            // определяем номер выработки по имени учитывая что имена могут повторяться, по горизонтам и участкам мы и так отобрали, но и для подэтажей и блоков есть повторения..
            EnumerableRowCollection<DataRow> query1 = from order in virabotki.AsEnumerable()
                                                      where order.Field<String>("Выработка") == Virabotka && order.Field<String>("Подэтаж") == Podetag && order.Field<String>("Блок") == Block
                                                      select order;
            List<DataRow> res = query1.ToList();
            return res[0].Field<int>("Выработка.id");
        }

                
        public bool SaveAngelData(List<AngelData> adl, string[] param) 
        {
            return baseConnection.SaveAngelData(adl, param);
        } 


    }
}

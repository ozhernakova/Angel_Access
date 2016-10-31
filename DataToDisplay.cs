using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Angel_Access
{
    public class DataToDisplay
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
        public string Poroda;
     //   public int idCenter;

        public void setVirabotkaHorizontid(string Virabotka, string Block, string Podetag)
        {
            // определяем номер выработки и горизонта по имени 
            EnumerableRowCollection<DataRow> query1 = from order in virabotki.AsEnumerable()
                                                      where order.Field<String>("Выработка") == Virabotka && order.Field<String>("Подэтаж") == Podetag && order.Field<String>("Блок") == Block
                                                      select order;
            List<DataRow> res = query1.ToList();
            idVirabotka = res[0].Field<int>("Выработка.id");
            idHorizont = res[0].Field<int>("Горизонт.id");
        }
         public void setNapravlenieid(string Napravlenie){
            // определяем номер направления
            EnumerableRowCollection<DataRow> query2 = from order in napravlenie.AsEnumerable()
                                                      where order.Field<String>("Направление") == Napravlenie
                                                      select order;
            List<DataRow> res = query2.ToList();
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
        public string setPoroda(int idPoroda)
        {
            EnumerableRowCollection<DataRow> query1 = from order in porodi.AsEnumerable()
                                                      where order.Field<int>("id") == idPoroda
                                                      select order;
            List<DataRow> res = query1.ToList();
            return (res[0].Field<string>("Порода"));
        }

    }
}

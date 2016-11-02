using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Angel_Access
{
    public struct AngelData
    {
        // 20 полей (в файле 21, но дату и время складываем в одно)
        public int Line { get; private set; }
        public int Picket { get; private set; }
        public int Comp { get; private set; }
        public DateTime Dt { get; private set; }
        public int t { get; private set; }
        public string A { get; private set; }
        public string Lmin { get; private set; }
        public string Lmax { get; private set; }
        public string VarA { get; private set; }
        public string B { get; private set; }
        public string L1 { get; private set; }
        public string L2 { get; private set; }
        public string L3 { get; private set; }
        public string L4 { get; private set; }
        public string L5 { get; private set; }
        public string L6 { get; private set; }
        public string L7 { get; private set; }
        public string L8 { get; private set; }
        public string L9 { get; private set; }
        public string L10 { get; private set; }

        public string getAllAsString()
        {
            return string.Format(@"{0},{1}, {2}, '{3}', {4}, '{5}', '{6}', '{7}','{8}', '{9}', '{10}', '{11}','{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}'", Line, Picket, Comp, Dt, t, A, Lmin, Lmax, VarA, B, L1, L2, L3, L4, L5, L6, L7, L8, L9, L10);   
        }
        public void setAllFromString(string[] source) 
        {
            Line = Int32.Parse(source[0]);
            Picket = Int32.Parse(source[1]);
            Comp = Int32.Parse(source[2]);
            string dateString = source[3] + " " + source[4];
            Dt = DateTime.Parse(dateString);  // тут возможны проблемы при других рег установках?
            t = Int32.Parse(source[5]);
            A = source[6];
            Lmin = source[7];
            Lmax = source[8];
            VarA = source[9];
            B = source[10];
            L1 = source[11];
            L2 = source[12];
            L3 = source[13];
            L4 = source[14];
            L5 = source[15];
            L6 = source[16];
            L7 = source[17];
            L8 = source[18];
            L9 = source[19];
            L10 = source[20];
        }
       // public int nomerZamera; // { get; set; }
    }

  

    class AngelDataList 
    {
        class Zamer  
        {public List<AngelData> odinZamer = new List<AngelData>();
        }
        List <AngelData> adl = new List<AngelData>();
        List<Zamer> zamerList = new List<Zamer>();
        public List <ListViewItem> lvi_list = new List<ListViewItem>();
        public void printSelectedZamer(int i, out DateTime dt, out float[]A, out float []B)
        {
            dt = zamerList[i].odinZamer[0].Dt;
            int number = zamerList[i].odinZamer.Count;
            A = new float[number];
            B = new float[number];
            int j = 0;
            foreach (AngelData ad in zamerList[i].odinZamer) 
            {
                A[j] = Single.Parse(ad.A);
                B[j] = Single.Parse(ad.B);
                j = j + 1;
            }
        
        }

        public List<AngelData> collectSelectedZameri(int[] items) 
        {
            List<AngelData> res = new List<AngelData>();
            foreach (int item in items)
                   res.AddRange (zamerList[item].odinZamer);
            return res;
        } 

        int divideIntoZameri() 
        {
            int i = 0;
            int num = adl.Count();
            if (num == 0 || num == null) return 0;

            Zamer zdnew = new Zamer();
            ListViewItem listItem = new ListViewItem();
            zamerList.Add(zdnew);
            int Picket = adl[0].Picket;
            
            zamerList[0].odinZamer.Add(adl[0]);

            listItem = new ListViewItem();  // new string[] { "1", "AJ", "22" } тоже работает.
         //   lvi.ImageIndex = 0; // установка картинки для файла
            listItem.Text = "Замер 1"; // замеры считаем не с 0 а с 1 
            listItem.SubItems.AddRange(new string[] { adl[0].Line.ToString(), (adl[0].Picket.ToString()) });
                      
            lvi_list.Add(listItem);

                for ( int j = 1; j < num ; j++)
                {
                    if (adl[j].Picket != adl[j - 1].Picket || adl[j].Line != adl[j-1].Line)
                    {
                        i += 1;
                        zdnew = new Zamer();
                        zamerList.Add(zdnew);
                        
                        // добавляем элемент в ListView
                        listItem = new ListViewItem();
                        listItem.Text = "Замер " + (i + 1).ToString();
                //        adl[j].nomerZamera = i + 1;
                        listItem.SubItems.AddRange(new string[] { adl[j].Line.ToString(), adl[j].Picket.ToString() });
                        lvi_list.Add (listItem);
                    }

                    zamerList[i].odinZamer.Add(adl[j]); 
                    
                }
                return i+1;  // число штук, а не номер последнего
        
        }

        public void readAngelData(StreamReader stream) 
        {
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                addAngelData(line);
            }
            divideIntoZameri();
        }
        void addAngelData(string line) 
        {
            // разбиваем на подстроки
            string[] stringSeparators = new string[] { " ", "\t" };
            string[] angelString = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

        // проверяем что там цифры и структура нужной длины
            int x;
            if (Int32.TryParse(angelString[0], out x) && angelString.Length == 21) 
            { 
                AngelData ad = new AngelData();
                ad.setAllFromString(angelString);
                
                adl.Add(ad);
            }

         }
    
    }
}

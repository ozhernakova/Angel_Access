using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angel_Access
{
    public struct AngelData
    {
        // 19 полей
        public int Line { get; set; }
        public int Picket { get; set; }
        public int Comp { get; set; }
        public int t { get; set; }
        public string A { get; set; }
        public string Lmin { get; set; }
        public string Lmax { get; set; }
        public string VarA { get; set; }
        public string B { get; set; }
        public string L1 { get; set; }
        public string L2 { get; set; }
        public string L3 { get; set; }
        public string L4 { get; set; }
        public string L5 { get; set; }
        public string L6 { get; set; }
        public string L7 { get; set; }
        public string L8 { get; set; }
        public string L9 { get; set; }
        public string L10 { get; set; }

        public string [] alldata 
        {
            get { return new String[] { Line.ToString(), Picket.ToString(), Comp.ToString(), t.ToString(),A, Lmin, Lmax, VarA, B}; }
        }
    }

    public class Zamer 
    {
        public string Virabotka { get; set; }
        public string Priviazka { get; set; }
        public DateTime dt { get; set; }
        public int Line { get; set; }
        public int Picket { get; set; }
    }

    public class ZamerData 
    {
        public List<AngelData> odinZamer = new List<AngelData>();
        public Zamer zamer = new Zamer();
    }
  

    class AngelDataList 
    {
        List <AngelData> adl = new List<AngelData>();
        List<ZamerData> zd = new List<ZamerData>();
        public List <ListViewItem> lvi_list = new List<ListViewItem>();

        public List<AngelData> getchoosenZameri(int[] items) 
        {
            List<AngelData> res = new List<AngelData>();

            foreach (int item in items)
            {
                foreach (AngelData tmp in zd[item].odinZamer ) 
                {
                    res.Add(tmp);
                }
            }                   

            return res;
        } 

        public int zameri() 
        {
            int i = 0;
            int num = adl.Count();
            if (num == 0 || num == null) return 0;

            ZamerData zdnew = new ZamerData();
            ListViewItem lvi = new ListViewItem();
            zd.Add(zdnew);
            int Picket = adl[0].Picket;
            
            zd[0].odinZamer.Add(adl[0]);
            zd[0].zamer.Line = adl[0].Line;
            zd[0].zamer.Picket = adl[0].Picket;

            lvi = new ListViewItem();  // new string[] { "1", "AJ", "22" } тоже работает.
         //   lvi.ImageIndex = 0; // установка картинки для файла
            lvi.Text = "Замер 1"; // замеры считаем не с 0 а с 1 
            lvi.SubItems.AddRange(new string[] { adl[0].Line.ToString(), (zd[0].zamer.Picket.ToString()) });
                      
            lvi_list.Add(lvi);

                for ( int j = 1; j < num ; j++)
                {
                    if (adl[j].Picket != adl[j - 1].Picket || adl[j].Line != adl[j-1].Line)
                    {
                        
                        
                        i += 1;
                        zdnew = new ZamerData();
                        zd.Add(zdnew);
                        zd[i].zamer.Line = adl[j].Line;
                        zd[i].zamer.Picket = adl[j].Picket;

                        lvi = new ListViewItem();
               //         lvi.ImageIndex = 0; // установка номера картинки для lvi

                        lvi.Text = "Замер " + (i + 1).ToString();
                        lvi.SubItems.AddRange(new string[] {  adl[j].Line.ToString(), zd[i].zamer.Picket.ToString() });
                // добавляем элемент в ListView
                        lvi_list.Add (lvi);


                    }
                        

                    zd[i].odinZamer.Add(adl[j]); 
                    
                    
                }
                return i+1;  // число штук, а не номер последнего
          
               
           
        
        }

        public void addAngelData(string line) {
        // проверяем что там цифры
            string[] stringSeparators = new string[] { " " };
            string[] angelString = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

        // проверяем что там цифры
        int x;
        
        if (Int32.TryParse(angelString[0], out x) && angelString.Length == 19) 
        { 
            AngelData ad = new AngelData();
            ad.Line = x;
            ad.Picket = Int32.Parse(angelString[1]);
            ad.Comp = Int32.Parse(angelString[2]);
            ad.t = Int32.Parse(angelString[3]);
            ad.A = angelString[4];
            ad.VarA = angelString[5];
            ad.B = angelString[6];
            ad.L1 = angelString[7];
            ad.L2 = angelString[8];
            ad.L3 = angelString[9];
            ad.L4 = angelString[10];
            ad.L5 = angelString[11];
            ad.L6 = angelString[12];
            ad.L7 = angelString[13];
            ad.L8 = angelString[14];
            ad.L9 = angelString[15];
            ad.L10 = angelString[16];
            adl.Add(ad);
  
            }
      
        }
    
    }
}

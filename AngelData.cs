using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angel_Access
{
    public struct AngelData
    {
        // 18 полей

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

        
    }

    class Zamer 
    {
        public string Virabotka { get; set; }
        public string Priviazka { get; set; }
        public DateTime dt { get; set; }
    
    }

    

    class AngelDataList 
    {
        public List <AngelData> adl = new List<AngelData>();

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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operatorok
{
    class Program
    {
        static List<Kifejezes> kifejezesek = new List<Kifejezes>();
        static void Main(string[] args)
        {
            BeolvasasF01();
            F02();
            F03();
            F04();
            F05();
            F07();
            F08();
            Console.ReadLine();
        }

        private static void F08()
        {
            using (StreamWriter sw = new StreamWriter("eredmenyek.txt"))
            {
                string beir = "";
                foreach (Kifejezes item in kifejezesek)
                {
                    beir = item.elsoOperandus + " " + item.operatorjel + " " + item.masodikOperandus;
                    sw.Write($"{F06(beir)} \n");
                }
                sw.Close();
                Console.WriteLine("8. feladat: eredmenyek.txt");
            }
        }

        private static void F07()
        {
            string beolvasottKif = "";
            while (!beolvasottKif.Equals("vége"))
            {
                Console.WriteLine("7.feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                beolvasottKif = Console.ReadLine();
                if (F06(beolvasottKif).Equals("vége"))
                {
                    beolvasottKif = F06(beolvasottKif);
                }
                else
                {
                    Console.WriteLine(F06(beolvasottKif) + "\n");
                }
            }
        }

        private static String F06(string beolvasottKif)
        {
            string adat ="";
            string visszater ="";
            if (beolvasottKif.Equals("vége"))
            {
                return "vége";
            }
            string[] darab = beolvasottKif.Split(' ');
            adat = darab[0] + " " + darab[1] + " " + darab[2];
            try
            {
                switch (darab[1])
                {
                    case "mod":
                        visszater = adat + " = " + (int.Parse(darab[0]) % int.Parse(darab[2]));
                        break;
                    case "div":
                        visszater = adat + " = " + (int.Parse(darab[0]) / int.Parse(darab[2]));
                        break;
                    case "/":
                        visszater = adat + " = " + (Double.Parse(darab[0]) / Double.Parse(darab[2]));
                        break;
                    case "-":
                        visszater = adat + " = " + (int.Parse(darab[0]) - int.Parse(darab[2]));
                        break;
                    case "*":
                        visszater = adat + " = " + (int.Parse(darab[0]) * int.Parse(darab[2]));
                        break;
                    case "+":
                        visszater = adat + " = " + (int.Parse(darab[0]) + int.Parse(darab[2]));
                        break;
                    default:
                        return ($"{adat} = Hibás operátor!");
                }
            }
            catch (Exception)
            {
                return ($"{adat} = Egyéb hiba!");
            }
            return visszater;
        }

        private static void F05()
        {
            Console.WriteLine("5. feladat: Statisztika");
            Console.WriteLine($"\tmod -> {kifejezesek.Count(a => a.operatorjel == "mod")} db");
            Console.WriteLine($"\t  / -> {kifejezesek.Count(a => a.operatorjel == "/")} db");
            Console.WriteLine($"\tdiv -> {kifejezesek.Count(a => a.operatorjel == "div")} db");
            Console.WriteLine($"\t  - -> {kifejezesek.Count(a => a.operatorjel == "-")} db");
            Console.WriteLine($"\t  * -> {kifejezesek.Count(a => a.operatorjel == "*")} db");
            Console.WriteLine($"\t  + -> {kifejezesek.Count(a => a.operatorjel == "+")} db");
        }

        private static void F04()
        {
            Console.WriteLine($"4. feladat: {(kifejezesek.FirstOrDefault(a => a.elsoOperandus % 10 == 0 && a.masodikOperandus % 10 == 0) != null ? "Van ilyen kifejezés" : "Nincs ilyen kifejezés")}");
        }

        private static void F03()
        {
            Console.WriteLine($"3. feladat: {kifejezesek.Count(a => a.operatorjel == "mod")}");
        }

        private static void F02()
        {
            Console.WriteLine($"2. feladat: {kifejezesek.Count()}");
        }

        private static void BeolvasasF01()
        {
            using (StreamReader sr = new StreamReader("kifejezesek.txt")){
                while (!sr.EndOfStream)
                {
                    kifejezesek.Add(new Kifejezes(sr.ReadLine()));
                }
                sr.Close();
            }
        }
    }
    class Kifejezes
    {
        public int elsoOperandus { get; set; }
        public string operatorjel { get; set; }
        public int masodikOperandus { get; set; }

        public Kifejezes(string sor)
        {
            string[] darab = sor.Split(' ');

            this.elsoOperandus = int.Parse(darab[0]);
            this.operatorjel = darab[1];
            this.masodikOperandus = int.Parse(darab[2]);
        }
    }
}

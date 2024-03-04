using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_02._23
{
    class Program
    {

        static string[] feladatok = { "Kilépés", "Adatok megtekintése", "Adatok törlése", "Adatok felvétele", "Adatok módosítása", "Mentés" };
        static string[] EszkozAdat = { "Mégse", "Név", "Ár", "Mennyiség", "Leírás", "Avuló-e" };

        class Eszkoz
        {
            private string nev;
            private int ar;
            private int mennyiseg;
            private string leiras;
            private bool avulo;

            string Nev
            {
                get { return nev; }
                set { nev = value; }
            }

            int Ar
            {
                get { return ar; }
                set { ar = value; }
            }

            int Mennyiseg
            {
                get { return mennyiseg; }
                set { mennyiseg = value; }
            }

            string Leiras
            {
                get { return leiras; }
                set { leiras = value; }
            }

            bool Avulo
            {
                set { avulo = value; }
            }

            public Eszkoz(string n, int a, int m, string l, bool av)
            {
                Nev = n;
                Ar = a;
                Mennyiseg = m;
                Leiras = l;
                Avulo = av;
            }

            public bool Avuloe()
            {
                return avulo;
            }

            public bool Kifogyoe()
            {
                if (mennyiseg < 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public string EszkozNev()
            {
                return Nev;
            }

            public void Megtekintes()
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Név: {0}\n",nev);
                Console.WriteLine("Ár: {0} Ft\n", ar);
                Console.WriteLine("Menniség: {0} db\n", mennyiseg);
                Console.WriteLine("Leírás: {0}\n", leiras);
                if (avulo)
                {
                    Console.WriteLine("Gyorsan avuló termék\n");
                }
                else
                {
                    Console.WriteLine("Nem gyorsan avuló termék\n");
                }
                if (mennyiseg < 10)
                {
                    Console.WriteLine("A Termék kifogyóban van!");
                }
            }

            public void Torles(List<Eszkoz> Eszkozok, int szam)
            {
                Eszkozok.RemoveAt(szam);
            }

            public void ModNev(List<Eszkoz> Eszkozok, int szam)
            {
                Console.WriteLine("Régi név: {0}",Eszkozok[szam].Nev);
                Console.WriteLine("Add meg az új nevet!");
                string a = Console.ReadLine();
                Eszkozok[szam].Nev = a;
                ModositasMenu(Eszkozok, szam);
            }

            public void ModAr(List<Eszkoz> Eszkozok, int szam)
            {
                Console.WriteLine("Régi Ár: {0}", Eszkozok[szam].Ar);
                Console.WriteLine("Add meg az új Árat!");
                string a = Console.ReadLine();
                while (!int.TryParse(a, out int value))
                {
                    Console.WriteLine("Egész számot adjon meg!");
                    a = Console.ReadLine();
                }
                Eszkozok[szam].Ar = int.Parse(a);
                ModositasMenu(Eszkozok, szam);
            }

            public void ModMennyiseg(List<Eszkoz> Eszkozok, int szam)
            {
                Console.WriteLine("Régi Mennyiség: {0}", Eszkozok[szam].Mennyiseg);
                Console.WriteLine("Add meg az új Mennyiséget!");
                string a = Console.ReadLine();
                while (!int.TryParse(a, out int value))
                {
                    Console.WriteLine("Egész számot adjon meg!");
                    a = Console.ReadLine();
                }
                Eszkozok[szam].Mennyiseg = int.Parse(a);
                ModositasMenu(Eszkozok, szam);
            }

            public void ModLeiras(List<Eszkoz> Eszkozok, int szam)
            {
                Console.WriteLine("Régi Leírás: {0}", Eszkozok[szam].Leiras);
                Console.WriteLine("Add meg az új Leírást!");
                string a = Console.ReadLine();
                Eszkozok[szam].Leiras = a;
                ModositasMenu(Eszkozok, szam);
            }

            public void ModAvulo(List<Eszkoz> Eszkozok, int szam)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (Eszkozok[szam].Avuloe())
                {
                    Eszkozok[szam].Avulo = false;
                    Console.WriteLine("Gyorsan avuló volt a termék");
                    Console.WriteLine("Most már nem avul gyorsan");
                }
                else
                {
                    Eszkozok[szam].Avulo = true;
                    Console.WriteLine("Nem volt gyorsan avuló a termék");
                    Console.WriteLine("Most már gyorsan avul");
                }
                Console.ReadLine();
                ModositasMenu(Eszkozok, szam);
            }

            public void Ment(List<Eszkoz> Eszkozok)
            {
                StreamWriter sw = new StreamWriter("adatok.txt");
                sw.WriteLine("Nev;Ar;Mennyiseg;Leiras;Gyorsan avulo");
                for (int i = 0; i < Eszkozok.Count(); i++)
                {
                    sw.WriteLine("{0};{1};{2};{3};{4}", Eszkozok[i].Nev, Eszkozok[i].Ar, Eszkozok[i].Mennyiseg, Eszkozok[i].Leiras, Eszkozok[i].avulo);
                }
                sw.Close();
            }

        }

        static void Hozzaad(List<Eszkoz> Eszkozok)
        {
            Console.WriteLine("Eszköz hozzáadása:\n\n");
            Console.WriteLine("Adja meg az eszköz nevét:");
            string a = Console.ReadLine();
            Console.WriteLine("Adja meg az eszköz árát:");
            string b = Console.ReadLine();
            while (!int.TryParse(b, out int value))
            {
                Console.WriteLine("Egész számot adjon meg!");
                b = Console.ReadLine();
            }
            Console.WriteLine("Adja meg az eszköz mennyiségét:");
            string c = Console.ReadLine();
            while (!int.TryParse(c, out int value))
            {
                Console.WriteLine("Egész számot adjon meg!");
                c = Console.ReadLine();
            }
            Console.WriteLine("Adja meg az eszköz leírását:");
            string d = Console.ReadLine();
            Console.WriteLine("Adja meg hogy gyorsan avuló-e a termék (I/N)");
            string e = Console.ReadLine();
            bool f = false;
            if (e.ToLower() == "i")
            {
                f = true;
            }
            Eszkoz temp = new Eszkoz(a, int.Parse(b), int.Parse(c), d, f);
            Eszkozok.Add(temp);
            Menu(Eszkozok);
        }

        static void Menu(List<Eszkoz> Eszkozok)
        {
            int kivalasztott = 0;

            ConsoleKeyInfo lenyomott;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Válasszon az alábbi lehetőségek közül:\n");

                for (int i = 0; i < feladatok.Length; i++)
                {
                    if (i == kivalasztott)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("\t" + (i + 1) + ") " + feladatok[i]);
                }

                lenyomott = Console.ReadKey();

                switch (lenyomott.Key)
                {
                    case ConsoleKey.UpArrow: if (kivalasztott > 0) kivalasztott--; else if (kivalasztott == 0) kivalasztott = 5; break;
                    case ConsoleKey.DownArrow: if (kivalasztott < feladatok.Length - 1) kivalasztott++; else if (kivalasztott == feladatok.Length-1) kivalasztott = 0; break;
                }

            } while (lenyomott.Key != ConsoleKey.Enter);
            Console.Clear();
            switch (kivalasztott)
            {
                case 0: Kilep(); break;
                case 1: Menu2(Eszkozok, kivalasztott); break;
                case 2: Menu2(Eszkozok, kivalasztott); break;
                case 3: Hozzaad(Eszkozok); break;
                case 4: Menu2(Eszkozok, kivalasztott); break;
                case 5: Mentes(Eszkozok); break;
            }
        }

        static void Menu2(List<Eszkoz> Eszkozok, int s)
        {
            int kivalasztott = 0;

            ConsoleKeyInfo lenyomott;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                switch (s)
                {
                    case 1: Console.WriteLine("Tekintse meg az alábbi termékeket:\n"); ; break;
                    case 2: Console.WriteLine("Töröljön ki az alábbi termékek közül:\n"); break;
                    case 4: Console.WriteLine("Módosítsa az alábbi termékeket:\n"); break;
                }
                for (int i = 0; i < Eszkozok.Count+1; i++)
                {
                    if (i == kivalasztott)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (i==0)
                    {
                        Console.WriteLine("\t" + (i + 1) + ") " + "Vissza");
                    }
                    else
                    {
                        Console.WriteLine("\t" + (i + 1) + ") " + Eszkozok[i - 1].EszkozNev());
                    }
                }

                lenyomott = Console.ReadKey();

                switch (lenyomott.Key)
                {
                    case ConsoleKey.UpArrow: if (kivalasztott > 0) kivalasztott--; else if (kivalasztott == 0) kivalasztott = Eszkozok.Count(); break;
                    case ConsoleKey.DownArrow: if (kivalasztott < Eszkozok.Count()+1 - 1) kivalasztott++; else if (kivalasztott == Eszkozok.Count()) kivalasztott = 0; break;
                }

            } while (lenyomott.Key != ConsoleKey.Enter);
            Console.Clear();
            if (kivalasztott == 0)
            {
                Vissza1(Eszkozok);
            }
            else if (s == 1)
            {
                Eszkozok[kivalasztott - 1].Megtekintes();
                Console.ReadLine();
                Menu2(Eszkozok, s);
            }
            else if (s == 2)
            {
                Eszkozok[kivalasztott - 1].Torles(Eszkozok, kivalasztott - 1);
                Menu2(Eszkozok, s);
            }
            else if (s == 4)
            {
                ModositasMenu(Eszkozok, kivalasztott -1);
            }
        }

        static void ModositasMenu(List<Eszkoz> Eszkozok, int szam)
        {
            int kivalasztott = 0;

            ConsoleKeyInfo lenyomott;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Melyik adatot szeretné Módosítani:\n");

                Eszkozok[szam].Megtekintes();

                for (int i = 0; i < EszkozAdat.Length; i++)
                {
                    if (i == kivalasztott)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("\t" + (i + 1) + ") " + EszkozAdat[i]);
                }

                lenyomott = Console.ReadKey();

                switch (lenyomott.Key)
                {
                    case ConsoleKey.UpArrow: if (kivalasztott > 0) kivalasztott--; else if (kivalasztott == 0) kivalasztott = 5; break;
                    case ConsoleKey.DownArrow: if (kivalasztott < EszkozAdat.Length - 1) kivalasztott++; else if (kivalasztott == EszkozAdat.Length - 1) kivalasztott = 0; break;
                }

            } while (lenyomott.Key != ConsoleKey.Enter);
            Console.Clear();
            switch (kivalasztott)
            {
                case 0: Menu2(Eszkozok, 4); break;
                case 1: Eszkozok[szam].ModNev(Eszkozok, szam); break;
                case 2: Eszkozok[szam].ModAr(Eszkozok, szam); break;
                case 3: Eszkozok[szam].ModMennyiseg(Eszkozok, szam); break;
                case 4: Eszkozok[szam].ModLeiras(Eszkozok, szam); break;
                case 5: Eszkozok[szam].ModAvulo(Eszkozok, szam); break;
            }
        }

        static void Vissza1(List<Eszkoz> Eszkozok)
        {
            Menu(Eszkozok);
        }
        static void Kilep()
        {
            System.Environment.Exit(0);
        }

        static List<Eszkoz> Beolvasas(List<Eszkoz> Eszkozok)
        {
            StreamReader sr = new StreamReader("adatok.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] mezok = sor.Split(';');
                Eszkoz temp = new Eszkoz(mezok[0], int.Parse(mezok[1]), int.Parse(mezok[2]), mezok[3], Convert.ToBoolean(mezok[4]));
                Eszkozok.Add(temp);
            }
            sr.Close();
            return Eszkozok;
        }

        static void Mentes(List<Eszkoz> Eszkozok)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Eszkozok[0].Ment(Eszkozok);
            Console.WriteLine("Adatok sikeresen mentve");
            Console.ReadLine();
            Menu(Eszkozok);
        }

        static void Main(string[] args)
        {
            List<Eszkoz> Eszkozok = new List<Eszkoz>();
            Beolvasas(Eszkozok);
            Menu(Eszkozok);
        }
    }
}

//Program obsługi przestrzeni buriowej. Zawiera klasę dla Pracowników i Bossów. Pracownik posiada dane osobowe oraz dane
//o firmie, w której pracuje. Menager posiada możliwość sprawdzenia ilości pracowników, wywołania dokładnej listy pracowników,
//przyznania podwyżki. Każde wywołanie metody z klasy Boss obniża poziom zadowolenia kierownika z pracy pracowników, dlatego ma 
// on też metodę pozwalającą to zadowolenie przywrócić

using System;
using System.Collections.Generic;

namespace Biuro
{
    public class Pracownik
    {
        public static int ilosc = 0;
        public string imie;
        public string nazwisko;
        public double zarobki;
        public string umowa;
        public string firma;
        public double robota;
        public static List<object> Lista = new List<object>();
        
        public Pracownik( string a, string b, double c, string d, string e)   
        {
            imie = a;
            nazwisko = b;
            zarobki = c;
            umowa = d;
            firma = e;
            ilosc += 1;
            string[] nowy = { imie, nazwisko, zarobki.ToString(), umowa, firma };
            Lista.Add(nowy);
        }
        
        public int Praca()    //pracownik może się przedstawić
        {
            Console.WriteLine("Dzień dobry, nazywam się {0} {1} i jestem nowym pracownikiem.\n", imie, nazwisko);
            return 1;          //metoda zwraca wartość, bo może być wykorzystana do przywrócenia zadowolenia kierownika
        }

        public double Wyk_pracy()      //pracownik może określić jak ciężko pracował
        {
            int czas = 8;
            double lenistwo = 0;
            Console.WriteLine("Szefie ja dzisiaj:\n" +
                "1 - Nie widzę się w pracy\n" +
                "2 - Myślę tylko jak przetrwać do 15:00\n" +
                "3 - Zasuwam jak maszyna!\n");
            Console.WriteLine("Podaj wartość: ");
            string wybor = Console.ReadLine();
            if (wybor == "1")
                lenistwo = 0.5;
            else if (wybor == "2")
                lenistwo = 1;
            else if (wybor == "3")
                lenistwo = 2;
            else
                Console.WriteLine("Wybrałeś niewłaściwą wartość.\n");
            robota = czas * lenistwo;
            Console.WriteLine("Przepracowałem dzisiaj solidnie: {0} godzin\n", robota);
            return robota;
        }
    }

    public class Boss : Pracownik
    {
        public static int count;
        //licznik wykorzystany do naliczania poziomu zadowolenia kierownika

        public Boss(string a, string b, double c, string d, string e) : base(a, b, c, d, e)
        {
        }
        public void Zadowolenie_z_pracow()
        {
            if (count <= 1)
                Console.WriteLine("Jest ok, ale możecie pracować jeszcze ciężej.\n");
            else if (count >=2 && count < 5)
                Console.WriteLine("Jest ok, ale szału nie ma.\n");
            else if (count >= 5)
                Console.WriteLine("Jestem wkurzony. Należy zrobić porządek z tą bandą obiboków.\n");
            else
                Console.WriteLine("Nie wiem co robić...\n");
        }

        public void Motywacja()                   //metoda przywracająca zadowolenie kierownika
        {
            
            Console.WriteLine("Do roboty nieroby!");
            foreach (string[] p in Lista)
            {
                count -= 1;
            }
                 
        }

        public void Ilosc_pracow()           //sprawdzenie ilości pracowników
        {
            int liczba_prac = 0;
            foreach (string[] p in Lista)
            {
                if (firma.Equals(p[4]))           //sprawdzenie czy pracownik należy do tej samej firmy co kierownik
                    liczba_prac += 1;
            }
            Console.WriteLine("W firmie {0} pracuje obecnie: {1} osób\n", firma, liczba_prac);
            count += 1;
        }

        public void Przyznaj_podwyzke(Pracownik obiekt)
        {
            obiekt.Wyk_pracy();
            if (obiekt.robota == 16)
            {
                obiekt.zarobki += 200;
                Console.WriteLine("W uznaniu za ciężką pracę " +
               "podwyżkę dostaje {0} {1}, \n" +
               "a jego wynagrodzenie będzie wynosić: {2} zł\n", obiekt.imie, obiekt.nazwisko, obiekt.zarobki);
            }
            else if (obiekt.robota == 8)
                Console.WriteLine("Przykro mi, musisz się bardziej postarać.\n");
            else if (obiekt.robota == 4)
                Console.WriteLine("Podwyżka? Chyba żartujesz, jesteś największym obibokiem w firmie!\n");
            count += 1;
        }

        public void Lista_pracow()            //lista pracowników ze szczegółowymi danymi
        {
            Console.WriteLine("Pracownicy w firmie {0}:\n", firma);
            foreach (string[] p in Lista)
                if (firma.Equals(p[4]))               //sprawdzenie czy pracownik należy do tej samej firmy co kierownik
                {
                    Console.WriteLine("Imię i nazwisko: {0,15} {1,18}", p[0], p[1]);
                    Console.WriteLine("Rodzaj zatrudnienia: {0,30} ", p[3]);
                    Console.WriteLine("Wysokość wynagrodzenia:  {0,25}zł\n", p[2]);
                }
            count += 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string firma1 =  "NAJSU Sp.z.o.o ul.Samo Centrum 1" ;
            string firma2 = "KąQurencja ul.Na Końcu Świata 100" ;

            Pracownik adam = new Pracownik("Adam", "Kowal", 2000, "umowa o pracę", firma1);
            Pracownik tomek = new Pracownik("Tomek", "Cebula", 3000, "umowa o pracę", firma1);
            Pracownik janusz = new Pracownik("Janusz", "Rogalski", 1800, "umowa zlecenie", firma2);

            Boss kierowniczka = new Boss("Anna", "Boss", 6000, "umowa o pracę", firma1);
            Boss kierownik = new Boss("Krzysztof", "Jeżyna", 5000, "umowa o pracę", firma2);

            adam.Praca();
            kierowniczka.Praca();
            kierowniczka.Ilosc_pracow();
            kierowniczka.Lista_pracow();
            kierownik.Lista_pracow();
            Console.WriteLine();
            kierowniczka.Przyznaj_podwyzke(adam);
            kierowniczka.Zadowolenie_z_pracow();
            
            kierowniczka.Motywacja(); 
            kierowniczka.Zadowolenie_z_pracow();  //sprawdzenie czy metoda Motywacja przywróciła zadowolenie kierowniczki
            Console.ReadKey();
        }
    }
}

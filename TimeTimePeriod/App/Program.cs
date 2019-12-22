using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTimePeriod;

namespace App
{
    class Program
    {
        static Time czas;
         static TimePeriod period;
        static void Main(string[] args)
        {
             TimeOperations();
            Console.ReadKey();

        }
        public static void TimeOperations()
        {
            bool correctTime = false;
            while (correctTime != true)
            {
                Console.WriteLine("Podaj godzinę w formacie h:m:s");
                try
                {
                   czas = new Time (Console.ReadLine());
                    
                    correctTime = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wprowadziles zle dane, sprobuj ponownie");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Wprowadziles ujemna lub zbyt duza liczbe, sprobuj ponownie");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Nie wprowadziles wszystkich danych, sprobuj ponownie");
                }

                catch (Exception)
                {

                    Console.WriteLine("Wprowadzono bledne dane, upewnij sie, ze oddzielasz liczby dwukropkiem");

                }
            }
            Console.Clear();
            Console.WriteLine("Wybrales czas: " + czas);
            Console.WriteLine("Wybierz jedna z trzech opcji");
            Console.WriteLine("Wpisz + jesli chcesz dodac okres czasu, - jesli odjac okres czasu, * jesli pomnozyc");
            string dzialanie;
            try
            {
                dzialanie = Console.ReadLine();
            }
            catch (Exception)
            {

                throw new ArgumentException(nameof(dzialanie), "wprowadz poprawna opcje");
            }
            if (dzialanie == "+")
            {
                Console.WriteLine(AddPeriod());
            }
            if (dzialanie == "-")
            {
                Console.WriteLine(MinusPeriod());
            }
            if (dzialanie == "*")
            {
                Console.WriteLine(MultiplyByPeriod());
            }


        }
        public static Time AddPeriod()
        {
                      
            bool correctTime = false;
            
            while (correctTime != true)
            {
                Console.WriteLine("Podaj okres czasu, ktory chcesz dodac w postaci h:m:s"); ;
                try
                {
                    period = new TimePeriod(Console.ReadLine());

                    correctTime = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wprowadziles zle dane, sprobuj ponownie");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Wprowadziles ujemna lub zbyt duza liczbe, sprobuj ponownie");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Nie wprowadziles wszystkich danych, sprobuj ponownie");
                }

                catch (Exception)
                {

                    Console.WriteLine("Wprowadzono bledne dane, upewnij sie, ze oddzielasz liczby dwukropkiem");

                }                
            }

           return czas + period;
        }


        public static Time MinusPeriod()
        {

            bool correctTime = false;

            while (correctTime != true)
            {
                Console.WriteLine("Podaj okres czasu, ktory chcesz odjac w postaci h:m:s"); ;
                try
                {
                    period = new TimePeriod(Console.ReadLine());

                    correctTime = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wprowadziles zle dane, sprobuj ponownie");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Wprowadziles ujemna lub zbyt duza liczbe, sprobuj ponownie");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Nie wprowadziles wszystkich danych, sprobuj ponownie");
                }

                catch (Exception)
                {

                    Console.WriteLine("Wprowadzono bledne dane, upewnij sie, ze oddzielasz liczby dwukropkiem");

                }
            }

            return czas.Minus(period);
        }

        public static Time MultiplyByPeriod()
        {
            int liczba;
            try
            {
                Console.WriteLine("Podaj dodatnia liczbe przez ktora chcesz mnozyc czas");
                liczba = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

                throw new ArgumentException(nameof(liczba), "wprowadz liczbe wieksza od zera");
            }
            return czas.Multiply(liczba);
        }

    }
}

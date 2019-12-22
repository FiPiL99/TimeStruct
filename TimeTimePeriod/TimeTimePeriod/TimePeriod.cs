using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTimePeriod
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        
        private readonly long numberOfSeconds;

        /// <summary>
        /// Zmienna przetrzymująca sumę sekund czasu
        /// </summary>
        public long NumberOfSeconds => numberOfSeconds;


        /// <summary>
        /// Godziny
        /// </summary>
        /// <value>
        /// Ilość godzin
        /// </value>      
        public long Hours => numberOfSeconds / 3600;

        /// <summary>
        /// Minuty
        /// </summary>
        /// <value>
        /// Ilość minut
        /// </value> 
        public long Minutes => (numberOfSeconds / 60) % 60;

        /// <summary>
        /// Sekundy
        /// </summary>
        /// <value>
        /// Ilość sekund
        /// </value> 
        public long Seconds => numberOfSeconds % 60;

        /// <summary>
        /// Konstruktor z podanymi godziną minutą i sekundą
        /// </summary>
        /// <param name="hours">bedzie przypisywał obiekotwi wartość godzin</param>
        /// <param name="minutes">bedzie przypisywał obiekotwi wartość minut</param>
        /// <param name="seconds">bedzie przypisywał obiekotwi wartość sekund</param>
        public TimePeriod(long hours, long minutes, long seconds) => numberOfSeconds = hours * 3600 + minutes * 60 + seconds;

        /// <summary>
        /// Konstruktor z podanymi godziną i minutą
        /// </summary>
        /// <param name="hours">bedzie przypisywał obiekotwi wartość godzin</param>
        /// <param name="minutes">bedzie przypisywał obiekotwi wartość minut</param>
        public TimePeriod(long hours, long minutes) => numberOfSeconds = hours * 3600 + minutes * 60;

        /// <summary>
        /// Konstruktor z podanymi sekundami
        /// </summary>
        /// <param name="seconds">bedzie przypisywał obiekotwi wartość godzin</param>
        public TimePeriod(long seconds) => numberOfSeconds = seconds;

        /// <summary>
        /// konstruktor z podanymi dwoma punktami na liniczasu z których wyliczana jest różnica i przypisywana do zmiennych
        /// </summary>
        /// <param name="t1">Obiekt typu Time pierwszy od którego bedziemy odejmować</param>
        /// <param name="t2">Obiekt typu Time drugi który będzie odejmowany</param>
        public TimePeriod(Time t1, Time t2)
        {
            long secondsT1;
            long secondsT2;
            secondsT1 = t1.Seconds + t1.Minutes * 60 + t1.Hours * 3600;
            secondsT2 = t2.Seconds + t2.Minutes * 60 + t2.Hours * 3600;
            numberOfSeconds = Math.Abs(secondsT1 - secondsT2);
        }

        /// <summary>
        /// Konstruktor z podanymi godziną, minutami i sekundami w postaci stringu
        /// </summary>
        /// <param name="czas">data która zostanie następnie zamieniona na tablice bytów i przypisana do odpowiednich wartości obiektu</param>
        public TimePeriod(string czas)
        {
            string[] split = czas.Split(':');
            numberOfSeconds = Int64.Parse(split[2]) + Int64.Parse(split[1]) * 60 + Int64.Parse(split[0]) * 3600;
        }

        /// <summary>
        /// Nadpisanie metody która będzie zwracała datę w formie stringa
        /// </summary>
        /// <returns>Zwraca datę w formie stringa w formacie"Hours:Minutes:Seconds"</returns>
        public override string ToString() => $"{Hours}:{Minutes:D2}:{Seconds:D2}";

        /// <summary>
        /// Implementacja Interfejsu IEquatable
        /// </summary>
        /// <param name="other">Obiekt typu TimePeriod który chcemy porównywać</param>
        /// <returns>Zwracamy prawdę gdy obiekty są równe lub false nie są</returns>
        public bool Equals(TimePeriod other)
        {
            if (Object.ReferenceEquals(this, other)) return true;
            return (NumberOfSeconds == other.NumberOfSeconds);
        }


        /// <summary>
        /// Implementacja Interfejsu IEquatable
        /// </summary>
        /// <param name="obj">Obiekt nieznanego typu który chcemy porównywać</param>
        /// <returns>fałsz jeżeli obiekt jest nullem lub nie jest typu TimePeriod lub zwraca metodę Equals z rzutowaniem obiektu na typ TimePeriod</returns>
        public override bool Equals(object obj)
        {
            if (obj is TimePeriod)
            {
                return Equals((TimePeriod)obj);
            }
            else
                return false;
        }

        /// <summary>
        /// Implementacja interfejsu IEquatable, nadpisanie metody GetHashCode
        /// </summary>
        /// <returns>zwraca unikalny numer podanego obiektu</returns>
        public override int GetHashCode() => (NumberOfSeconds).GetHashCode();

        /// <summary>
        /// Implementacja interfejsu IEquatable
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu TimePeriod</param>
        /// <param name="t2">Drugi obiekt typu TimePeriod</param>
        /// <returns>Jeżeli obiekty są równe zwraca true inaczej zwraca false</returns>
        public static bool Equals(TimePeriod t1, TimePeriod t2) => t1.Equals(t2);


        /// <summary>
        /// Przeciążenie operatora ==
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu TimePeriod</param>
        /// <param name="t2">Drugi obiekt typu TimePeriod</param>
        /// <returns>Jeżeli obiekty są równe zwraca true inaczej zwraca false</returns>
        public static bool operator ==(TimePeriod t1, TimePeriod t2) => Equals(t1, t2);

        /// <summary>
        /// Przeciążenie operatora !=
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu TimePeriod</param>
        /// <param name="t2">Drugi obiekt typu TimePeriod</param>
        /// <returns>Jeżeli obiekty nie są równe zwraca true inaczej zwraca false</returns>
        public static bool operator !=(TimePeriod t1, TimePeriod t2) => !(t1 == t2);

        /// <summary>
        /// Przeciążenie operatora >
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu TimePeriod</param>
        /// <param name="t2">Drugi obiekt typu TimePeriod</param>
        /// <returns>Zwraca true gdy obiekt pierwszy jest większy niż drugi inaczej zwraca false</returns>
        public static bool operator >(TimePeriod t1, TimePeriod t2) => t1.CompareOperator(t2);

        /// <summary>
        /// Przeciążenie operatora <
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu TimePeriod</param>
        /// <param name="t2">Drugi obiekt typu TimePeriod</param>
        /// <returns>Zwraca true gdy obiekt pierwszy jest mniejszy niż drugi inaczej zwraca false</returns>
        public static bool operator <(TimePeriod t1, TimePeriod t2) => !(t1 > t2);

        /// <summary>
        /// Przeciążenie operatora >=
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu TimePeriod</param>
        /// <param name="t2">Drugi obiekt typu TimePeriod</param>
        /// <returns>Zwraca true gdy obiekt pierwszy jest większy niż drugi lub są one równe, inaczej zwraca false</returns>
        public static bool operator >=(TimePeriod t1, TimePeriod t2) => ((t1 > t2) || (t1 == t2));

        /// <summary>
        /// Przeciążenie operatora <=
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu TimePeriod</param>
        /// <param name="t2">Drugi obiekt typu TimePeriod</param>
        /// <returns>Zwraca true gdy obiekt pierwszy jest mniejszy niż drugi lub są one równe, inaczej zwraca false</returns>
        public static bool operator <=(TimePeriod t1, TimePeriod t2) => ((t1 < t2) || (t1 == t2));

        /// <summary>
        /// Przeciążenie operatora +
        /// </summary>
        /// <param name="t1">Obiekt typu TimePeriod określający jaki okres czasu chcemy dodać</param>
        /// <param name="t2">Obiekt typu TimePeriod określający jaki okres czasu chcemy dodać</param>
        /// <returns>Zwracamy nowy obiekt typu TimePeriod który wskazuje nam odległości w czasie</returns>
        public static TimePeriod operator +(TimePeriod t1, TimePeriod t2) => Plus(t1, t2);

        /// <summary>
        /// Implementacja interfejsu IComparable
        /// </summary>
        /// <param name="other">Obiekt typu TimePeriod do którego chcemy być przyrównani</param>
        public int CompareTo(TimePeriod other)
        {
            if (this == other) return 0;
            return NumberOfSeconds.CompareTo(other.NumberOfSeconds);
        }

        /// <summary>
        /// Implementacja interfejsu IComparable
        /// </summary>
        public bool CompareOperator(TimePeriod other)
        {
            if (this == other) return false;
            return (NumberOfSeconds > other.NumberOfSeconds);
        }

        /// <summary>
        /// Metoda zwracająca punkt po dodaniu do naszego punktu odległości w czasie
        /// </summary>
        /// <param name="period">Obiekt typu TimePeriod określający ile czasu ma upłynąć</param>
        /// <returns>Zwracany jest nowy obiekt TimePeriod który pokazuje nam okres czasu</returns>
        public TimePeriod Plus(TimePeriod period)
        {
            var numberOfSeconds1 = NumberOfSeconds + period.NumberOfSeconds;
            return new TimePeriod(numberOfSeconds1);
        }

        /// <summary>
        /// Dodawanie dwóch przedziałów czasowych do siebie
        /// </summary>
        /// <param name="p1">Pierwszy parametr sumy czasu który będziemy dodawać</param>
        /// <param name="p2">Drugi parametr sumy czasu który będziemy dodawać</param>
        /// <returns>Zwraca nowy obiekt typu TimePeriod który reprezentuje sumę składowych</returns>
        public static TimePeriod Plus(TimePeriod p1, TimePeriod p2)
        {
            var numberOfSeconds1 = p1.NumberOfSeconds + p2.NumberOfSeconds;
            return new TimePeriod(numberOfSeconds1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTimePeriod
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte hours;
        private readonly byte minutes;
        private readonly byte seconds;

        /// <summary>
        /// Godziny
        /// </summary>
        /// <value>
        /// Ilość godzin
        /// </value>  
        public byte Hours => hours;

        /// <summary>
        /// Minuty
        /// </summary>
        /// <value>
        /// Ilość minut
        /// </value>  
        public byte Minutes => minutes;

        /// <summary>
        /// Sekundy
        /// </summary>
        /// <value>
        /// Ilość sekund
        /// </value>    
        public byte Seconds => seconds;
        public long NumberOfSeconds => hours * 3600 + minutes * 60 + seconds;

        /// <summary>
        /// Konstruktor z podaniem godziny minuty i sekundy
        /// </summary>
        /// <param name="hours">bedzie przypisywał obiekotwi wartość godzin</param>
        /// <param name="minutes">bedzie przypisywał obiekotwi wartość minut</param>
        /// <param name="seconds">bedzie przypisywał obiekotwi wartość sekund</param>
        public Time(byte hours, byte minutes, byte seconds)
        {

            if (hours < 0 || hours > 23)
                throw new ArgumentException();

            if (minutes < 0 || minutes > 59)
                throw new ArgumentException();

            if (seconds < 0 || seconds > 59)
                throw new ArgumentException();

            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        /// <summary>
        /// Konstruktor z podanymi godziną minutą i domyślnymi sekundami
        /// </summary>
        /// <param name="hours">bedzie przypisywał obiekotwi wartość godzin</param>
        /// <param name="minutes">bedzie przypisywał obiekotwi wartość minut</param>
        public Time(byte hours, byte minutes)
        {
            if (hours < 0 || hours > 23)
                throw new ArgumentException();

            if (minutes < 0 || minutes > 59)
                throw new ArgumentException();

            this.hours = hours;
            this.minutes = minutes;
            this.seconds = 0;
        }

        /// <summary>
        /// Konstruktor z podanymi godziną i domyślnymi sekundami i minutami
        /// </summary>
        /// <param name="hours">bedzie przypisywał obiekotwi wartość godzin</param>
        public Time(byte hours)
        {
            if (hours < 0 || hours > 23)
                throw new ArgumentException();
            this.hours = hours;
            minutes = 0;
            seconds = 0;
        }

        /// <summary>
        /// Konstruktor z podaniem godziny, minut i sekund w postaci stringu
        /// </summary>
        /// <param name="time">data która zostanie następnie zamieniona na tablice bitów i przypisana do odpowiednich wartości obiektu</param>
        public Time(string time)
        {
            string[] numbers = time.Split(':');
            if (Byte.Parse(numbers[0]) < 0 || Byte.Parse(numbers[0]) > 23)
                throw new ArgumentException();

            if (Byte.Parse(numbers[1]) < 0 || Byte.Parse(numbers[1]) > 59)
                throw new ArgumentException();

            if (Byte.Parse(numbers[1]) < 0 || Byte.Parse(numbers[1]) > 59)
                throw new ArgumentException();

            hours = Byte.Parse(numbers[0]);
            minutes = Byte.Parse(numbers[1]);
            seconds = Byte.Parse(numbers[2]);
        }


        /// <summary>
        /// Nadpisanie metody która będzie zwracała datę w postaci stringa
        /// </summary>
        /// <returns>Zwraca datę w postaci stringa w formacie"Hours:Minutes:Secunds"</returns>
        public override string ToString() => $"{Hours:D2}:{Minutes:D2}:{seconds:D2}";

        /// <summary>
        /// Implementacja Interfejsu IEquatable
        /// </summary>
        /// <param name="other">Obiekt typu Time który chcemy porównywać</param>
        /// <returns>Zwracamy prawdę gdy obiekty są równe lub false nie są</returns>
        public bool Equals(Time other)
        {
            if (Object.ReferenceEquals(this, other)) return true;
            return (Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds);
        }

        /// <summary>
        /// Implementacja Interfejsu IEquatable
        /// </summary>
        /// <param name="obj">Obiekt nieznanego typu który chcemy porównywać</param>
        /// <returns>fałsz jeżeli obiekt jest nullem lub nie jest typu Time lub zwraca metodę Equals z rzutowaniem obiektu na typ Time</returns>
        public override bool Equals(object obj)
        {
            if (obj is Time time)
            {
                return Equals(time);
            }
            else
                return false;
        }

        /// <summary>
        /// Implementacja interfejsu IEquatable, nadpisanie metody GetHashCode
        /// </summary>
        /// <returns>zwraca unikalny numer podanego obiektu</returns>
        public override int GetHashCode() => (Hours, Minutes, Seconds).GetHashCode();

        /// <summary>
        /// Implementacja interfejsu IEquatable
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu Time</param>
        /// <param name="t2">Drugi obiekt typu Time</param>
        /// <returns>Jeżeli obiekty są równe zwraca true inaczej zwraca false</returns>
        public static bool Equals(Time t1, Time t2) => t1.Equals(t2);

        /// <summary>
        /// Przeciążenie operatora ==
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu Time</param>
        /// <param name="t2">Drugi obiekt typu Time</param>
        /// <returns>Jeżeli obiekty są równe zwraca true inaczej zwraca false</returns>
        public static bool operator ==(Time t1, Time t2) => Equals(t1, t2);

        /// <summary>
        /// Przeciążenie operatora !=
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu Time</param>
        /// <param name="t2">Drugi obiekt typu Time</param>
        /// <returns>Jeżeli obiekty nie są równe zwraca true inaczej zwraca false</returns>
        public static bool operator !=(Time t1, Time t2) => !(t1 == t2);

        /// <summary>
        /// Przeciążenie operatora >
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu Time</param>
        /// <param name="t2">Drugi obiekt typu Time</param>
        /// <returns>Zwraca true gdy obiekt pierwszy jest większy niż drugi inaczej zwraca false</returns>
        public static bool operator >(Time t1, Time t2) => CompareOperator(t1, t2);

        /// <summary>
        /// Przeciążenie operatora <
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu Time</param>
        /// <param name="t2">Drugi obiekt typu Time</param>
        /// <returns>Zwraca true gdy obiekt pierwszy jest mniejszy niż drugi inaczej zwraca false</returns>
        public static bool operator <(Time t1, Time t2) => !(t1 > t2);

        /// <summary>
        /// Przeciążenie operatora >=
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu Time</param>
        /// <param name="t2">Drugi obiekt typu Time</param>
        /// <returns>Zwraca true gdy obiekt pierwszy jest większy niż drugi lub są one równe, inaczej zwraca false</returns>
        public static bool operator >=(Time t1, Time t2) => ((t1 == t2) || (t1 > t2));

        /// <summary>
        /// Przeciążenie operatora <=
        /// </summary>
        /// <param name="t1">Pierwszy Obiekt typu Time</param>
        /// <param name="t2">Drugi obiekt typu Time</param>
        /// <returns>Zwraca true gdy obiekt pierwszy jest mniejszy niż drugi lub są one równe, inaczej zwraca false</returns>
        public static bool operator <=(Time t1, Time t2) => ((t1 < t2) || (t1 == t2));

        /// <summary>
        /// Przeciążenie operatora +
        /// </summary>
        /// <param name="t1">Obiekt typu Time określający punkt do którego chcemy dodawać</param>
        /// <param name="t2">Obiekt typu TimePeriod określający jaki okres czasu chcemy dodać</param>
        /// <returns>Zwracamy nowy obiekt typu Time który wskazuje nam godzine po dodaniu odległości w czasie</returns>
        public static Time operator +(Time t1, TimePeriod t2) => Plus(t1, t2);

        /// <summary>
        /// Implementacja interfejsu IComparable
        /// </summary>
        /// <param name="other">Obiekt typu Time do którego chcemy być przyrównani</param>
        public int CompareTo(Time other)
        {
            if (this == other) return 0;
            if (Hours != other.Hours)
                return Hours.CompareTo(other.Hours);
            if (Minutes != other.Minutes)
                return Minutes.CompareTo(other.Minutes);
            return Seconds.CompareTo(other.Seconds);
        }

        /// <summary>
        /// Implementacja interfejsu IComparable
        /// </summary>
        /// <param name="t1">Pierwszy obiekt typu Time, który chcemy porównywać</param>
        /// <param name="t1">Drugi obiekt typu Time, który chcemy porównywać</param>
        public static bool CompareOperator(Time t1, Time t2)
        {
            if (t1.CompareTo(t2) > 0)
                return true;
            else 
                return false;
        }

        /// <summary>
        /// Metoda zwracająca czas po dodaniu do naszego czasu okresu
        /// </summary>
        /// <param name="time">Obiekt typu TimePeriod określający ile czasu ma upłynąć</param>
        /// <returns>Zwracany jest nowy obiekt Time który pokazuje punkt na lini czasu po dodaniu</returns>
        public Time Plus(TimePeriod time)
        {
            byte hours = (byte)((time.Hours + Hours));
            byte minutes = (byte)((time.Minutes + Minutes));
            byte seconds = (byte)(time.Seconds + Seconds);
            return new Time((byte)(hours % 24), (byte)(minutes % 60), (byte)(seconds % 60));
        }

        /// <summary>
        /// Metoda zwracająca punkt po odjeciu od naszego punktu odległości w czasie
        /// </summary>
        /// <param name="time">Obiekt typu TimePeriod określający ile czasu mamy odjąć</param>
        /// <returns>Zwracany jest nowy obiekt Time który pokazuje punkt na lini czasu po odjeciu</returns>
        public Time Minus(TimePeriod time)
        {
            long hours = Hours - time.Hours;
            if (hours < 0) hours += 24;
            long minutes = Minutes - time.Minutes;
            if (minutes < 0) minutes += 60;
            long seconds =  Seconds - time.Seconds;
            if (seconds < 0) seconds += 60;
            return new Time((byte)(hours % 24), (byte)(minutes % 60), (byte)(seconds % 60));
        }

        /// <summary>
        /// Metoda zwracająca punkt w czasie po mnozenie przez liczbe
        /// </summary>
        /// <param name="mnozenie">Liczba przez, którą będziemy mnożyć nasz czas</param>
        /// <returns>Zwracany jest nowy obiekt Time który pokazuje punkt na lini czasu po mnożeniu</returns>
        public Time Multiply(int mnozenie)
        {
            long newNumberOfSeconds = NumberOfSeconds * mnozenie;
            return new Time((byte)((newNumberOfSeconds / 3600) % 24), (byte)((newNumberOfSeconds / 60) % 60), (byte)(newNumberOfSeconds % 60));
        }


        /// <summary>
        /// Metoda zwracająca punkt po dodaniu do naszego punktu odległości w czasie
        /// </summary>
        /// <param name="time">Obiekt typu Time określający punkt do którego chcemy dodawać</param>
        /// <param name="okres">Obiekt typu TimePeriod określający jaki okres czasu chcemy dodać</param>
        /// <returns>Zwracamy nowy obiekt typu Time który wskazuje nam godzine po dodaniu odległości w czasie</returns>
        static Time Plus(Time time, TimePeriod okres)
        {
            byte hours = (byte)((time.Hours + okres.Hours));
            byte minutes = (byte)((time.Minutes + okres.Minutes));
            byte seconds = (byte)(time.Seconds + okres.Seconds);
            if ((seconds) % 60 == 0)
                minutes++;
            if ((minutes) % 60 == 0)
                hours++;
            return new Time((byte)(hours % 24), (byte)(minutes % 60), (byte)(seconds % 60));
        }
    }


}

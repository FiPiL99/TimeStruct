using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTimePeriod;

namespace TimeTimePeriodTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow((byte)4, (byte)5, (byte)1, (byte)4, (byte)5, (byte)1)]
        [DataRow((byte)23, (byte)5, (byte)1, (byte)23, (byte)5, (byte)1)]
        [DataRow((byte)23, (byte)59, (byte)59, (byte)23, (byte)59, (byte)59)]
        public void ConstructorThreeVariables(byte hours, byte minutes, byte seconds, byte expectedHours, byte expectedMinutes, byte expectedSeconds)
        {
            Time time = new Time(hours, minutes, seconds);
            Assert.AreEqual(time.Hours, expectedHours);
            Assert.AreEqual(time.Minutes, expectedMinutes);
            Assert.AreEqual(time.Seconds, expectedSeconds);

        }

        [DataTestMethod]
        [DataRow((byte)4, (byte)5, (byte)0, (byte)4, (byte)5, (byte)0)]
        [DataRow((byte)23, (byte)5, (byte)0, (byte)23, (byte)5, (byte)0)]
        [DataRow((byte)23, (byte)59, (byte)0, (byte)23, (byte)59, (byte)0)]
        public void ConstructorTwoVariables(byte hours, byte minutes, byte seconds, byte expectedHours, byte expectedMinutes, byte expectedSeconds)
        {
            Time time = new Time(hours, minutes);
            Assert.AreEqual(time.Hours, expectedHours);
            Assert.AreEqual(time.Minutes, expectedMinutes);
            Assert.AreEqual(time.Seconds, expectedSeconds);

        }


        [DataTestMethod]
        [DataRow((byte)4, (byte)0, (byte)0, (byte)4, (byte)0, (byte)0)]
        [DataRow((byte)23, (byte)0, (byte)0, (byte)23, (byte)0, (byte)0)]
        [DataRow((byte)23, (byte)0, (byte)0, (byte)23, (byte)0, (byte)0)]
        public void ConstructorOneVariables(byte hours, byte minutes, byte seconds, byte expectedHours, byte expectedMinutes, byte expectedSeconds)
        {
            Time time = new Time(hours);
            Assert.AreEqual(time.Hours, expectedHours);
            Assert.AreEqual(time.Minutes, expectedMinutes);
            Assert.AreEqual(time.Seconds, expectedSeconds);
        }

        [DataTestMethod]
        [DataRow("1:23:49", (byte)1, (byte)23, (byte)49)]
        [DataRow("22:23:49", (byte)22, (byte)23, (byte)49)]
        [DataRow("6:29:10", (byte)6, (byte)29, (byte)10)]
        public void ConstructorStringVariables(string timeToByte, byte expectedHours, byte expectedMinutes, byte expectedSeconds)
        {
            Time time = new Time(timeToByte);
            Assert.AreEqual(time.Hours, expectedHours);
            Assert.AreEqual(time.Minutes, expectedMinutes);
            Assert.AreEqual(time.Seconds, expectedSeconds);
        }

        [DataTestMethod]
        [DataRow((byte)1, (byte)23, (byte)49, "01:23:49")]
        [DataRow((byte)20, (byte)13, (byte)49, "20:13:49")]
        [DataRow((byte)5, (byte)7, (byte)9, "05:07:09")]
        public void ToStringTest(byte hours, byte minutes, byte seconds, string expectedString)
        {
            Time time = new Time(hours, minutes, seconds);
            Assert.AreEqual(time.ToString(), expectedString);
        }

        [DataTestMethod]
        [DataRow((byte)1, (byte)23, (byte)49, true)]
        public void EqualsTest(byte hours, byte minutes, byte seconds, bool expectedBool)
        {
            Time time = new Time(hours, minutes, seconds);
            Time time2 = time;
            Assert.AreEqual(time.Equals(time2), expectedBool);
        }

        [DataTestMethod]
        [DataRow((byte)1, (byte)23, (byte)49, true)]
        public void EqualsTest10(byte hours, byte minutes, byte seconds, bool expectedBool)
        {
            Time time = new Time(hours, minutes, seconds);
            Time time2 = time;
            Assert.AreEqual(time.Equals(time2), expectedBool);
        }
        [TestMethod()]
        public void EqualsTest2()
        {
            Time punktCzasu1 = new Time("1:3:15");
            Time punktCzasu2 = new Time("1:3:15");
            bool areEqual = punktCzasu1.Equals(punktCzasu2);
            bool expectedBool = true;
            Assert.AreEqual(areEqual, expectedBool);
        }

        public void EqualsTest3()
        {
            Time punktCzasu1 = new Time("2:3:10");
            Time punktCzasu2 = new Time("2:33:15");
            bool areEqual = (punktCzasu1 == punktCzasu2);
            bool expected = false;
            Assert.AreEqual(areEqual, expected);
        }

        [TestMethod()]
        public void NotEqualsTest()
        {
            Time punktCzasu1 = new Time("12:31:55");
            Time punktCzasu2 = new Time("1:3:45");
            bool areEqual = punktCzasu1 != punktCzasu2;
            bool expected = true;
            Assert.AreEqual(areEqual, expected);
        }

        [TestMethod()]
        public void NotEqualsMethodTest()
        {
            Time punktCzasu1 = new Time("13:4:20");
            Time punktCzasu2 = new Time("13:4:20");
            bool areEqual = punktCzasu1 != punktCzasu2;
            bool expected = false;
            Assert.AreEqual(areEqual, expected);
        }

        [TestMethod()]
        public void CompareToTest()
        {
            Time punktCzasu1 = new Time("10:0:13");
            Time punktCzasu2 = new Time("23:11:10");
            int expected = -13;
            int current = punktCzasu1.CompareTo(punktCzasu2);
            Assert.AreEqual(current, expected);
        }
        [TestMethod()]
        public void CompareToTest3()
        {
            Time punktCzasu1 = new Time("14:2:2");
            Time punktCzasu2 = new Time("14:2:2");
            int expected = 0;
            int current = punktCzasu2.CompareTo(punktCzasu1);
            Assert.AreEqual(current, expected);

        }

              [TestMethod()]
        public void OperatorMniejszościTest()
        {
            Time punktCzasu1 = new Time("1:1:4");
            Time punktCzasu2 = new Time("14:2:3");
            bool expected = true;
            bool currnet = punktCzasu1 < punktCzasu2;
            Assert.AreEqual(currnet, expected);
        }

        [TestMethod()]
        public void OperatorMniejszościTest2()
        {
            Time punktCzasu1 = new Time("19:1:4");
            Time punktCzasu2 = new Time("7:6:8");
            bool expected = false;
            bool current = (punktCzasu1 < punktCzasu2);
            Assert.AreEqual(current, expected);
        }

        [TestMethod()]
        public void OperatorWiększościTest()
        {
            Time punktCzasu1 = new Time("12:3:5");
            Time punktCzasu2 = new Time("20:3:1");
            bool expected = false;
            bool current = punktCzasu1 > punktCzasu2;
            Assert.AreEqual(current, expected);
        }

        [TestMethod()]
        public void OperatorWiększościTest2()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("3:15:26");
            bool expected = true;
            bool current = punktCzasu1 > punktCzasu2;
            Assert.AreEqual(current, expected);
        }

        [TestMethod()]
        public void OperatorMniejszościRównościTest()
        {
            Time punktCzasu1 = new Time("2:4:5");
            Time punktCzasu2 = new Time("14:2:5");
            bool expected = true;
            bool current = punktCzasu1 <= punktCzasu2;
            Assert.AreEqual(current, expected);
        }

        public void OperatorMniejszościRównościTest2()
        {
            Time punktCzasu1 = new Time("2:4:5");
            Time punktCzasu2 = new Time("14:2:5");
            bool expected = false;
            bool current = punktCzasu1 <= punktCzasu2;
            Assert.AreEqual(current, expected);
        }

        [TestMethod()]
        public void OperatorMniejszościRównościTest3()
        {
            Time punktCzasu1 = new Time("12:2:4");
            Time punktCzasu2 = new Time("12:2:4");
            bool expected = true;
            bool current = punktCzasu1 <= punktCzasu2;
            Assert.AreEqual(current, expected);
        }

        [TestMethod()]
        public void OperatorWiększościRównościTest()
        {
            Time punktCzasu1 = new Time("21:3:5");
            Time punktCzasu2 = new Time("23:23:1");
            bool expected = false;
            bool current = punktCzasu1 >= punktCzasu2;
            Assert.AreEqual(current, expected);
        }

        [TestMethod()]
        public void Plus()
        {
            Time punktCzasu1 = new Time("1:1:2");
            TimePeriod przedziałCzasu1 = new TimePeriod("1:23:1");
            string expected = "02:24:03";
            Assert.AreEqual(punktCzasu1.Plus(przedziałCzasu1).ToString(), expected);
        
        }

        [TestMethod()]
        public void Minus()
        {
            Time punktCzasu1 = new Time("2:25:2");
            TimePeriod przedziałCzasu1 = new TimePeriod("1:23:1");
            string expected = "01:02:01";
            Assert.AreEqual(punktCzasu1.Minus(przedziałCzasu1).ToString(), expected);

        }

        [TestMethod()]
        public void Multiply()
        {
            Time punktCzasu1 = new Time("1:1:2");
            int number = 3;
            string expected = "03:03:06";
            Assert.AreEqual(punktCzasu1.Multiply(number).ToString(), expected);

        }
        [TestMethod()]
        public void GetVariablesFromTimePeriod()
        {
            TimePeriod period = new TimePeriod("2:4:3");
            long hours = period.Hours;
            long expectHours = 2;
            long minutes = period.Minutes;
            long expectMinutes = 4;
            long seconds = period.Seconds;
            long expectSeconds = 3;
            long numberOfSeconds = period.NumberOfSeconds;
            long expectedNumberOfSecods = 2 * 3600 + 4 * 60 + 3;
            Assert.AreEqual(hours, expectHours);
            Assert.AreEqual(minutes, expectMinutes);
            Assert.AreEqual(seconds, expectSeconds);
            Assert.AreEqual(numberOfSeconds,expectedNumberOfSecods );
        }

        [TestMethod()]
        public void TimePeriodByConstructorTest1()
        {
            TimePeriod okresCzasu = new TimePeriod(10, 2, 3);
            string expected = okresCzasu.ToString();
            string actual = "10:02:03";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TimePeriodByConstructorTest2()
        {
            TimePeriod okresCzasu = new TimePeriod(1, 4);
            string expected = okresCzasu.ToString();
            string actual = "1:04:00";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TimePeriodByConstructorTest3()
        {
            TimePeriod okresCzasu = new TimePeriod(2);
            string expected = okresCzasu.ToString();
            string actual = "0:00:02";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TimePeriodByConstructorTest4()
        {
            TimePeriod okresCzasu = new TimePeriod(100);
            string expected = okresCzasu.ToString();
            string acctual = "0:01:40";
            Assert.AreEqual(expected, acctual);
        }

        [TestMethod()]
        public void TimePeriodByConstructor()
        {
            Time punktCzasu1 = new Time(2, 4, 2);
            Time punktCzasu2 = new Time(5, 6, 7);
            TimePeriod okresCzasu = new TimePeriod(punktCzasu1, punktCzasu2);
            string expected = okresCzasu.ToString();
            string actual = "3:02:05";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void TimePeriodByConstructorTest6()
        {
            TimePeriod okresCzasu = new TimePeriod("10:23:2");
            string expected = okresCzasu.ToString();
            string actual = "10:23:02";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TimePeriodToString()
        {
            TimePeriod okresCzasu = new TimePeriod("12:4:2");
            string expected = "12:04:02";
            string actual = okresCzasu.ToString();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void EqualsTestPeriod()
        {
            TimePeriod okresCzasu1 = new TimePeriod("12:3:4");
            TimePeriod okresCzasu2 = new TimePeriod("45:3:12");
            bool areEqual = okresCzasu1.Equals(okresCzasu2);
            bool expected = false;
            Assert.AreEqual(expected, areEqual);
        }

        public void EqualsTestPeriod2()
        {
            TimePeriod okresCzasu1 = new TimePeriod("12:3:4");
            TimePeriod okresCzasu2 = new TimePeriod("12:3:4");
            bool areEqual = okresCzasu1.Equals(okresCzasu2);
            bool expected = true;
            Assert.AreEqual(expected, areEqual);
        }

        [TestMethod()]
        public void CompareToPeriodTest1()
        {
            TimePeriod okresCzasu1 = new TimePeriod("2:1:1");
            TimePeriod okresCzasu2 = new TimePeriod("2:1:1");
            int expected = 0;
            int actual = okresCzasu1.CompareTo(okresCzasu2);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void OperatorMniejszościPeriodTest()
        {
            TimePeriod okresCzasu1 = new TimePeriod("10:2:3");
            TimePeriod okresCzasu2 = new TimePeriod("14:22:1");
            bool expected = true;
            bool actual = okresCzasu1 < okresCzasu2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OperatorMniejszościPeriodTest2()
        {
            TimePeriod okresCzasu1 = new TimePeriod("23:33:4");
            TimePeriod okresCzasu2 = new TimePeriod("4:1:6");
            bool expected = false;
            bool actual = okresCzasu1 < okresCzasu2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OperatorWiększościPeriodTest()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("23:15:26");
            bool expected = false;
            bool actual = okresCzasu1 > okresCzasu2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OperatorWiększościPeriodTest2()
        {
            TimePeriod okresCzasu1 = new TimePeriod("12:3:4");
            TimePeriod okresCzasu2 = new TimePeriod("1:1:4");
            bool expected = true;
            bool actual = okresCzasu1 > okresCzasu2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OperatorMniejszościRównościPeriodTest()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("23:15:26");
            bool expected = true;
            bool actual = okresCzasu1 <= okresCzasu2;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void OperatorMniejszościRównościPeriodTest2()
        {
            TimePeriod okresCzasu1 = new TimePeriod("12:3:4");
            TimePeriod okresCzasu2 = new TimePeriod("2:3:4");
            bool expected = false;
            bool actual = okresCzasu1 <= okresCzasu2;
            Assert.AreEqual(expected, actual);
        }
        public void OperatorWiększościRównościPeriodTest()
        {
            TimePeriod okresCzasu1 = new TimePeriod("1:2:3");
            TimePeriod okresCzasu2 = new TimePeriod("22:1:4");
            bool expected = false;
            bool actual = okresCzasu1 >= okresCzasu2;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void OperatorWiększościRównościPeriodTest2()
        {
            TimePeriod okresCzasu1 = new TimePeriod("12:3:4");
            TimePeriod okresCzasu2 = new TimePeriod("5:2:5");
            bool expected = true;
            bool actual = okresCzasu1 >= okresCzasu2;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void PlusPeriodTest1()
        {
            TimePeriod przedziałCzasu1 = new TimePeriod("4:2:1");
            TimePeriod przedziałCzasu2 = new TimePeriod("2:5:6");
            string expected = "6:07:07";
            Assert.AreEqual(expected, przedziałCzasu1.Plus(przedziałCzasu2).ToString());

        }


    }
}

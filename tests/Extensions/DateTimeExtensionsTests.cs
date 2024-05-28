using LGov.Library.Extensions;
using System;
using System.Globalization;

namespace LGov.Library.Tests.Extensions
{
    [TestFixture]
    [Category("Date")]
    public class DateTimeExtensionsTests
    {
        //check to see if both true and false results show correctly
        //function returns the date of easter sunday

        //uses http://www.maa.mhn.de/StarDate/publ_holidays.html
        private readonly CultureInfo _ukCulture = CultureInfo.CreateSpecificCulture("en-GB");

        [Test]
        [Sequential]
        public void ArbitraryDatesReturnCorrectIsoWeek([Values("24/1/2018",
                        "1/1/2018",
                        "31/12/2018",
                        "16/12/2018",
                        "8/1/2040")]
                    string date,
            [Values(4,
                        1,
                        1,
                        50,
                        1)]
                    int actualWeek)
        {
            var expected = actualWeek;

            if (!DateTime.TryParse(date, _ukCulture, DateTimeStyles.None,
                out var dtResult))
            {
                return;
            }

            var actual = dtResult.IsoWeek();

            Assert.That(actual,
                Is.EqualTo(expected));
        }

        [Test]
        [Category("EasterDate")]
        [Category("Date")]
        public void CheckEasterFalse()
        {
            //Checks the formula and ensure easter returns false when implemented (dates aren't easter)
            //Check 1943, 1996, 2008 and 2060

            //1943
            long year = 1943;
            var expected = new DateTime(1943,
                4,
                23, 0, 0, 0, DateTimeKind.Utc);
            var actual = year.EasterDate();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //1996
            year = 1996;
            expected = new DateTime(1996,
                4,
                5, 0, 0, 0, DateTimeKind.Utc);
            actual = year.EasterDate();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2008
            year = 2008;
            expected = new DateTime(2008,
                3,
                24, 0, 0, 0, DateTimeKind.Utc);
            actual = year.EasterDate();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2060
            year = 2060;
            expected = new DateTime(2060,
                4,
                30, 0, 0, 0, DateTimeKind.Utc);
            actual = year.EasterDate();
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test]
        [Category("EasterDate")]
        [Category("Date")]
        public void CheckEasterTrue()
        {
            //Checks the formula and ensure easter returns true when implemented (dates are easter)
            //Check 1943, 1996, 2008 and 2060

            //1943
            long year = 1943;
            var expected = new DateTime(1943,
                4,
                25, 0, 0, 0, DateTimeKind.Utc);
            var actual = year.EasterDate();
            Assert.That(actual, Is.EqualTo(expected));

            //1996
            year = 1996;
            expected = new DateTime(1996,
                4,
                7, 0, 0, 0, DateTimeKind.Utc);
            actual = year.EasterDate();
            Assert.That(actual, Is.EqualTo(expected));

            //2008
            year = 2008;
            expected = new DateTime(2008,
                3,
                23, 0, 0, 0, DateTimeKind.Utc);
            actual = year.EasterDate();
            Assert.That(actual, Is.EqualTo(expected));

            //2060
            year = 2060;
            expected = new DateTime(2060,
                4,
                18, 0, 0, 0, DateTimeKind.Utc);
            actual = year.EasterDate();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Daylight Saving Time")]
        [Category("Date")]
        public void DstEndInValid()
        {
            //Test to see the end of the Daylight Savings Time - Last Sunday in October
            //Test range - 2010-2019

            //2010
            var year = 2010;
            var expected = new DateTime(2010,
                10,
                30, 0, 0, 0, DateTimeKind.Utc);
            var actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2011
            year += 1;
            expected = new DateTime(2011,
                11,
                1, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2012
            year += 1;
            expected = new DateTime(2012,
                10,
                27, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2013
            year += 1;
            expected = new DateTime(2013,
                10,
                2, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2014
            year += 1;
            expected = new DateTime(2014,
                10,
                29, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2015
            year += 1;
            expected = new DateTime(2015,
                10,
                30, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2016
            year += 1;
            expected = new DateTime(2016,
                10,
                31, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2017
            year += 1;
            expected = new DateTime(2017,
                12,
                25, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2018
            year += 1;
            expected = new DateTime(2018,
                10,
                25, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2019
            year += 1;
            expected = new DateTime(2019,
                10,
                24, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test]
        [Category("Daylight Saving Time")]
        [Category("Date")]
        public void DstEndValid()
        {
            //Test to see the end of the Daylight Savings Time - Last Sunday in October
            //Test range - 2010-2019

            //2010
            var year = 2010;
            var expected = new DateTime(2010,
                10,
                31, 0, 0, 0, DateTimeKind.Utc);
            var actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.EqualTo(expected));

            //2011
            year += 1;
            expected = new DateTime(2011,
                10,
                30, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.EqualTo(expected));

            //2012
            year += 1;
            expected = new DateTime(2012,
                10,
                28, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.EqualTo(expected));

            //2013
            year += 1;
            expected = new DateTime(2013,
                10,
                27, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.EqualTo(expected));

            //2014
            year += 1;
            expected = new DateTime(2014,
                10,
                26, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.EqualTo(expected));

            //2015
            year += 1;
            expected = new DateTime(2015,
                10,
                25, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.EqualTo(expected));

            //2016
            year += 1;
            expected = new DateTime(2016,
                10,
                30, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.EqualTo(expected));

            //2017
            year += 1;
            expected = new DateTime(2017,
                10,
                29, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.EqualTo(expected));

            //2018
            year += 1;
            expected = new DateTime(2018,
                10,
                28, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.EqualTo(expected));

            //2019
            year += 1;
            expected = new DateTime(2019,
                10,
                27, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkEnd();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Daylight Saving Time")]
        [Category("Date")]
        public void DstStartInvalid()
        {
            //Ensures false data doesn't return unexpected results
            //Test carried from 2010-2019

            //2010
            var year = 2010;
            var expected = new DateTime(2010,
                3,
                21, 0, 0, 0, DateTimeKind.Utc);
            var actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2011
            year += 1;
            expected = new DateTime(2011,
                4,
                4, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2012
            year += 1;
            expected = new DateTime(2012,
                3,
                24, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2013
            year += 1;
            expected = new DateTime(2013,
                4,
                6, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2014
            year += 1;
            expected = new DateTime(2014,
                3,
                28, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2015
            year += 1;
            expected = new DateTime(2015,
                3,
                27, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2016
            year += 1;
            expected = new DateTime(2016,
                3,
                31, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2017
            year += 1;
            expected = new DateTime(2017,
                3,
                16, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2018
            year += 1;
            expected = new DateTime(2018,
                1,
                1, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.Not.EqualTo(expected));

            //2019
            year += 1;
            expected = new DateTime(2019,
                3,
                13, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test]
        [Category("Daylight Saving Time")]
        [Category("Date")]
        public void DstStartValid()
        {
            //Tests when Daylight Savings Start in the UK, based on the last Sunday of the Month
            //Test carried from 2010-2019

            //2010
            var year = 2010;
            var expected = new DateTime(2010,
                3,
                28, 0, 0, 0, DateTimeKind.Utc);
            var actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.EqualTo(expected));

            //2011
            year += 1;
            expected = new DateTime(2011,
                3,
                27, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.EqualTo(expected));

            //2012
            year += 1;
            expected = new DateTime(2012,
                3,
                25, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.EqualTo(expected));

            //2013
            year += 1;
            expected = new DateTime(2013,
                3,
                31, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.EqualTo(expected));

            //2014
            year += 1;
            expected = new DateTime(2014,
                3,
                30, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.EqualTo(expected));

            //2015
            year += 1;
            expected = new DateTime(2015,
                3,
                29, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.EqualTo(expected));

            //2016
            year += 1;
            expected = new DateTime(2016,
                3,
                27, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.EqualTo(expected));

            //2017
            year += 1;
            expected = new DateTime(2017,
                3,
                26, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.EqualTo(expected));

            //2018
            year += 1;
            expected = new DateTime(2018,
                3,
                25, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.EqualTo(expected));

            //2019
            year += 1;
            expected = new DateTime(2019,
                3,
                31, 0, 0, 0, DateTimeKind.Utc);
            actual = year.DaylightSavingsTimeUkStart();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Invalid_IsAnyDate_ReturnsFalse([Values("31/12/20160",
                        "31.13.2016",
                        "32-12-2016",
                        "2016-0-31",
                        "29/2/2015",
                        "0/0/0",
                        "12/31/2016",
                        "",
                        "2345.5.5.0",
                        "abc")]
                    string date)
        {
            var input = date;
            var actual = input.IsAnyDate();
            Assert.That(actual, Is.False);
        }

        [Test]
        [Sequential]
        public void InvalidDatesReturnFalse([Values("31/12/20160",
                        "31.13.2016",
                        "32-12-2016",
                        "2016-0-31",
                        "29/2/2015",
                        "0/0/0",
                        "12/31/2016")]
                    string date)
        {
            var input = date;

            var actual = input.IsDate();

            Assert.That(actual, Is.False);
        }

        /// <summary>
        ///     The is date empty returns false.
        /// </summary>
        [Test]
        public void IsDateEmptyReturnsFalse()
        {
            var input = string.Empty;

            var actual = input.IsDate();

            Assert.That(actual,
                Is.False);
        }

        /// <summary> A test for IsEnglishBankHolidayWeek </summary>
        /// <returns>return:True - New Year falls on a Monday in 2018</returns>
        [Test]
        [Category("Date")]
        public void IsEnglishBankHolidayWeekMondayNewYear()
        {
            var testDate = new DateTime(2018,
                1,
                1, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsEnglishBankHolidayWeek();
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary> A test for IsEnglishBankHolidayWeek </summary>
        /// <returns>return:True - New Year falls on a sunday in 2012</returns>
        [Test]
        [Category("Date")]
        public void IsEnglishBankHolidayWeekSundayNewYear()
        {
            var testDate = new DateTime(2012,
                1,
                1, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsEnglishBankHolidayWeek();
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>A test for IsEnglishBankHolidayWeek </summary>
        /// <returns>return: true - boxing day falls on a monday</returns>
        [Test]
        [Category("Date")]
        public void IsEnglishBankHolidayWeekTestMondayBoxingDay()
        {
            var testDate = new DateTime(2011,
                12,
                31, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsEnglishBankHolidayWeek();
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary> A test for IsEnglishBankHolidayWeek </summary>
        /// <returns>return: False - Bank Hols are moved to the following Mon/Tues.Current week does not contain a bank holiday</returns>
        [Test]
        [Category("Date")]
        public void IsEnglishBankHolidayWeekTestSundayXmas()
        {
            var testDate = new DateTime(2011,
                12,
                24, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsEnglishBankHolidayWeek();
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary> A test for IsEnglishBankHolidayWeek </summary>
        /// <returns>return: False - 20/9/20 does not contain bank holiday</returns>
        [Test]
        [Category("Date")]
        public void IsEnglishBankHolidayWeekTestToFail()
        {
            var testDate = new DateTime(2011,
                9,
                20, 0, 0, 0, DateTimeKind.Utc);
            Assert.That(testDate.IsEnglishBankHolidayWeek(),
                Is.False);
        }

        /// <summary> A test for IsEnglishBankHolidayWeek </summary>
        /// <returns>return: True - 20/9/1 does contain a bank holiday</returns>
        [Test]
        [Category("Date")]
        public void IsEnglishBankHolidayWeekTestToSucceed()
        {
            var testDate = new DateTime(2011,
                9,
                1, 0, 0, 0, DateTimeKind.Utc);
            Assert.That(testDate.IsEnglishBankHolidayWeek(),
                Is.True);
        }

        /// <summary> A test for IsUKBankHolidayWeek </summary>
        /// <returns>return:True - Bank Holiday</returns>
        [Test]
        [Category("Date")]
        public void IsFormerJubileeHolidayAHoliday()
        {
            var testDate = new DateTime(2012,
                6,
                5, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkWorkingDay();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Date")]
        public void IsFormerJubileeHolidayAHolidayWeek()
        {
            var testDate = new DateTime(2012,
                5,
                28, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsEnglishBankHolidayWeek();
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary> A test for IsUKBankHolidayWeek </summary>
        /// <returns>return:False - Not Bank Holiday</returns>
        [Test]
        [Category("Date")]
        public void IsJubileeBankHolidayAHoliday()
        {
            var testDate = new DateTime(2012,
                6,
                4, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Date")]
        public void IsJubileeBankHolidayAHolidayWeek()
        {
            var testDate = new DateTime(2012,
                6,
                4, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsEnglishBankHolidayWeek();
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary> A test for IsUKBankHolidayWeek </summary>
        /// <returns>return:True - Special Bank Holiday</returns>
        [Test]
        [Category("Date")]
        public void IsJubileeHolidayAHoliday()
        {
            var testDate = new DateTime(2012,
                6,
                5, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Date")]
        public void IsJubileeHolidayAHolidayWeek()
        {
            var testDate = new DateTime(2012,
                6,
                5, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsEnglishBankHolidayWeek();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Date")]
        public void IsJubileeSundayAHoliday()
        {
            var testDate = new DateTime(2012,
                6,
                3, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Date")]
        public void IsJubileeSundayAHolidayWeek()
        {
            var testDate = new DateTime(2012,
                6,
                3, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsEnglishBankHolidayWeek();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Date")]
        public void IsJubileeWednesdayAHoliday()
        {
            var testDate = new DateTime(2012,
                6,
                6, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Date")]
        public void IsJubileeWednesdayAHolidayWeek()
        {
            var testDate = new DateTime(2012,
                6,
                6, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsEnglishBankHolidayWeek();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHoliday_WhenDateIsBankHoliday_ReturnsTrue()
        {
            // Arrange
            var bankHoliday = new DateTime(2012, 6, 4, 0, 0, 0, DateTimeKind.Utc);

            // Act
            var actual = bankHoliday.IsUkBankHoliday();

            // Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHoliday_WhenDateIsNotBankHoliday_ReturnsFalse()
        {
            // Arrange
            var nonBankHoliday = new DateTime(2012, 5, 28, 0, 0, 0, DateTimeKind.Utc);

            // Act
            var actual = nonBankHoliday.IsUkBankHoliday();

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHoliday_WhenDateIsExceptionalCase_ReturnsFalse()
        {
            // Arrange
            var exceptionalCase = new DateTime(2020, 5, 4, 0, 0, 0, DateTimeKind.Utc);

            // Act
            var actual = exceptionalCase.IsUkBankHoliday();

            // Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHoliday_WhenDateIsEaster_ReturnsTrue()
        {
            // Arrange
            var easterSunday = new DateTime(2020, 4, 12, 0, 0, 0, DateTimeKind.Utc);
            var goodFriday = easterSunday.AddDays(-2);
            var easterMonday = easterSunday.AddDays(1);

            // Act
            var actualGoodFriday = goodFriday.IsUkBankHoliday();
            var actualEasterMonday = easterMonday.IsUkBankHoliday();

            // Assert
            Assert.That(actualGoodFriday, Is.True);
            Assert.That(actualEasterMonday, Is.True);
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayBDayFriday()
        {
            var testDate = new DateTime(2008,
                12,
                26, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayBDaySaturday()
        {
            var testDate = new DateTime(2009,
                12,
                26, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayBDaySunday()
        {
            var testDate = new DateTime(2010,
                12,
                26, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayBdayThursday()
        {
            var testDate = new DateTime(2013,
                12,
                26, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayBDayTuesday()
        {
            var testDate = new DateTime(2006,
                12,
                26, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayBDayWednesday()
        {
            var testDate = new DateTime(2007,
                12,
                26, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayEasterMonday()
        {
            var testDate = new DateTime(2013,
                4,
                1, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayFirstMondayInMay()
        {
            var testDate = new DateTime(2013,
                5,
                6, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayFirstMondayNonMay()
        {
            var testDate = new DateTime(2013,
                10,
                1, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayFriday()
        {
            var testDate = new DateTime(2013,
                3,
                8, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayGoodFriday()
        {
            var testDate = new DateTime(2013,
                3,
                29, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayJanOne()
        {
            var testDate = new DateTime(2013,
                1,
                1, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayJanOneSaturday()
        {
            var testDate = new DateTime(2011,
                1,
                1, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayJanOneSaturdayMonday()
        {
            var testDate = new DateTime(2011,
                1,
                3, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayJanOneSaturdaySunday()
        {
            var testDate = new DateTime(2011,
                1,
                2, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayJanOneSunday()
        {
            var testDate = new DateTime(2012,
                1,
                1, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayLastMondayInMay()
        {
            var testDate = new DateTime(2013,
                5,
                27, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayLastMondayNonMay()
        {
            var testDate = new DateTime(2013,
                10,
                29, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayMonday()
        {
            var testDate = new DateTime(2013,
                3,
                4, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Date")]
        [Category("UK Bank Holiday")]
        public void IsUkBankHolidaySaturday()
        {
            var testDate = new DateTime(2013,
                3,
                9, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidaySecondMondayInMay()
        {
            var testDate = new DateTime(2013,
                5,
                13, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidaySecondMondayNonMay()
        {
            var testDate = new DateTime(2013,
                10,
                8, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Date")]
        [Category("UK Bank Holiday")]
        public void IsUkBankHolidaySunday()
        {
            //Test will return false as Bank Holiday is
            var testDate = new DateTime(2013,
                3,
                10, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayThursday()
        {
            var testDate = new DateTime(2013,
                3,
                7, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayTuesday()
        {
            var testDate = new DateTime(2013,
                3,
                5, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayWednesday()
        {
            var testDate = new DateTime(2013,
                3,
                6, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayXmasFriday()
        {
            var testDate = new DateTime(2009,
                12,
                25, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayXmasMonday()
        {
            var testDate = new DateTime(2006,
                12,
                25, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayXmasSaturday()
        {
            var testDate = new DateTime(2010,
                12,
                25, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayXmasSunday()
        {
            var testDate = new DateTime(2011,
                12,
                25, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayXmasThursday()
        {
            var testDate = new DateTime(2008,
                12,
                25, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayXmasTuesday()
        {
            var testDate = new DateTime(2012,
                12,
                25, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("UK Bank Holiday")]
        [Category("Date")]
        public void IsUkBankHolidayXmasWednesday()
        {
            var testDate = new DateTime(2013,
                12,
                25, 0, 0, 0, DateTimeKind.Utc);
            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///     Check next monday function
        /// </summary>
        /// <remarks>
        ///     It should be
        ///     1. a monday
        ///     2. after start date
        ///     3. no more than 7 days after start date
        /// </remarks>
        [Test]
        public void NextMondayIsAMonday()
        {
            var testDate = new DateTime(2016,
                1,
                1, 0, 0, 0, DateTimeKind.Utc);

            var nextMon = testDate.NextMonday();

            var diff = nextMon - testDate;

            Assert.That(nextMon.DayOfWeek,
                Is.EqualTo(DayOfWeek.Monday));
            Assert.That(nextMon,
                Is.GreaterThan(testDate));
            Assert.That(diff.Days,
                Is.LessThanOrEqualTo(7));
            Assert.That(diff.Days,
                Is.GreaterThan(0));
        }

        /// <summary>
        ///     The non numeric input returns false.
        /// </summary>
        /// <param name="date">
        ///     The date.
        /// </param>
        [Test]
        [Sequential]
        public void NonNumericInputReturnsFalse([Values(" ",
                        "        ",
                        "steve",
                        "SteveSteve",
                        "Steve Fred Joe Noddy",
                        " _ ",
                        "$%^&*",
                        "One",
                        "1/1/1/1/1",
                        "2nd Feb",
                        "0.1",
                        "0.0.0",
                        "1234456")]
                    string date)
        {
            var input = date;

            var actual = input.IsDate();

            Assert.That(actual,
                Is.False);
        }

        /// <summary>
        ///     The sensible dates return true.
        /// </summary>
        /// <param name="date">
        ///     The date.
        /// </param>
        [Test]
        [Sequential]
        public void SensibleDatesReturnTrue([Values("31/12/2016",
                        "31.12.2016",
                        "31-12-2016",
                        "2016-12-31",
                        "1 Feb, 2016")]
                    string date)
        {
            var input = date;

            var actual = input.IsDate();

            Assert.That(actual,
                Is.True);
        }

        [Test]
        public void Summer_dates_are_in_UK_DST([Values("30/06/2016",
                        "1499040000")]
                    string dateString)
        {
            var dateTime = dateString.ToDateTime();
            if (dateTime.HasValue)
            {
                var actual = dateTime.Value.IsInDaylightSavingsTimeUk();
                Assert.IsTrue(actual);
            }
            else
            {
                Assert.Fail("The provided date string could not be converted to a DateTime object.");
            }
        }

        [Test]
        public void ToDate_Returns_ExpectedValue([Values("31/12/2016",
                        "1483142400", "1483142400.00")]
                    string date)
        {
            var expected = new DateTime(2016, 12, 31, 0, 0, 0, DateTimeKind.Utc);
            var input = date;
            var actual = input.ToDateTime();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Valid_IsAnyDate_ReturnsTrue([Values("31/12/2016",
                        "31.10.2016",
                        "2345.5.5", "1555334468")]
                    string date)
        {
            var input = date;
            var actual = input.IsAnyDate();
            Assert.That(actual, Is.True);
        }

        [Test]
        [Category("Date")]
        public void VeDayMove_MovedBankHoliday_IsBankHoliday()
        {
            var testDate = new DateTime(2020, 5, 8, 0, 0, 0, DateTimeKind.Utc);

            const bool expected = true;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Sequential]
        [Category("Date")]
        public void VeDayMove_MovedBankHoliday_IsBankHolidayWeek(
            [Values(4, 5, 6, 7, 8)] int dow)
        {
            var testDate = new DateTime(2020, 5, dow, 0, 0, 0, DateTimeKind.Utc);

            const bool expected = true;
            var actual = testDate.IsEnglishBankHolidayWeek();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Category("Date")]
        public void VeDayMove_OriginalBankHoliday_IsNotBankHoliday()
        {
            var testDate = new DateTime(2020, 5, 4, 0, 0, 0, DateTimeKind.Utc);

            const bool expected = false;
            var actual = testDate.IsUkBankHoliday();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Winter_dates_are_not_in_UK_DST([Values("31/12/2016",
                        "1548787800")]
                    string date)
        {
            var dateTime = date.ToDateTime();
            if (dateTime.HasValue)
            {
                var actual = dateTime.Value.IsInDaylightSavingsTimeUk();
                Assert.IsFalse(actual);
            }
            else
            {
                Assert.Fail("The provided date string could not be converted to a DateTime object.");
            }
        }
          
        [Test]
        public void AddUkWorkingDays_ShouldAddPositiveWorkingDays()
        {
            // Arrange
            var date = new DateTime(2022, 1, 3, 0, 0, 0, DateTimeKind.Utc); // Monday
            var days = 5;

            // Act
            var actual = date.AddUkWorkingDays(days);

            // Assert
            Assert.That(actual, Is.EqualTo(new DateTime(2022, 1, 10, 0, 0, 0, DateTimeKind.Utc)));
        }

        [Test]
        public void AddUkWorkingDays_ShouldSubtractNegativeWorkingDays()
        {
            // Arrange
            var date = new DateTime(2022, 1, 10, 0, 0, 0, DateTimeKind.Utc); // Monday
            var days = -5;

            // Act
            var actual = date.AddUkWorkingDays(days);

            // Assert
            Assert.That(actual, Is.EqualTo(new DateTime(2021, 12, 31, 0, 0, 0, DateTimeKind.Utc)));
        }

        [Test]
        public void AddUkWorkingDays_ShouldHandleZeroDays()
        {
            // Arrange
            var date = new DateTime(2022, 1, 3, 0, 0, 0, DateTimeKind.Utc); // Monday
            var days = 0;

            // Act
            var actual = date.AddUkWorkingDays(days);

            // Assert
            Assert.That(actual, Is.EqualTo(new DateTime(2022, 1, 3, 0, 0, 0, DateTimeKind.Utc)));
        }

        [Test]
        public void AddUkWorkingDays_ShouldHandleWeekendDays()
        {
            // Arrange
            var date = new DateTime(2022, 1, 7, 0, 0, 0, DateTimeKind.Utc); // Saturday
            var days = 2;

            // Act
            var actual = date.AddUkWorkingDays(days);

            // Assert
            Assert.That(actual, Is.EqualTo(new DateTime(2022, 1, 11, 0, 0, 0, DateTimeKind.Utc)));
        }

        [Test]
        public void AddUkWorkingDays_ShouldHandleNegativeWeekendDays()
        {
            // Arrange
            var date = new DateTime(2022, 1, 11, 0, 0, 0, DateTimeKind.Utc); // Tuesday
            var days = -2;

            // Act
            var actual = date.AddUkWorkingDays(days);

            // Assert
            Assert.That(actual, Is.EqualTo(new DateTime(2022, 1, 7, 0, 0, 0, DateTimeKind.Utc)));
        }

        [Test]
        public void AddUkWorkingDays_ShouldHandleNegativeDaysExceedingWeekend()
        {
            // Arrange
            var date = new DateTime(2022, 1, 11, 0, 0, 0, DateTimeKind.Utc); // Tuesday
            var days = -5;

            // Act
            var actual = date.AddUkWorkingDays(days);

            // Assert
            Assert.That(actual, Is.EqualTo(new DateTime(2022, 1, 4, 0, 0, 0, DateTimeKind.Utc)));
        }

        [Test]
        public void AddUkWorkingDays_ShouldHandlePositiveDaysExceedingWeekend()
        {
            // Arrange
            var date = new DateTime(2022, 1, 7, 0, 0, 0, DateTimeKind.Utc); // Saturday
            var days = 5;

            // Act
            var actual = date.AddUkWorkingDays(days);

            // Assert
            Assert.That(actual, Is.EqualTo(new DateTime(2022, 1, 14, 0, 0, 0, DateTimeKind.Utc)));
        }

        [Test]
        public void AddUkWorkingDays_ShouldHandleNegativeDaysExceedingMultipleWeekends()
        {
            // Arrange
            var date = new DateTime(2022, 1, 11, 0, 0, 0, DateTimeKind.Utc); // Tuesday
            var days = -12;

            // Act
            var actual = date.AddUkWorkingDays(days);

            // Assert
            Assert.That(actual, Is.EqualTo(new DateTime(2021, 12, 21, 0, 0, 0, DateTimeKind.Utc)));
        }

        [Test]
        public void AddUkWorkingDays_ShouldHandlePositiveDaysExceedingMultipleWeekends()
        {
            // Arrange
            var date = new DateTime(2021, 12, 24, 0, 0, 0, DateTimeKind.Utc); // Friday
            var days = 12;

            // Act
            var actual = date.AddUkWorkingDays(days);

            // Assert
            Assert.That(actual, Is.EqualTo(new DateTime(2022, 1, 14, 0, 0, 0, DateTimeKind.Utc)));
        }
    }
}
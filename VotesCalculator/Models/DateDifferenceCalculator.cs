﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotesCalculator.Models
{
    /*
     * Class handles calculation of difference between dates taking into account leap years
     */
    public class DateDifferenceCalculator
    {

        //Source: http://nice-tutorials.blogspot.com/2011/02/calculate-number-of-years-months-and.html

        /// <summary>
        /// defining Number of days in month; index 0 represents january and 11 represents December
        /// february contain either 28 or 29 days, so here its value is -1
        /// which will be calculate later.
        /// </summary>

        private int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        /// <summary>
        /// contain from date
        /// </summary>

        private DateTime fromDate;

        /// <summary>
        /// contain To Date
        /// </summary>

        private DateTime toDate;

        /// <summary>
        /// these three variable of integer type for output representation..
        /// </summary>

        private int year;
        private int month;
        private int day;

        //Public type Constructor

        public DateDifferenceCalculator(DateTime d1, DateTime d2)
        { 
            int increment;

            //To Date must be greater
            if (d1 > d2)
            {
                this.fromDate = d2;
                this.toDate = d1;
            }
            else
            {
                this.fromDate = d1;
                this.toDate = d2;
            }

            ///
            /// Day Calculation
            ///

            increment = 0;

            if (this.fromDate.Day > this.toDate.Day)
            { 
                increment = this.monthDay[this.fromDate.Month - 1];
            }

            /// if it is february month
            /// if it's to day is less then from day

            if (increment == -1)
            { 
                if (DateTime.IsLeapYear(this.fromDate.Year))
                {
                    // leap year february contain 29 days
                    increment = 29;
                }
                else
                {
                    increment = 28;
                }
            }

            if (increment != 0)
            {
                day = (this.toDate.Day + increment) - this.fromDate.Day;
                increment = 1;
            }

            else
            {
                day = this.toDate.Day - this.fromDate.Day;
            }

            ///
            ///month calculation
            ///

            if ((this.fromDate.Month + increment) > this.toDate.Month)
            {
                this.month = (this.toDate.Month + 12) - (this.fromDate.Month + increment);
                increment = 1;
            }
            else
            {
                this.month = (this.toDate.Month) - (this.fromDate.Month + increment);
                increment = 0;
            }

            ///
            /// year calculation
            ///

            this.year = this.toDate.Year - (this.fromDate.Year + increment);
        }

        public override string ToString()
        {
            //return base.ToString();
            return this.year + " Year(s), " + this.month + " month(s), " + this.day + " day(s)";
        }

        public int Years
        {
            get
            {
                return this.year;
            }
        }

        public int Months
        {
            get
            {
                return this.month;
            }

        }

        public int Days
        {
            get
            {
                return this.day;
            }
        }
    }
}

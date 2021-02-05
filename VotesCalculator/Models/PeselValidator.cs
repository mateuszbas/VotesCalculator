using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace VotesCalculator.Models
{
    /*
     * Class handles validation of personal id number by checking length, digits and calculating checksum
     */
    class PESELValidator
    {

        //Source: https://github.com/piter0/PESEL-Validator

        //Checks if personal id has 11 digits
        public static bool CheckPESELLength(string PESELNumber)
        {
            if (PESELNumber.Length != 11)
            {
                return false;
            }

            return true;
        }

        //Checks if personal id number is digits only
        public static bool CheckIfPESELContainsDigitsOnly(string PESELNumber)
        {
            foreach (var c in PESELNumber.Select(d => !Char.IsDigit(d)))
            {
                if (c)
                {
                    return false;
                }
            }

            return true;
        }

        //Computes year of given personal id number based on the month and year digits
        public static int ComputePESELYear(int PESEL2DigitsYear, int PESELMonth)
        {
            if (PESELMonth > 0 && PESELMonth < 13)
            {
                return 1900 + PESEL2DigitsYear;
            }

            if (PESELMonth > 20 && PESELMonth < 33)
            {
                return 2000 + PESEL2DigitsYear;
            }

            if (PESELMonth > 40 && PESELMonth < 53)
            {
                return 2100 + PESEL2DigitsYear;
            }

            if (PESELMonth > 60 && PESELMonth < 73)
            {
                return 2200 + PESEL2DigitsYear;
            }

            return 1800 + PESEL2DigitsYear;
        }

        //Checks if month is correct
        public static bool CheckIfMonthIsCorrect(int PESELMonth)
        {
            //Is dividable by 20
            if (PESELMonth % 20 == 0)
            {
                return false;
            }

            for (int i = 0; i <= 80; i += 20)
            {
                for (int j = 13 + i; j <= 19 + i; j++)
                {
                    if (PESELMonth == j)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //Checks if day is correct
        public static bool CheckIfDayIsCorrect(int PESELDay, int PESELMonth, int PESELYear)
        {
            if (PESELDay == 0 || PESELDay > 31)
            {
                return false;
            }

            for (int i = 0; i <= 80; i += 20)
            {
                for (int j = 1 + i; j <= 7 + i ? j <= 7 + i : j <= 12 + i; j += 2)
                {
                    if (PESELMonth == j && PESELDay > 31)
                    {
                        return false;
                    }
                }

                for (int j = 4 + i; j <= 6 + i; j += 2)
                {
                    if (PESELMonth == j && PESELDay > 30)
                    {
                        return false;
                    }
                }

                for (int j = 9 + i; j <= 11 + i; j += 2)
                {
                    if (PESELMonth == j && PESELDay > 30)
                    {
                        return false;
                    }
                }
            }

            if (PESELYear == 2000 || (PESELYear % 4 == 0 && PESELYear % 100 != 0))
            {
                if (PESELMonth % 20 == 2 && PESELDay > 29)
                {
                    return false;
                }
            }
            else
            {
                if (PESELMonth % 20 == 2 && PESELDay > 28)
                {
                    return false;
                }
            }

            return true;
        }

        //Calculates personal id number checksum
        public static int ComputePESELChecksum(List<int> PESELList)
        {
            int sum = PESELList[0] * 9 + PESELList[1] * 7 + PESELList[2] * 3 + PESELList[3] * 1 + PESELList[4] * 9 +
                      PESELList[5] * 7 + PESELList[6] * 3 + PESELList[7] * 1 + PESELList[8] * 9 + PESELList[9] * 7;

            return sum % 10;
        }

        //Checks if personal id number belongs to underaged person
        public static bool IsUnderaged(string pesel)
        {
            int PESELMonth;
            int PESELDay;
            int PESELYear;

            PESELMonth = Int32.Parse(pesel.Substring(2, 2));
            PESELDay = Int32.Parse(pesel.Substring(4, 2));
            PESELYear = ComputePESELYear(Int32.Parse(pesel.Substring(0, 2)), PESELMonth);

            DateTime peselDate = new DateTime(PESELYear, GetMonth(PESELMonth), PESELDay);
            DateTime todayDate = DateTime.Now.Date;

            DateDifferenceCalculator dateDifferenceCalculator = new DateDifferenceCalculator(peselDate, todayDate);
            if (dateDifferenceCalculator.Years < 18)
                return true;

            return false;
        }

        //Checks if personal id number is disallowed to vote
        public static bool IsBlacklisted(string pesel)
        {
            //Connection and downloading disallowed personal id from server
            XmlWebClientConnection xmlWebClient = new XmlWebClientConnection();
            string doc = xmlWebClient.GetXmlData(@"http://webtask.future-processing.com:8069/blocked");
            XDocument xdoc = XDocument.Parse(doc);

            //Searching for "pesel" markup
            List<string> list = xdoc.Root.Descendants("pesel")
                               .Select(x => x.Value)
                               .ToList();

            //Checking if personal id is on blacklist
            foreach (string element in list)
                if (element == pesel)
                    return true;

            return false;
        }

        public static string ConvertMonthToString(int PESELMonth)
        {
            switch (PESELMonth)
            {
                case 1:
                case 21:
                case 41:
                case 61:
                case 81:
                    return "stycznia";

                case 2:
                case 22:
                case 42:
                case 62:
                case 82:
                    return "lutego";

                case 3:
                case 23:
                case 43:
                case 63:
                case 83:
                    return "marca";

                case 4:
                case 24:
                case 44:
                case 64:
                case 84:
                    return "kwietnia";

                case 5:
                case 25:
                case 45:
                case 65:
                case 85:
                    return "maja";

                case 6:
                case 26:
                case 46:
                case 66:
                case 86:
                    return "czerwca";

                case 7:
                case 27:
                case 47:
                case 67:
                case 87:
                    return "lipca";

                case 8:
                case 28:
                case 48:
                case 68:
                case 88:
                    return "sierpnia";

                case 9:
                case 29:
                case 49:
                case 69:
                case 89:
                    return "wrzeœnia";

                case 10:
                case 30:
                case 50:
                case 70:
                case 90:
                    return "paŸdziernika";

                case 11:
                case 31:
                case 51:
                case 71:
                case 91:
                    return "listopada";

                default:
                    return "grudnia";
            }
        }

        public static int GetMonth(int month)
        {
            switch (month)
            {
                case 1:
                case 21:
                case 41:
                case 61:
                case 81:
                    return 1;

                case 2:
                case 22:
                case 42:
                case 62:
                case 82:
                    return 2;

                case 3:
                case 23:
                case 43:
                case 63:
                case 83:
                    return 3;

                case 4:
                case 24:
                case 44:
                case 64:
                case 84:
                    return 4;

                case 5:
                case 25:
                case 45:
                case 65:
                case 85:
                    return 5;

                case 6:
                case 26:
                case 46:
                case 66:
                case 86:
                    return 6;

                case 7:
                case 27:
                case 47:
                case 67:
                case 87:
                    return 7;

                case 8:
                case 28:
                case 48:
                case 68:
                case 88:
                    return 8;

                case 9:
                case 29:
                case 49:
                case 69:
                case 89:
                    return 9;

                case 10:
                case 30:
                case 50:
                case 70:
                case 90:
                    return 10;

                case 11:
                case 31:
                case 51:
                case 71:
                case 91:
                    return 11;

                default:
                    return 12;
            }
        }

        //Checks overall validty of personal id number
        public static bool PESEL(string PESELReadLine)
        {
            List<int> PESELList;
            int PESELMonth;
            string PESELMonthToString;
            int PESELDay;
            int PESELYear;
            int PESELChecksum;

            if (!CheckPESELLength(PESELReadLine) || !CheckIfPESELContainsDigitsOnly(PESELReadLine))
            {
                return true;
            }

            PESELList = PESELReadLine.ToCharArray().Select(n => (int)char.GetNumericValue(n)).ToList();
            PESELMonth = Int32.Parse(PESELReadLine.Substring(2, 2));
            PESELMonthToString = ConvertMonthToString(PESELMonth);
            PESELDay = Int32.Parse(PESELReadLine.Substring(4, 2));
            PESELYear = ComputePESELYear(Int32.Parse(PESELReadLine.Substring(0, 2)), PESELMonth);
            PESELChecksum = Int32.Parse(PESELReadLine.Substring(10, 1));

            if (!CheckIfMonthIsCorrect(PESELMonth))
            {
                return true;
            }

            if (!CheckIfDayIsCorrect(PESELDay, PESELMonth, PESELYear))
            {
                return true;
            }

            if (!PESELChecksum.Equals(ComputePESELChecksum(PESELList)))
            {
                return true;
            }


            return false;

        }
    }
}



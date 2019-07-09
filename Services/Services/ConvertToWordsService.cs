using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Services
{
    public class ConvertToWordsService : IConvertToWords
    {
        public string CheckNumber(string num)
        {
            string number = Convert.ToDouble(num).ToString();
            string isNegative = "";
            if (number.Contains("-"))
            {
                isNegative = "MINUS ";
                number = number.Substring(1, number.Length - 1);
            }
            if (number == "0")
                return "ZERO DOLLARS";
            else
                return isNegative + ConvertToWords(number);
        }

        public string ConvertToWords(string num)
        {
            String val = "", wholeNo = num, points = "", andStr = "DOLLARS", pointStr = "";
            String endStr = "";
            try
            {
                int decimalPlace = num.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = num.Substring(0, decimalPlace);
                    points = num.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "DOLLARS AND";// just to separate whole numers from points/cents   
                        endStr = "CENTS";//Cents   
                        pointStr = ConvertNum.ConvertDecimals(points).ToUpper();
                    }
                }
                val = String.Format("{0} {1}{2} {3}", ConvertNum.ConvertWholeNumber(wholeNo).Trim().ToUpper(), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }
    }
}
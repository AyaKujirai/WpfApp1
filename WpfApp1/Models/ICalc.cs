namespace WpfApp1.Models
{
    using System.Globalization;

    public interface ICalc
    {
        string Add(string x, string y, string answer);
    }

    public class Calc : ICalc
    {
        public string Add(string stringX, string stringY, string answer)
        {
            if (double.TryParse(stringX, out double x) && double.TryParse(stringY, out double y))
            {
                answer = (x + y).ToString(CultureInfo.CurrentCulture);
                return (x + y).ToString(CultureInfo.CurrentCulture);
            }

            answer = string.Empty;
            return string.Empty;
        }
    }
}

namespace WpfApp1.Models
{
    using System.Globalization;

    public interface ICalc
    {
        string Add(string x, string y);
    }

    public class Calc : ICalc
    {
        public string Add(string stringX, string stringY)
        {
            if (double.TryParse(stringX, out double x) && double.TryParse(stringY, out double y))
            {
                return (x + y).ToString(CultureInfo.CurrentCulture);
            }

            return string.Empty;
        }
    }
}

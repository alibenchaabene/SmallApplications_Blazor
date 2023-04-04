using MudBlazor;
using SmallApplications_Blazor.Helpers;
using SmallApplications_Blazor.Models;
using System.Globalization;

namespace SmallApplications_Blazor.ViewModels.Beginner
{
	public class DollarToCentConverterViewModel
	{

		public string? DollarValue { get; set; }

		public int Cents { get; set; }
		public string? ReturnMessage { get; set; }
		public bool HasError => !string.IsNullOrEmpty(ReturnMessage);

		public IList<CoinResult> CoinResults { get; private set; } = new List<CoinResult>();

		public void Convert()
		{
			try
			{
				ReturnMessage = string.Empty;
				if (string.IsNullOrEmpty(DollarValue)) throw new FormatException();
				Cents = CalculateCents(DollarValue);
				CoinResults = CoinCalculator.CalculateCoinBreakdown(Cents);
			}
			catch
			{
				ReturnMessage = "The dollar value must be a valid number between 0.00 and 1000.00.";
				CoinResults.Clear();
			}
		}

		public void Reset()
		{
			DollarValue = string.Empty;
			ReturnMessage = string.Empty;
			Cents = 0;
			CoinResults.Clear();
		}
		private static int CalculateCents(string dollarValue)
		{
			decimal dollar = System.Convert.ToDecimal(dollarValue, CultureInfo.InvariantCulture);
			if (dollar < 0.0M || dollar > 1000.0M)
				throw new NotSupportedException();

			return (int)Math.Round(dollar * 100);
		}
	}
}

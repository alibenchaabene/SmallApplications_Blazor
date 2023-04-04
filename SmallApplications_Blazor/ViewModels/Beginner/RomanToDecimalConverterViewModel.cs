using MudBlazor;
using SmallApplications_Blazor.Models;

namespace SmallApplications_Blazor.ViewModels.Beginner
{
	public class RomanToDecimalConverterViewModel
	{

		public string? Roman { get; set; }
		public string? Decimal { get; set; }
		public string? ReturnMessage { get; private set; }
		public bool HasError => !string.IsNullOrEmpty(ReturnMessage);
		public void ConvertRoman()
		{
			try
			{
				ReturnMessage=string.Empty;
				if (string.IsNullOrEmpty(Decimal)) throw new FormatException();
				var number = Convert.ToInt32(Decimal);
				Roman = RomanNumeral.FromDecimal(number).Value;
			}
			catch
			{
				ReturnMessage="Decimal must be a valid number with only digits 0-9.";
			}
		}

		public void ConvertDecimal()
		{
			try
			{
				ReturnMessage = string.Empty;
				if (string.IsNullOrEmpty(Roman)) throw new FormatException();
				Decimal = new RomanNumeral(Roman).ToInt().ToString();
			}
			catch
			{
				ReturnMessage = "Roman numerals only support the following characters: I, V, X, L, C, D, M.";
			}
		}
		public void Reset()
		{
			Decimal = string.Empty;
			Roman = string.Empty;
			ReturnMessage=string.Empty;
		}
	}
}

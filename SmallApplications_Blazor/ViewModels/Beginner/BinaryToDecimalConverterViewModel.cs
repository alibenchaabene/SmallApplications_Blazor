using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace SmallApplications_Blazor.ViewModels.Beginner
{
	public class BinaryToDecimalConverterViewModel
	{
		[Inject]
		private ISnackbar Snackbar { get; set; } = default!;
		public string? Binary { get; set; }
		public string? Decimal { get; set; }
		public string? ReturnMessage { get; private set; }
		public bool HasError => !string.IsNullOrEmpty(ReturnMessage);

		public void ConvertDecimal()
		{
			try
			{
				ReturnMessage=string.Empty;
				if (string.IsNullOrEmpty(Binary)) throw new FormatException();
				Decimal = Convert.ToInt32(Binary, 2).ToString();
			}
			catch
			{
				ReturnMessage = "Binary must be a valid number with only 0s and 1s.";
			}
		}

		public void ConvertBinary()
		{
			try
			{
				ReturnMessage = string.Empty;
				if (string.IsNullOrEmpty(Decimal)) throw new FormatException();
				int number = Convert.ToInt32(Decimal);
				Binary = Convert.ToString(number, 2);
			}
			catch
			{
				ReturnMessage = "Decimal must be a valid number with only digits 0-9.";
			}
		}
		public void Reset()
		{
			Decimal = string.Empty;
			Binary = string.Empty;
			ReturnMessage=string.Empty;
		}

	}
}

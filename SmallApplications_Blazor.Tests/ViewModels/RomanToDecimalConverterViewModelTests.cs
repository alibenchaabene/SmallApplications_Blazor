using SmallApplications_Blazor.Pages.Beginner;
using SmallApplications_Blazor.ViewModels.Beginner;
using Xunit;

namespace SmallApplications_Blazor.Tests.ViewModels
{
	public class RomanToDecimalConverterViewModelTests
	{
		private const string romanErrorMessage = "Roman numerals only support the following characters: I, V, X, L, C, D, M.";
		private const string decimalErrorMessage = "Decimal must be a valid number with only digits 0-9.";

		[Fact]
		public void Construction()
		{
			// arrange

			// act
			var vm = new RomanToDecimalConverterViewModel();

			// assert
			Assert.NotNull(vm);
			Assert.Null(vm.Roman);
			Assert.Null(vm.Decimal);
			Assert.Null(vm.ReturnMessage);
		}

		[Theory]
		[InlineData("V", "5", "")]
		[InlineData("CCXVIII", "218", "")]
		[InlineData(null, null, romanErrorMessage)]
		[InlineData("CCQVI", null, romanErrorMessage)]
		public void ConvertDecimal_WithRomanString(
			string initialRoman, string expectedDecimal, string expectedErrorMessage)
		{
			// arrange
			var vm = new RomanToDecimalConverterViewModel
			{
				Roman = initialRoman
			};

			// act
			vm.ConvertDecimal();

			// assert
			Assert.Equal(expectedDecimal, vm.Decimal);
			Assert.Equal(expectedErrorMessage, vm.ReturnMessage);
		}

		[Theory]
		[InlineData("5", "V", "")]
		[InlineData("186", "CLXXXVI", "")]
		[InlineData("", null, decimalErrorMessage)]
		[InlineData("102l", null, decimalErrorMessage)]
		public void ConvertBinary_WithDecimalString(
			string initialDecimal, string expectedRoman, string expectedErrorMessage)
		{
			// arrange
			var vm = new RomanToDecimalConverterViewModel
			{
				Decimal = initialDecimal
			};

			// act
			vm.ConvertRoman();

			// assert
			Assert.Equal(expectedRoman, vm.Roman);
			Assert.Equal(expectedErrorMessage, vm.ReturnMessage);
		}
	}
}
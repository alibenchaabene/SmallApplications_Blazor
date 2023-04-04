using SmallApplications_Blazor.Pages.Beginner;
using SmallApplications_Blazor.ViewModels.Beginner;
using Xunit;

namespace SmallApplications_Blazor.Tests.ViewModels
{
	public class BinaryToDecimalConverterViewModelTests
	{
		private const string binaryErrorMessage = "Binary must be a valid number with only 0s and 1s.";
		private const string decimalErrorMessage = "Decimal must be a valid number with only digits 0-9.";

		[Fact]
		public void Construction()
		{
			// arrange

			// act
			var vm = new BinaryToDecimalConverterViewModel();

			// assert
			Assert.NotNull(vm);
			Assert.Null(vm.Binary);
			Assert.Null(vm.Decimal);
			Assert.Null(vm.ReturnMessage);
		}

		[Theory]
		[InlineData("101", "5", "")]
		[InlineData("11011010", "218", "")]
		[InlineData("", null, binaryErrorMessage)]
		[InlineData("102", null, binaryErrorMessage)]
		public void ConvertDecimal_WithBinaryString(
			string initialBinary, string expectedDecimal, string expectedErrorMessage)
		{
			// arrange
			var vm = new BinaryToDecimalConverterViewModel
			{
				Binary = initialBinary
			};

			// act
			vm.ConvertDecimal();

			// assert
			Assert.Equal(expectedDecimal, vm.Decimal);
			Assert.Equal(expectedErrorMessage, vm.ReturnMessage);
		}

		[Theory]
		[InlineData("5", "101", "")]
		[InlineData("186", "10111010", "")]
		[InlineData("", null, decimalErrorMessage)]
		[InlineData("102l", null, decimalErrorMessage)]
		public void ConvertBinary_WithDecimalString(
			string initialDecimal, string expectedBinary, string expectedErrorMessage)
		{
			// arrange
			var vm = new BinaryToDecimalConverterViewModel
			{
				Decimal = initialDecimal
			};

			// act
			vm.ConvertBinary();

			// assert
			Assert.Equal(expectedBinary, vm.Binary);
			Assert.Equal(expectedErrorMessage, vm.ReturnMessage);
		}
	}
}

using SmallApplications_Blazor.ViewModels.Beginner;
using System.Text;
using Xunit;

namespace SmallApplications_Blazor.Tests.ViewModels
{
	public class DollarToCentConverterViewModelTests
	{
		private const string dollarErrorMessage = "The dollar value must be a valid number between 0.00 and 1000.00.";

		[Fact]
		public void Construction()
		{
			// arrange

			// act
			var vm = new DollarToCentConverterViewModel();

			// assert
			Assert.NotNull(vm);
			Assert.Null(vm.DollarValue);
			Assert.Equal(0, vm.Cents);
			Assert.Empty(vm.CoinResults);
			Assert.Null(vm.ReturnMessage);
			Assert.False(vm.HasError);
		}

		[Theory]
		[InlineData("0.41", 41, "", false)]
		[InlineData("1.49", 149, "", false)]
		[InlineData("", 0, dollarErrorMessage, true)]
		[InlineData("1.e4", 0, dollarErrorMessage, true)]
		[InlineData("-3.89", 0, dollarErrorMessage, true)]
		public void Convert_WithDollarValue(string initialDollar, int expectedCents, string expectedErrorMessage, bool expectedHasError)
		{
			// arrange
			var vm = new DollarToCentConverterViewModel
			{
				DollarValue = initialDollar
			};

			// act
			vm.Convert();

			// assert
			Assert.Equal(expectedCents, vm.Cents);
			Assert.Equal(expectedErrorMessage, vm.ReturnMessage);
			Assert.Equal(expectedHasError, vm.HasError);
		}
	}
}

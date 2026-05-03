namespace TaxCalculator.Test;

[TestClass]
public class IncomeTaxCalculatorTests
{
    MSTesting.TaxCalculator? calculator;
    const int VALUE_LESS_THAN_ZERO=-1;
    [TestInitialize]
    public void Setup()
    {
        calculator = new MSTesting.TaxCalculator();
    }

   private static IEnumerable<object[]> RegularTestData
	{get
        {
            return new[]
            {
                new object[] {25000m, 1088m},
                new object[] {50000m, 5788m},
                new object[] {60000m, 8788.00m},
                new object[] {100000m, 20788.00m},
                new object[] {150000m, 36838.00m},
                new object[] {220000m, 65138.00m},
                new object[] {500000m, 191138.00m}
            };
        }
}

 private static IEnumerable<object[]> EdgeCaseTestData
	{get
        {
            return new[]
            {
                new object[] {45000m, 4288m},
                new object[] {45002.51m, 4289m},
               
            };
        }
}
    [TestMethod]
    [DynamicData("EdgeCaseTestData")]
    public void Income_EdgeCases_ExpectedTax(decimal income, decimal expectedTax)
    {
        calculator.Income = income;
        decimal actualTax = calculator.IncomeTax();
        Assert.AreEqual(expectedTax, actualTax);
    }
    

    [TestMethod]
    [DynamicData("RegularTestData")]
    public void Income_RegularCases_ExpectedTax(decimal income, decimal expectedTax)
    {
        calculator.Income = income;
        decimal actualTax = calculator.IncomeTax();
        Assert.AreEqual(expectedTax, actualTax);
    }


    [TestMethod]
     public void IncomeTax_EnterValueLessThanZero_ArgumentException()
    {
        calculator.Income = VALUE_LESS_THAN_ZERO;
        
        Assert.ThrowsExactly<ArgumentException>(() => calculator.IncomeTax());
    }
  
}
  

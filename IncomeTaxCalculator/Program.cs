using MSTesting;

namespace MSTest_IncomeTax;

class Program
{
    const string ARGUMENT_EXCEPTION_NARRATION = "Not a valid input - Please enter a number\n";
    const string FORMAT_EXCEPTION_NARRATION = "Please enter a number\n";
   const string PROMPT="\n****************************************************\nEnter Income to calculate tax - ";
    const string INVALID_NUMERIC_EXCEPTION = "Invalid input - enter a decimal value\n";
    const string RERUN_TAX="Run again (Y or any key to exit) - ";
    const string TAX_OUTPUT="The tax payable on income of ${0} is ${1}\n****************************************************\n\n";
    static void Main(string[] args)
    {
        Program pg = new Program();
        pg.Run();     
        
    }

    private void Run()
    {
        bool keepRunning = true;
        while (keepRunning) {
            decimal income=0m;
            bool error = false;
            try { 
                income = GetIncome();
            } catch (ArgumentException)
            {
                DisplayNarration(INVALID_NUMERIC_EXCEPTION);
                error = true;
            }
            catch (FormatException)
            {
                DisplayNarration(FORMAT_EXCEPTION_NARRATION);
                error = true;
            }
            if (!error)
            {
                TaxCalculation(income);
            }
            keepRunning = RunAgain();
        }
        
    }

    private void TaxCalculation(decimal income)
    {
        try {
        TaxCalculator taxCalculator = new TaxCalculator(income);
        decimal tax = taxCalculator.IncomeTax();
        DisplayNarration(string.Format(TAX_OUTPUT, taxCalculator.Income, tax));
        } catch (ArgumentException)
        {
            DisplayNarration(ARGUMENT_EXCEPTION_NARRATION);
        }
    }

    private bool RunAgain()
    {
        DisplayNarration(RERUN_TAX);
        return String.Compare(Console.ReadLine()??"".ToLower(), "y")==0;
    }

    /// <summary>
    /// Prompts the user for an income about to calculate tax payable
    /// </summary>
    /// <returns>A decimal value</returns>
     private decimal GetIncome()
    {
        decimal value;
        while (true)
        {
           DisplayNarration(PROMPT);
           string? input = Console.ReadLine();
           if ((string.IsNullOrEmpty(input)) || (string.IsNullOrWhiteSpace(input)))
                {
                    throw new ArgumentException(ARGUMENT_EXCEPTION_NARRATION);
                }
                if (decimal.TryParse(input, out value))
                {
                    return value;
                } 
            else {
                throw new FormatException(FORMAT_EXCEPTION_NARRATION);
            }            
           
        }
    }

    private void DisplayNarration(string narration)
    {
        Console.Write(narration);
    }

}

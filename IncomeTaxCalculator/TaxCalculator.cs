using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTesting {
	public class TaxCalculator {

		public decimal Income{get; set;}

		public TaxCalculator() {}
		public TaxCalculator(decimal income)
		{
			Income = income;
		}
		public decimal IncomeTax() {
			if ( Income < 0 ) throw new ArgumentException();

			Income = Math.Truncate(Income);

			decimal tax =
				Income <= 18200 ? 0 :
				Income <= 45000 ? ( Income - 18200 ) * 0.16m :
				Income <= 135000 ? ( Income - 45000) * 0.3m + 4288 :
				Income <= 190000 ? ( Income - 135000) * 0.37m + 31288 :
				( Income - 190000 ) * 0.45m + 51638;

			return Math.Round(tax);
		}
	}
}


namespace a
{
    public class Reciept
    {
        public int customerID { get; set; }
        public int cogQuant { get; set; }
        public int gearQuant { get; set; }
        public DateTime saleDate { get; set; }
        public double salesTaxPercent { get; set; }
        public double cogPrice { get; set; }
        public double gearPrice { get; set; }

        public Reciept()
        {
            this.customerID = 0;
            this.cogQuant = 0;
            this.gearQuant = 0;
            this.saleDate = DateTime.Now;
            this.salesTaxPercent = 0.089;
            this.gearPrice = 250.00;
            this.cogPrice = 79.99;
        }
        public Reciept(int id, int cog, int gear)
        {
            this.customerID = id;
            this.cogQuant = cog;
            this.gearQuant = gear;
            this.saleDate = DateTime.Now;
            this.salesTaxPercent = 0.089;
            this.gearPrice = 250.00;
            this.cogPrice = 79.99;
        }
        public double CalculateTotal()
        {
            double netAmount = this.CalculateNetAmount();
            double salesTaxAmount = this.CalculateTaxedAmount();
            double totalAmount = netAmount + salesTaxAmount;
            return totalAmount;
        }
        public void PrintReciept()
        {
            Console.WriteLine("=======================");
            Console.WriteLine($"Customer ID: {this.customerID}");
            Console.WriteLine($"# of cogs: {this.cogQuant}");
            Console.WriteLine($"# of gears: {this.gearQuant}");
            Console.WriteLine($"Net Amount: {CalculateNetAmount():C2}");
            Console.WriteLine($"Sales Tax: {CalculateTaxedAmount():C2}");
            Console.WriteLine($"Grand Total: {CalculateTotal():C2}");
            Console.WriteLine($"Time: {this.saleDate}");
            Console.WriteLine("=======================");
        }
        private double CalculateTaxedAmount()
        {
            double netAmount = this.CalculateNetAmount();
            double salesTax = netAmount * this.salesTaxPercent;
            return salesTax;
        }
        private double CalculateNetAmount()
        {
            double markup = 0.15;
            if(this.cogQuant > 10 || this.gearQuant>10 || this.cogQuant+this.gearQuant>16)
            {
                markup = .125;
            } else
            {
                markup = .15;
            }

            double netAmount = this.cogQuant * this.cogPrice * (1 + markup) + this.gearQuant * this.gearPrice * (1 + markup);

            return netAmount;
        } 
    }
}

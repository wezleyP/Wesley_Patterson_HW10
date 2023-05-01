// HW10
// Wesley Patterson
// 113562579
using a;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Numerics;


int cogNum = 0;
int gearNum = 0;

List<Reciept> rList = new List<Reciept>();

Console.Write("Do you want to print a new receipt? (y/n)");
string userInput = Console.ReadLine().ToLower();

while (userInput == "y")
{
    Console.Write("Please input the number of cogs: ");
    cogNum = Convert.ToInt16(Console.ReadLine());

    Console.Write("Please input the number of gears: ");
    gearNum = Convert.ToInt16(Console.ReadLine());

    Console.Write("Please input the Customer ID:");
    int custID = Convert.ToInt16(Console.ReadLine());


    //Reciept r = new Reciept();
    //r.customerID = custID;
    //r.cogQuant = cogNum;
    //r.gearQuant = gearNum;

    //same as 

    Reciept r = new Reciept(custID, cogNum, gearNum);

    r.PrintReciept();

    rList.Add(r);
    Console.Write("Do you want to enter a new receipt? (y/n)");
    userInput = Console.ReadLine().ToLower();
}
do
{
    Console.WriteLine("Please choose from the options:");
    Console.WriteLine("1: Print all receipt of one customer");
    Console.WriteLine("2: Print all receipt for today");
    Console.WriteLine("3: Print the highest total receipt");
    Console.WriteLine("4.Print the average grand total");
    Console.WriteLine("Press other keys to end");

    userInput = Console.ReadLine();

    if(userInput == "1")
    {
         
        Console.WriteLine("Please enter a cust ID:");
        int idStr = Convert.ToInt16(Console.ReadLine());
        for(int i = 1; i<=rList.Count;i++)
        {
            if(rList[i-1].customerID == idStr)
            {
                rList[i-1].PrintReciept();
            }
        }

    } else if(userInput == "2")
    {
        for (int i = 0; i < rList.Count; i++)
        {
                rList[i].PrintReciept();
        }
    } else if(userInput == "3")
    {
        Reciept highest = rList[0];
        for(int i = 1; i<=rList.Count; i++)
        {
            if (rList[i-1].CalculateTotal() > highest.CalculateTotal())
            {
                highest = rList[i - 1];
            }
        }
        Console.WriteLine("receipt with highest total: ");
        highest.PrintReciept();

    } else if(userInput == "4" )
    {
        double sumTotal = 0;
        for(int i = 0; i<rList.Count; i++)
        {
            sumTotal = sumTotal + rList[i].CalculateTotal();
        }
        double averageTotal = sumTotal/ rList.Count;
        Console.WriteLine($"The average grandTotal is: {averageTotal:C2}");
    } else
    {
        break;
    }

} while (userInput == "1" || userInput == "2" || userInput == "3" || userInput =="4");



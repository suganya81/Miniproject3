using Microsoft.VisualBasic;

List<Product> products = new List<Product>();

string type;
string brand;
string model;
string office;
string purchaseDate;
int priceUSD;
string currency;
double lprice;
DateTime EndDate ;
DateTime CurrentDate = DateTime.Now;
DateTime PurchaseDt;
int nod;

while (true)
{
    Console.WriteLine("Enter the Product Type : 'c' for Computer/Laptop : 'p' for Phone . 'q' to quit application.");
    type = Console.ReadLine();

    if (type.ToLower().Trim() == "q")
    {
        break;
    }
    else if (type.ToLower().Trim() == "c")
    {
        type = "Computer";
        Console.WriteLine("Enter brand Name: ");
        brand = Console.ReadLine();
        Console.WriteLine("Enter model: ");
        model = Console.ReadLine();
        Console.WriteLine("Enter office: ");
        office = Console.ReadLine();
        currency = GetCurrency(office);
        Console.WriteLine("Enter Purchase Date:");
        purchaseDate  = Console.ReadLine();
        PurchaseDt = Convert.ToDateTime(purchaseDate);
        nod = CalcDays(PurchaseDt);
        Console.WriteLine(nod);
        Console.WriteLine("Enter Price in USD:");
        priceUSD = Convert.ToInt32(Console.ReadLine());
        lprice = localPrice(office, priceUSD);
        Console.WriteLine(lprice);
        products.Add(new Computer(type,brand,model,office,purchaseDate,priceUSD,currency,lprice,nod));
    }
    else if (type.ToLower().Trim() == "p")
            {
            type = "Phone";
            Console.WriteLine("Enter brand Name:");
            brand = Console.ReadLine();
            Console.WriteLine("Enter model:");
            model = Console.ReadLine();
            Console.WriteLine("Enter office:");
            office = Console.ReadLine();
            currency = GetCurrency(office);
            Console.WriteLine("Enter Purchase Date:");
            purchaseDate = Console.ReadLine();
            PurchaseDt = Convert.ToDateTime(purchaseDate);
            nod = CalcDays(PurchaseDt);
            Console.WriteLine(nod);
            Console.WriteLine("Enter Price in USD:");
            priceUSD = Convert.ToInt32(Console.ReadLine());
            lprice = localPrice(office, priceUSD);
            Console.WriteLine(lprice);
            products.Add(new Phone(type, brand, model, office, purchaseDate, priceUSD,currency,lprice,nod));
            }


}

//prints the list
PrintProduct(products);


//calculates the rest of days until Expiry (expiry=3yrs)
int CalcDays(DateTime purDate)
{
    int days = 0;
    EndDate = purDate.AddDays(1095);
    days = (EndDate - CurrentDate).Days;
    return days;
}

//Assigning the currency as per office 
string GetCurrency(string country)
{
    if (country.ToLower().Trim() == "sweden")
    { return "SEK";
    }
    else if (country.ToLower().Trim() == "usa")
    { return "USD";
    }
    else
        return "EUR";
}

// calculating local price as per the countries currency
double localPrice(string  country, int price)
{
    if (country.ToLower().Trim() == "sweden")
    {
        return price * 10.5;
    }
    else if (country.ToLower().Trim() == "usa")
    {
        return price;
    }
    else
        return price * 0.91;
}



static void PrintProduct(List<Product> products)
{
    List<Product> sorted = products.OrderBy(product => product.Type).ToList();
    Console.WriteLine("Type".PadRight(10) +"Brand".PadRight(10) +"Model".PadRight(10) + "Office".PadRight(10) +"Purchasedate".PadRight(20) + "PriceinUSD".PadRight(15)+ "Localcurrency".PadRight(15)+ "Price");
    foreach (Product product in sorted)
    {
        Console.WriteLine(product.Show());
        Console.ForegroundColor = ConsoleColor.White;
    }
}

class Product
{
    int days;
    public Product(string type, string brand,string model,string office,string purchaseDate,int price,string currency,double lprice)
    {
        Type = type;
        Brand = brand;
        Model = model;
        Office = office;
        PurchaseDate = purchaseDate;
        Price = price;
        Currency = currency;
        Lprice = lprice;
    }

    public string Type { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Office { get; set; }
    public string PurchaseDate { get; set; }
    public int Price { get; set; }
    public string Currency { get; set; }
    public double Lprice { get; set; }



    public virtual string Show()
    
    {
        return "SomeThing";
       
    }

}

class Computer : Product
{
    public Computer(string type, string brand, string model, string office, string purchaseDate, int price,string currency, double lprice,int nod) : base(type, brand, model, office, purchaseDate, price,currency,lprice)
    {
      NOD =nod;         
    }


    public int NOD
    { get; set; }
    
    public override string Show()
    {
        {
            //Console.ForegroundColor = ConsoleColor.White;
            //return Type.PadRight(10) + Brand.PadRight(10) + Model.PadRight(10) + Office.PadRight(10) + PurchaseDate.PadRight(10) + Price + " **** " +NOD;
            if (NOD <= 90)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return Type.PadRight(10) + Brand.PadRight(10) + Model.PadRight(10) + Office.PadRight(10) + PurchaseDate.PadRight(20) + Price.ToString().PadRight(20) + Currency.PadRight(10) + Lprice;
            }
            else if (NOD <= 180 && NOD > 90)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return Type.PadRight(10) + Brand.PadRight(10) + Model.PadRight(10) + Office.PadRight(10) + PurchaseDate.PadRight(20) + Price.ToString().PadRight(20) + Currency.PadRight(10) + Lprice;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                return Type.PadRight(10) + Brand.PadRight(10) + Model.PadRight(10) + Office.PadRight(10) + PurchaseDate.PadRight(20) + Price.ToString().PadRight(20) + Currency.PadRight(10) + Lprice;
            }
        }
        
    }
}

class Phone : Product
{
    //int days;
    public Phone(string type, string brand, string model, string office, string purchaseDate, int price,string currency, double lprice, int nod) : base(type, brand, model, office, purchaseDate, price, currency, lprice)
    {
        NOD = nod; 
    }
    public int NOD { get; set; }
    public override string Show()
    {
        //return Type.PadRight(10) + Brand.PadRight(10) + Model.PadRight(10) + Office.PadRight(10) + PurchaseDate.PadRight(10) + Price +" --- " + NOD;
        if (NOD <= 90)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return Type.PadRight(10) + Brand.PadRight(10) + Model.PadRight(10) + Office.PadRight(10) + PurchaseDate.PadRight(20) + Price.ToString().PadRight(20) + Currency.PadRight(10) + Lprice;
        }
        else if (NOD <= 180 && NOD > 90)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return Type.PadRight(10) + Brand.PadRight(10) + Model.PadRight(10) + Office.PadRight(10) + PurchaseDate.PadRight(20) + Price.ToString().PadRight(20) + Currency.PadRight(10) + Lprice;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            return Type.PadRight(10) + Brand.PadRight(10) + Model.PadRight(10) + Office.PadRight(10) + PurchaseDate.PadRight(20) + Price.ToString().PadRight(20) +  Currency.PadRight(10) +  Lprice;
        }
    }
}

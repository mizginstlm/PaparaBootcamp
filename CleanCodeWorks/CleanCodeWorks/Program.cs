
/////////////////////////////diamond problem bad: multiple inheritances
// interface IShape
// {
//     void Draw();
// }

// interface IColorable : IShape
// {
//     void SetColor(string color);
// }

// // Implement interfaces in a class
// class Circle : IColorable
// {
//     public void Draw()
//     {
//         Console.WriteLine("Drawing a circle");
//     }

//     public void SetColor(string color)
//     {
//         Console.WriteLine($"Setting color to {color}");
//     }
// }

///without diamond problem : good code inheritances
interface IShape
{
    void Draw();
}

interface IColorable
{
    void SetColor(string color);
}

class Circle : IShape, IColorable
{
    public void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }

    public void SetColor(string color)
    {
        Console.WriteLine($"Setting color to {color}");
    }
}

//////////////////////////bad code: without single responsibility principle
public class NotResponsibleUser
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void SaveUserToFile(User user)
    {
        Console.WriteLine($"Saving user to file");
    }

    public void SendUserEmail(User user, string email)
    {
        Console.WriteLine($"Sending email to {email}");
    }
}

//good code: with single responsibility principle
public class ResponsibleUser
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class UserSaver
{
    public void SaveUserToFile(User user)
    {
        Console.WriteLine($"Saving user to file");
    }
}

public class EmailSender
{
    public void SendUserEmail(User user, string email)
    {
        Console.WriteLine($"Sending email to {email}");
    }
}

//////////////////////////////////abstraction subject
public interface IUser
{
    void DisplayInfo();
}

public class User : IUser
{
    public double Width { get; set; }
    public double Height { get; set; } = 173;

    public User(double width)
    {
        Width = width;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"User - Width: {Width}, Height: {Height}");
    }
}



///////////////////////////////open closed principle didnt used and so here is EVIL code
public class PaymentService2
{
    private readonly List<object> paymentProcessors;
    public PaymentService2()
    {
        paymentProcessors = new List<object>
        {
            new TraditionalCardPaymentProcessor(),
            new CoinPaymentProcessor()
        };
    }
    public void ProcessPayments2(decimal amount)
    {
        foreach (var paymentProcessor in paymentProcessors)
        {
            if (paymentProcessor is TraditionalCardPaymentProcessor traditionalCardPaymentProcessor)
            {
                //traditionalCardPaymentProcessor.ProcessTradtionalCardPayment(amount);
            }
            else if (paymentProcessor is CoinPaymentProcessor coinProcessor)
            {
                //paypalProcessor.ProcessCoinPayment(amount);
            }
        }
    }
}

/////open closed principle and good code
public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}
public class TraditionalCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of ${amount}");
    }
}

public class CoinPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Coin payment of ${amount}");
    }
}
public class PaymentService
{
    private readonly List<IPaymentProcessor> paymentProcessors;

    public PaymentService(List<IPaymentProcessor> paymentProcessors)
    {
        this.paymentProcessors = paymentProcessors;
    }

    public void ProcessPayments(decimal amount)
    {
        foreach (var paymentProcessor in paymentProcessors)
        {
            paymentProcessor.ProcessPayment(amount);
        }
    }
}

/////////Interface Segregation Principle good code
public interface ILogger
{
    void Log(string message);
}
public interface ICache
{
    object Get(string key);
    void Set(string key, object value);
}

public class LogService : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Logging message: {message}");
    }
}

public class CacheService : ICache
{
    public object Get(string key)
    {
        return "value";
    }

    public void Set(string key, object value)
    {
        Console.WriteLine($"Setting cache with key: {key} and value: {value}");
    }
}

//interface segregation principle bad code
public interface ILoggingAndCaching
{
    void Log(string message);
    object Get(string key);
    void Set(string key, object value);
}

public class LoggingAndCachingService : ILoggingAndCaching
{
    private readonly Dictionary<string, object> cache = new Dictionary<string, object>();

    public void Log(string message)
    {
        Console.WriteLine($"Logging message: {message}");
    }

    public object Get(string key)
    {
        return "value";

    }
    public void Set(string key, object value)
    {
        cache[key] = value;
    }
}

/////////////////////////////dependency inversion principle good code example
public interface IDatabase
{
    void Add(string data);
}
public class UserService
{
    private IDatabase _database;
    public UserService(IDatabase database)
    {
        _database = database;
    }

    public void AddUser(string username)
    {
        _database.Add(username);
    }
}

public class ADatabase : IDatabase
{
    public void Add(string data)
    {
        Console.WriteLine($"Adding user to database");
    }
}

//Dependency Inversion Principle related, bad code
public class BadUserService
{
    private SqlDatabase sqlDatabase;

    public BadUserService()
    {
        this.sqlDatabase = new SqlDatabase();
    }

    public void AddUser(string username)
    {
        sqlDatabase.Add(username);
    }
}
public class SqlDatabase
{
    public void Add(string data)
    {
        Console.WriteLine($"Adding user to database");
    }
}


class Program
{
    static void Main()
    {
        // 1. Abstraction good code:
        IUser User1 = new User(40.0);
        User1.DisplayInfo();

        // 1. Abstraction bad code: somut sınıftan direkt new lediğimiz için bad code örneği diyebiliriz.
        User User2 = new User(5.0);
        User2.DisplayInfo();
        Console.WriteLine(User2.Height);//ve içerideki somut değerlere de ulaşabiliyoruz, classtaki her bilgiye erşemememiz lazım.   

        //open closed principle good code example
        IPaymentProcessor TraditionalCardProcessor = new TraditionalCardPaymentProcessor();//normalde constructorda olması daha iyidir ancak burada örnek olması için böyle yaptım.
        IPaymentProcessor CoinProcessor = new CoinPaymentProcessor();
        var paymentProcessors = new List<IPaymentProcessor>
        {
            TraditionalCardProcessor,
            CoinProcessor
        };
        var paymentService = new PaymentService(paymentProcessors);
        paymentService.ProcessPayments(100.50M);

        //ISP good code example results
        ILogger logger = new LogService();
        logger.Log("This is a log message.");
        ICache cache = new CacheService();
        string key = "exampleKey";
        string value = "exampleValue";
        object cachedValues = cache.Get(key);
        Console.WriteLine($"Retrieved from cache: {cachedValues}");
        cache.Set(key, value);
    }
}

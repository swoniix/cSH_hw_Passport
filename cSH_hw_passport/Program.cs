using System;

public class ForeignPassport
{
    private string number;
    private string fullname;
    private DateTime birthday;
    private DateTime issueDate;
    private DateTime expirationDate;
    private string authority;
    private string countryCode;

    public ForeignPassport()
    {
        number = "";
        fullname = "";
        authority = "";
        countryCode = "";
    }

    public void Fill(string number, string fullname, DateTime birthday, DateTime issueDate,
        DateTime expirationDate, string authority, string countryCode)
    {
        if (string.IsNullOrEmpty(fullname))
        {
            throw new ArgumentNullException("Incorrect fullname");
        }
        if (string.IsNullOrEmpty(number) || number.Length != 8)
        {
            throw new ArgumentNullException("Incorrect number");
        }

        foreach (char symb in number)
        {
            if (!char.IsLetterOrDigit(symb))
            {
                throw new ArgumentException("Incorrect number, enter numbers and letters");
            }
        }
        if (birthday > issueDate)
        {
            throw new ArgumentException("Incorrect birthday");
        }

        if (expirationDate <= issueDate)
        {
            throw new ArgumentException("Incorrect expirationDate");
        }
        if (string.IsNullOrWhiteSpace(authority))
        {
            throw new ArgumentException("Орган выдачи не заполнен.");
        }
        if (countryCode != "UKR" && countryCode != "POL" && countryCode != "DEU")
        {
            throw new ArgumentException("Недопустимый код страны.");
        }
        this.number = number;
        this.fullname = fullname;
        this.birthday = birthday;
        this.issueDate = issueDate;
        this.expirationDate = expirationDate;
        this.authority = authority;
        this.countryCode = countryCode;
    }

    public void Show()
    {
        if (fullname == "")
        {
            Console.WriteLine("The passport hasn't been filled out yet");
        }
        Console.WriteLine("Number: "+number);
        Console.WriteLine("Fullname: " + fullname);
        Console.WriteLine("Birthday: " + birthday);
        Console.WriteLine("Issue Date: " + issueDate);
        Console.WriteLine("Expiration Date: " + expirationDate);
        Console.WriteLine("Authority: " + authority);
        Console.WriteLine("CountryCode: " + countryCode);
    }
}

class Program
{
    static void Main()
    {
        ForeignPassport passport = new ForeignPassport();
        try
        {
            passport.Fill("AB123456",
                "Петренко Анна Іванівна",
                new DateTime(2000, 5, 15),
                new DateTime(2025, 9, 10),
                new DateTime(2035, 1, 10),
                "Орган выдачи",
                "UKR");
            passport.Show();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error"+e.Message);
        }
    }
}
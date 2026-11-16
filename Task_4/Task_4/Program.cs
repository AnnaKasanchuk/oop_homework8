using System;

interface IDiscountable
{
    void ApplyDiscount(String discount);
}

interface IPromocodeable
{
    void ApplyPromocode(String promocode);
}

interface IColorable
{
    void SetColor(byte color);
}

interface ISizable
{
    void SetSize(byte size);
}

interface IPriceable
{
    void SetPrice(double price);
}

class Book : IPriceable, IDiscountable, IPromocodeable
{
    private double price;
    private String discount = "";
    private String promocode = "";

    public void SetPrice(double price)
    {
        this.price = price;
    }

    public void ApplyDiscount(String discount)
    {
        this.discount = discount;
    }

    public void ApplyPromocode(String promocode)
    {
        this.promocode = promocode;
    }
}

class Outerwear : IPriceable, IDiscountable, IColorable, ISizable
{
    private double price;
    private String discount = "";
    private byte color;
    private byte size;

    public void SetPrice(double price)
    {
        this.price = price;
    }

    public void ApplyDiscount(String discount)
    {
        this.discount = discount;
    }

    public void SetColor(byte color)
    {
        this.color = color;
    }

    public void SetSize(byte size)
    {
        this.size = size;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book();
        book.SetPrice(250.0);
        book.ApplyDiscount("10%");
        book.ApplyPromocode("SPRING");

        Outerwear jacket = new Outerwear();
        jacket.SetPrice(1999.0);
        jacket.SetColor(3);
        jacket.SetSize(48);
        jacket.ApplyDiscount("15%");

        Console.WriteLine("Об'єкти створено без зайвих методів.");
        Console.ReadKey();
    }
}
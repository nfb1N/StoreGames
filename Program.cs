using System;
using System.Collections.Generic;

namespace StoreGames
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("-------------------------------------------------------------------");
            Seller seller = new Seller("Play Market");
            seller.AddGame(new Game("horizon", 1500, "about robots"));
            seller.AddGame(new Game("god of war", 3000, "about gods"));
            seller.AddGame(new Game("infamous: second son", 1000, "about super power"));

            Customer customer = new Customer("Valery", 10000, new LoginParameters("password", "login"));
            customer.Notify += Console.WriteLine;

            customer.JoinToTheSeller(seller);
            customer.EnterTheSeller(seller);

            System.Console.WriteLine(seller);
            System.Console.WriteLine(customer);


            customer.BuyGame(seller, "horizon");
            customer.BuyGame(seller, "god of war");
            customer.BuyGame(seller, "batlefield");

            System.Console.WriteLine("");
            System.Console.WriteLine(seller);
            System.Console.WriteLine("");
            System.Console.WriteLine(customer);

        }
    }
}

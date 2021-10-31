using System.Collections.Generic;
public class Seller{
    public string Name { get; set; }
    
    public List<Game> MyGames{get; set;}

    public List<LoginParameters> LogPases;

    public Seller(string name)
    {
        this.MyGames = new List<Game>();
        this.Name = name;
        this.LogPases = new List<LoginParameters>();
    }

    public Seller(string name, List<Game> games)
    {
        this.MyGames = games;
        this.Name = name;
        this.LogPases = new List<LoginParameters>();
    }

    public void LoginCustomer(Customer customer){
        customer.AmIAtTheSeller = true;
    }

    public void AddGame(Game game){
        this.MyGames.Add(game);
    }

    public void SoldGame(Game game){
        this.MyGames.Remove(game);
    }

    public override string ToString()
    {
        if(this.MyGames.Count != 0){
            string returned = string.Empty;
            this.MyGames.ForEach((x) => returned+= x.ToString() + "\n");
            return $"{this.Name} has this Games:\n"+ returned;
        }
        else return $"{this.Name} doesn`t have any games";
    }

} 
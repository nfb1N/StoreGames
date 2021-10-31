public class Game{
    public string Name { get; private set; }
    public int Price { get; set;}

    public string Description { get; private set; }

    public Game()
    {
        this.Name = string.Empty;
        this.Description = string.Empty;
        this.Price = 0;
    }
    public Game(string name, int price, string descrip)
    {
        this.Name = name;
        this.Description = descrip;
        this.Price = price;
    }

    public override string ToString()
    {
        return $"Name: '{this.Name}'\tPrice: {this.Price}\tDescription: {this.Description}";
    }

}
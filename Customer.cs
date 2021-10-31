using System.Collections.Generic;
public class Customer{
    public string Name { get; private set; }
    public int Cash { get; set; }

    LoginParameters LogPas;

    public bool AmIAtTheSeller { get; set; }
    
    List<Game> MyGames{get; set;}

    public delegate void CheckPurChaseStatus(string str);
    public event CheckPurChaseStatus Notify;


    public Customer()
    {
        this.Name = string.Empty;
        this.LogPas = new LoginParameters();
        this.Cash = 0;
        this.AmIAtTheSeller = false;
        MyGames = new List<Game>();
    }

    public Customer(string name, int cash,LoginParameters logpas)
    {
        this.AmIAtTheSeller = false;
        this.Name = name;
        this.Cash = cash;
        MyGames = new List<Game>();
        this.LogPas = logpas;
    }

    public void JoinToTheSeller(Seller seller){
        if(!this.AmIAtTheSeller){
            foreach (var item in seller.LogPases)
            {
                if(string.Compare(item.Login, this.LogPas.Login, true) == 0)  
                {
                    Notify?.Invoke($"this login is already taken");
                    return;
                }
            }
            seller.LogPases.Add(this.LogPas);            
            seller.LoginCustomer(this);
            Notify?.Invoke($"{this.Name} joined to the {seller.Name}");
        }
        else  Notify?.Invoke($"you are already in the {seller.Name}");
    }

     public void EnterTheSeller(Seller seller){
         if(!this.AmIAtTheSeller){
            foreach (var item in seller.LogPases)
            {
                if(string.Compare(item.Login, this.LogPas.Login, true) == 0 && item.Password == this.LogPas.Password)  
                {
                    Notify?.Invoke($"{this.Name} entered the {seller.Name}");
                    seller.LoginCustomer(this);
                    return;
                }
            }
            Notify?.Invoke($"login or password is incorrect");
         }
        else  Notify?.Invoke($"you are already in the {seller.Name}");
     }

    public void BuyGame(Seller seller, string Name){
        if(this.AmIAtTheSeller){
            foreach (var item in seller.MyGames)
            {
                if(item.Name == Name){
                    if(this.Cash > item.Price){
                        this.Cash -= item.Price;
                        seller.SoldGame(item);
                        this.MyGames.Add(item);
                        Notify?.Invoke($"{seller.Name} sold '{item.Name}' to {this.Name}");
                        return;
                    }
                }
            }
            Notify?.Invoke($"the name '{Name}' or {this.Name}`s cash does not match the requirements");
        }
        Notify?.Invoke($"{this.Name} isn`t at the {seller.Name}");
    }

    public override string ToString()
    {
        if(this.MyGames.Count != 0){
            string returned = string.Empty;
            this.MyGames.ForEach((x) => returned+= x.ToString()+"\n");
            return $"{this.Name} has this Games:\n"+ returned;
        }
        else return $"{this.Name} doesn`t have any games";
    }
}
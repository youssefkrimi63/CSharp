public class Ennemy
{
    public string Name {get;set;}
    public int Health {get;set;}
    public List<Attack> AttackList { get; set; }

    public Ennemy(string name)
    {
        Name = name ;
        Health = 100 ;
        AttackList = new List<Attack>();
    } 

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
        if (Health <= 0)
        {
            Console.WriteLine($"{Name} has been defeated!");
        }
    }

    public void RandomAttack()
    {
        if (AttackList.Count == 0)
        {
            Console.WriteLine($"{Name} has no attacks!");
            return;
        }

        Random random = new Random();
        int randomIndex = random.Next(AttackList.Count);
        Attack selectedAttack = AttackList[randomIndex];;
    }
}
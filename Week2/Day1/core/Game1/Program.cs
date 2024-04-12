// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Ennemy orc = new Ennemy("Orc");

Attack fireballAttack = new Attack("Fireball", 20);
Attack swordSlashAttack = new Attack("Sword Slash", 15);
Attack roundhouseKickAttack = new Attack("Roundhouse Kick", 25);

orc.AttackList.Add(fireballAttack);
orc.AttackList.Add(swordSlashAttack);
orc.AttackList.Add(roundhouseKickAttack);

Console.WriteLine($"{orc.Name} - Health: {orc.Health}");
Console.WriteLine("Attacks:");
foreach (Attack attack in orc.AttackList)
{
    Console.WriteLine($"  {attack.Name} - Damage: {attack.Damage}");
}
for (int i = 0; i < 3; i++)
{
    orc.RandomAttack();
}
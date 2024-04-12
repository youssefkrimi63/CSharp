Ennemy orc = new Ennemy("Orc");

Attack fireballAttack = new Attack("Fireball", 30);
Attack swordSlashAttack = new Attack("Sword Slash", 25);
Attack poisonDartAttack = new Attack("Poison Dart", 15);

orc.AttackList.Add(fireballAttack);
orc.AttackList.Add(swordSlashAttack);
orc.AttackList.Add(poisonDartAttack);

Console.WriteLine($"{orc.Name} - Health: {orc.Health}");
Console.WriteLine("Attacks:");
foreach (Attack attack in orc.AttackList)
{
    Console.WriteLine($"  {attack.Name} - Damage: {attack.Damage}");
}

// Simulate the enemy performing random attacks multiple times
for (int i = 0; i < 3; i++)
{
    orc.RandomAttack();
}
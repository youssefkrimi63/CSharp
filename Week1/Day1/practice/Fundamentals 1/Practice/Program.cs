// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// num 1
for(int i = 1 ; i<=255 ; i++)
{
    System.Console.WriteLine(i);
}


Random rand=new Random();
for(int i = 0 ; i< 5;i++)
{
    System.Console.WriteLine(rand.Next(10,21));
}
// num 3
// Random rand = new Random();
    int sum = 0;

        for (int i = 0; i < 5; i++)
        {
            int randomValue = rand.Next(10, 21);
            Console.WriteLine(randomValue);
            sum += randomValue;
        } 
        System.Console.WriteLine(sum);
// num 4
for(int i = 1 ; i <=100 ; i++)
{
    if ((i % 3 == 0) != (i % 5 == 0))
            {
                Console.WriteLine(i);
            }
}


//  num 5

for(int i = 1 ; i <=100 ; i++)
{
    if ((i % 3 == 0) && (i % 5 == 0))
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0 )
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else 
            {
                Console.WriteLine(i);
            }
}





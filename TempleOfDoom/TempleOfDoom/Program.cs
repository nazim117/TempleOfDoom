/*
2 4 6 8
11 3 5 7 9
24 28 18 30

13 7 4 22 11 15 20
3 2 1
12 10 5

*/

Queue<int> tools = new(Console.ReadLine().Split().Select(int.Parse));
Stack<int> substances = new(Console.ReadLine().Split().Select(int.Parse));
List<int> challenges = new(Console.ReadLine().Split().Select(int.Parse));

while (true)
{
    int tool = tools.Dequeue();
    int substance = substances.Pop();
    int result = tool * substance;
    if (challenges.Contains(result))
    {
        challenges.Remove(result);
    }
    else 
    {
        tool++;
        tools.Enqueue(tool);

        substance--;
        if (substance > 0)
        {
            substances.Push(substance);
        }
    }
    if ((!tools.Any() || !substances.Any()) && challenges.Any())
    {
        Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
        break;
    }
    if (!challenges.Any())
    {
        Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
        break;
    }
}

if (tools.Any())
{
    Console.WriteLine($"Tools: {string.Join(", ", tools)}");
}
if (substances.Any())
{
    Console.WriteLine($"Substances: {string.Join(", ", substances)}");
}
if (challenges.Any())
{
    Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
}
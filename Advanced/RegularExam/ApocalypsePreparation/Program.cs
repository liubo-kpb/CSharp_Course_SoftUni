int[] inputTextiles = Console.ReadLine().Split().Select(int.Parse).ToArray();


int[] inputMedicaments = Console.ReadLine().Split().Select(int.Parse).ToArray();

Queue<int> textiles = new Queue<int>(inputTextiles);
Stack<int> medicaments = new Stack<int>(inputMedicaments);

int patch = 30;
int bandage = 40;
int medKit = 100;

Dictionary<string, int> medicine = new Dictionary<string, int>();
while (textiles.Count > 0 && medicaments.Count > 0)
{
    int currentTextile = textiles.Dequeue();
    int currentMedicament = medicaments.Pop();
    int medicineSum = currentTextile + currentMedicament;

    if(medicineSum >= medKit)
    {
        if (!medicine.ContainsKey("MedKit"))
        {
            medicine["MedKit"] = 0;
        }
        medicine["MedKit"]++;
        if (medicineSum - medKit > 0)
        {
            currentMedicament = medicaments.Pop();
            currentMedicament += medicineSum - medKit;
            medicaments.Push(currentMedicament);
        }

    }
    else if (medicineSum == bandage)
    {
        if (!medicine.ContainsKey("Bandage"))
        {
            medicine["Bandage"] = 0;
        }
        medicine["Bandage"]++;
    }
    else if (medicineSum == patch)
    {
        if (!medicine.ContainsKey("Patch"))
        {
            medicine["Patch"] = 0;
        }
        medicine["Patch"]++;
    }
    else
    {
        currentMedicament += 10;
        medicaments.Push(currentMedicament);
    }
}

if (medicaments.Count == 0 && textiles.Count== 0)
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else if (medicaments.Count == 0)
{
    Console.WriteLine("Medicaments are empty.");
}
else if (textiles.Count == 0)
{
    Console.WriteLine("Textiles are empty.");
}

foreach (var item in medicine.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}

if (medicaments.Count > 0)
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
}
else if (textiles.Count > 0)
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
}
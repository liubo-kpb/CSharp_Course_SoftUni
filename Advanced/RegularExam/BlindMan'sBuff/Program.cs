int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

int n = dimensions[0];
int m = dimensions[1];

char[,] matrix = new char[n, m];
int playerRow = 0;
int playerCol = 0;
for (int i = 0; i < n; i++)
{
    char[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
    for (int j = 0; j < m; j++)
    {
        matrix[i, j] = row[j];
        if (matrix[i, j] == 'B')
        {
            playerRow = i;
            playerCol = j;
        }
    }
}

int timesMoved = 0;
int playersCaught = 0;

string command = string.Empty;
while ((command = Console.ReadLine()) != "Finish" && playersCaught < 3)
{
    switch (command)
    {
        case "up":
            if (CheckPosition(playerRow - 1, playerCol))
            {
                playerRow -= 1;
                timesMoved++;
            }
            break;
        case "down":
            if (CheckPosition(playerRow + 1, playerCol))
            {
                playerRow += 1;
                timesMoved++;
            }
            break;
        case "right":
            if (CheckPosition(playerRow, playerCol + 1))
            {
                playerCol += 1;
                timesMoved++;
            }
            break;
        case "left":
            if (CheckPosition(playerRow, playerCol - 1))
            {
                playerCol -= 1;
                timesMoved++;
            }
            break;
    }
    if (matrix[playerRow, playerCol] == 'P')
    {
        matrix[playerRow, playerCol] = '-';
        playersCaught++;
    }
}
Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {playersCaught} Moves made: {timesMoved}");

bool CheckPosition(int newRow, int newCol)
{
    bool canMove = false;
    if (newRow >= 0 && newCol >= 0 && newRow < matrix.GetLength(0) && newCol < matrix.GetLength(1) && matrix[newRow, newCol] != 'O')
    {
        canMove = true;
    }
    return canMove;
}
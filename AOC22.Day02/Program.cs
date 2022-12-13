#region PART ONE
{
    int score = 0;
    int rock = 1, paper = 2, scissors = 3;
    int win = 6, tie = 3, lost = 0;

/*
 * A = ROCK, B = PAPER, C = SCISSORS
 * X = ROCK, Y = PAPER, Z = SCISSORS
 */

    foreach (var line in File.ReadLines(AppContext.BaseDirectory + @"Files/input.txt"))
    {
        char ennemy = line[0], self = line[2];

        switch (self)
        {
            case 'X': // ROCK
                score += rock + (ennemy switch
                {
                    'C' => win,
                    'A' => tie,
                    _ => lost
                });
                break;
            case 'Y': // PAPER
                score += paper + (ennemy switch
                {
                    'A' => win,
                    'B' => tie,
                    _ => lost
                });
                break;
            case 'Z': // SCISSORS
                score += scissors + (ennemy switch
                {
                    'B' => win,
                    'C' => tie,
                    _ => lost
                });
                break;
            default:
                Console.WriteLine("weird " + line);
                break;
        }
    }

    Console.WriteLine("PART ONE Total score is: " + score);
}
#endregion

#region PART TWO

{
    int score = 0;
    int rock = 1, paper = 2, scissors = 3;
    int win = 6, tie = 3, lost = 0;

/*
 * A = ROCK, B = PAPER, C = SCISSORS
 * X = LOSE, Y = TIE, Z = WIN
 */

    foreach (var line in File.ReadLines(AppContext.BaseDirectory + @"Files/input.txt"))
    {
        char ennemy = line[0], self = line[2];

        switch (self)
        {
            case 'X': // LOSE
                score += lost + (ennemy switch
                {
                    'C' => paper,
                    'A' => scissors,
                    _ => rock
                });
                break;
            case 'Y': // TIE
                score += tie + (ennemy switch
                {
                    'A' => rock,
                    'B' => paper,
                    _ => scissors
                });
                break;
            case 'Z': // WIN
                score += win + (ennemy switch
                {
                    'B' => scissors,
                    'C' => rock,
                    _ => paper
                });
                break;
            default:
                Console.WriteLine("weird " + line);
                break;
        }
    }

    Console.WriteLine("PART TWO Total score is: " + score);
}
#endregion
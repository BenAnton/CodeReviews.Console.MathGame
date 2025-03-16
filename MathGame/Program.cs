
internal class Program
{
    private static void Main(string[] args)
    {
        string[] operations = ["addition", "subtraction", "multiplication", "division", "history"];
        bool menuSelected = false;
        int menuOptions;
        Random random = new Random();
        int score = 0;

        List<(string, int, string)> history = new List<(string, int, string)>();


        playGame();

        void playGame()
        {

            MenuSelection();
        }


        (string, int) ProduceSum(string selectedOperation)
        {

            int a = random.Next(0, 100);
            int b = random.Next(0, 100);

            string sum = $"{a} {selectedOperation} {b}?";
            int answer;

            switch (selectedOperation)
            {
                case "+":
                    answer = a + b;
                    break;

                case "-":
                    answer = a - b;
                    break;

                case "*":
                    answer = a * b;
                    break;

                case "/":
                    do
                    {
                        a = random.Next(1, 100);
                        b = random.Next(1, 100);
                    } while (a % b != 0);
                    answer = a / b;
                    sum = $"{a} {selectedOperation} {b}?";
                    break;

                default:
                    throw new InvalidOperationException("Invalid operation chosen");

            }

            return (sum, answer);
        }



        void MenuSelection()
        {
            do
            {
                Console.WriteLine("Please Choose from one of the following options:");
                Console.WriteLine("1: +, \n2: -, \n3: *, \n4: / \n5: history");
                string userInput = Console.ReadLine() ?? string.Empty;


                if (userInput == null || userInput.Length == 0)
                {
                    break;
                }


                if (int.TryParse(userInput, out menuOptions))
                    switch (menuOptions)
                    {
                        case 1:
                            menuSelected = true;
                            Console.WriteLine("You have chosen addition...");
                            PlayRound("+");
                            break;

                        case 2:
                            Console.WriteLine("You have chosen subtraction...");
                            PlayRound("-");
                            break;

                        case 3:
                            Console.WriteLine("You have chosen multiplication...");
                            PlayRound("*");
                            break;

                        case 4:
                            Console.WriteLine("You have chosen division...");
                            PlayRound("/");
                            break;

                        case 5:
                            Console.WriteLine("History:");
                            PrintHistory();
                            break;

                        default:
                            break;
                    }

            } while (!menuSelected);
        }

        void PlayRound(string selectedOperation)
        {
            score = 0;
            // history.Clear();
            for (int i = 0; i < 5; i++)
            {
                (string sum, int answer) = ProduceSum(selectedOperation);
                Console.WriteLine(sum);
                string userAnswer = Console.ReadLine() ?? string.Empty;
                if (userAnswer != null && userAnswer.Length != 0)
                {
                    int intAnswer = int.Parse(userAnswer);

                    if (intAnswer == answer)
                    {
                        System.Console.WriteLine("Correct!");
                        score++;
                        history.Add((sum, intAnswer, "Correct"));
                    }
                    else
                    {
                        System.Console.WriteLine("Incorrect");
                        history.Add((sum, intAnswer, "Incorrect"));
                    }
                }
            }
            System.Console.WriteLine($"After five rounds the final score is: {score} / 5");
            playGame();
        }


        void PrintHistory()
        {
            if (history.Count == 0)
            {
                System.Console.WriteLine("No history available");
            }
            else
            {
                foreach (var entry in history)
                {
                    System.Console.WriteLine($"Question: {entry.Item1}, Answer: {entry.Item2}, Result: {entry.Item3}");
                }
            }
            playGame();
        }
    }
}
using System;
using System.Threading;

// Strategy interface
interface IAnswerStrategy
{
    bool IsCorrectAnswer(string userAnswer);
}

// Concrete strategies
class CorrectAnswerStrategy : IAnswerStrategy
{
    public bool IsCorrectAnswer(string userAnswer)
    {
        return userAnswer.ToLower() == "b";
    }
}

class IncorrectAnswerStrategy : IAnswerStrategy
{
    public bool IsCorrectAnswer(string userAnswer)
    {
        return false;
    }
}

// Context class
class MathQuestion
{
    private IAnswerStrategy answerStrategy;

    public MathQuestion(IAnswerStrategy strategy)
    {
        answerStrategy = strategy;
    }

    public void AskQuestion()
    {
        do
        {
            Console.Clear(); // Clear the screen
            Console.WriteLine("What is 1 + 1?");
            Console.WriteLine("A) 1");
            Console.WriteLine("B) 2");
            Console.WriteLine("C) 3");
            Console.Write("Your answer (A/B/C): ");
            string userAnswer = Console.ReadLine();

            if (answerStrategy.IsCorrectAnswer(userAnswer))
            {
                
                Console.WriteLine("Congratulations! You got it right!");
                Thread.Sleep(2000); 
                break; 
            }
            else
            {
                Console.Clear(); 
                Console.WriteLine("Sorry, that's incorrect. Try again.");
                Thread.Sleep(2000);
            }
        } while (true);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a MathQuestion with a CorrectAnswerStrategy
        MathQuestion mathQuestion = new MathQuestion(new CorrectAnswerStrategy());

        // Ask the question until the correct answer is provided
        mathQuestion.AskQuestion();

        Console.ReadKey();
    }
}

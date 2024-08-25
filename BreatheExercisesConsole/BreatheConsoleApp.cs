// See https://aka.ms/new-console-template for more information
using BreatheExercisesConsole.Exercises;
using System.Runtime.CompilerServices;

/// <summary>
/// The BreatheConsoleApp runs from this class. The Main method will start the
/// process. Asking the user a series of options and acting on those options. 
/// </summary>
public class BreatheConsoleApp
{
    /// <summary>
    /// List of exercises currently available. 
    /// </summary>
    private List<Exercise> Exercises = new List<Exercise>();
    
    /// <summary>
    /// Signals to stop an exercise early.
    /// </summary>
    private bool StopExercise = false;

    /// <summary>
    /// Flag to indicate that an exercise is currently running.
    /// </summary>
    private bool IsExerciseActive = false;

    /// <summary>
    /// Main method of BreatheConsoleApp. Prompts the user for action and enacts the requests of the user. 
    /// </summary>
    /// <param name="args">Currently no args needed</param>
    public static void Main(string[] args)
    {
        BreatheConsoleApp breatheApp = new BreatheConsoleApp();
        breatheApp.AddDefaultExercises();
        bool run = true;
        breatheApp.IsExerciseActive = false;

        while (run)
        {
            if (!breatheApp.IsExerciseActive)
            {
                breatheApp.MainDialogue();
            }

            string operation = Console.ReadLine();
            if (!string.IsNullOrEmpty(operation))
            {
                breatheApp.SelectOperation(operation);
            }
            
            Console.WriteLine();
            Console.WriteLine();

        }
    }

    /// <summary>
    /// Main dialog options. User can select any of these to take action. 
    /// Current Options:
    /// List - lists the current exercises available.
    /// Run [exercise] - runs the selected exercise.
    /// [S]top - stopes the current exercise.
    /// Add - Adds an exercise to the list.
    /// Remove [exercise] - Removes an exercise from the list.
    /// Exit - exits the program.
    /// </summary>
    private void MainDialogue()
    {
        Console.WriteLine("**********************************************");
        Console.WriteLine("Breathing Exercises Console");
        Console.WriteLine("Please Select an Option:");
        Console.WriteLine("List - lists the exercises available.");
        Console.WriteLine("Run [exercise] - sets the exercise to run.");
        Console.WriteLine("[S]top - stops the current exercise.");
        Console.WriteLine("Add - creates an exercise.");
        Console.WriteLine("Remove [exercise] - removes an exercise");
        Console.WriteLine("Exit - exits the program.");
        Console.WriteLine("**********************************************");
    }

    /// <summary>
    /// The action selected by the user.
    /// </summary>
    /// <param name="operation">The operation the user wants to enact. Currently
    /// can be list, run, stop, add, remove, and exit. 
    /// </param>
    private void SelectOperation(string operation) 
    {
        switch (operation.ToLower().Split(" ")[0])
        {
            case "list":
                //List the breathing exercises
                foreach (Exercise exercise in Exercises)
                {
                    Console.WriteLine(exercise.Name);
                }
                break;

            case "run":
                //Run through an exercise
                if (operation.Split(" ").Length <= 1)
                {
                    Console.WriteLine("Exercise name is required. Try again.");
                }
                else
                {
                    string exerciseName = operation.ToLower().Split(" ")[1];
                    Exercise curExercise = GetExercise(exerciseName);
                    if (curExercise.Name != "Failed")
                    {
                        Console.WriteLine("How many times would you like to cycle through the breathing exercise?");
                        string? roundsString = Console.ReadLine();
                        int.TryParse(roundsString, out int rounds);
                        curExercise.Rounds = rounds;

                        Console.WriteLine("Starting " + curExercise.Name);
                        Task.Run(() =>
                        {
                            RunExercise(curExercise);
                        });
                    }
                }
                break;

            case "s" or "stop":
                StopExercise = true;
                break;

            case "add":
                //Add an exercise
                break;

            case "remove":
                //Remove an exercise
                break;

            case "exit":
                //Exit the program
                System.Environment.Exit(0);
                break;
        }
    }

    /// <summary>
    /// A list of common breathing exercises that are added at the start of the application.
    /// </summary>
    private void AddDefaultExercises()
    {
        Exercise box = new Exercise("Box", "Inhale, hold, exhale, hold, repeat: Used to help return breathing to normal after a stressful situation.", 5);
        box.AddStep(new Step(StepType.Inhale, 4));
        box.AddStep(new Step(StepType.Hold, 4));
        box.AddStep(new Step(StepType.Exhale, 4));
        box.AddStep(new Step(StepType.Hold, 4));

        Exercises.Add(box);

        Exercise _478 = new Exercise("478", "Inhale, hold, exhale: Helps with anxiety.", 4);
        _478.AddStep(new Step(StepType.Inhale, 4));
        _478.AddStep(new Step(StepType.Hold, 7));
        _478.AddStep(new Step(StepType.Exhale, 8));

        Exercises.Add(_478);
    }

    /// <summary>
    /// Gets the exercise from the list of exercises. 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private Exercise GetExercise(string name)
    {
        Exercise exercise;
        try
        {
            exercise = Exercises.First(x => x.Name.ToLower() == name.ToLower());                       
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exercise didn't exist. Please use the list to see available exercises.");
            exercise = new Exercise("Failed", "Failed");
        }
        return exercise;
    }

    /// <summary>
    /// Private run exercise used during the proof of concept stage. Remove when added to Exercise method.
    /// </summary>
    /// <param name="exercise"></param>
    private void RunExercise(Exercise exercise)
    {
        if (exercise == null)
        {
            return;
        }
        
        IsExerciseActive = true;

        for (int curRound = 0; curRound < exercise.Rounds; curRound++)
        {
            foreach (Step step in exercise.Steps)
            {
                Console.WriteLine(step.StepType);
                for (int i = 1; i <= step.StepTime; i++)
                {
                    if (StopExercise)
                    {
                        IsExerciseActive = false;
                        StopExercise = false;
                        return;
                    }

                    Console.WriteLine(i);
                    //Add timer to wait for a second.
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
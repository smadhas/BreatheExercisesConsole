namespace BreatheExercisesConsole.Exercises
{
    /// <summary>
    /// Container for the breathing exercise. Capable of containing 
    /// steps and running and stopping the breathing exercise. 
    /// </summary>
    public class Exercise
    {
        /// <summary>
        /// Name of the exercise.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the exercise. 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Number of times to repeat the exercise.
        /// </summary>
        public int Rounds { get; set; }

        /// <summary>
        /// The steps of the exercise. It can contain 
        /// inhale, exhale, and hold. 
        /// </summary>
        public List<Step> Steps;

        /// <summary>
        /// Base constructor.
        /// </summary>
        public Exercise() 
        {
            Steps = new List<Step>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of exercise.</param>
        /// <param name="description">Brief desciption of exercise.</param>
        public Exercise(string name, string description)
        {
            Name = name;
            Description = description;
            Rounds = 1;
            Steps = new List<Step>();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of exercise.</param>
        /// <param name="description">Brief description of exercise.</param>
        /// <param name="rounds">Number of times to repeat exercise.</param>
        public Exercise(string name, string description, int rounds)
        {
            Name = name;
            Description = description;
            Rounds = rounds;
            Steps = new List<Step>();
        }

        /// <summary>
        /// Adds a step to the end of the list of steps. 
        /// </summary>
        /// <param name="step"></param>
        public void AddStep(Step step)
        {
            Steps.Add(step);
        }

        /// <summary>
        /// Removes a step located at the index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemoveStep(int index)
        {
            try
            {
                if (Steps.Count > index && Steps[index] != null)
                {
                    Steps.RemoveAt(index);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        //Add Run

        //Add Stop
    }
}

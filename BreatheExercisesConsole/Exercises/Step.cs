namespace BreatheExercisesConsole.Exercises
{
    /// <summary>
    /// Different steps of the breathing exercise. Currently contains hold, inhale, and exhale.
    /// </summary>
    public enum StepType
    {
        Hold,
        Inhale,
        Exhale
    }

    /// <summary>
    /// Step object used to keep type and time for a particular step in the exercise.
    /// </summary>
    public class Step
    {
        /// <summary>
        /// The action to be taken during this step.
        /// </summary>
        public StepType StepType { get; private set; }

        /// <summary>
        /// The amount of time to perform the action during this step.
        /// </summary>
        public int StepTime { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stepType">The action to be taken during this step.</param>
        /// <param name="stepTime">The amount of time to perform the action during this step.</param>
        public Step(StepType stepType, int stepTime)
        {
            StepType = stepType;
            StepTime = stepTime;
        }
    }
}

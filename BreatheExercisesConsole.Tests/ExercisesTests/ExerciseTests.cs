using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BreatheExercisesConsole.Exercises;

namespace BreatheExercisesConsole.Tests.ExercisesTests
{
    public class ExerciseTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Exercise_AddStep_CheckCount()
        {
            //Arrange
            var exercise = new Exercise();
            Step step = new Step(StepType.Inhale, 5);

            //Act
            exercise.AddStep(step);

            //Assert
            Assert.Equal(Assert.Single(exercise.Steps), step);
        }

        [Fact]
        public void Exercise_RemoveStep_ReturnBool()
        {
            //Arrange - variables, classes, mocks
            var exercise = new Exercise();
            Step stepKeep = new Step(StepType.Inhale, 5);
            Step stepRemove = new Step(StepType.Exhale, 5);
            exercise.AddStep(stepKeep);
            exercise.AddStep(stepRemove);

            //Act - call the function
            var result = exercise.RemoveStep(1);

            //Assert
            Assert.True(result);
            Assert.Equal(Assert.Single(exercise.Steps), stepKeep);
            Assert.DoesNotContain(stepRemove, exercise.Steps);
        }
    }
}

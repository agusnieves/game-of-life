using GameOfLife.Api.Services;
using Xunit;
using System.Collections.Generic;
using static GameOfLife.Tests.Data.TestBoards;
using static common.Utils.Utils;

namespace GameOfLife.Tests
{
    public class GameOfLifeServiceTests
    {

        [Fact]
        public void GetNextState_WithEmptyBoardShouldReturnEmptyBoard()
        {
            var initialState = new List<List<int>>();

            var service = new GameOfLifeService();
            var result = service.GetNextState(initialState);

            Assert.Empty(result);
        }

        [Fact]
        public void GetNextState_FromFullAliveToDeadBoard()
        {
            var initialState = FullAliveBoard;
            var expectedNextState = CornersBoard;

            var service = new GameOfLifeService();
            var result = service.GetNextState(initialState);

            Assert.Equal(expectedNextState, result);

            result = service.GetNextState(result);
            
            Assert.Equal(DeadBoard, result);
        }

        [Fact]
        public void GetNextState_ShouldApplyRulesCorrectlyAndValidateNextState()
        {
            var initialState = LoopVertical;
            var expectedNextState = LoopHorizontal;

            var service = new GameOfLifeService();
            var result = service.GetNextState(initialState);

            Assert.Equal(expectedNextState, result);
        }

        [Fact]
        public void GetSelectedStepAheadState_WithTwoSteps_ShouldReturnOriginalState()
        {
            var initialState = LoopVertical;
            var expectedState = initialState;

            var service = new GameOfLifeService();
            var result = service.GetSelectedStepAheadState(initialState, 2);

            Assert.Equal(expectedState, result);  
        }

        [Fact]
        public void GetFinalState_WithCentralBoard_ShouldDie()
        {
            var initialState = CentralBoard;
            var expectedFinalState = DeadBoard;

            var service = new GameOfLifeService();
            var result = service.GetFinalState(initialState, out bool converged);

            Assert.True(converged, "The final state should converge.");
            Assert.Equal(expectedFinalState, result);
        }

        [Fact]
        public void GetFinalState_WithoutSettingAttepts_ShouldConverge()
        {
            var initialState = XBoard;
            var expectedFinalState = initialState;

            var service = new GameOfLifeService();
            var result = service.GetFinalState(initialState, out bool converged);

            Assert.True(converged, "The final state should converge.");
            Assert.Equal(expectedFinalState, result); 
        }

        [Fact]
        public void GetFinalState_WithLoopBoard_ShouldNotConverge()
        {
            var initialState = LoopVertical;
            var expectedNextState = LoopHorizontal;

            var service = new GameOfLifeService();
            var result = service.GetFinalState(initialState, out bool converged);

            Assert.False(converged, "The final state should not converge.");            
        } 
          
    }
}     
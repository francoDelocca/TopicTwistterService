using NUnit.Framework;
using TopicTwisterService.Player.Domain;

namespace TopicTwisterServiceTest
{
    public class MatchShould
    {
        Match match;       

        [Test]
        public void ReturnPlayerOneAsWinnerIfPlayerOneWonMoreRoundsThanPlayerTwo()
        {

            GivenANewMatch();

            WhenPlayerOneWinsTwoRoundsAndPlayerTwoWinsOne();

            ThenPlayerOneWinsTheMatch();
        }
       
        [Test]
        public void ReturnPlayerTwoAsWinnerIfPlayerOneWonMoreRoundsThanPlayerOne()
        {
            GivenANewMatch();

            WhenPlayerTwoWinsTwoRoundsAndPlayerOneWinsOne();

            ThenPlayerTwoWinsTheMatch();
        }       

        [Test]
        public void IncreaseNumberOfWinsByOneWhenPlayerWins()
        {
            GivenANewMatch();

            WhenPlayerTwoWinsTheMatch();

            ThenNumberOfWinsOfPlayerTwoIsIncreased();
        }

        [Test]
        public void ReturnAllRoundsWerePlayedIfSamePlayerWonTwoRounds()
        {
            GivenANewMatch();

            WhenSamePlayerWinsTwoRounds();

            ThenAllRoundsWerePlayed();
        }
        
        private void GivenANewMatch()
        {
            match = new Match();
            match.MatchId = 1;
            Player playerOne = new Player();
            playerOne.PlayerId = 1;
            Player playerTwo = new Player();
            playerTwo.PlayerId = 2;
            match.PlayerOne = playerOne;
            match.PlayerTwo = playerTwo;
        }

        private void WhenSamePlayerWinsTwoRounds()
        {
            Round round1 = new Round();
            round1.Match = match;
            round1.Winner = match.PlayerTwo;
            Round round2 = new Round();
            round2.Match = match;
            round2.Winner = match.PlayerTwo;

            match.Rounds.Add(round1);
            match.Rounds.Add(round2);
        }
        private void WhenPlayerOneWinsTwoRoundsAndPlayerTwoWinsOne()
        {
            Round round1, round2;
            round1 = new Round();
            round1.Match = match;
            round1.Winner = match.PlayerOne;
            round2 = new Round();
            round2.Match = match;
            round2.Winner = match.PlayerOne;
            Round round3 = new Round();
            round3.Match = match;
            round3.Winner = match.PlayerTwo;
            match.Rounds.Add(round1);
            match.Rounds.Add(round2);
            match.Rounds.Add(round3);
        }
        private void WhenPlayerTwoWinsTwoRoundsAndPlayerOneWinsOne()
        {
            Round round1 = new Round();
            round1.Match = match;
            round1.Winner = match.PlayerTwo;
            Round round2 = new Round();
            round2.Match = match;

            round2.Winner = match.PlayerOne;
            Round round3 = new Round();
            round3.Match = match;
            round3.Winner = match.PlayerTwo;
            match.Rounds.Add(round1);
            match.Rounds.Add(round2);
            match.Rounds.Add(round3);
        }
        private void WhenPlayerTwoWinsTheMatch()
        {
            match.MatchClosed = true;
            match.WinnerPlayer = match.PlayerTwo;
            match.AddWinToWinner();
        }

        private void ThenAllRoundsWerePlayed()
        {
            Assert.IsTrue(match.AllRoundsWerePlayed());
        }
        private void ThenNumberOfWinsOfPlayerTwoIsIncreased()
        {
            Assert.True(match.PlayerTwo.Wins == 1);
        }        
        private void ThenPlayerOneWinsTheMatch()
        {
            Assert.True(match.CalculateMatchWinner().PlayerId == match.PlayerOne.PlayerId);
        }
        private void ThenPlayerTwoWinsTheMatch()
        {
            Assert.True(match.CalculateMatchWinner().PlayerId == match.PlayerTwo.PlayerId);
        }
    }
}
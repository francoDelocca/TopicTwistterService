using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using TopicTwisterService.Player.Domain;

namespace TopicTwisterServiceTest
{
    public class GetListOfPendingAndFinishedMatchesUsesCasesTests
    {
        [SetUp]
        public void Setup()
        {
    
        }

        [Test]
        public void ShouldReturnPlayableIfIamPlayerOneAndLastRoundIsClosed()
        {
            //given
            
            List<Round> roundList = new List<Round>();
            roundList.Add(CreateNewRound(true));
            
            Match match = CreateMatchWithRounds(roundList,1,2,false);
            GetListOfFinishedAndPendingMatchesUseCases getListOfFinishedAndPendingMatchesUseCases =
                new GetListOfFinishedAndPendingMatchesUseCases(null);
            //when

            //then

        }
        

        [Test]
        public void ShouldReturnTwoPendingMatchesIfTheUserHasToUnfinishedMatches()
        {
            //given
    /*        var context = Substitute.For<DataContext>();
            GetListOfFinishedAndPendingMatchesUseCases getListOfFinishedAndPendingMatchesUseCases =
                new GetListOfFinishedAndPendingMatchesUseCases(context);

            List<Match> matches = new List<Match>();
            matches.Add(CreateNewMatch(1,2,false));

            var fakePendingMatches = FakeDbSet(matches);
            context.Matches.Returns(fakePendingMatches);

            //when
            var listOfPendingMatches = getListOfFinishedAndPendingMatchesUseCases.GetListOfFinishedMatches(1);
            //then
            Assert.True(1 == listOfPendingMatches.Result.Count);
        } 
        
        public static DbSet<T> FakeDbSet<T>(List<T> data) where T : class
        {
            var _data = data.AsQueryable();
            var fakeDbSet = Substitute.For<DbSet<T>, IQueryable<T>>();
            ((IQueryable<T>)fakeDbSet).Provider.Returns(_data.Provider);
            ((IQueryable<T>)fakeDbSet).Expression.Returns(_data.Expression);
            ((IQueryable<T>)fakeDbSet).ElementType.Returns(_data.ElementType);
            ((IQueryable<T>)fakeDbSet).GetEnumerator().Returns(_data.GetEnumerator());

            fakeDbSet.AsNoTracking().Returns(fakeDbSet);

            return fakeDbSet;*/
        }

        private Match CreateMatchWithRounds(List<Round> roundsList, int PlayerOneId, int PlayerTwoId, bool closed)
        {
            Match match = new Match();
            Player playerOne = new Player();
            playerOne.PlayerId = PlayerOneId;
            Player playerTwo = new Player();
            playerTwo.PlayerId = PlayerTwoId;
            match.PlayerOne = playerOne;
            match.PlayerTwo = playerTwo;
            match.MatchClosed = closed;
            match.Rounds = roundsList;
            return match;
            
        }

        private Round CreateNewRound(bool close)
        {

            Round round = new Round();
            round.Close = close;
            return round;

        }
 
        
        
        private Match CreateNewMatch(int PlayerOneId, int PlayerTwoId, bool closed)
        {
            Match match = new Match();
            Player playerOne = new Player();
            playerOne.PlayerId = PlayerOneId;
            Player playerTwo = new Player();
            playerTwo.PlayerId = PlayerTwoId;
            match.PlayerOne = playerOne;
            match.PlayerTwo = playerTwo;
            match.MatchClosed = closed;
            return match;
        }
        
        
    }
}
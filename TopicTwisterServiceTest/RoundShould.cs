using System.Collections.Generic;
using NUnit.Framework;
using TopicTwisterService.Player.Domain;
using System;

namespace TopicTwisterServiceTest
{
    public class RoundShould
    {

        Match match;        

        [Test]
        public void DeclarePlayerOneAsRoundWinnerIfPlayerOneEnteredMoreCorrectWords()
        {
            GivenANewMatch();
            WhenPlayerOneEnteredMoreCorrectWords();
            ThenPlayerOneWinsTheRound();
        }
      
        [Test]
        public void DeclarePlayerTwoAsRoundWinnerIfPlayerOneEnteredLessCorrectWords()
        {

            GivenANewMatch();
            WhenPlayerTwoEnteredMoreCorrectWords();
            ThenPlayerTwoWinsTheRound();
        }

        [Test]
        public void DeclarePlayerOneAsRoundWinnerIfBothPlayersEnteredSameAmmountOfCorrectWordsButPlayerOneWasFaster()
        {
            GivenANewMatch();            
            WhenRoundIsADrawButPlayerOneWasFaster();
            ThenPlayerOneWinsTheRound();
        }

        [Test]
        public void DeclarePlayerOneAsRoundWinnerIfBothPlayersEnteredSameAmmountOfWordsInTheSameTimeButPlayerOneHasLessWins()
        {
            GivenANewMatch();
            WhenRoundWasADrawAndNoneWasFasterButPlayerOneHasLessWins();
            ThenPlayerOneWinsTheRound();
        }
      
        [Test]
        public void DeclarePlayerTwoAsRoundWinnerIfBothPlayersEnteredSameAmmountOfWordsInTheSameTimeAndBothHaveTheSameAmountOfWins()
        {
            GivenANewMatch();

            WhenRoundWasADrawAndNoneWasFasterAndBothHaveTheSameAmountOfWins();

            ThenPlayerTwoWinsTheRound();
        }

        private void WhenRoundWasADrawAndNoneWasFasterAndBothHaveTheSameAmountOfWins()
        {
            match.PlayerOne.Wins = 3;
            match.PlayerTwo.Wins = 3;

            CreateCategoriesWithValidWords();
            Round round = new Round();
            round.Match = match;

            round.WordEnteredByPlayers = new List<WordsEnteredByPlayer>();
            round.Categories = CreateCategoriesWithValidWords();
            round.TimeByPlayerOne = 20;
            round.TimeByPlayerTwo = 20;
            AddWordsEnteredByPlayer(round, match.PlayerOne.PlayerId, "melon", "mandarin", "", "", "");
            AddWordsEnteredByPlayer(round, match.PlayerTwo.PlayerId, "", "", "", "madrid", "mandril");
            round.RoundLetter = 'm';
            match.Rounds.Add(round);
        }

        [Test]
        public void BeClosedAfterClosingIt()
        {

            Round round = new Round();
            round.CloseRound();
            
            Assert.True(round.Close);

        }


        private void GivenANewMatch()
        {
            match = new Match();
            Player playerOne = new Player();
            playerOne.PlayerId = 1;
            Player playerTwo = new Player();
            playerTwo.PlayerId = 2;
            match.PlayerOne = playerOne;
            match.PlayerTwo = playerTwo;
        }

        private List<Category> CreateCategoriesWithValidWords()
        {
            List<Category> categoriesList = new List<Category>();
            Category category1 = new Category();
            category1.CategoryId = 1;
            category1.Name = "Frutas y Verduras";
            category1.Words = new List<Word>() ;
            Word word = new Word();
            word.Categories = new List<Category>();
            word.WordId = 1;
            word.Name = "melon";
            category1.Words.Add(word);
            
            Category category2 = new Category();
            category2.CategoryId = 2;
            category2.Name = "idiomas";
            word = new Word();
            word.Categories = new List<Category>();
            word.WordId = 2;
            word.Name = "mandarin";
            category2.Words = new List<Word>();
            category2.Words.Add(word);

            Category category3 = new Category();
            category3.CategoryId = 3;
            category3.Name = "Cosas";
            word = new Word();
            word.Categories = new List<Category>();
            word.WordId = 3;
            word.Name = "manivela";
            category3.Words = new List<Word>();
            category3.Words.Add(word);

            Category category4 = new Category();
            category4.CategoryId =4;
            category4.Name = "Ciudades";
            word = new Word();
            word.Categories = new List<Category>();
            word.WordId = 4;
            word.Name = "madrid";
          
            category4.Words = new List<Word>();
            category4.Words.Add(word);

            Category category5 = new Category();
            category5.CategoryId = 5;
            category5.Name = "Animales";
            word = new Word();
            word.Categories = new List<Category>();
            word.WordId = 5;
            word.Name = "mandril";
            category5.Words = new List<Word>();
            category5.Words.Add(word);

            categoriesList.Add(category1);
            categoriesList.Add(category2);
            categoriesList.Add(category3);
            categoriesList.Add(category4);
            categoriesList.Add(category5);

            return categoriesList;
        }

        private void  AddWordsEnteredByPlayer(Round round, int playerId, string name1, string name2, string name3, string name4, string name5)
        {
            WordsEnteredByPlayer word1 = new WordsEnteredByPlayer();
            word1.CategoryId = 1;
            word1.
                WordEntered = name1;
            word1.PlayerId = playerId;
            word1.Category = round.Categories[0];
            
            WordsEnteredByPlayer word2 = new WordsEnteredByPlayer();
            word2.CategoryId = 2;
            word2.WordEntered = name2;
            word2.PlayerId = playerId;
            word2.Category = round.Categories[1];


            WordsEnteredByPlayer word3 = new WordsEnteredByPlayer();
            word3.CategoryId = 3;
            word3.WordEntered = name3;
            word3.PlayerId =  playerId;
            word3.Category = round.Categories[2];

            WordsEnteredByPlayer word4 = new WordsEnteredByPlayer();
            word4.CategoryId = 4;
            word4.WordEntered = name4;
            word4.PlayerId = playerId;
            word4.Category = round.Categories[3];

            WordsEnteredByPlayer word5 = new WordsEnteredByPlayer();
            word5.CategoryId = 5;
            word5.WordEntered = name5;
            word5.PlayerId =  playerId;
            word5.Category = round.Categories[4];
           
            round.WordEnteredByPlayers.Add(word1);
            round.WordEnteredByPlayers.Add(word2);
            round.WordEnteredByPlayers.Add(word3);
            round.WordEnteredByPlayers.Add(word4);
            round.WordEnteredByPlayers.Add(word5);

        }

       
        private void WhenPlayerOneEnteredMoreCorrectWords()
        {
            Round round = new Round();
            round.Match = match;
            round.WordEnteredByPlayers = new List<WordsEnteredByPlayer>();
            round.Categories = CreateCategoriesWithValidWords();
            AddWordsEnteredByPlayer(round, match.PlayerOne.PlayerId, "melon", "mandarin", "", "", "");
            AddWordsEnteredByPlayer(round, match.PlayerTwo.PlayerId, "melon", "hola", "perro", "", "");
            round.RoundLetter = 'm';
            match.Rounds.Add(round);
        }


        private void WhenRoundWasADrawAndNoneWasFasterButPlayerOneHasLessWins()
        {

            match.PlayerOne.Wins = 2;
            match.PlayerTwo.Wins = 3;

            Round round = new Round();
            round.Match = match;

            round.WordEnteredByPlayers = new List<WordsEnteredByPlayer>();
            round.Categories = CreateCategoriesWithValidWords();
            round.TimeByPlayerOne = 20;
            round.TimeByPlayerTwo = 20;
            AddWordsEnteredByPlayer(round, match.PlayerOne.PlayerId, "melon", "mandarin", "", "", "");
            AddWordsEnteredByPlayer(round, match.PlayerTwo.PlayerId, "", "", "", "madrid", "mandril");
            round.RoundLetter = 'm';
            match.Rounds.Add(round);
        }

        private void WhenPlayerTwoEnteredMoreCorrectWords()
        {
            Round round = new Round();
            round.Match = match;
            round.WordEnteredByPlayers = new List<WordsEnteredByPlayer>();
            round.Categories = CreateCategoriesWithValidWords();
            AddWordsEnteredByPlayer(round, match.PlayerOne.PlayerId, "melon", "mandarin", "", "", "");
            AddWordsEnteredByPlayer(round, match.PlayerTwo.PlayerId, "melon", "mandarin", "manivela", "madrid", "mandril");
            round.RoundLetter = 'm';
            match.Rounds.Add(round);
        }

        private void WhenRoundIsADrawButPlayerOneWasFaster()
        {
            Round round = new Round();
            round.Match = match;

            round.WordEnteredByPlayers = new List<WordsEnteredByPlayer>();
            round.Categories = CreateCategoriesWithValidWords();
            round.TimeByPlayerOne = 20;
            round.TimeByPlayerTwo = 10;
            AddWordsEnteredByPlayer(round, match.PlayerOne.PlayerId, "melon", "mandarin", "", "", "");
            AddWordsEnteredByPlayer(round, match.PlayerTwo.PlayerId, "", "", "", "madrid", "mandril");
            round.RoundLetter = 'm';
            match.Rounds.Add(round);
        }


        private void ThenPlayerOneWinsTheRound()
        {
            Assert.AreEqual(match.PlayerOne.PlayerId, match.Rounds[0].CalculateRoundWinner());
        }

        private void ThenPlayerTwoWinsTheRound()
        {
            Assert.AreEqual(match.PlayerTwo.PlayerId, match.Rounds[0].CalculateRoundWinner());
        }

    }
}
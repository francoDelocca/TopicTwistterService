using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace TopicTwisterServiceTest
{
    public class CategoryShould
    {
        private int _wordId = 0;


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReturnTrueWhenAWordBelongsToCategoryAndStartsWithTheRightLetter()
        {
            //Given
            string letter = "M";
            string word = "melon";
            var category = GivenACategoryAndAValidWordInTheDataBase(word);

            //then
            ThenAWordAWordStartingWithThatLetterShouldBeValidInThatCategory(category, word, letter);
        }


        [Test]
        public void ReturnFalseWhenAWordBelongsToCategoryAndStartsWithTheWrongLetter()
        {
            string letter = "L";
            string word = "melon";
            var category = GivenACategoryAndAValidWordInTheDataBase(word);

            //then
            ThenAWordAWordStartingWithADifferentLetterShouldBeInValidInThatCategory(category, word, letter);
        }
      

        [Test]
        public void ReturnFalseWhenAWordDoesNotBelongToCategoryAndStartsWithTheRightLetter()
        {
            
            //Given
            string letter = "M";
            string word = "melon";
            var category = GivenACategoryAndAValidWordInTheDataBase(word);

            string wrongWord = "manana";

            //then
            ThenAWordStartingWithTheRightLetterButMispelledShouldBeInValidInThatCategory(category, wrongWord, letter);
        }

        private void ThenAWordStartingWithTheRightLetterButMispelledShouldBeInValidInThatCategory(Category category,
            string wrongWord, string letter)
        {
            Assert.False(category.IsValidWord(wrongWord, letter));
        }

        private void AddWordToCategory(string word, Category category)
        {
            _wordId++;
            Word newWord = new Word();
            newWord.WordId = _wordId;
            newWord.Name = word;
            newWord.Categories = new List<Category> {category};
            category.Words.Add(newWord);
        }


        private static void ThenAWordAWordStartingWithThatLetterShouldBeValidInThatCategory(Category category, string word,
            string letter)
        {
            Assert.True(category.IsValidWord(word, letter));
        }

        private Category GivenACategoryAndAValidWordInTheDataBase(string word)
        {
            Category category = new Category();

            category.Words = new List<Word>();
            AddWordToCategory(word, category);
            return category;
        }
        
        private void ThenAWordAWordStartingWithADifferentLetterShouldBeInValidInThatCategory(Category category, string word,
            string letter)
        {
            Assert.False(category.IsValidWord(word, letter));
        }
    }
}
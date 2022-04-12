using System.Collections.Generic;
using System.Linq;
using TopicTwisterService.shared.Domain;

public class Category 
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public List<Word> Words { get; set; }

    public List<Round> Rounds { get; set; }

    public bool IsValidWord(string word, string letter)
    {
        if ((word != null) && (Words != null))
        {

            word = word.ToLower();
            letter = letter.ToLower();

                
            bool isAValidWord = this.Words
                .Any(w =>
                    w.Name.ToLower().StartsWith(letter)
                    && word.Contains(w.Name.ToLower()));


            return isAValidWord;
        }
        return false;

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TopicTwisterService.Player.Domain;

public class Round
{
    public int RoundId { get; set; }

    [ForeignKey("WinnerRoundPlayerId")] public Player Winner { get; set; }

    public int MatchId { get; set; }

    public Match Match { get; set; }

    public char RoundLetter { get; set; }

    public List<Category> Categories { set; get; }

    public List<WordsEnteredByPlayer> WordEnteredByPlayers { get; set; }

    public bool Close { get; set; }

    [NotMapped]
    public bool Open { get => !Close;}

    public int TimeByPlayerOne { get; set; }

    public int TimeByPlayerTwo { get; set; }

    public DateTime CreatedAt { get; set; }


    public Round()
    {
        this.CreatedAt = DateTime.Now;
    }

    public int CalculateRoundWinner()
    {
        int correctWordsPlayerOne = 0;
        int correctWordsPlayerTwo = 0;

        foreach (var roundWordEnteredByPlayer in WordEnteredByPlayers)
        {
            if (roundWordEnteredByPlayer.Category.IsValidWord(roundWordEnteredByPlayer.WordEntered,
                RoundLetter.ToString()))
            {
                if (roundWordEnteredByPlayer.PlayerId == Match.PlayerOne.PlayerId)
                {
                    correctWordsPlayerOne++;
                }
                else
                {
                    correctWordsPlayerTwo++;
                }
            }
        }


        return DefineWinner(correctWordsPlayerOne, correctWordsPlayerTwo);
    }

    private int DefineWinner(int correctWordsPlayerOne, int correctWordsPlayerTwo)
    {
        if (correctWordsPlayerOne > correctWordsPlayerTwo)
        {
            return (int)Match.PlayerOne.PlayerId;
        }
        else if (correctWordsPlayerOne < correctWordsPlayerTwo)
        {
            return (int)Match.PlayerTwo.PlayerId;
        }
        else
        {
            if (TimeByPlayerOne == TimeByPlayerTwo)
            {
                if (Match.PlayerOne.Wins < Match.PlayerTwo.Wins)
                {
                    return (int)Match.PlayerOne.PlayerId;
                }
                else
                {
                    return (int)Match.PlayerTwo.PlayerId;
                }
            }
            else
            {
                if (TimeByPlayerOne < TimeByPlayerTwo)
                {
                    return (int)Match.PlayerTwo.PlayerId;
                }
                else
                {
                    return (int)Match.PlayerOne.PlayerId;
                }
            }
            
        }
    }

    public void CloseRound()
    {
        Close = true;
    }

    public List<string> GetEnteredWordsFromPlayer(int playerId)
    {
        try
        {
            return WordEnteredByPlayers.Where(x => x.PlayerId == playerId).Select(x => x.WordEntered).ToList();
        }
        catch (Exception)
        {
            return new List<string>();
        }
    }
}
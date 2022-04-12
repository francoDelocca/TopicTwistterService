using System;
using System.Collections.Generic;
using System.Linq;
using TopicTwisterService.Player.Domain;

public class Match
{

    private const int TOTALROUNDS = 3;

    public int MatchId { get; set; }
    public bool MatchClosed { get; set; }

    public Player WinnerPlayer { get; set; }
    public Player PlayerOne { get; set; }
    public Player PlayerTwo { get; set; }
    public List<Round> Rounds { get; set; }

    public Match()
    {
        Rounds = new List<Round>();
    }

    public bool AllRoundsWerePlayed()
    {
        if (this.Rounds is not null && 
            (this.Rounds.Count(x => x.Winner.PlayerId == this.PlayerOne.PlayerId) == 2 || 
            this.Rounds.Count(x => x.Winner.PlayerId == this.PlayerTwo.PlayerId) == 2) || 
            this.Rounds.Count() == TOTALROUNDS)
        {
            return true;
        }

        return false;
    }

    public Match(Player playerOne, Round round)
    {
        Rounds = new List<Round>();
        round.MatchId = MatchId;
        round.Match = this;
        PlayerOne = playerOne;
        Rounds.Add(round);
    }

    public Round getCurrentRound()
    {
        return Rounds.Where(a => a.Close == false).First();
    }

    public bool HasRemaingRoundsToPlayer()
    {
        return Rounds.Count(x => x.Close) < TOTALROUNDS;
    }

    public Player CalculateMatchWinner()
    {
        int winsPlayerOne = 0;
        int winsPlayerTwo = 0;

        if (!AllRoundsWerePlayed())
        {
            throw new Exception("No se puede calcular el ganador, faltan rounds por jugar");
        }
        else
        {
            foreach (var round in Rounds)
            {

                if (round.Winner.PlayerId == PlayerOne.PlayerId)
                {
                    winsPlayerOne++;
                }
                else
                {
                    winsPlayerTwo++;
                }
            }

            if (winsPlayerOne == 2)
            {
                this.WinnerPlayer = this.PlayerOne;

                return PlayerOne;
            }
            else
            {
                this.WinnerPlayer = this.PlayerTwo;

                return PlayerTwo;
            }
        }


    }

    public void Close()
    {
        this.MatchClosed = true;
    }

    public void AddWinToWinner()
    {
        if (this.MatchClosed == true && this.WinnerPlayer.PlayerId == this.PlayerOne.PlayerId)
        {
            this.PlayerOne.Wins++;
        }
        else if (this.MatchClosed == true)
        {
            this.PlayerTwo.Wins++;
        }
    }
}

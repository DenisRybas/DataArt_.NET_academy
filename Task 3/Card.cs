#nullable enable
using System;
using System.Linq;

namespace Task3
{
    public class Card
    {
        public string Rank { get; }
        public char Suit { get; }

        public Card(string rank, char suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public static bool TryParse(string s, out Card? result)
        {
            var suit = s.Last();
            var rank = new string(s.Take(s.Length - 1).ToArray());
            if (CardService.Suits().Contains(suit) && CardService.Ranks().Contains<string>(rank))
            {
                result = new Card(rank, suit);
                return true;
            }

            result = null;
            return false;
        }

        public override string ToString()
        {
            return Rank + Suit;
        }
    }
}
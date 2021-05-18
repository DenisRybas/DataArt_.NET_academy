using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class CardService
    {
        public static IEnumerable<string> Ranks()
        {
            yield return "A";
            yield return "2";
            yield return "3";
            yield return "4";
            yield return "5";
            yield return "6";
            yield return "7";
            yield return "8";
            yield return "9";
            yield return "10";
            yield return "J";
            yield return "Q";
            yield return "K";
        }

        public static IEnumerable<char> Suits()
        {
            yield return '♣';
            yield return '♦';
            yield return '♥';
            yield return '♠';
        }

        public void Part1()
        {
            var startingDeck = Suits()
                .SelectMany(suit => Ranks().Select(rank => new Card(rank, suit)));

            var shuffledDeck = startingDeck.Shuffle(new Random(Environment.TickCount));
            var deck = shuffledDeck as Card[] ?? shuffledDeck.ToArray();
            Console.WriteLine($"First 6 elements: {string.Join(",", deck.Take(6))}");
            Console.WriteLine($"Second 6 elements: {string.Join(",", deck.Take(12).Skip(6))}");
        }

        public void Part2()
        {
            Card card;
            Console.WriteLine($"{Card.TryParse("10♣", out card)}, card: {card}");
            Card card1;
            Console.WriteLine($"{Card.TryParse("2♥", out card1)}, card: {card1}");
            Card card2;
            Console.WriteLine($"{Card.TryParse("251", out card2)}, card: {card2}");
        }

        public void Part3()
        {
            var notSortedDeck = new List<Card>()
            {
                new Card("A", '♠'),
                new Card("5", '♠'),
                new Card("4", '♠'),
                new Card("6", '♠'),
                new Card("A", '♥'),
                new Card("5", '♥'),
                new Card("4", '♥'),
                new Card("6", '♥')
            };

            var sortedSpadesDeck = notSortedDeck
                .OrderBy(card => card.Rank)
                .Where(card => card.Suit == '♠');
            Console.WriteLine($"Sorted spades deck: {string.Join(", ", sortedSpadesDeck)}");

            var sortedHeartsDeck = notSortedDeck
                .OrderBy(card => card.Rank != "A")
                .ThenBy(card => card.Rank)
                .Where(card => card.Suit == '♥');
            Console.WriteLine($"Sorted hearts deck: {string.Join(", ", sortedHeartsDeck)}");
        }

        public List<Card> Part4()
        {
            var partOfSeriesDeck1 = new List<Card>()
            {
                new Card("3", '♠'),
                new Card("4", '♥'),
            };

            var partOfSeriesDeck2 = new List<Card>()
            {
                new Card("5", '♣'),
                new Card("6", '♦')
            };

            var seriesDeck = partOfSeriesDeck1.Concat(partOfSeriesDeck2).ToList();

            var blacks = new List<char>
            {
                '♣',
                '♠'
            };

            var reds = new List<char>
            {
                '♦',
                '♥'
            };

            var cardRanks = Ranks().ToList();
            if (partOfSeriesDeck1.All(c => partOfSeriesDeck2.Any(c1 =>
                (blacks.Contains(c.Suit) && blacks.Contains(c1.Suit) || reds.Contains(c.Suit) && reds.Contains(c1.Suit))
                && cardRanks.IndexOf(c.Rank) == cardRanks.IndexOf(c1.Rank) - 2
            )))
                Console.WriteLine("Sequence is series!");
            return seriesDeck;
        }

        public void Part6()
        {
            var cards = new List<Card>()
            {
                new Card("3", '♠'),
                new Card("4", '♥'),
                new Card("5", '♣'),
                new Card("6", '♦'),
                new Card("A", '♦')
            };

            var sortedCards = cards
                .OrderBy(card => card.Rank != "A")
                .ThenBy(card => card.Rank);

            Console.WriteLine($"Highest/lowest hearts card: {sortedCards.Last(card => card.Suit == '♥')}/" +
                              $"{sortedCards.First(card => card.Suit == '♥')}\n" +
                              $"Highest/lowest clubs card: {sortedCards.Last(card => card.Suit == '♣')}/" +
                              $"{sortedCards.First(card => card.Suit == '♣')}\n" +
                              $"Highest/lowest diamonds card: {sortedCards.Last(card => card.Suit == '♦')}/" +
                              $"{sortedCards.First(card => card.Suit == '♦')}\n" +
                              $"Highest/lowest spades card: {sortedCards.Last(card => card.Suit == '♠')}/" +
                              $"{sortedCards.First(card => card.Suit == '♠')}");
        }
    }

    static class Extensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.Shuffle(new Random());
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (rng == null) throw new ArgumentNullException("rng");

            return source.ShuffleIterator(rng);
        }

        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (var i = 0; i < buffer.Count; i++)
            {
                var j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}
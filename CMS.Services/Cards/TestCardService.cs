using CMS.Services.Interfaces;
using CMS.Services.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Services.Cards
{
    class TestCardService : ICardService
    {
        private static readonly Random _rand;
        private static readonly string[] _letters;
        private static Card[] _cards;

        static TestCardService()
        {
            _rand = new Random(Environment.TickCount);
            _letters = Enumerable.Repeat('A', 26)
                .Select((c, i) => ((char)(c + i)).ToString())
                .ToArray();
            _cards = Enumerable.Repeat(0, 20)
                .Select(x => GetRandomCard())
                .ToArray();
        }

        public Task<Card[]> GetCardsAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                return _cards;
            });
        }

        public Task<Card> GetCardByIdAsync(Guid id)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                return _cards.FirstOrDefault(c => c.Id.Equals(id));
            });
        }

        public Task<Card> GetCardByNumberAsync(decimal cardNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Card> AddNewCardAsync(Card newCard)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                newCard.Id = Guid.NewGuid();
                _cards = _cards.Append(newCard).ToArray();
                return newCard;
            });

        }

        public Task RemoveCardAsync(Card card)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCardAsync(Card card)
        {
            throw new NotImplementedException();
        }


        private static Card GetRandomCard()
        {
            return new Card(Guid.NewGuid(), GetRandomCardNumber(), GetRandomCardHolder(), GetRandomExpirationDate());
        }

        private static DateTime GetRandomExpirationDate()
        {
            return DateTime.Now.AddDays(_rand.Next(365, 5 * 365));
        }

        private static string GetRandomCardHolder()
        {
            return RandomString(35);
        }

        private static string GetRandomCardNumber()
        {
            return RandomString(35);
        }

        private static bool RandomBoolean()
        {
            return _rand.Next(1, 100) < 50;
        }

        private static string RandomString(int size)
        {
            var letters = Enumerable.Repeat("", size)
                .Select(x => _letters[_rand.Next(0, _letters.Length - 1)])
                .ToArray();
            return string.Join("", letters);
        }


    }
}

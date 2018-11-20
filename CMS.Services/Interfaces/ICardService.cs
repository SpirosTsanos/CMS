using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Services.Models;

namespace CMS.Services.Interfaces
{
    public interface ICardService
    {
        Task<Card[]> GetCardsAsync();
        Task<Card> GetCardByIdAsync(Guid id);
        Task<Card> GetCardByNumberAsync(decimal cardNumber);
        Task<Card> AddNewCardAsync(Card newCard);
        Task RemoveCardAsync(Card card);
        Task UpdateCardAsync(Card card);
    }
}

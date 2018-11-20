using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Models
{
    public class Card
    {
        public Card() { }

        public Card(Guid id, string cardNumber, string cardHolder, DateTime expirationDate)
        {
            Id = id;
            CardNumber = cardNumber;
            CardHolder = cardHolder ?? throw new ArgumentNullException(nameof(cardHolder));
            ExpirationDate = expirationDate;
        }

        public Guid Id { get; set; }

        public string CardNumber { get; set; }

        public string CardHolder { get; set; }

        public DateTime ExpirationDate { get; set; }

    }
}

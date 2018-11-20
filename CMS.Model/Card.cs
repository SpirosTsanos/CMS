using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public enum CardBrand
    {
        Unknown = 0,
        VISA = 1,
        MasterCard = 2,
        Maestro = 3,
        AmericanExpress = 4
    }

    public enum CardType
    {
        Unknown = 0,
        DebitCard = 1,
        CreditCard = 2,
        FleetCard = 3,
        Prepaid = 4
    }

    public struct PAN
    {
        public int PAN1;
        public int PAN2;
        public int PAN3;
        public int PAN4;
    }

    public class Card : EntityBase
    {
        public Card(Guid id, Institution issuingBank, CardType cardType, CardBrand cardBrand, PAN cardNumber, int cardSecurityCode, string cardholderName, DateTime expirationDate)
        {
            Id = id.Equals(Guid.Empty) ? Guid.NewGuid() : id;
            IssuingBank = issuingBank;
            CardBrand = cardBrand;
            CardType = cardType;
            CardNumber = cardNumber;
            CardSecurityCode = cardSecurityCode;
            CardholderName = cardholderName;
            ExpirationDate = expirationDate;
        }

        public Institution IssuingBank { get; private set; }
        public CardType CardType { get; private set; }
        public CardBrand CardBrand { get; private set; }
        public PAN CardNumber { get; private set; }
        public int CardSecurityCode { get; private set; }
        public string CardholderName { get; private set; }
        public DateTime ExpirationDate { get; private set; }
    }
}

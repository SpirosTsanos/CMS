using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{

    public enum TransactionType
    {
        Unknown = 0,
        Purchase = 1,
        Withdrawal = 2,
        Deposit = 3,
        Refund = 4
    }

    public class CardTransaction : EntityBase
    {
        public CardTransaction(Guid id, DateTime transactionDate, TransactionType transactionType, decimal amount, int accountType, Card card, CardAcceptor cardAcceptor, Terminal terminal)
        {
            Id = id.Equals(Guid.Empty) ? Guid.NewGuid() : id;
            TransactionDate = transactionDate;
            TransactionType = transactionType;
            Amount = amount;
            AccountType = accountType;
            Card = card;
            CardAcceptor = cardAcceptor;
            Terminal = terminal;
        }

        public DateTime TransactionDate { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public decimal Amount { get; private set; }
        public int AccountType { get; private set; }
        public Card Card { get; private set; }
        public CardAcceptor CardAcceptor { get; private set; }
        public Terminal Terminal { get; private set; }
    }
}

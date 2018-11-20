using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class DBContextMock : IDBContext
    {
        public ISet<Customer> Customers { get; private set; }
        public ISet<CardAcceptor> CardAcceptors { get; private set; }
        public ISet<Terminal> Terminals { get; private set; }
        public ISet<Card> Cards { get; private set; }
        public ISet<CardTransaction> CardTransactions { get; private set; }

        public DBContextMock()
        {

        }

        public void InitializeDbContext()
        {
            Customers = new HashSet<Customer>() {
                new Customer(Guid.NewGuid(), "C1 First Name", "C1 Last Name", CustomerType.Retail),
                new Customer(Guid.NewGuid(), "C2 First Name", "C2 Last Name", CustomerType.Retail),
                new Customer(Guid.NewGuid(), "C3 First Name", "C3 Last Name", CustomerType.Corporate),
                new Customer(Guid.NewGuid(), "C4 First Name", "C4 Last Name", CustomerType.Retail),
                new Customer(Guid.NewGuid(), "C5 First Name", "C5 Last Name", CustomerType.Corporate),
                new Customer(Guid.NewGuid(), "C6 First Name", "C6 Last Name", CustomerType.Retail),
                new Customer(Guid.NewGuid(), "C7 First Name", "C7 Last Name", CustomerType.Corporate)
            };

            Cards = new HashSet<Card>()
            {
                new Card(Guid.NewGuid(),
                new Institution(Guid.NewGuid(), "Bank1"),
                CardType.CreditCard,
                CardBrand.MasterCard,
                new PAN(){ PAN1 = 1111, PAN2=2222, PAN3=3333, PAN4=4444},
                111,
                "Card Holder Name 1",
                DateTime.Now.Date.AddYears(1)),

                new Card(Guid.NewGuid(),
                new Institution(Guid.NewGuid(), "Bank2"),
                CardType.DebitCard,
                CardBrand.Maestro,
                new PAN(){ PAN1 = 2222, PAN2=2222, PAN3=3333, PAN4=4444},
                222,
                "Card Holder Name 2",
                DateTime.Now.Date.AddYears(1)),

                new Card(Guid.NewGuid(),
                new Institution(Guid.NewGuid(), "Bank3"),
                CardType.DebitCard,
                CardBrand.Maestro,
                new PAN(){ PAN1 = 3333, PAN2=2222, PAN3=3333, PAN4=4444},
                333,
                "Card Holder Name 3",
                DateTime.Now.Date.AddYears(1)),

                new Card(Guid.NewGuid(),
                new Institution(Guid.NewGuid(), "Bank4"),
                CardType.CreditCard,
                CardBrand.VISA,
                new PAN(){ PAN1 = 4444, PAN2=2222, PAN3=3333, PAN4=4444},
                444,
                "Card Holder Name 4",
                DateTime.Now.Date.AddYears(1)),

                new Card(Guid.NewGuid(),
                new Institution(Guid.NewGuid(), "Bank5"),
                CardType.CreditCard,
                CardBrand.AmericanExpress,
                new PAN(){ PAN1 = 5555, PAN2=2222, PAN3=3333, PAN4=4444},
                555,
                "Card Holder Name 5",
                DateTime.Now.Date.AddYears(1)),

                new Card(Guid.NewGuid(),
                new Institution(Guid.NewGuid(), "Bank6"),
                CardType.Prepaid,
                CardBrand.Maestro,
                new PAN(){ PAN1 = 6565, PAN2=2222, PAN3=3333, PAN4=4444},
                656,
                "Card Holder Name 6",
                DateTime.Now.Date.AddYears(1)),

                new Card(Guid.NewGuid(),
                new Institution(Guid.NewGuid(), "Bank7"),
                CardType.CreditCard,
                CardBrand.AmericanExpress,
                new PAN(){ PAN1 = 7777, PAN2=2222, PAN3=3333, PAN4=4444},
                777,
                "Card Holder Name 7",
                DateTime.Now.Date.AddYears(1)),

                new Card(Guid.NewGuid(),
                new Institution(Guid.NewGuid(), "Bank8"),
                CardType.CreditCard,
                CardBrand.AmericanExpress,
                new PAN(){ PAN1 = 8888, PAN2=2222, PAN3=3333, PAN4=4444},
                888,
                "Card Holder Name 8",
                DateTime.Now.Date.AddYears(1))
            };

            CardAcceptors = new HashSet<CardAcceptor>()
            {
                new CardAcceptor(Guid.NewGuid(), "Card Acceptor1"),
                new CardAcceptor(Guid.NewGuid(), "Card Acceptor2"),
                new CardAcceptor(Guid.NewGuid(), "Card Acceptor3")
            };

            Terminals = new HashSet<Terminal>()
            {
                new Terminal(Guid.NewGuid(), "Terminal1"),
                new Terminal(Guid.NewGuid(), "Terminal2"),
                new Terminal(Guid.NewGuid(), "Terminal3"),
                new Terminal(Guid.NewGuid(), "Terminal4"),
                new Terminal(Guid.NewGuid(), "Terminal5"),
                new Terminal(Guid.NewGuid(), "Terminal6"),
                new Terminal(Guid.NewGuid(), "Terminal7"),
                new Terminal(Guid.NewGuid(), "Terminal8")
            };

            CardTransactions = new HashSet<CardTransaction>()
            {
                new CardTransaction(Guid.NewGuid(), DateTime.Now, TransactionType.Purchase, 123.45m, 1,  Cards.Skip(0).Take(0).FirstOrDefault(), CardAcceptors.Skip(0).Take(0).FirstOrDefault(), Terminals.Skip(0).Take(0).FirstOrDefault()),
                new CardTransaction(Guid.NewGuid(), DateTime.Now, TransactionType.Purchase, 123.45m, 1,  Cards.Skip(1).Take(0).FirstOrDefault(), CardAcceptors.Skip(1).Take(0).FirstOrDefault(), Terminals.Skip(1).Take(0).FirstOrDefault()),
                new CardTransaction(Guid.NewGuid(), DateTime.Now, TransactionType.Deposit, 123.45m, 1,  Cards.Skip(2).Take(0).FirstOrDefault(), CardAcceptors.Skip(2).Take(0).FirstOrDefault(), Terminals.Skip(2).Take(0).FirstOrDefault()),
                new CardTransaction(Guid.NewGuid(), DateTime.Now, TransactionType.Withdrawal, 123.45m, 1,  Cards.Skip(3).Take(0).FirstOrDefault(), CardAcceptors.Skip(0).Take(0).FirstOrDefault(), Terminals.Skip(3).Take(0).FirstOrDefault()),
                new CardTransaction(Guid.NewGuid(), DateTime.Now, TransactionType.Purchase, 123.45m, 1,  Cards.Skip(4).Take(0).FirstOrDefault(), CardAcceptors.Skip(1).Take(0).FirstOrDefault(), Terminals.Skip(4).Take(0).FirstOrDefault()),
                new CardTransaction(Guid.NewGuid(), DateTime.Now, TransactionType.Purchase, 123.45m, 1,  Cards.Skip(5).Take(0).FirstOrDefault(), CardAcceptors.Skip(2).Take(0).FirstOrDefault(), Terminals.Skip(5).Take(0).FirstOrDefault()),
                new CardTransaction(Guid.NewGuid(), DateTime.Now, TransactionType.Purchase, 123.45m, 1,  Cards.Skip(6).Take(0).FirstOrDefault(), CardAcceptors.Skip(0).Take(0).FirstOrDefault(), Terminals.Skip(6).Take(0).FirstOrDefault()),
                new CardTransaction(Guid.NewGuid(), DateTime.Now, TransactionType.Purchase, 123.45m, 1,  Cards.Skip(7).Take(0).FirstOrDefault(), CardAcceptors.Skip(1).Take(0).FirstOrDefault(), Terminals.Skip(7).Take(0).FirstOrDefault())
            };
        }

        public void Add(EntityBase entity)
        {
            if (entity is Customer)
            {
                Customers.Add(entity as Customer);
                return;
            }

            if (entity is Card)
            {
                Cards.Add(entity as Card);
                return;
            }

            if (entity is CardTransaction)
            {
                CardTransactions.Add(entity as CardTransaction);
                return;
            }

        }

        public void RemoveByKey(Guid key)
        {

        }

        public void Remove(EntityBase entity)
        {
            if (entity is Customer)
            {
                Customers.Remove(entity as Customer);
                return;
            }

            if (entity is Card)
            {
                Cards.Remove(entity as Card);
                return;
            }

            if (entity is CardTransaction)
            {
                CardTransactions.Remove(entity as CardTransaction);
                return;
            }
        }

        public void Update(EntityBase entity)
        {
            if (entity is Customer)
            {
                var customerItem = Customers.First(c => c.Id.Equals(entity.Id));
                Customers.Remove(customerItem);
                Customers.Add(entity as Customer);
                return;
            }

            if (entity is Card)
            {
                var cardItem = Cards.First(c => c.Id.Equals(entity.Id));
                Cards.Remove(cardItem as Card);
                Cards.Add(entity as Card);
                return;
            }

            if (entity is CardTransaction)
            {
                var cardTransactionItem = CardTransactions.First(c => c.Id.Equals(entity.Id));
                CardTransactions.Remove(cardTransactionItem as CardTransaction);
                CardTransactions.Add(entity as CardTransaction);
                return;
            }
        }
    }
}

using CMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CMS.NewCard.CardIssuingBankInfo
{
    public class CardIssuingBankInfoViewModel : BaseViewModel, IDataErrorInfo
    {
        protected readonly Dictionary<string, string> _errors;

        public CardIssuingBankInfoViewModel()
        {
            _errors = new Dictionary<string, string>();
            ExpirationDate = DateTime.Now;
        }

        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get => _expirationDate;
            set
            {
                SetPropertyValue(ref _expirationDate, value);
            }
        }

        private string _cardIssuingBank;
        public string CardIssuingBank
        {
            get => _cardIssuingBank;
            set
            {
                SetPropertyValue(ref _cardIssuingBank, value);
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (_errors.ContainsKey(columnName))
                    return _errors[columnName];
                return null;
            }
        }

        public string Error => _errors
            .Select(x => x.Value)
            .FirstOrDefault();

        public override bool HasErrors => string.IsNullOrWhiteSpace(CardIssuingBank)
                                          || string.IsNullOrWhiteSpace(CardIssuingBank)
                                          || _errors.Any();


        private void Validate(object value, ValidationRule validator, [CallerMemberName] string propertyName = null)
        {
            var error = validator.Validate(value, null);
            if (!error.IsValid)
                _errors[nameof(propertyName)] = error.ErrorContent as string;
            else
                _errors.Remove(nameof(propertyName));
            OnErrorsChanged();
        }
    }
}

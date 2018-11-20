using CMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace CMS.NewCard.CardInfo
{
    public class CardInfoViewModel : BaseViewModel, IDataErrorInfo
    {
        protected readonly Dictionary<string, string> _errors;

        public CardInfoViewModel()
        {
            _errors = new Dictionary<string, string>();
        }

        private string _cardname;
        public string CardNumber
        {
            get => _cardname;
            set
            {
                SetPropertyValue(ref _cardname, value);
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

        public override bool HasErrors => string.IsNullOrWhiteSpace(CardNumber)
                                          || string.IsNullOrWhiteSpace(CardNumber)
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
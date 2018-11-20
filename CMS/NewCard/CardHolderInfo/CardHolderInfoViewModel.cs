using CMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CMS.NewCard.CardHolderInfo
{
    public class CardHolderInfoViewModel : BaseViewModel, IDataErrorInfo
    {
        protected readonly Dictionary<string, string> _errors;

        public CardHolderInfoViewModel()
        {
            _errors = new Dictionary<string, string>();
        }

        private string _cardHolder;
        public string CardHolder
        {
            get => _cardHolder;
            set
            {
                SetPropertyValue(ref _cardHolder, value);
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

        public override bool HasErrors => string.IsNullOrWhiteSpace(CardHolder)
                                          || string.IsNullOrWhiteSpace(CardHolder)
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

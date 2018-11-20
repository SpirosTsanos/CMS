using CMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace CMS.NewClient.AddressInfo
{
    public class AddressInfoViewModel : BaseViewModel, IViewModel, IFlowElement, IDataErrorInfo
    {
        private Dictionary<string, string> _errors;

        public AddressInfoViewModel()
        {
            _errors = new Dictionary<string, string>();
        }

        private string _addressName;
        public string AddressName
        {
            get => _addressName;
            set
            {
                SetPropertyValue(ref _addressName, value);
                Validate(value, new AddressNameValidator());
            }
        }

        private string _city;
        public string City
        {
            get => _city;
            set
            {
                SetPropertyValue(ref _city, value);
                Validate(value, new AddressNameValidator());
            }
        }

        private string _addressNumber;

        public string AddressNumber
        {
            get { return _addressNumber; }
            set {
                SetPropertyValue(ref _addressNumber, value);
                Validate(value, new AddressNumberValidator());
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

        public override bool HasErrors => string.IsNullOrWhiteSpace(AddressName)
                                          || string.IsNullOrWhiteSpace(City)
                                          || _errors.Any();

        public bool IsHomeView => false;
        public bool IsLastView => true;

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
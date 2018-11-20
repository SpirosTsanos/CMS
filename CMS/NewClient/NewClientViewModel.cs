using CMS.NewClient.AddressInfo;
using CMS.NewClient.PersonalInfo;
using CMS.Tools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using CMS.Services.Interfaces;
using CMS.Services.Models;

namespace CMS.NewClient
{
    public class NewClientViewModel : BaseViewModel, IViewModel
    {
        private const string VIEW_MODEL_NAME = "Customer";
        private IClientService _clientService;
        private BaseViewModel currentViewModel;

        public NewClientViewModel(IClientService _clientService)
        {
            this._clientService = _clientService;

            currentViewModel = FlowManager.Instance.FlowMove(VIEW_MODEL_NAME, FlowMove.HOME) as BaseViewModel;
            currentViewModel.ErrorsChanged -= currentViewModel_ErrorsChanged;
            currentViewModel.ErrorsChanged += currentViewModel_ErrorsChanged;

            ActiveViewModel = currentViewModel;

            PreviousStep = new RelayCommand(OnPreviousStep, CanGoPrevious);
            NextStep = new RelayCommand(OnNextStep, CanGoNext);
        }

        private void currentViewModel_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            NextStep.OnCanExecuteChanged();
        }

        private BaseViewModel _activeViewModel;
        public BaseViewModel ActiveViewModel
        {
            get => _activeViewModel;
            set => SetPropertyValue(ref _activeViewModel, value);
        }

        public RelayCommand PreviousStep { get; set; }

        private bool CanGoPrevious(object param)
        {
            return true; //!ActiveViewModel.HasErrors;
        }

        private void OnPreviousStep(object param)
        {
            CacheChanges();

            if (FlowManager.Instance.IsFlowAtFirstIndex(VIEW_MODEL_NAME))
            {
                OnReturnedToWelcomePage();
                return;
            }

            currentViewModel = FlowManager.Instance.FlowMove(VIEW_MODEL_NAME, FlowMove.BACK) as BaseViewModel;
            currentViewModel.ErrorsChanged -= currentViewModel_ErrorsChanged;
            currentViewModel.ErrorsChanged += currentViewModel_ErrorsChanged;

            ActiveViewModel = currentViewModel;
        }

        public RelayCommand NextStep { get; set; }

        private bool CanGoNext(object param)
        {
            return true; //!ActiveViewModel.HasErrors;
        }

        private void OnNextStep(object param)
        {
            CacheChanges();

            // if last FlowViewModel then Save Cache Changes and return to Welcome FlowViewModel
            if (FlowManager.Instance.IsFlowAtLastIndex(VIEW_MODEL_NAME))
            {
                var taskResult = SaveChangesAsync();

                OnReturnedToWelcomePage();
                return;
            }

            currentViewModel = FlowManager.Instance.FlowMove(VIEW_MODEL_NAME, FlowMove.NEXT) as BaseViewModel;
            currentViewModel.ErrorsChanged -= currentViewModel_ErrorsChanged;
            currentViewModel.ErrorsChanged += currentViewModel_ErrorsChanged;

            ActiveViewModel = currentViewModel;
        }

        private async Task<Client> SaveChangesAsync()
        {
            var client = this.Data as Client;
            var newClient = await this._clientService.AddNewClientAsync(client);
            return newClient;
        }

        private void CacheChanges()
        {
            if (currentViewModel is PersonalInfoViewModel personalInfoViewModel)
            {
                if (this.Data == null) this.Data = new Client();
                var client = this.Data as Client;
                client.Name = personalInfoViewModel.Name;
                client.Lastname = personalInfoViewModel.LastName;
                client.Birthday = personalInfoViewModel.Birthday;
            }
            if (currentViewModel is AddressInfoViewModel addressInfoViewModel)
            {
                if (this.Data == null) this.Data = new Client();
                var client = this.Data as Client;
                client.Address = new Address() { City = addressInfoViewModel.City, StreeName = addressInfoViewModel.AddressName, StreetNumber = int.Parse(addressInfoViewModel?.AddressNumber?.Replace(" ", "") ?? "0") };
                client.Type = ClientTypeEnum.Ιδιώτης;
            }

        }

    }
}

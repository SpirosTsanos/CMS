using CMS.Interfaces;
using CMS.MainClient;
using CMS.NewCard;
using CMS.NewClient;
using CMS.Services.Interfaces;
using CMS.Tools;
using System;

namespace CMS
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IClientService _clientService;
        private ICardService _cardService;

        private ClientsViewModel _clientsViewModel;
        private NewClientViewModel _newClientViewModel;
        private NewCardViewModel _newCardViewModel;


        public string AuthToken { get; private set; }

        private BaseViewModel _activeView;
        public BaseViewModel ActiveView
        {
            get => _activeView;
            set => SetPropertyValue(ref _activeView, value);
        }

        public MainWindowViewModel()
        {
            _clientService = App.ClientFactory.InstatiateService();
            _clientsViewModel = new ClientsViewModel(_clientService);

            _clientsViewModel.OnAddNewClient += ClientsViewModelOnAddNewClient;
            _clientsViewModel.OnAddNewCard += ClientsViewModelOnAddNewCard;
        }

        private void ClientsViewModelOnAddNewClient(BaseViewModel sender)
        {
            if (_newClientViewModel == null)
            {
                if (_cardService == null)
                    _cardService = App.CardFactory.InstatiateService();
                _newClientViewModel = new NewClientViewModel(_clientService);
            }


            _newClientViewModel.ReturnedToWelcomePage -= _newClientViewModel_ReturnedToWelcomePage;
            _newClientViewModel.ReturnedToWelcomePage += _newClientViewModel_ReturnedToWelcomePage;

            ActiveView = _newClientViewModel;
        }

        private void ClientsViewModelOnAddNewCard(IViewModel sender)
        {
            if (_newCardViewModel == null)
            {
                if (_cardService == null)
                    _cardService = App.CardFactory.InstatiateService();
                _newCardViewModel = new NewCardViewModel(_cardService);
            }

            _newCardViewModel.ReturnedToWelcomePage -= _newCardViewModel_ReturnedToWelcomePage;
            _newCardViewModel.ReturnedToWelcomePage += _newCardViewModel_ReturnedToWelcomePage;

            ActiveView = _newCardViewModel;
        }

        private void _newCardViewModel_ReturnedToWelcomePage(object sender, EventArgs e)
        {
            ActiveView = _clientsViewModel;
        }

        private void _newClientViewModel_ReturnedToWelcomePage(object sender, EventArgs e)
        {
            ActiveView = _clientsViewModel;
        }

        public async void LoadAuthToken(IClosable owner)
        {
            ActiveView = _clientsViewModel;

            //var service = App.LoginFactory.InstatiateService();
            //var token = await service.Authenticate();
            //if (string.IsNullOrWhiteSpace(token))
            //{
            //    owner.Close();
            //}
            //else
            //{
            //    MessageBox.Show(token);
            //    _clientService.AuthToken = token;
            //    ActiveView = new ClientsViewModel(_clientService);
            //}

        }

    }
}

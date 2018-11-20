using CMS.NewCard.CardHolderInfo;
using CMS.NewCard.CardInfo;
using CMS.NewCard.CardIssuingBankInfo;
using CMS.Services.Interfaces;
using CMS.Services.Models;
using CMS.Tools;
using System.Threading.Tasks;
using System.Windows;

namespace CMS.NewCard
{
    public class NewCardViewModel : BaseViewModel
    {
        private const string VIEW_MODEL_NAME = "Card";
        private ICardService _cardService;
        private BaseViewModel currentViewModel;

        public NewCardViewModel(ICardService cardService)
        {
            this._cardService = cardService;

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



        private async Task<Card> SaveChangesAsync()
        {
            var card = this.Data as Card;
            var newCard = await this._cardService.AddNewCardAsync(card);
            return newCard;
        }

        private void CacheChanges()
        {
            if (currentViewModel is CardInfoViewModel cardInfoViewModel)
            {
                if (this.Data == null) this.Data = new Card();
                var card = this.Data as Card;

                card.CardNumber = cardInfoViewModel.CardNumber;
            }
            if (currentViewModel is CardIssuingBankInfoViewModel cardIssuingBankInfoViewModel)
            {
                if (this.Data == null) this.Data = new Card();
                var card = this.Data as Card;
                card.ExpirationDate = cardIssuingBankInfoViewModel.ExpirationDate;
            }
            if (currentViewModel is CardHolderInfoViewModel cardHolderInfoViewModel)
            {
                if (this.Data == null) this.Data = new Card();
                var card = this.Data as Card;
                card.CardHolder= cardHolderInfoViewModel.CardHolder;
            }

        }
    }
}

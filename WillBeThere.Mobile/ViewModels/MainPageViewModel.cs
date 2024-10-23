using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WillBeThere.Mobile.Controls;
using MediatR;
using WillBeThere.ApplicationLayer.Queries.OrganizationCategories;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Contracts.Dtos.ResultModels;
using WillBeThere.ApplicationLayer.Queries.OrganizationPrograms;

namespace WillBeThere.Mobile.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private readonly Task _initTask;

        private List<PublicOrganizationProgramDto> allPublicOrganizationPrograms = new List<PublicOrganizationProgramDto>();
        private HashSet<string> _selectedOrganizationCategories = new HashSet<string>();
        
        [ObservableProperty] private List<PublicOrganizationProgramDto> _selectedPublicOrganizationPrograms = new();
        [ObservableProperty] private List<OrganizationCategoryDto> _organizationCategories = new();

        [ObservableProperty] private string _searchProgramTite=string.Empty;
        [ObservableProperty] private bool _isBusy=false;

        public MainPageViewModel()
        {
            _initTask = InitializeData();
        }

        public MainPageViewModel(IMediator? mediator)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator), $"{nameof(MainPageViewModel)} osztályban a mediator inicializálása nem sikerült." );
            _initTask=InitializeData();
        }

        private async Task InitializeData()
        {
            IsBusy = true;

            OrganizationCategories = await _mediator.Send(new GetOrganizationsCategoriesQuery());
            allPublicOrganizationPrograms = await _mediator.Send(new GetPublicOrgranizationProgramListQuery());
            SelectedPublicOrganizationPrograms = new List<PublicOrganizationProgramDto>(allPublicOrganizationPrograms);
            IsBusy = false;
        }

        [RelayCommand]
        private void PerformSearchByProgramTitle(string programTitle)
        {
            
            if (string.IsNullOrEmpty(programTitle))
                SelectedPublicOrganizationPrograms=new List<PublicOrganizationProgramDto>(allPublicOrganizationPrograms);
            else
            {
                List<PublicOrganizationProgramDto> newPublicOrganizationPrograms =allPublicOrganizationPrograms.Where(publicPrograms => publicPrograms.Title.Contains(programTitle, StringComparison.OrdinalIgnoreCase)).ToList();
                SelectedPublicOrganizationPrograms.Clear();
                SelectedPublicOrganizationPrograms = new List<PublicOrganizationProgramDto>(newPublicOrganizationPrograms);
            }               
        }

        [RelayCommand]
        private void PerformSearchByOrganizationCategory(MUIChipCommandParameter commandParameter)
        {
            if (commandParameter.IsSelected)
                _selectedOrganizationCategories.Add(commandParameter.ChipName);
            else
                _selectedOrganizationCategories.Remove(commandParameter.ChipName);
            FilteringByOrganizationCategory();

        }

        private void FilteringByOrganizationCategory()
        {
            List<PublicOrganizationProgramDto> newSelectedPrograms = new List<PublicOrganizationProgramDto>();

            SelectedPublicOrganizationPrograms.Clear();
            if ((_selectedOrganizationCategories is null || !_selectedOrganizationCategories.Any()))
                SelectedPublicOrganizationPrograms = new List<PublicOrganizationProgramDto>(allPublicOrganizationPrograms);
            else
            {

                foreach (string organizationCategoryName in _selectedOrganizationCategories)
                {
                    List<PublicOrganizationProgramDto> newPublicOrganizationPrograms = allPublicOrganizationPrograms.Where(publicProgram => publicProgram.OrganizationCategory == organizationCategoryName).ToList();
                    newSelectedPrograms.AddRange(newPublicOrganizationPrograms);
                }
                SelectedPublicOrganizationPrograms = new List<PublicOrganizationProgramDto>(newSelectedPrograms);
            }
        }
    }
}

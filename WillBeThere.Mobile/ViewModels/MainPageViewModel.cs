using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WillBeThere.Mobile.Controls;
using WillBeThere.Domain.Models.ResultModels;
using WillBeThere.Domain.Entites;
using WillBeThere.Application.Services.DataService;

namespace WillBeThere.Mobile.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly IOrganizationProgramDataService? _organizationProgramDataService;
        private readonly IOrganizationCategoryDataService? _organizationCategoryDataService;
        private readonly Task _initTask;

        private List<PublicOrganizationProgram> allPublicOrganizationPrograms = new List<PublicOrganizationProgram>();
        private HashSet<string> _selectedOrganizationCategories = new HashSet<string>();
        
        [ObservableProperty] private List<PublicOrganizationProgram> _selectedPublicOrganizationPrograms = new();
        [ObservableProperty] private List<OrganizationCategory> _organizationCategories = new();

        [ObservableProperty] private string _searchProgramTite=string.Empty;
        [ObservableProperty] private bool _isBusy=false;

        public MainPageViewModel()
        {
            _initTask = InitializeData();
        }

        public MainPageViewModel(
            IOrganizationProgramDataService organizationProgramDataService,
            IOrganizationCategoryDataService organizationCategoryDataService
            )
        {
            _organizationProgramDataService = organizationProgramDataService;
            _organizationCategoryDataService = organizationCategoryDataService;
            _initTask=InitializeData();
        }

        private async Task InitializeData()
        {
            IsBusy = true;
            if (_organizationProgramDataService is not null)
            {
                allPublicOrganizationPrograms = await _organizationProgramDataService.GetAllPublicOrganizationProgramsAsync();               
                SelectedPublicOrganizationPrograms = new List<PublicOrganizationProgram>(allPublicOrganizationPrograms);
            }
            if (_organizationCategoryDataService is not null)
            {
                OrganizationCategories = await _organizationCategoryDataService.SelectAsync();
            }
            IsBusy = false;
        }

        [RelayCommand]
        private void PerformSearchByProgramTitle(string programTitle)
        {
            
            if (string.IsNullOrEmpty(programTitle))
                SelectedPublicOrganizationPrograms=new List<PublicOrganizationProgram>(allPublicOrganizationPrograms);
            else
            {
                List<PublicOrganizationProgram> newPublicOrganizationPrograms =allPublicOrganizationPrograms.Where(publicPrograms => publicPrograms.Title.Contains(programTitle, StringComparison.OrdinalIgnoreCase)).ToList();
                SelectedPublicOrganizationPrograms.Clear();
                SelectedPublicOrganizationPrograms = new List<PublicOrganizationProgram>(newPublicOrganizationPrograms);
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
            List<PublicOrganizationProgram> newSelectedPrograms = new List<PublicOrganizationProgram>();

            SelectedPublicOrganizationPrograms.Clear();
            if ((_selectedOrganizationCategories is null || !_selectedOrganizationCategories.Any()))
                SelectedPublicOrganizationPrograms = new List<PublicOrganizationProgram>(allPublicOrganizationPrograms);
            else
            {

                foreach (string organizationCategoryName in _selectedOrganizationCategories)
                {
                    List<PublicOrganizationProgram> newPublicOrganizationPrograms = allPublicOrganizationPrograms.Where(publicProgram => publicProgram.OrganizationCategory == organizationCategoryName).ToList();
                    newSelectedPrograms.AddRange(newPublicOrganizationPrograms);
                }
                SelectedPublicOrganizationPrograms = new List<PublicOrganizationProgram>(newSelectedPrograms);
            }
        }
    }
}

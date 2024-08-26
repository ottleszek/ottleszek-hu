using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WillBeThere.HttpService.DataService;
using WillBeThere.Shared.Models;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.Mobile.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly IOrganizationProgramDataService? _organizationProgramDataService;
        private readonly IOrganizationCategoryDataService? _organizationCategoryDataService;

        private readonly Task _initTask;
        private List<PublicOrganizationProgram> _allPublicOrganizationProgramList=new List<PublicOrganizationProgram>();
        
        [ObservableProperty] private List<PublicOrganizationProgram> _publicOrganizationPrograms = new();
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
                PublicOrganizationPrograms = await _organizationProgramDataService.GetAllPublicOrganizationProgramsAsync();
                _allPublicOrganizationProgramList.AddRange(PublicOrganizationPrograms);                
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
                PublicOrganizationPrograms.AddRange(PublicOrganizationPrograms);
            else
            {
                List<PublicOrganizationProgram> newPublicOrganizationPrograms =_allPublicOrganizationProgramList.Where(publicPrograms => publicPrograms.Title.Contains(programTitle, StringComparison.OrdinalIgnoreCase)).ToList();
                PublicOrganizationPrograms.Clear();
                PublicOrganizationPrograms=newPublicOrganizationPrograms;
            }               
        }

        [RelayCommand]
        private void PerformSearchByOrganizationCategory(string organizationCategory)
        {
            Console.WriteLine(organizationCategory);
        }
    }
}

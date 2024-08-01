using CommunityToolkit.Mvvm.ComponentModel;
using WillBeThere.HttpService.DataService;
using WillBeThere.Shared.Models.ResultModels;

namespace WillBeThere.Mobile.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly Task _initTask;

        //private readonly IOrganizationCategoryDataService? _organizationCategoryDataService;
        private readonly IOrganizationProgramDataService? _organizationProgramDataService;

        [ObservableProperty]
        private List<PublicOrganizationProgram> _publicOrganizationPrograms = new();

        [ObservableProperty] private bool _isLoaded=false;
        [ObservableProperty] private bool _isBusy=false;

        public MainPageViewModel()
        {
            _initTask = InitializeData();
        }

        public MainPageViewModel(IOrganizationProgramDataService organizationProgramDataService)
        {
            _organizationProgramDataService = organizationProgramDataService;
            _initTask=InitializeData();
        }

        private async Task InitializeData()
        {
            IsBusy = true;
            if (_organizationProgramDataService is not null)
            {
                PublicOrganizationPrograms = await _organizationProgramDataService.GetAllPublicOrganizationProgramsAsync();
                IsLoaded = true;
            }
            IsBusy = false;
        }
    }
}

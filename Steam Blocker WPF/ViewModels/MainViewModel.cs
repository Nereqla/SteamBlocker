using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Steam_Blocker_UI.Services;
using System.Windows.Media;


namespace Steam_Blocker_UI;
internal partial class MainViewModel : ObservableObject
{
    private FireWallService _firewallService;
    private bool _isButtonEnable = true;
    private Color Red1 = (Color)ColorConverter.ConvertFromString("#FFE80D0D");
    private Color Red2 = (Color)ColorConverter.ConvertFromString("#FFC80909");
    private Color Green1 = (Color)ColorConverter.ConvertFromString("#FF4EFF00");
    private Color Green2 = (Color)ColorConverter.ConvertFromString("#FF7BD244");

    [ObservableProperty]
    private Color _gradientColor1;
    [ObservableProperty]
    private Color _gradientColor2;
    [ObservableProperty]
    private SolidColorBrush _gradientBrush1;

    public MainViewModel()
    {
        _firewallService = new FireWallService();
        _ = RuleTrackerAsync();
    }

    [ObservableProperty]
    private string _currentSteamStatusText = "Steam Offline";
    [ObservableProperty]
    private string _currentButtonText = "Kapat!";
    [ObservableProperty]
    private bool _currentFirewallStatus = false;


    [RelayCommand(CanExecute = nameof(ChangeRuleButtonCanClick))]
    private async Task ChangeRule()
    {
        _isButtonEnable = false;

        _firewallService.ChangeRuleToOpposite();
        CurrentFirewallStatus = _firewallService.CheckRuleIsExistAndEnabled();

        await Task.Delay(TimeSpan.FromSeconds(2));
        ChangeControlsStatus();
        _isButtonEnable = true;
    }
    private bool ChangeRuleButtonCanClick() => _isButtonEnable;

    private async Task RuleTrackerAsync()
    {
        CurrentFirewallStatus = _firewallService.CheckRuleIsExistAndEnabled();
        ChangeControlsStatus();

        while (true)
        {
            bool checkFirewallStatus = _firewallService.CheckRuleIsExistAndEnabled();
            if (CurrentFirewallStatus != checkFirewallStatus)
            {
                CurrentFirewallStatus = checkFirewallStatus;
                ChangeControlsStatus();
            }
            await Task.Delay(TimeSpan.FromSeconds(3));
        }
    }

    private void ChangeControlsStatus()
    {
        CurrentSteamStatusText = _currentFirewallStatus ? "Steam Offline" : "Steam Online";
        CurrentButtonText = _currentFirewallStatus ? "Aç" : "Kapat";
        GradientColor1 = _currentFirewallStatus ? Red1 : Green1;
        GradientColor2 = _currentFirewallStatus ? Red2 : Green2;
        GradientBrush1 = new SolidColorBrush(GradientColor1);
    }
}

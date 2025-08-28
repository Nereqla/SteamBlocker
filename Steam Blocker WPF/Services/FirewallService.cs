using NetFwTypeLib;
using System.Data;
using System.Windows;

namespace Steam_Blocker_UI.Services;
class FireWallService
{
    private readonly string _ruleName = "SteamEngelle";
    private readonly string _defaultSteamApplicationPath = @"C:\Program Files (x86)\Steam\steam.exe";

    public bool CheckRuleIsExistAndEnabled()
    {
        try
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);

            IEnumerable<INetFwRule> rules = fwPolicy.Rules.Cast<INetFwRule>();
            return rules.Any(rule => rule.Name == _ruleName && rule.Enabled == true);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"HATA OLUŞTU:\n{ex.ToString()}","Kritik Hata");
            return false;
        }
    }

    public void ChangeRuleToOpposite()
    {
        try
        {
            Type tNetFwPolicy = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy);

            foreach (INetFwRule rule in fwPolicy.Rules)
            {
                if (rule.Name == _ruleName)
                {
                    rule.Enabled = !rule.Enabled;
                    break;
                }
                else
                {
                    INetFwRule newRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                    newRule.Name = _ruleName;
                    newRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                    newRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    newRule.Enabled = true;
                    // Steam default dizinde kurulu olmalı!
                    newRule.ApplicationName = _defaultSteamApplicationPath;
                    fwPolicy.Rules.Add(newRule);
                    break;
                }
            }
        }
        catch (UnauthorizedAccessException exception)
        {
            MessageBox.Show($"Program Yönetici olarak çalışmalı!", "Yönetici olarak çalıştır!", MessageBoxButton.OK,MessageBoxImage.Error);
        }
        catch (Exception exception)
        {
            MessageBox.Show($"HATA OLUŞTU:\n{exception.ToString()}", "Kritik Hata");
        }
    }
}

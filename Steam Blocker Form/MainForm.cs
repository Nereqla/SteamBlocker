using NetFwTypeLib;

namespace SteamOnline;

public partial class MainForm : Form
{
    private string _ruleName = "SteamEngelle";
    private string _defaultSteamApplicationPath = @"C:\Program Files (x86)\Steam\steam.exe";
    public MainForm()
    {
        CheckForIllegalCrossThreadCalls = false;
        InitializeComponent();
        ChangeControlsStatus();
        Task.Factory.StartNew(RuleTracker);
    }

    private void ChangeControlsStatus()
    {
        if (CheckRuleIsExistAndEnabled())
        {
            this.pnl_statusColor.BackColor = Color.Red;
            this.lbl_status.Text = "Steam Erişime Kapalı!";
            this.btn_change.Text = "Aç!";
        }
        else
        {
            this.pnl_statusColor.BackColor = Color.Green;
            this.lbl_status.Text = "Steam Erişime Açık!";
            this.btn_change.Text = "Kapat!";
        }
    }

    private void RuleTracker()
    {
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            ChangeControlsStatus();
        }
    }

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
            MessageBox.Show($"HATA OLUŞTU:\n{ex.ToString()}", "Kritik Hata");
            return false;
        }
    }

    private void ChangeRuleToOpposite()
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

    private void btn_change_Click(object sender, EventArgs e)
    {
        ChangeRuleToOpposite();
        ChangeControlsStatus();
    }
}

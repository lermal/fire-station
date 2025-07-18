using Content.Client.Administration.Managers;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Options.UI
{
    [GenerateTypedNameReferences]
    public sealed partial class OptionsMenu : DefaultWindow
    {
        [Dependency] private readonly IClientAdminManager _adminManager = default!;

        public OptionsMenu()
        {
            RobustXamlLoader.Load(this);
            IoCManager.InjectDependencies(this);

            // Fire edit start - добавил нашу страничку настроек
            Tabs.SetTabTitle(0, Loc.GetString("ui-options-tab-scp"));
            Tabs.SetTabTitle(1, Loc.GetString("ui-options-tab-extra"));
            Tabs.SetTabTitle(2, Loc.GetString("ui-options-tab-misc"));
            Tabs.SetTabTitle(3, Loc.GetString("ui-options-tab-graphics"));
            Tabs.SetTabTitle(4, Loc.GetString("ui-options-tab-controls"));
            Tabs.SetTabTitle(5, Loc.GetString("ui-options-tab-audio"));
            Tabs.SetTabTitle(6, Loc.GetString("ui-options-tab-accessibility"));
            Tabs.SetTabTitle(7, Loc.GetString("ui-options-tab-admin"));
            // Fire edit end

            UpdateTabs();
        }

        public void UpdateTabs()
        {
            var isAdmin = _adminManager.IsAdmin(true);
            Tabs.SetTabVisible(6, isAdmin);

            GraphicsTab.Control.ReloadValues();
            MiscTab.Control.ReloadValues();
            AccessibilityTab.Control.ReloadValues();
            AudioTab.Control.ReloadValues();
            AdminOptionsTab.Control.ReloadValues();
        }
    }
}

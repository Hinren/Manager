using chkam05.Tools.ControlsEx.InternalMessages;
using ProjectManager.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectManager.Utilities
{
    public static class InternalMessagesHelper
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        public static void ApplyVisualStyle(BaseFilesSelectorInternalMessageEx internalMessage)
        {
            var configManager = ConfigManager.Instance;

            internalMessage.Background = configManager.AppearanceThemeBackgroundBrush;
            internalMessage.BorderBrush = configManager.AppearanceThemeShadeBackgroundBrush;
            internalMessage.BottomBackground = configManager.AppearanceThemeShadeBackgroundBrush;
            internalMessage.BottomBorderBrush = configManager.AppearanceAccentColorBrush;
            internalMessage.BottomPadding = new Thickness(8);
            internalMessage.ButtonBackground = configManager.AppearanceAccentColorBrush;
            internalMessage.ButtonBorderBrush = configManager.AppearanceAccentColorBrush;
            internalMessage.ButtonForeground = configManager.AppearanceAccentForegroundBrush;
            internalMessage.ButtonMouseOverBackground = configManager.AppearanceAccentMouseOverBrush;
            internalMessage.ButtonMouseOverBorderBrush = configManager.AppearanceAccentMouseOverBrush;
            internalMessage.ButtonMouseOverForeground = configManager.AppearanceAccentForegroundBrush;
            internalMessage.ButtonPressedBackground = configManager.AppearanceAccentPressedBrush;
            internalMessage.ButtonPressedBorderBrush = configManager.AppearanceAccentPressedBrush;
            internalMessage.ButtonPressedForeground = configManager.AppearanceAccentForegroundBrush;
            internalMessage.ButtonPressedForeground = configManager.AppearanceAccentForegroundBrush;
            internalMessage.Foreground = configManager.AppearanceThemeForegroundBrush;
            internalMessage.HeaderBackground = configManager.AppearanceThemeShadeBackgroundBrush;
            internalMessage.HeaderBorderBrush = configManager.AppearanceAccentColorBrush;
            internalMessage.HeaderPadding = new Thickness(8);
            internalMessage.Padding = new Thickness(0);
            internalMessage.UseCustomSectionBreaksBorderBrush = true;

            internalMessage.TextBoxMouseOverBackground = configManager.AppearanceAccentMouseOverBrush;
            internalMessage.TextBoxMouseOverBorderBrush = configManager.AppearanceAccentMouseOverBrush;
            internalMessage.TextBoxMouseOverForeground = configManager.AppearanceAccentForegroundBrush;
            internalMessage.TextBoxSelectedBackground = configManager.AppearanceAccentSelectedBrush;
            internalMessage.TextBoxSelectedBorderBrush = configManager.AppearanceAccentSelectedBrush;
            internalMessage.TextBoxSelectedForeground = configManager.AppearanceAccentForegroundBrush;
            internalMessage.TextBoxSelectedTextBackground = configManager.AppearanceAccentForegroundBrush;
        }

    }
}

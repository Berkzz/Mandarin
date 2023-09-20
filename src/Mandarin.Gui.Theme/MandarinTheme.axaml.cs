using Avalonia.Markup.Xaml;

namespace Mandarin.Gui.Theme;

public class MandarinTheme : Avalonia.Styling.Styles
{
    public MandarinTheme()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
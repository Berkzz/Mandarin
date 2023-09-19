using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Mandarin.Core.Interfaces.Audio;

namespace Mandarin.Gui.Views;

public partial class MainView : UserControl
{
    private IAudioPlayer _player;
    private string _songPath;

    public MainView()
    {
        _player = new NAudioPlayer.NAudioPlayer();
        InitializeComponent();
        Volume.Value = _player.Volume;
    }

    private void ButtonPlay_OnClick(object? sender, RoutedEventArgs e)
    {
        _player.Play(_songPath);
    }

    private async void OpenFileButton_OnClick(object sender, RoutedEventArgs args)
    {
        // Get top level from the current control. Alternatively, you can use Window reference instead.
        var topLevel = TopLevel.GetTopLevel(this);

        // Start async operation to open the dialog.
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open Text File",
            AllowMultiple = false
        });

        _songPath = files.Single().Path.AbsolutePath;
    }

    private void ButtonPause_OnClick(object? sender, RoutedEventArgs e)
    {
        _player.Pause();
    }

    private void VolumeSlider_Changed(object? sender, RangeBaseValueChangedEventArgs e)
    {
        _player.Volume = (float)(Volume.Value / Volume.Width);
    }

    private void ButtonStop_OnClick(object? sender, RoutedEventArgs e)
    {
        _player.Stop();
    }
}

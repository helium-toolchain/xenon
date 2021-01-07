using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Xenon.Launcher
{
    public class Xenon : Window
    {
        public Xenon()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
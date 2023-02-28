using System;
using Windows.System;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.Notifications;


// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace custom_lockscreen_text
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            string lineOne = first_line_input.Text.ToString();
            string lineTwo = second_line_input.Text.ToString();
            string lineThree = third_line_input.Text.ToString();

            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    LockDetailedStatus1 = lineOne,

                    LockDetailedStatus2 = lineTwo,

                    LockDetailedStatus3 = lineThree,

                    TileWide = new TileBinding() { }
                }
            };

            TileUpdateManager.CreateTileUpdaterForApplication().Update(new TileNotification(content.GetXml()));
        }

        private async void goto_lockscreen_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-settings:lockscreen"));
        }
    }
}

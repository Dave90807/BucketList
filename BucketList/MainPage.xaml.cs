using BucketList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BucketList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Item> SampleItems;
        public MainPage()
        {
            this.InitializeComponent();
            SampleItems = Samples.PopulateSamples();
        }

        private void Hamburger_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DisplayIntroListBoxItem.IsSelected) { ResultTextBlock.Text = "Show Introduction here."; } // Navigation goes here
            else if (DisplayAllListBoxItem.IsSelected) { ResultTextBlock.Text = "All Items display here."; }
            else if (EditListBoxItem.IsSelected) { ResultTextBlock.Text = "Editing page goes here"; }
        }
    }
}

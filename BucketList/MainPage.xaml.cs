using BucketList.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
        public ObservableCollection<Item> SampleItems;
        public MainPage()
        {
            this.InitializeComponent();
            SampleItems = Samples.PopulateSamples();
            ResultTextBlock.Text = "Saving List To Storage"; // Just for debugging purposes
            FileOperations.SaveListToStorage(SampleItems);
            ResultTextBlock.Text = "Item List Was Saved To Local Storage"; // Just for debugging purposes
           // SampleItems = FileOperations.GetListFromStorage();  // SampleItems = FileOperations.GetListFromStorage().Result;
           // Adding Result defeats purpose of Await and causes a cumulative exception  - try to find alternative solution
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

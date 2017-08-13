using BucketList;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BucketList.Models
{
    public class Item
    {
        public int ItemKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public bool Completed { get; set; }
        public string PhotoMain { get; set; }
        public int Priority { get; set; }

        public Item(int ItemKey, string Name, string Description, DateTime EditDate, DateTime CompletedDate, string PhotoMain, bool Completed,  int Priority)
        {
            this.ItemKey = ItemKey;
            this.Name = Name;
            this.Description = Description;
            this.EditDate = Convert.ToDateTime(EditDate);
            this.CompletedDate = Convert.ToDateTime(CompletedDate);
            this.PhotoMain = PhotoMain; // = "/Assets/BlankPhoto.jpg"; changing to "/Images...
            this.Completed = false;
            this.Priority = Priority;
        }
        public Item() { }
    }

    public class Samples
    {
        public static ObservableCollection<Item> PopulateSamples()
        {
            var samples = new ObservableCollection<Item>();
            Item itemOne = new Item { ItemKey = 1, Name = "Camping", Description = 
                "Rent a trailer or camper for a weekend outing.", PhotoMain =
                "Images/camper.jpg", Priority = 10 };
            samples.Add(itemOne);
            Item itemTwo = new Item { ItemKey = 2, Name = "Play Piano", Description =
                "Increase piano repetoire with various forms of music.", PhotoMain =
                "Images/ElectricKeyboard.jpg", Priority = 1 };
            samples.Add(itemTwo);
            Item itemThree = new Item {ItemKey = 3, Name = "Play Violin", Description =
                "Increase ability to make music with the electric violin.", PhotoMain =
                "Images/CecelioViolin.jpg", Priority = 5 };
            samples.Add(itemThree);
            Item itemFour = new Item {ItemKey = 4, Name = "Practice French", Description =
                "Impliment various ways to increase vocabulary and grammar.", PhotoMain =
                "Images/France.jpg", Priority = 2 };
            samples.Add(itemFour);
            Item itemFive = new Item {ItemKey = 5, Name = "Practice Midi", Description =
                "Practice midi Software developing as a tool to help master complex musical forms.", PhotoMain =
                "Images/MidiMusic.jpg", Priority = 5 };
            samples.Add(itemFive);
            return samples;
        }
    }

    public class FileOperations
    {
        public static async void SaveListToStorage(ObservableCollection<Item> sampleItems)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile OutPutFile = await localFolder.CreateFileAsync("Data.json", CreationCollisionOption.ReplaceExisting);
            string outPutJSON = "";
            foreach (Item item in sampleItems)
            {
                outPutJSON = outPutJSON + JsonConvert.SerializeObject(item);
            }
            await FileIO.WriteTextAsync(OutPutFile, outPutJSON);
        }

        public static async Task<ObservableCollection<Item>> GetListFromStorage()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile InPutFile = await localFolder.GetFileAsync("Data.json");
            string JSONstring = await FileIO.ReadTextAsync(InPutFile);
            ObservableCollection<Item> sampleItems1 = JsonConvert.DeserializeObject<ObservableCollection<Item>>(JSONstring);
            return sampleItems1;
        }
    }
}

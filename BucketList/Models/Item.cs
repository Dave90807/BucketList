using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketList.Models
{
    public class Item
    {
        public int ItemKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoMain { get; set; }
        public int Priority { get; set; }
    }

    public class Samples
    {
        public static ObservableCollection<Item> PopulateSamples()
        {
            var samples = new ObservableCollection<Item>();
            Item itemOne = new Item { ItemKey = 1, Name = "Camping", Description = 
                "Rent a trailer or camper for a weekend outing.", PhotoMain =
                "Assets/camper.jpg", Priority = 10 };
            samples.Add(itemOne);
            Item itemTwo = new Item { ItemKey = 2, Name = "Play Piano", Description =
                "Increase piano repetoire with various forms of music.", PhotoMain =
                "Assets/ElectricKeyboard.jpg", Priority = 1 };
            samples.Add(itemTwo);
            Item itemThree = new Item {ItemKey = 3, Name = "Play Violin", Description =
                "Increase ability to make music with the electric violin.", PhotoMain =
                "Assets/CecelioViolin.jpg", Priority = 5 };
            samples.Add(itemThree);
            Item itemFour = new Item {ItemKey = 4, Name = "Practice French", Description =
                "Impliment various ways to increase vocabulary and grammar.", PhotoMain =
                "Assets/France.jpg", Priority = 2 };
            samples.Add(itemFour);
            Item itemFive = new Item {ItemKey = 5, Name = "Practice Midi", Description =
                "Practice midi Software developing as a tool to help master complex musical forms.", PhotoMain =
                "Assets/MidiMusic.jpg", Priority = 5 };
            samples.Add(itemFive);
            return samples;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace Tamagotchi
{
    public partial class MainPage : ContentPage
    {
        public Creature MyCreature { get; set; } = new Creature
        {
            id = 0,
            Name = "Boris",
            Hunger = 0.5f,
            Thirst = 0.3f,
            Boredom = 0.2f,
            Loneliness = 0.8f,
            Stimulated = 0.2f,
            Tired = 0.1f
        };



        public string TextFromCode { get; set; }
        
        public MainPage()
        {
            BindingContext = this;

            var timer = new Timer
            {
                Interval = 1000 * 20,
                AutoReset = true
            };

            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();

            MyCreature = creatureDataStore.ReadItem();

            if (MyCreature == null)
            {
                MyCreature = new Creature { Name = "Boris" };
                creatureDataStore.CreateItem(MyCreature);
            }


            TextFromCode = "Click me!";

            InitializeComponent();

            MyCreatureView.MyCreature = MyCreature;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MyCreature.Hunger -= 0.1f;
            MyCreature.Thirst -= 0.1f;
            MyCreature.Boredom += 0.1f;
            MyCreature.Loneliness += 0.1f;
            MyCreature.Stimulated += 0.1f;
            MyCreature.Tired += 0.1f;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(MyCreature);
        }

        private void Button_Clicked_Hunger(object sender, EventArgs e)
        {
            MyCreature.Hunger += 0.1f;
            
            Navigation.PushAsync(new HungerPage());
        }

        private void Button_Clicked_Thirst(object sender, EventArgs e)
        {
            MyCreature.Thirst += 0.1f;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(MyCreature);
            // Navigation.PushAsync(new ThirstPage());
        }
        private void Button_Clicked_Boredom(object sender, EventArgs e)
        {
            MyCreature.Boredom += 0.1f;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(MyCreature);
            Navigation.PushAsync(new BoredomPage());
        }
        private void Button_Clicked_Loneliness(object sender, EventArgs e)
        {
            MyCreature.Loneliness -= 0.1f;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(MyCreature);
            Navigation.PushAsync(new LonelinessPage());
        }
        private void Button_Clicked_Stimulation(object sender, EventArgs e)
        {
            MyCreature.Stimulated += 0.1f;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(MyCreature);
            Navigation.PushAsync(new StimulationPage());
        }
        private void Button_Clicked_Tired(object sender, EventArgs e)
        {
            MyCreature.Tired += 0.1f;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(MyCreature);
            Navigation.PushAsync(new TiredPage());
        }
    }
}

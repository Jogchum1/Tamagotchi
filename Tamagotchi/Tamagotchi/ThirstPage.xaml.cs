using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirstPage : ContentPage
    {
        public Creature MyCreature;

        
        public ThirstPage()
        {
            BindingContext = this;
            InitializeComponent();
            MyCreature = MyCreatureView.MyCreature;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            MyCreatureView.MyCreature = creatureDataStore.ReadItem();
        }


        private void Back_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void Drink_Button(object sender, EventArgs e)
        {
            if(MyCreatureView.MyCreature.Thirst >= 0)
            {
                MyCreatureView.MyCreature.Thirst -= 0.1f;
                var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
                creatureDataStore.UpdateItem(MyCreatureView.MyCreature);
            }
            
        }
    }
}
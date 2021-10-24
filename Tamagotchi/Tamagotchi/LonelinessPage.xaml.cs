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
    public partial class LonelinessPage : ContentPage
    {
        public Creature MyCreature;


        public LonelinessPage()
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

        private void Company_Button(object sender, EventArgs e)
        {
            if (MyCreatureView.MyCreature.Loneliness >= 0)
            {
                MyCreatureView.MyCreature.Loneliness -= 0.1f;
                var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
                creatureDataStore.UpdateItem(MyCreatureView.MyCreature);
            }
        }
    }
}
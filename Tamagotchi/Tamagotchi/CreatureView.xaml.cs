using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tamagotchi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatureView : ContentView, INotifyPropertyChanged
    {
        public string HappyUil
        {
            get { return "UilBlij.png"; }
        }

        public string SadUil
        {
            get { return "UilSad.png"; }
        }
        public Creature MyCreature { get; set; }
        public CreatureView()
        {
            MyCreature = DependencyService.Get<IDataStore<Creature>>().ReadItem();
            if(MyCreature == null)
            {
                MyCreature = new Creature { Name = "Boris" };
                DependencyService.Get<IDataStore<Creature>>().CreateItem(MyCreature);
            }
            BindingContext = this;
            InitializeComponent();
        }
	}

}
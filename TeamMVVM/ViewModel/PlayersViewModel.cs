using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TeamMVVM.ViewModel
{
    using TeamMVVM.Model;

    class PlayersViewModel
    {
        private ObservableCollection<PlayerViewModel> playersCollection = new ObservableCollection<PlayerViewModel>();
        private ushort[] ages = new ushort[50];
        
        public void AddPlayer(string firstName, string lastName, ushort age, double weight)
        {
            playersCollection.Add(new PlayerViewModel(new PlayerModel(firstName, lastName, age, weight)));
        }

        public void ModifyPlayer(int index, string firstName, string lastName, ushort Age, double weight)
        {
            PlayerViewModel player = playersCollection[index];
            player.FirstName = firstName;
            player.LastName = lastName;
            player.Age = Age;
            player.Weight = weight;
        }

        public void DeletePlayer(int index)
        {
            playersCollection.RemoveAt(index);
        }

        public void LoadPlayers()
        {
            //loading method
        }

        public void SavePlayers()
        {
            //saving method
        }

        public ObservableCollection<PlayerViewModel> PlayersCollection { get => playersCollection; }
        public ushort[] Ages { get => ages; }
    }
}

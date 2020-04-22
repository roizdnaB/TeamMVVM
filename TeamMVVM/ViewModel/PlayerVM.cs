using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMVVM.ViewModel
{
    using Model;
    using TeamMVVM.Model.Base;

    class PlayerVM : ViewModelBase
    {
        private PlayerModel representedPlayer;
        
        public PlayerVM(PlayerModel player)
        {
            player = representedPlayer;
        }

        public PlayerModel RepresentedPlayer { get { return representedPlayer; } }

        public string FirstName 
        { 
            get { return representedPlayer.FirstName; } 
            set { representedPlayer.FirstName = value; onPropertyChanged(nameof(FirstName)); }
        }

        public string LastName
        {
            get { return representedPlayer.LastName; }
            set { representedPlayer.LastName = value; onPropertyChanged(nameof(LastName)); }
        }

        public ushort Age
        {
            get { return representedPlayer.Age; }
            set { representedPlayer.Age = value; onPropertyChanged(nameof(Age)); }
        }

        public double Weight
        {
            get { return representedPlayer.Weight; }
            set { representedPlayer.Weight = value; onPropertyChanged(nameof(Weight)); }
        }
    }
}

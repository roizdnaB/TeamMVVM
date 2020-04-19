using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TeamMVVM.ViewModel
{
    using TeamMVVM.Model;
 
    class PlayerViewModel : ViewModelBase
    {
        private PlayerModel playerViewModel;
        
        public PlayerViewModel(PlayerModel player)
        {
            this.playerViewModel = player;
        }
        
        public string FirstName
        {
            get { return playerViewModel.FirstName; }
            set
            {
                playerViewModel.FirstName = value;
                onPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return playerViewModel.LastName; }
            set
            {
                playerViewModel.LastName = value;
                onPropertyChanged(nameof(LastName));
            }
        }

        public ushort Age
        {
            get { return playerViewModel.Age; }
            set
            {
                playerViewModel.Age = value;
                onPropertyChanged(nameof(LastName));
            }
        }

        public double Weight
        {
            get { return playerViewModel.Weight; }
            set
            {
                playerViewModel.Weight = value;
                onPropertyChanged(nameof(Weight));
            }
        }
    }
}

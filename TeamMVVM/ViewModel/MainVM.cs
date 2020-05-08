using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace TeamMVVM.ViewModel
{
    using Model;
    using TeamMVVM.Model.Base;

    internal partial class MainVM : ViewModelBase
    {
        private ObservableCollection<PlayerVM> players = null;
        private ushort[] ageList = ViewModel.Base.Utils.Age();

        private string currentFirstName = "Enter the first name";
        private string currentLastName = "Enter the last name";
        private ushort currentAge = 15;
        private double currentWeight = 55;
        private int currentIndex;

        public ObservableCollection<PlayerVM> Players
        {
            get { 
                if (players == null)
                {
                    players = new ObservableCollection<PlayerVM>();
                    LoadPlayers();
                }
                return players;
                }
        }

        public ushort[] AgeList
        {
            get { return ageList; }
            set { ageList = value; }
        }
        
        public string CurrentFirstName 
        { 
            get { return currentFirstName; } 
            set { currentFirstName = value; } 
        }
        
        public string CurrentLastName 
        { 
            get { return currentLastName; } 
            set { currentLastName = value; } 
        }
        
        public ushort CurrentAge 
        { 
            get { return currentAge; } 
            set { currentAge = value; } 
        }
       
        public double CurrentWeight 
        { 
            get { return currentWeight; } 
            set { currentWeight = value; } 
        }

        public int CurrentIndex
        {
            get { return currentIndex; }
            set { currentIndex = value; }
        }

    }
}

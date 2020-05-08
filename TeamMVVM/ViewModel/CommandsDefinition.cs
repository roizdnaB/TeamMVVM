using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace TeamMVVM.ViewModel
{
    using TeamMVVM.Model;
    using TeamMVVM.Model.Base;
    using Newtonsoft.Json;
    using System.IO;
    using System.Windows;

    internal partial class MainVM : ViewModelBase
    {
        private ICommand addPlayer = null;
        private ICommand modifyPlayer = null;
        private ICommand deletePlayer = null;

        private ICommand clearFirstName = null;
        private ICommand clearLastName = null;
        private ICommand loadPlayer = null;

        public ICommand AddPlayer
        {
            get
            {
                if (addPlayer == null)
                {
                    addPlayer = new RelayCommand(
                        arg => { Players.Add(new PlayerVM(new PlayerModel(CurrentFirstName, CurrentLastName, CurrentAge, CurrentWeight))); },
                        arg => !(string.IsNullOrEmpty(CurrentFirstName) || CurrentFirstName == "Enter the first name" 
                                 || string.IsNullOrEmpty(CurrentLastName) || CurrentLastName == "Enter the last name"));
                }
                return addPlayer;    
            }
        }

        public ICommand ModifyPlayer
        {
            get
            {
                if (modifyPlayer == null)
                {
                    modifyPlayer = new RelayCommand(
                        arg =>
                        {
                            if (MessageBox.Show("Do you want to modify player?", "Modify player", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                PlayerVM player = players[currentIndex];
                                player.FirstName = currentFirstName;
                                player.LastName = currentLastName;
                                player.Age = currentAge;
                                player.Weight = currentWeight;
                            }
                        },
                        arg => CurrentIndex != -1);
                };
                return modifyPlayer;
            }
        }

        public ICommand DeletePlayer
        {
            get
            {
                if (deletePlayer == null)
                {
                    deletePlayer = new RelayCommand(
                        arg =>
                        {
                            if (MessageBox.Show("Do you want to delete this player?", "Delete player", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                players.RemoveAt(currentIndex);
                                onPropertyChanged(nameof(players));
                            }
                        },
                        arg => CurrentIndex != -1);
                }
                return deletePlayer;
            }
        }

        public ICommand ClearFirstName
        {
            get
            {
                if (clearFirstName == null)
                {
                    clearFirstName = new RelayCommand(
                        arg =>
                        {
                            CurrentFirstName = null;
                            onPropertyChanged(nameof(CurrentFirstName));
                        },
                        arg => CurrentFirstName == "Enter the first name");
                }
                return clearFirstName;
            }
        }

        public ICommand ClearLastName
        {
            get
            {
                if (clearLastName == null)
                {
                    clearLastName = new RelayCommand(
                        arg =>
                        {
                            CurrentLastName = null;
                            onPropertyChanged(nameof(CurrentLastName));
                        },
                        arg => CurrentLastName == "Enter the last name");
                }
                return clearLastName;
            }
        }

        public ICommand LoadPlayer
        {
            get
            {
                if(loadPlayer == null)
                {
                    loadPlayer = new RelayCommand
                    (
                        arg =>
                        {
                            PlayerVM player = players[currentIndex];
                            CurrentFirstName = player.FirstName;
                            CurrentLastName = player.LastName;
                            CurrentAge = player.Age;
                            CurrentWeight = player.Weight;
                            onPropertyChanged(nameof(CurrentFirstName), nameof(CurrentLastName), nameof(CurrentAge), nameof(CurrentWeight));
                        },
                        arg => CurrentIndex != -1);
                }
                return loadPlayer;
            }
        }

        public ICommand SavePlayers
        {
            get { return new RelayCommand(arg => savePlayers(), arg => true); }
        }

        public void savePlayers()
        {
            List<PlayerModel> savePlayers = new List<PlayerModel>();
            foreach (PlayerVM player in players)
                savePlayers.Add(player.RepresentedPlayer);

            string json = JsonConvert.SerializeObject(savePlayers);
            File.WriteAllText("data.json", json);
        }

        public void LoadPlayers()
        {
            if (!File.Exists("data.json"))
                return;

            List<PlayerModel> loadPlayers = JsonConvert.DeserializeObject<List<PlayerModel>>(File.ReadAllText("data.json"));

            if (loadPlayers != null)
                foreach (PlayerModel player in loadPlayers)
                    players.Add(new PlayerVM(player));
        }
        
    }
}

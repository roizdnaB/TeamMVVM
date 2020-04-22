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

    internal partial class MainVM : ViewModelBase
    {
        private ICommand addPlayer = null;
        private ICommand modifyPlayer = null;
        private ICommand deletePlayer = null;
        private ICommand savePlayers = null;
        private ICommand loadPlayers = null;

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


        public ICommand SavePlayers
        {
            get
            {
                if (SavePlayers == null)
                {
                    savePlayers = new RelayCommand(
                        arg =>
                        {
                            string json = JsonConvert.SerializeObject(players);
                            File.WriteAllText(@"data.json", json);
                        },
                        arg => true);
                }
                return savePlayers;
            }
        }

        
    }
}

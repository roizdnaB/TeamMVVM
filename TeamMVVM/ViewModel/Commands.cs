using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace TeamMVVM.ViewModel
{
    using TeamMVVM.Model;

    class Commands : ViewModelBase
    {
        private ICommand addPlayer = null;
        private ICommand modifyPlayer = null;
        private ICommand deletePlayer = null;
        private ICommand savePlayer = null;
        private ICommand loadPlayer = null;

        public ICommand AddPlayer
        {
            get
            {
                if (addPlayer == null)
                {
                    addPlayer = new ViewModel.RelayCommand(
                        arg =>
                        {
                            
                        })
                }
            }
        }
        
    }
}

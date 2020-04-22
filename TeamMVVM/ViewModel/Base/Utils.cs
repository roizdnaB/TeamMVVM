using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMVVM.ViewModel.Base
{
    class Utils
    {
        public static ushort[] Age()
        {
            ushort[] age = new ushort[51];

            for (ushort i = 0; i < age.Length; i++)
                age[i] = (ushort)(i + 15);

            return age;
        }
    }
}

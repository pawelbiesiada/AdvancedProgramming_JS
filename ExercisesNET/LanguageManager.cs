using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesNET
{
    public class LanguageManager
    {
        private static LanguageManager _instance = null;
        private static object _locker = new object();

        public static LanguageManager GetInstance()
        {
            lock (_locker)
            {
                if (_instance == null)
                    _instance = new LanguageManager();

            }
            return _instance;
        }

        private LanguageManager() { }
    }
}

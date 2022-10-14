using Criminal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criminal.Service
{
    public class Singleton
    {
        private static Singleton _current;
        public static Singleton Instance
        {
            get
            {
                if (_current==null)
                {
                    _current = new Singleton();
                }
                return _current;
            }
        }
        public Usuario usuario;
    }
}

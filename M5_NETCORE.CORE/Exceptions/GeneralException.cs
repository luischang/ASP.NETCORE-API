using System;
using System.Collections.Generic;
using System.Text;

namespace M5_NETCORE.CORE.Exceptions
{
    public class GeneralException: Exception
    {
        public GeneralException()
        {

        }

        public GeneralException(string message): base(message)
        {
        }


    }
}

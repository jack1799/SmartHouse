﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public interface IModes
    {
        IMode BlenderMode { get; set; }

        Boolean SetMode(String Argument);
    }
}
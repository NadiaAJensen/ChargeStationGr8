﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary
{
    public interface IUSBCharger
    {
        public event EventHandler<CurrentChangedEventArgs> CurrentChangedEvent;


    }
}
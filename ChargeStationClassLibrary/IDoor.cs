﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary
{
    public interface IDoor
    {
        public event EventHandler<DoorChangedEventArgs> DoorStatusChangedEvent;

        public void UnLockDoor();

        public void LockDoor();

    }
}

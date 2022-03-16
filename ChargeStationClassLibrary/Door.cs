using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary
{
    public class Door:IDoor
    {
        public event EventHandler<DoorChangedEventArgs> DoorStatusChangedEvent;
        public void UnLockDoor()
        {
            Console.WriteLine("Door is unlocked");
        }

        public void LockDoor()
        {
            Console.WriteLine("Door is locked");
        }
    }
}

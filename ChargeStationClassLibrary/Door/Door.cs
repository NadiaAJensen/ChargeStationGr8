using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary.Door
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

        public void OpenDoor(bool status)
        {
            DoorStatusChangedEvent?.Invoke(this, new DoorChangedEventArgs{DoorStatus = status});
        }

        public void CloseDoor(bool status)
        {
            DoorStatusChangedEvent?.Invoke(this, new DoorChangedEventArgs { DoorStatus = status });
        }
    }
}

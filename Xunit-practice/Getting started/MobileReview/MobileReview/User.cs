using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobileReview
{
    public class User
    {
        
        private int _defaultCapacity = 8;

        public event EventHandler<EventArgs> TurnOn;
        public int DefaultCapacity
        {
            get => _defaultCapacity;
            set
            {
                _defaultCapacity = value;
                OnPropertyChanged();
            }
        }

        public int BatteryCharge { get; private set; }

        public void InsertBattery()
        {
            var batteryCharge = GetBatteryCharge();

            BatteryCharge = batteryCharge;

            TurnOnMobile(EventArgs.Empty);
        }
        private int GetBatteryCharge()
        {
            var rnd = new Random();

            return rnd.Next(1, 101);
        }


        protected virtual void TurnOnMobile(EventArgs e)
        {
            TurnOn?.Invoke(this, e);
        }

        public void InsertMemory(int capacity)
        {
            DefaultCapacity = Math.Max(256, DefaultCapacity += capacity);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

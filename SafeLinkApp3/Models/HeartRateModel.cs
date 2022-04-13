using System;
using System.Collections.Generic;
using System.Text;

namespace SafeLinkApp3.Models
{
    public class HeartRateModel : ParentViewModel
    {
        private float heartRateValue;
        public float HeartRateValue
        {
            get { return heartRateValue; }
            set { heartRateValue = value; OnPropertyChanged("HeartRateValue"); }
        }

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged("Time"); }
        }


    }
}

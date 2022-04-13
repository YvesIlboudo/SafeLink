using SafeLinkApp3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Timers;
using Xamarin.Forms;

namespace SafeLinkApp3.ViewModels
{
    public class HeartRateViewModel : ParentViewModel
    {
        #region Properties
        private ObservableCollection<HeartRateModel> heartRateData;

        public ObservableCollection<HeartRateModel> HeartRateData
        {
            get { return heartRateData; }
            set { heartRateData = value; OnPropertyChanged("HeartRateData"); }
        }
        #endregion

        #region Private Members
        private Timer SampleTimer;
        #endregion



        #region Constructor
        public HeartRateViewModel()
        {
            HeartRateData = new ObservableCollection<HeartRateModel>();
            SampleTimer = new Timer();
            SampleTimer.Interval = 5000;
            SampleTimer.Elapsed += SampleTimer_Elapsed;
            SampleTimer.Start();
        }
        #endregion
        //UI Threads - Main Thread
        //Other Threads
        #region Functions
        private void SampleTimer_Elapsed(object sender,ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Random random = new Random();
                int demoHeartRateValues = random.Next(55, 60);
                
                HeartRateData.Add(new HeartRateModel() { HeartRateValue = demoHeartRateValues, Time = DateTime.Now });
                if (HeartRateData.Count == 20)
                {
                    HeartRateData.Clear();
                }
            });
          
        }
        #endregion

    }
}

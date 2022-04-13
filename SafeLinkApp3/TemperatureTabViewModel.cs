using System;
using System.Collections.Generic;
using System.Text;

namespace SafeLinkApp3
{
   public class TemperatureTabViewModel: ParentViewModel
    {
        public CountryGdp GdpValueForUSA { get; }

        public TemperatureTabViewModel()
        {
            GdpValueForUSA = new CountryGdp(
                "USA",
                new GdpValue(new DateTime(2017, 1, 1), 19.391),
                new GdpValue(new DateTime(2016, 1, 1), 18.624),
                new GdpValue(new DateTime(2015, 1, 1), 18.121),
                new GdpValue(new DateTime(2014, 1, 1), 17.428),
                new GdpValue(new DateTime(2013, 1, 1), 16.692),
                new GdpValue(new DateTime(2012, 1, 1), 16.155),
                new GdpValue(new DateTime(2011, 1, 1), 15.518),
                new GdpValue(new DateTime(2010, 1, 1), 14.964),
                new GdpValue(new DateTime(2009, 1, 1), 14.419),
                new GdpValue(new DateTime(2008, 1, 1), 14.719),
                new GdpValue(new DateTime(2007, 1, 1), 14.478)
            );
           
        }
    }

    public class CountryGdp
    {
        public string CountryName { get; }
        public IList<GdpValue> Values { get; }

        public CountryGdp(string country, params GdpValue[] values)
        {
            this.CountryName = country;
            this.Values = new List<GdpValue>(values);
        }
    }

    public class GdpValue
    {
        public DateTime Year { get; }
        public double Value { get; }

        public GdpValue(DateTime year, double value)
        {
            this.Year = year;
            this.Value = value;
        }
    }
}

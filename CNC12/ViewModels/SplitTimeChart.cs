using CNC12.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CNC12.ViewModels
{
    public class SplitTimeChart : TimeCalculation
    {
        public SeriesCollection SeriesCal(double[] timeShift1CNC, double[] timeShift2CNC, double[] timeShift3CNC)
        {
            SeriesCollection Series = new SeriesCollection
            {
                new StackedRowSeries
                {
                    Title = "Run Time",
                    Values = new ChartValues<double> { timeShift1CNC[0], timeShift2CNC[0], timeShift3CNC[0] },
                    StackMode = StackMode.Percentage,
                    DataLabels = true,
                    LabelPoint = p => p.X.ToString()

                },
                new StackedRowSeries
                {
                    Title = "Stop Time",
                    Values = new ChartValues<double> { timeShift1CNC[1], timeShift2CNC[1], timeShift3CNC[1] },
                    StackMode = StackMode.Percentage,
                    DataLabels = true,
                    LabelPoint = p => p.X.ToString()
                },
                new StackedRowSeries
                {
                    Title = "Fail Time",
                    Values = new ChartValues<double> { timeShift1CNC[2], timeShift2CNC[2], timeShift3CNC[2]},
                    StackMode = StackMode.Percentage,
                    DataLabels = true,
                    LabelPoint = p => p.X.ToString()
                },
                new StackedRowSeries
                {
                    Title = "Time Left",
                    Values = new ChartValues<double> { timeShift1CNC[3], timeShift2CNC[3], timeShift3CNC[3]},
                    StackMode = StackMode.Percentage,
                    DataLabels = true,
                    LabelPoint = p => p.X.ToString()
                }
            };
            return Series;
        }
        public DateTime[] DateTimeCal(DateTime DisplayDateSplitTime)
        {
            DateTime[] t = new DateTime[6];
            t[0] = DateTime.ParseExact(DisplayDateSplitTime.ToString("yyyy-MM-dd") + " " + "00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            t[1] = DateTime.ParseExact(DisplayDateSplitTime.ToString("yyyy-MM-dd") + " " + "07:59:59.999", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);

            t[2] = DateTime.ParseExact(DisplayDateSplitTime.ToString("yyyy-MM-dd") + " " + "08:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            t[3] = DateTime.ParseExact(DisplayDateSplitTime.ToString("yyyy-MM-dd") + " " + "15:59:59.999", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);

            t[4] = DateTime.ParseExact(DisplayDateSplitTime.ToString("yyyy-MM-dd") + " " + "16:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            t[5] = DateTime.ParseExact(DisplayDateSplitTime.ToString("yyyy-MM-dd") + " " + "23:59:59.999", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            return t;
        }    
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC1(IEnumerable<EventManagerCNC1> tableCNC, DateTime DisplayDateSplitTime)
        {
            DateTime[] t = DateTimeCal(DisplayDateSplitTime);
                var time1 = TimeCalculation_CNC1(t[0], t[1], tableCNC);
                var time2 = TimeCalculation_CNC1(t[2], t[3], tableCNC);
                var time3 = TimeCalculation_CNC1(t[4], t[5], tableCNC);

                await Task.WhenAll(
                    time1,
                    time2,
                    time3
                    );
                double[] timeShift1CNC = { 0, 0, 0, 8 };
                double[] timeShift2CNC = { 0, 0, 0, 8 };
                double[] timeShift3CNC = { 0, 0, 0, 8 };

                if (time1 != null)
                {
                    timeShift1CNC = time1.Result;
                }
                if (time2 != null)
                {
                    timeShift2CNC = time2.Result;
                }
                if (time3 != null)
                {
                    timeShift3CNC = time3.Result;
                }

                SeriesCollection Series = SeriesCal(timeShift1CNC, timeShift2CNC, timeShift3CNC);
                return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC2(IEnumerable<EventManagerCNC2> tableCNC, DateTime DisplayDateSplitTime)
        {

            DateTime[] t = DateTimeCal(DisplayDateSplitTime);
            var time1 = TimeCalculation_CNC2(t[0], t[1], tableCNC);
            var time2 = TimeCalculation_CNC2(t[2], t[3], tableCNC);
            var time3 = TimeCalculation_CNC2(t[4], t[5], tableCNC);
            await Task.WhenAll(
                time1,
                time2,
                time3
                );


            double[] timeShift1CNC = { 0, 0, 0, 8 };
            double[] timeShift2CNC = { 0, 0, 0, 8 };
            double[] timeShift3CNC = { 0, 0, 0, 8 };

            if (time1 != null)
            {
                timeShift1CNC = time1.Result;
            }
            if (time2 != null)
            {
                timeShift2CNC = time2.Result;
            }
            if (time3 != null)
            {
                timeShift3CNC = time3.Result;
            }
            SeriesCollection Series = SeriesCal(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC3(IEnumerable<EventManagerCNC3> tableCNC, DateTime DisplayDateSplitTime)
        {
            DateTime[] t = DateTimeCal(DisplayDateSplitTime);
            var time1 = TimeCalculation_CNC3(t[0], t[1], tableCNC);
            var time2 = TimeCalculation_CNC3(t[2], t[3], tableCNC);
            var time3 = TimeCalculation_CNC3(t[4], t[5], tableCNC);
            await Task.WhenAll(
                time1,
                time2,
                time3
                );

            double[] timeShift1CNC = { 0, 0, 0, 8 };
            double[] timeShift2CNC = { 0, 0, 0, 8 };
            double[] timeShift3CNC = { 0, 0, 0, 8 };

            if (time1 != null)
            {
                timeShift1CNC = time1.Result;
            }
            if (time2 != null)
            {
                timeShift2CNC = time2.Result;
            }
            if (time3 != null)
            {
                timeShift3CNC = time3.Result;
            }

            SeriesCollection Series = SeriesCal(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC4(IEnumerable<EventManagerCNC4> tableCNC, DateTime DisplayDateSplitTime)
        {
            DateTime[] t = DateTimeCal(DisplayDateSplitTime);
            var time1 = TimeCalculation_CNC4(t[0], t[1], tableCNC);
            var time2 = TimeCalculation_CNC4(t[2], t[3], tableCNC);
            var time3 = TimeCalculation_CNC4(t[4], t[5], tableCNC);
            await Task.WhenAll(
                time1,
                time2,
                time3
                );


            double[] timeShift1CNC = { 0, 0, 0, 8 };
            double[] timeShift2CNC = { 0, 0, 0, 8 };
            double[] timeShift3CNC = { 0, 0, 0, 8 };

            if (time1 != null)
            {
                timeShift1CNC = time1.Result;
            }
            if (time2 != null)
            {
                timeShift2CNC = time2.Result;
            }
            if (time3 != null)
            {
                timeShift3CNC = time3.Result;
            }

            SeriesCollection Series = SeriesCal(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC5(IEnumerable<EventManagerCNC5> tableCNC, DateTime DisplayDateSplitTime)
        {
            DateTime[] t = DateTimeCal(DisplayDateSplitTime);
            var time1 = TimeCalculation_CNC5(t[0], t[1], tableCNC);
            var time2 = TimeCalculation_CNC5(t[2], t[3], tableCNC);
            var time3 = TimeCalculation_CNC5(t[4], t[5], tableCNC);
            await Task.WhenAll(
                time1,
                time2,
                time3
                );


            double[] timeShift1CNC = { 0, 0, 0, 8 };
            double[] timeShift2CNC = { 0, 0, 0, 8 };
            double[] timeShift3CNC = { 0, 0, 0, 8 };

            if (time1 != null)
            {
                timeShift1CNC = time1.Result;
            }
            if (time2 != null)
            {
                timeShift2CNC = time2.Result;
            }
            if (time3 != null)
            {
                timeShift3CNC = time3.Result;
            }

            SeriesCollection Series = SeriesCal(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC6(IEnumerable<EventManagerCNC6> tableCNC, DateTime DisplayDateSplitTime)
        {
            DateTime[] t = DateTimeCal(DisplayDateSplitTime);
            var time1 = TimeCalculation_CNC6(t[0], t[1], tableCNC);
            var time2 = TimeCalculation_CNC6(t[2], t[3], tableCNC);
            var time3 = TimeCalculation_CNC6(t[4], t[5], tableCNC);
            await Task.WhenAll(
                time1,
                time2,
                time3
                );


            double[] timeShift1CNC = time1.Result;
            double[] timeShift2CNC = time2.Result;
            double[] timeShift3CNC = time3.Result;

            SeriesCollection Series = SeriesCal(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC7(IEnumerable<EventManagerCNC7> tableCNC, DateTime DisplayDateSplitTime)
        {
            DateTime[] t = DateTimeCal(DisplayDateSplitTime);
            var time1 = TimeCalculation_CNC7(t[0], t[1], tableCNC);
            var time2 = TimeCalculation_CNC7(t[2], t[3], tableCNC);
            var time3 = TimeCalculation_CNC7(t[4], t[5], tableCNC);
            await Task.WhenAll(
                time1,
                time2,
                time3
                );


            double[] timeShift1CNC = { 0, 0, 0, 8 };
            double[] timeShift2CNC = { 0, 0, 0, 8 };
            double[] timeShift3CNC = { 0, 0, 0, 8 };

            if (time1 != null)
            {
                timeShift1CNC = time1.Result;
            }
            if (time2 != null)
            {
                timeShift2CNC = time2.Result;
            }
            if (time3 != null)
            {
                timeShift3CNC = time3.Result;
            }

            SeriesCollection Series = SeriesCal(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC8(IEnumerable<EventManagerCNC8> tableCNC, DateTime DisplayDateSplitTime)
        {
            DateTime[] t = DateTimeCal(DisplayDateSplitTime);
            var time1 = TimeCalculation_CNC8(t[0], t[1], tableCNC);
            var time2 = TimeCalculation_CNC8(t[2], t[3], tableCNC);
            var time3 = TimeCalculation_CNC8(t[4], t[5], tableCNC);
            await Task.WhenAll(
                time1,
                time2,
                time3
                );
            double[] timeShift1CNC = { 0, 0, 0, 8 };
            double[] timeShift2CNC = { 0, 0, 0, 8 };
            double[] timeShift3CNC = { 0, 0, 0, 8 };

            if (time1 != null)
            {
                timeShift1CNC = time1.Result;
            }
            if (time2 != null)
            {
                timeShift2CNC = time2.Result;
            }
            if (time3 != null)
            {
                timeShift3CNC = time3.Result;
            }

            SeriesCollection Series = SeriesCal(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
    }
}

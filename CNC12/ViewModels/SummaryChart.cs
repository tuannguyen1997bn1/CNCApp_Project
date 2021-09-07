using CNC12.Model;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC12.ViewModels
{
    public class SummaryChart
    {
        public SeriesCollection SendToPieChartSummary(int[] valueArray)
        {
            GC.Collect();
            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            SeriesCollection SeriesPieSummary = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Line1",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(valueArray[0]) },
                    DataLabels = true,
                    PushOut = 5,
                    FontSize = 11,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Line2",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(valueArray[1]) },
                    DataLabels = true,
                    PushOut = 0,
                    FontSize = 11,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Line3",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(valueArray[2]) },
                    DataLabels = true,
                    PushOut = 0,
                    FontSize = 11,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Line4",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(valueArray[3]) },
                    DataLabels = true,
                    PushOut = 0,
                    FontSize = 11,
                    LabelPoint = labelPoint
                }
            };
            return SeriesPieSummary;
        }
        public async Task<int[]> ProductivitySummaryChartCNC1(int y, int t1, int t2, IEnumerable<EventManagerCNC1> db)
        {
            GC.Collect();
            int[] value = new int[2] { 0, 0 };
            if (db.Count() != 0)
            {
                var yearP1 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 1).Count();
                var yearP2 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 2).Count();
                value[1] = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 3).Count();
                if (yearP1 >= yearP2)
                {
                    value[0] = yearP2;
                }
                else
                {
                    value[0] = yearP1;
                }
            }
            await Task.Delay(0);
            return value;
        }
        public async Task<int[]> ProductivitySummaryChartCNC2(int y, int t1, int t2, IEnumerable<EventManagerCNC2> db)
        {
            GC.Collect();
            int[] value = new int[2] { 0, 0 };
            if (db.Count() != 0)
            {
                var yearP1 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 1).Count();
                var yearP2 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 2).Count();
                value[1] = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 3).Count();
                if (yearP1 >= yearP2)
                {
                    value[0] = yearP2;
                }
                else
                {
                    value[0] = yearP1;
                }
            }
            await Task.Delay(0);
            return value;
        }
        public async Task<int[]> ProductivitySummaryChartCNC3(int y, int t1, int t2, IEnumerable<EventManagerCNC3> db)
        {
            GC.Collect();
            int[] value = new int[2] { 0, 0 };
            if (db.Count() != 0)
            {
                var yearP1 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 1).Count();
                var yearP2 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 2).Count();
                value[1] = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 3).Count();
                if (yearP1 >= yearP2)
                {
                    value[0] = yearP2;
                }
                else
                {
                    value[0] = yearP1;
                }
            }
            await Task.Delay(0);
            return value;
        }
        public async Task<int[]> ProductivitySummaryChartCNC4(int y, int t1, int t2, IEnumerable<EventManagerCNC4> db)
        {
            GC.Collect();
            int[] value = new int[2] { 0, 0 };
            if (db.Count() != 0)
            {
                var yearP1 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 1).Count();
                var yearP2 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 2).Count();
                value[1] = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 3).Count();
                if (yearP1 >= yearP2)
                {
                    value[0] = yearP2;
                }
                else
                {
                    value[0] = yearP1;
                }
            }
            await Task.Delay(0);
            return value;
        }
        public async Task<int[]> ProductivitySummaryChartCNC5(int y, int t1, int t2, IEnumerable<EventManagerCNC5> db)
        {
            GC.Collect();
            int[] value = new int[2] { 0, 0 };
            if (db.Count() != 0)
            {
                var yearP1 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 1).Count();
                var yearP2 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 2).Count();
                value[1] = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 3).Count();
                if (yearP1 >= yearP2)
                {
                    value[0] = yearP2;
                }
                else
                {
                    value[0] = yearP1;
                }
            }
            await Task.Delay(0);
            return value;
        }
        public async Task<int[]> ProductivitySummaryChartCNC6(int y, int t1, int t2, IEnumerable<EventManagerCNC6> db)
        {
            GC.Collect();
            int[] value = new int[2] { 0, 0 };
            if (db.Count() != 0)
            {
                var yearP1 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 1).Count();
                var yearP2 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 2).Count();
                value[1] = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 3).Count();
                if (yearP1 >= yearP2)
                {
                    value[0] = yearP2;
                }
                else
                {
                    value[0] = yearP1;
                }
            }
            await Task.Delay(0);
            return value;
        }
        public async Task<int[]> ProductivitySummaryChartCNC7(int y, int t1, int t2, IEnumerable<EventManagerCNC7> db)
        {
            GC.Collect();
            int[] value = new int[2] { 0, 0 };
            if (db.Count() != 0)
            {
                var yearP1 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 1).Count();
                var yearP2 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 2).Count();
                value[1] = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 3).Count();
                if (yearP1 >= yearP2)
                {
                    value[0] = yearP2;
                }
                else
                {
                    value[0] = yearP1;
                }
            }
            await Task.Delay(0);
            return value;
        }
        public async Task<int[]> ProductivitySummaryChartCNC8(int y, int t1, int t2, IEnumerable<EventManagerCNC8> db)
        {
            GC.Collect();
            int[] value = new int[2] { 0, 0 };
            if (db.Count() != 0)
            {
                var yearP1 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 1).Count();
                var yearP2 = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 2).Count();
                value[1] = db.Where(p => p.ThoiDiem.Value.Year == y && p.ThoiDiem.Value.Month <= t2 && p.ThoiDiem.Value.Month >= t1 && p.IdHienTrangMayCNC == 3).Count();
                if (yearP1 >= yearP2)
                {
                    value[0] = yearP2;
                }
                else
                {
                    value[0] = yearP1;
                }
            }
            await Task.Delay(0);
            return value;
        }
    }
}

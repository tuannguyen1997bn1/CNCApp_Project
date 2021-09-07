using CNC12.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC12.ViewModels
{
    public class ProductionChart
    {
        public DateTime[] DateTimeProductionCal(DateTime DisplayDateProduct)
        {
            int DayInt = int.Parse(DisplayDateProduct.ToString("dd"));
            string MonthYear = DisplayDateProduct.ToString("yyyy-MM");
            string Day1 = (DayInt).ToString();
            string Day2 = (DayInt + 1).ToString();
            string Day3 = (DayInt + 2).ToString();
            string Day4 = (DayInt + 3).ToString();
            string Day5 = (DayInt + 4).ToString();
            string Day6 = (DayInt + 5).ToString();
            string Day7 = (DayInt + 6).ToString();
            string Day8 = (DayInt + 7).ToString();
            if (DayInt < 10)
            {
                Day1 = "0" + Day1;
            }
            if (DayInt + 1 < 10)
            {
                Day2 = "0" + Day2;
            }
            if (DayInt + 2 < 10)
            {
                Day3 = "0" + Day3;
            }
            if (DayInt + 3 < 10)
            {
                Day4 = "0" + Day4;
            }
            if (DayInt + 4 < 10)
            {
                Day5 = "0" + Day5;
            }
            if (DayInt + 5 < 10)
            {
                Day6 = "0" + Day6;
            }
            if (DayInt + 6 < 10)
            {
                Day7 = "0" + Day7;
            }
            if (DayInt + 7 < 10)
            {
                Day8 = "0" + Day8;
            }
            DateTime Date1 = DateTime.ParseExact(MonthYear + "-" + Day1 + " " + "00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime Date2 = DateTime.ParseExact(MonthYear + "-" + Day2 + " " + "00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime Date3 = DateTime.ParseExact(MonthYear + "-" + Day3 + " " + "00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime Date4 = DateTime.ParseExact(MonthYear + "-" + Day4 + " " + "00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime Date5 = DateTime.ParseExact(MonthYear + "-" + Day5 + " " + "00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime Date6 = DateTime.ParseExact(MonthYear + "-" + Day6 + " " + "00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime Date7 = DateTime.ParseExact(MonthYear + "-" + Day7 + " " + "00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime Date8 = DateTime.ParseExact(MonthYear + "-" + Day8 + " " + "00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime[] time = { Date1, Date2, Date3, Date4, Date5, Date6, Date7, Date8 };
            return time;
        }
        public SeriesCollection SeriesCal(int[] returnDays, int[] returnDays1, int[] returnDays2)
        {
            for (int i = 0; i < 7; i++)
            {
                if (returnDays1[i] >= returnDays2[i])
                {
                    returnDays[i] = returnDays2[i];
                }
                else
                {
                    returnDays[i] = returnDays1[i];
                }
            }
            SeriesCollection SeriesP = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Product",
                    Values = new ChartValues<double> { returnDays[0], returnDays[1], returnDays[2], returnDays[3], returnDays[4], returnDays[5], returnDays[6] }
                }
            };
            SeriesP.Add(new ColumnSeries
            {
                Title = "Falling",
                Values = new ChartValues<double> { returnDays[7], returnDays[8], returnDays[9], returnDays[10], returnDays[11], returnDays[12], returnDays[13] }
            });
            return SeriesP;
        }
        public SeriesCollection SendDataToProductionChartCNC1(IEnumerable<EventManagerCNC1> table, DateTime DisplayDateProduct)
        {
            DateTime[] Date = DateTimeProductionCal(DisplayDateProduct);
            int[] returnDays = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays1 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays2 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            using (CNCProjectEntities db = new CNCProjectEntities())
            {
                returnDays1[0] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays1[1] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays1[2] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays1[3] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays1[4] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays1[5] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays1[6] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays2[0] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays2[1] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays2[2] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays2[3] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays2[4] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays2[5] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays2[6] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays[7] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays[8] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays[9] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays[10] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays[11] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays[12] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays[13] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

            }
            SeriesCollection series = SeriesCal(returnDays, returnDays1, returnDays2);
            return series;
        }
        public SeriesCollection SendDataToProductionChartCNC2(IEnumerable<EventManagerCNC2> table, DateTime DisplayDateProduct)
        {
            DateTime[] Date = DateTimeProductionCal(DisplayDateProduct);
            int[] returnDays = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays1 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays2 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            using (CNCProjectEntities db = new CNCProjectEntities())
            {
                returnDays1[0] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays1[1] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays1[2] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays1[3] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays1[4] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays1[5] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays1[6] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays2[0] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays2[1] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays2[2] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays2[3] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays2[4] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays2[5] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays2[6] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays[7] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays[8] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays[9] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays[10] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays[11] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays[12] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays[13] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

            }
            SeriesCollection series = SeriesCal(returnDays, returnDays1, returnDays2);
            return series;
        }
        public SeriesCollection SendDataToProductionChartCNC3(IEnumerable<EventManagerCNC3> table, DateTime DisplayDateProduct)
        {
            DateTime[] Date = DateTimeProductionCal(DisplayDateProduct);
            int[] returnDays = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays1 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays2 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            using (CNCProjectEntities db = new CNCProjectEntities())
            {
                returnDays1[0] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays1[1] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays1[2] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays1[3] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays1[4] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays1[5] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays1[6] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays2[0] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays2[1] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays2[2] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays2[3] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays2[4] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays2[5] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays2[6] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays[7] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays[8] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays[9] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays[10] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays[11] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays[12] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays[13] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

            }
            SeriesCollection series = SeriesCal(returnDays, returnDays1, returnDays2);
            return series;
        }
        public SeriesCollection SendDataToProductionChartCNC4(IEnumerable<EventManagerCNC4> table, DateTime DisplayDateProduct)
        {
            DateTime[] Date = DateTimeProductionCal(DisplayDateProduct);
            int[] returnDays = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays1 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays2 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            using (CNCProjectEntities db = new CNCProjectEntities())
            {
                returnDays1[0] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays1[1] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays1[2] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays1[3] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays1[4] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays1[5] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays1[6] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays2[0] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays2[1] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays2[2] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays2[3] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays2[4] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays2[5] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays2[6] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays[7] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays[8] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays[9] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays[10] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays[11] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays[12] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays[13] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

            }
            SeriesCollection series = SeriesCal(returnDays, returnDays1, returnDays2);
            return series;
        }
        public SeriesCollection SendDataToProductionChartCNC5(IEnumerable<EventManagerCNC5> table, DateTime DisplayDateProduct)
        {
            DateTime[] Date = DateTimeProductionCal(DisplayDateProduct);
            int[] returnDays = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays1 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays2 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            using (CNCProjectEntities db = new CNCProjectEntities())
            {
                returnDays1[0] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays1[1] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays1[2] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays1[3] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays1[4] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays1[5] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays1[6] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays2[0] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays2[1] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays2[2] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays2[3] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays2[4] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays2[5] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays2[6] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays[7] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays[8] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays[9] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays[10] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays[11] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays[12] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays[13] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

            }
            SeriesCollection series = SeriesCal(returnDays, returnDays1, returnDays2);
            return series;
        }
        public SeriesCollection SendDataToProductionChartCNC6(IEnumerable<EventManagerCNC6> table, DateTime DisplayDateProduct)
        {
            DateTime[] Date = DateTimeProductionCal(DisplayDateProduct);
            int[] returnDays = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays1 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays2 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            using (CNCProjectEntities db = new CNCProjectEntities())
            {
                returnDays1[0] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays1[1] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays1[2] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays1[3] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays1[4] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays1[5] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays1[6] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays2[0] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays2[1] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays2[2] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays2[3] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays2[4] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays2[5] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays2[6] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays[7] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays[8] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays[9] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays[10] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays[11] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays[12] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays[13] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

            }
            SeriesCollection series = SeriesCal(returnDays, returnDays1, returnDays2);
            return series;
        }
        public SeriesCollection SendDataToProductionChartCNC7(IEnumerable<EventManagerCNC7> table, DateTime DisplayDateProduct)
        {
            DateTime[] Date = DateTimeProductionCal(DisplayDateProduct);
            int[] returnDays = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays1 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays2 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            using (CNCProjectEntities db = new CNCProjectEntities())
            {
                returnDays1[0] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays1[1] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays1[2] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays1[3] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays1[4] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays1[5] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays1[6] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays2[0] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays2[1] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays2[2] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays2[3] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays2[4] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays2[5] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays2[6] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays[7] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays[8] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays[9] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays[10] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays[11] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays[12] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays[13] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

            }
            SeriesCollection series = SeriesCal(returnDays, returnDays1, returnDays2);
            return series;
        }
        public SeriesCollection SendDataToProductionChartCNC8(IEnumerable<EventManagerCNC8> table, DateTime DisplayDateProduct)
        {
            DateTime[] Date = DateTimeProductionCal(DisplayDateProduct);
            int[] returnDays = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays1 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            int[] returnDays2 = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            using (CNCProjectEntities db = new CNCProjectEntities())
            {
                returnDays1[0] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays1[1] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays1[2] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays1[3] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays1[4] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays1[5] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays1[6] = table.Where(x => x.IdHienTrangMayCNC == 1 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays2[0] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays2[1] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays2[2] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays2[3] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays2[4] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays2[5] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays2[6] = table.Where(x => x.IdHienTrangMayCNC == 2 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

                returnDays[7] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[0] && x.ThoiDiem < Date[1]).Count();
                returnDays[8] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[1] && x.ThoiDiem < Date[2]).Count();
                returnDays[9] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[2] && x.ThoiDiem < Date[3]).Count();
                returnDays[10] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[3] && x.ThoiDiem < Date[4]).Count();
                returnDays[11] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[4] && x.ThoiDiem < Date[5]).Count();
                returnDays[12] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[5] && x.ThoiDiem < Date[6]).Count();
                returnDays[13] = table.Where(x => x.IdHienTrangMayCNC == 3 && x.ThoiDiem >= Date[6] && x.ThoiDiem < Date[7]).Count();

            }
            SeriesCollection series = SeriesCal(returnDays, returnDays1, returnDays2);
            return series;
        }
    }
}

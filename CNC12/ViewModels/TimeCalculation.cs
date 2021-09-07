using CNC12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC12.ViewModels
{
    public class TimeCalculation
    {
        public double[] TimeFirstToLastCalculate(int SeasonCount, int CountTotalLastUp, int LastUpStatus, DateTime? t1l, DateTime? t2l)
        {
            double[] result = { 0, 0, 0 };
            DateTime? tNow0 = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan? tSpan1 = tNow0 - t1l;
            TimeSpan? tSpan2 = t2l - t1l;
            if (SeasonCount == 0)
            {
                if (CountTotalLastUp > 0)
                {
                    if (t2l >= tNow0 && t1l <= tNow0)
                    {
                        if (LastUpStatus == 1)
                        {
                            result[0] = result[0] + tSpan1.Value.TotalSeconds;
                        }
                        if (LastUpStatus == 2)
                        {
                            result[1] = result[1] + tSpan1.Value.TotalSeconds;
                        }
                        if (LastUpStatus == 3)
                        {
                            result[2] = result[2] + tSpan1.Value.TotalSeconds;
                        }
                    }
                    if (tNow0 > t2l)
                    {
                        if (LastUpStatus == 1)
                        {
                            result[0] = result[0] + tSpan2.Value.TotalSeconds;
                        }
                        if (LastUpStatus == 2)
                        {
                            result[1] = result[1] + tSpan2.Value.TotalSeconds;
                        }
                        if (LastUpStatus == 3)
                        {
                            result[2] = result[2] + tSpan2.Value.TotalSeconds;
                        }
                    }
                    if (tNow0 < t1l)
                    {
                        return result;
                    }
                }
                else
                {
                    return result;
                }
            }

            return result;
        }
        public double[] TimeLastToEndCalculate(int lasttotalId, int lastId, int LastStatus, DateTime? lastThoiDiem, DateTime? lasttotalThoiDiem, DateTime? t1l, DateTime? t2l)
        {
            double[] result = { 0, 0, 0 };
            DateTime? tNow0 = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            if (lasttotalThoiDiem < t1l)
            {
                return result;
            }
            if (lasttotalThoiDiem == lastThoiDiem)
            {
                if (t1l <= tNow0 && tNow0 <= t2l)
                {
                    TimeSpan? time = DateTime.Now - lastThoiDiem;
                    if (LastStatus == 1)
                    {
                        result[0] = result[0] + time.Value.TotalSeconds;
                    }
                    if (LastStatus == 2)
                    {
                        result[1] = result[1] + time.Value.TotalSeconds;
                    }
                    if (LastStatus == 3)
                    {
                        result[2] = result[2] + time.Value.TotalSeconds;
                    }
                }
                if (t2l < tNow0)
                {
                    TimeSpan? time = t2l - lastThoiDiem;
                    if (LastStatus == 1)
                    {
                        result[0] = result[0] + time.Value.TotalSeconds;
                    }
                    if (LastStatus == 2)
                    {
                        result[1] = result[1] + time.Value.TotalSeconds;
                    }
                    if (LastStatus == 3)
                    {
                        result[2] = result[2] + time.Value.TotalSeconds;
                    }
                }
            }
            if (lasttotalId > lastId)
            {
                TimeSpan? time = t2l - lastThoiDiem;
                if (LastStatus == 1)
                {
                    result[0] = result[0] + time.Value.TotalSeconds;
                }
                if (LastStatus == 2)
                {
                    result[1] = result[1] + time.Value.TotalSeconds;
                }
                if (LastStatus == 3)
                {
                    result[2] = result[2] + time.Value.TotalSeconds;
                }
            }
            return result;
        }
        public double[] TimeStartToFirstCalculate(int LastUpStatus, int CountTotalLastUp, DateTime? timeFirst, DateTime? t1l)
        {
            double[] result = { 0, 0, 0 };
            TimeSpan? tfirst1 = timeFirst - t1l;
            double tfirst = 0;
            if (tfirst1 == null)
            {
                tfirst = 0;
            }
            else
            {
                tfirst = tfirst + tfirst1.Value.TotalSeconds;
            }
            if (CountTotalLastUp > 0)
            {
                if (LastUpStatus == 2)
                {
                    result[1] = result[1] + tfirst;
                }
                if (LastUpStatus == 3)
                {
                    result[2] = result[2] + tfirst;
                }
                if (LastUpStatus == 1)
                {
                    result[0] = result[0] + tfirst;
                }
            }
            return result;
        }
        public async Task<double[]> TimeCalculation_AllCNC(int month1, int month2, int year)
        {
            GC.Collect();
            string monthStr1 = month1.ToString();
            if (month1 < 10)
            {
                monthStr1 = "0" + monthStr1;
            }
            string monthStr2 = month2.ToString();
            if (month2 < 10)
            {
                monthStr2 = "0" + monthStr2;
            }
            string days = DateTime.DaysInMonth(year, month2).ToString();
            DateTime t1m = DateTime.ParseExact(year.ToString() + "-" + monthStr1 + "-01 00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime t2m = DateTime.ParseExact(year.ToString() + "-" + monthStr2 + "-" + days + " " + "23:59:59.999", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);

            var total1m = TimeCalculation_CNC1(t1m, t2m, DataProvider.Ins.DB.EventManagerCNC1.AsEnumerable());
            var total2m = TimeCalculation_CNC2(t1m, t2m, DataProvider.Ins.DB.EventManagerCNC2.AsEnumerable());
            var total3m = TimeCalculation_CNC3(t1m, t2m, DataProvider.Ins.DB.EventManagerCNC3.AsEnumerable());
            var total4m = TimeCalculation_CNC4(t1m, t2m, DataProvider.Ins.DB.EventManagerCNC4.AsEnumerable());
            var total5m = TimeCalculation_CNC5(t1m, t2m, DataProvider.Ins.DB.EventManagerCNC5.AsEnumerable());
            var total6m = TimeCalculation_CNC6(t1m, t2m, DataProvider.Ins.DB.EventManagerCNC6.AsEnumerable());
            var total7m = TimeCalculation_CNC7(t1m, t2m, DataProvider.Ins.DB.EventManagerCNC7.AsEnumerable());
            var total8m = TimeCalculation_CNC8(t1m, t2m, DataProvider.Ins.DB.EventManagerCNC8.AsEnumerable());

            await Task.WhenAll(
                total1m,
                total2m,
                total3m,
                total4m,
                total5m,
                total6m,
                total7m,
                total8m
                );

            double[] total1 = total1m.Result.ToArray();
            double[] total2 = total2m.Result.ToArray();
            double[] total3 = total3m.Result.ToArray();
            double[] total4 = total4m.Result.ToArray();
            double[] total5 = total5m.Result.ToArray();
            double[] total6 = total6m.Result.ToArray();
            double[] total7 = total7m.Result.ToArray();
            double[] total8 = total8m.Result.ToArray();

            double[] result = new double[3] { 0, 0, 0 };
            for (int i = 0; i < 3; i++)
            {
                result[i] = total1[i] + total2[i] + total3[i] + total4[i] + total5[i] + total6[i] + total7[i] + total8[i];
            }
            return result;

        }
        public async Task<double[]> TimeCalculation_CNC1(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC1> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] m = new double[4] { 0, 0, 0, tpanm.Value.TotalHours };
            double TimeStop = 0;
            double TimeRun = 0;
            double TimeFail = 0;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
                return m;

            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();

            if (LastUp != null)
            {
                double[] result1 = { 0, 0, 0 };
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun = TimeRun + result1[0];
                TimeStop = TimeStop + result1[1];
                TimeFail = TimeFail + result1[2];
                if (first != null)
                {
                    double[] result2 = { 0, 0, 0 };
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun = TimeRun + result2[0];
                    TimeStop = TimeStop + result2[1];
                    TimeFail = TimeFail + result2[2];
                }
            }

            if (season.Count() > 0)
            {
                double[] result = { 0, 0, 0 };
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun = TimeRun + result[0];
                TimeStop = TimeStop + result[1];
                TimeFail = TimeFail + result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun = TimeRun + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop = TimeStop + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail = TimeFail + tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            m[0] = Math.Truncate((TimeRun / 3600) * 100) / 100;
            m[1] = Math.Truncate((TimeStop / 3600) * 100) / 100;
            m[2] = Math.Truncate((TimeFail / 3600) * 100) / 100;
            m[3] = Math.Truncate((tpanm.Value.TotalHours - m[0] - m[1] - m[2]) * 100) / 100;
            await Task.Delay(0);
            return m;
        }
        public async Task<double[]> TimeCalculation_CNC2(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC2> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] m = new double[4] { 0, 0, 0, tpanm.Value.TotalHours };
            double TimeStop = 0;
            double TimeRun = 0;
            double TimeFail = 0;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
                return m;

            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();

            if (LastUp != null)
            {
                double[] result1 = { 0, 0, 0 };
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun = TimeRun + result1[0];
                TimeStop = TimeStop + result1[1];
                TimeFail = TimeFail + result1[2];
                if (first != null)
                {
                    double[] result2 = { 0, 0, 0 };
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun = TimeRun + result2[0];
                    TimeStop = TimeStop + result2[1];
                    TimeFail = TimeFail + result2[2];
                }
            }

            if (season.Count() > 0)
            {
                double[] result = { 0, 0, 0 };
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun = TimeRun + result[0];
                TimeStop = TimeStop + result[1];
                TimeFail = TimeFail + result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun = TimeRun + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop = TimeStop + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail = TimeFail + tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            m[0] = Math.Truncate((TimeRun / 3600) * 100) / 100;
            m[1] = Math.Truncate((TimeStop / 3600) * 100) / 100;
            m[2] = Math.Truncate((TimeFail / 3600) * 100) / 100;
            m[3] = Math.Truncate((tpanm.Value.TotalHours - m[0] - m[1] - m[2]) * 100) / 100;
            await Task.Delay(0);
            return m;
        }
        public async Task<double[]> TimeCalculation_CNC3(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC3> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] m = new double[4] { 0, 0, 0, tpanm.Value.TotalHours };
            double TimeStop = 0;
            double TimeRun = 0;
            double TimeFail = 0;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
                return m;

            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();

            if (LastUp != null)
            {
                double[] result1 = { 0, 0, 0 };
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun = TimeRun + result1[0];
                TimeStop = TimeStop + result1[1];
                TimeFail = TimeFail + result1[2];
                if (first != null)
                {
                    double[] result2 = { 0, 0, 0 };
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun = TimeRun + result2[0];
                    TimeStop = TimeStop + result2[1];
                    TimeFail = TimeFail + result2[2];
                }
            }

            if (season.Count() > 0)
            {
                double[] result = { 0, 0, 0 };
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun = TimeRun + result[0];
                TimeStop = TimeStop + result[1];
                TimeFail = TimeFail + result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun = TimeRun + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop = TimeStop + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail = TimeFail + tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            m[0] = Math.Truncate((TimeRun / 3600) * 100) / 100;
            m[1] = Math.Truncate((TimeStop / 3600) * 100) / 100;
            m[2] = Math.Truncate((TimeFail / 3600) * 100) / 100;
            m[3] = Math.Truncate((tpanm.Value.TotalHours - m[0] - m[1] - m[2]) * 100) / 100;
            await Task.Delay(0);
            return m;
        }
        public async Task<double[]> TimeCalculation_CNC4(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC4> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] m = new double[4] { 0, 0, 0, tpanm.Value.TotalHours };
            double TimeStop = 0;
            double TimeRun = 0;
            double TimeFail = 0;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
                return m;

            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();

            if (LastUp != null)
            {
                double[] result1 = { 0, 0, 0 };
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun = TimeRun + result1[0];
                TimeStop = TimeStop + result1[1];
                TimeFail = TimeFail + result1[2];
                if (first != null)
                {
                    double[] result2 = { 0, 0, 0 };
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun = TimeRun + result2[0];
                    TimeStop = TimeStop + result2[1];
                    TimeFail = TimeFail + result2[2];
                }
            }

            if (season.Count() > 0)
            {
                double[] result = { 0, 0, 0 };
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun = TimeRun + result[0];
                TimeStop = TimeStop + result[1];
                TimeFail = TimeFail + result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun = TimeRun + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop = TimeStop + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail = TimeFail + tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            m[0] = Math.Truncate((TimeRun / 3600) * 100) / 100;
            m[1] = Math.Truncate((TimeStop / 3600) * 100) / 100;
            m[2] = Math.Truncate((TimeFail / 3600) * 100) / 100;
            m[3] = Math.Truncate((tpanm.Value.TotalHours - m[0] - m[1] - m[2]) * 100) / 100;
            await Task.Delay(0);
            return m;
        }
        public async Task<double[]> TimeCalculation_CNC5(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC5> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] m = new double[4] { 0, 0, 0, tpanm.Value.TotalHours };
            double TimeStop = 0;
            double TimeRun = 0;
            double TimeFail = 0;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
                return m;

            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();

            if (LastUp != null)
            {
                double[] result1 = { 0, 0, 0 };
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun = TimeRun + result1[0];
                TimeStop = TimeStop + result1[1];
                TimeFail = TimeFail + result1[2];
                if (first != null)
                {
                    double[] result2 = { 0, 0, 0 };
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun = TimeRun + result2[0];
                    TimeStop = TimeStop + result2[1];
                    TimeFail = TimeFail + result2[2];
                }
            }

            if (season.Count() > 0)
            {
                double[] result = { 0, 0, 0 };
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun = TimeRun + result[0];
                TimeStop = TimeStop + result[1];
                TimeFail = TimeFail + result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun = TimeRun + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop = TimeStop + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail = TimeFail + tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            m[0] = Math.Truncate((TimeRun / 3600) * 100) / 100;
            m[1] = Math.Truncate((TimeStop / 3600) * 100) / 100;
            m[2] = Math.Truncate((TimeFail / 3600) * 100) / 100;
            m[3] = Math.Truncate((tpanm.Value.TotalHours - m[0] - m[1] - m[2]) * 100) / 100;
            await Task.Delay(0);
            return m;
        }
        public async Task<double[]> TimeCalculation_CNC6(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC6> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] m = new double[4] { 0, 0, 0, tpanm.Value.TotalHours };
            double TimeStop = 0;
            double TimeRun = 0;
            double TimeFail = 0;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
                return m;

            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();

            if (LastUp != null)
            {
                double[] result1 = { 0, 0, 0 };
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun = TimeRun + result1[0];
                TimeStop = TimeStop + result1[1];
                TimeFail = TimeFail + result1[2];
                if (first != null)
                {
                    double[] result2 = { 0, 0, 0 };
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun = TimeRun + result2[0];
                    TimeStop = TimeStop + result2[1];
                    TimeFail = TimeFail + result2[2];
                }
            }

            if (season.Count() > 0)
            {
                double[] result = { 0, 0, 0 };
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun = TimeRun + result[0];
                TimeStop = TimeStop + result[1];
                TimeFail = TimeFail + result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun = TimeRun + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop = TimeStop + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail = TimeFail + tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            m[0] = Math.Truncate((TimeRun / 3600) * 100) / 100;
            m[1] = Math.Truncate((TimeStop / 3600) * 100) / 100;
            m[2] = Math.Truncate((TimeFail / 3600) * 100) / 100;
            m[3] = Math.Truncate((tpanm.Value.TotalHours - m[0] - m[1] - m[2]) * 100) / 100;
            await Task.Delay(0);
            return m;
        }
        public async Task<double[]> TimeCalculation_CNC7(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC7> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] m = new double[4] { 0, 0, 0, tpanm.Value.TotalHours };
            double TimeStop = 0;
            double TimeRun = 0;
            double TimeFail = 0;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
                return m;

            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();

            if (LastUp != null)
            {
                double[] result1 = { 0, 0, 0 };
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun = TimeRun + result1[0];
                TimeStop = TimeStop + result1[1];
                TimeFail = TimeFail + result1[2];
                if (first != null)
                {
                    double[] result2 = { 0, 0, 0 };
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun = TimeRun + result2[0];
                    TimeStop = TimeStop + result2[1];
                    TimeFail = TimeFail + result2[2];
                }
            }

            if (season.Count() > 0)
            {
                double[] result = { 0, 0, 0 };
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun = TimeRun + result[0];
                TimeStop = TimeStop + result[1];
                TimeFail = TimeFail + result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun = TimeRun + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop = TimeStop + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail = TimeFail + tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            m[0] = Math.Truncate((TimeRun / 3600) * 100) / 100;
            m[1] = Math.Truncate((TimeStop / 3600) * 100) / 100;
            m[2] = Math.Truncate((TimeFail / 3600) * 100) / 100;
            m[3] = Math.Truncate((tpanm.Value.TotalHours - m[0] - m[1] - m[2]) * 100) / 100;
            await Task.Delay(0);
            return m;
        }
        public async Task<double[]> TimeCalculation_CNC8(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC8> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] m = new double[4] { 0, 0, 0, tpanm.Value.TotalHours };
            double TimeStop = 0;
            double TimeRun = 0;
            double TimeFail = 0;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
                return m;

            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();

            if (LastUp != null)
            {
                double[] result1 = { 0, 0, 0 };
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun = TimeRun + result1[0];
                TimeStop = TimeStop + result1[1];
                TimeFail = TimeFail + result1[2];
                if (first != null)
                {
                    double[] result2 = { 0, 0, 0 };
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun = TimeRun + result2[0];
                    TimeStop = TimeStop + result2[1];
                    TimeFail = TimeFail + result2[2];
                }
            }

            if (season.Count() > 0)
            {
                double[] result = { 0, 0, 0 };
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun = TimeRun + result[0];
                TimeStop = TimeStop + result[1];
                TimeFail = TimeFail + result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun = TimeRun + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop = TimeStop + tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail = TimeFail + tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            m[0] = Math.Truncate((TimeRun / 3600) * 100) / 100;
            m[1] = Math.Truncate((TimeStop / 3600) * 100) / 100;
            m[2] = Math.Truncate((TimeFail / 3600) * 100) / 100;
            m[3] = Math.Truncate((tpanm.Value.TotalHours - m[0] - m[1] - m[2]) * 100) / 100;
            await Task.Delay(0);
            return m;
        }
    }
}

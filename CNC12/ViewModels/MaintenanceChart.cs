using CNC12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CNC12.ViewModels
{
    public class MaintenanceChart
    {
        public Brush[] ColorLightMaintenance(double[] temp)
        {
            GC.Collect();
            Brush[] light = new Brush[8] { Brushes.Lime, Brushes.Lime, Brushes.Lime, Brushes.Lime, Brushes.Lime, Brushes.Lime, Brushes.Lime, Brushes.Lime };
            for (int i = 0; i < 8; i++)
            {
                if (1000 - temp[i] >= 0 && 1000 - temp[i] <= 24)
                {
                    light[i] = Brushes.Red;
                }
                else
                {
                    light[i] = Brushes.Lime;
                }
            }
            return light;

        }
        public async Task<double> TimeMaintenance_CNC1(IEnumerable<EventManagerCNC1> total)
        {
            GC.Collect();
            double u = 0;
            if (total == null)
                return u;
            else
            {
                var run = total.Where(p => p.IdHienTrangMayCNC == 1);
                if (run == null)
                {
                    return u;
                }
                else
                {
                    var lasttotal = total.ToArray().LastOrDefault();
                    var firsttotal = total.ToArray().FirstOrDefault();
                    var last = run.ToArray().LastOrDefault();
                    var first = run.ToArray().FirstOrDefault();
                    double temp = 0;

                    TimeSpan? tpan = DateTime.Now - lasttotal.ThoiDiem;
                    if (lasttotal.IdHienTrangMayCNC == 1)
                    {
                        temp = temp + tpan.Value.TotalSeconds;
                    }
                    foreach (var item in total)
                    {
                        foreach (var item1 in run)
                        {
                            if (item1.Id + 1 == item.Id)
                            {
                                TimeSpan? tpan1 = item.ThoiDiem - item1.ThoiDiem;
                                temp = temp + tpan1.Value.TotalSeconds;
                            }
                        }
                    }
                    double tempDouble = Math.Truncate(temp / 3600 * 100) / 100;
                    int Value1 = Convert.ToInt32(Math.Floor((double)tempDouble));
                    double result1 = Value1 % 1000 + tempDouble - Math.Floor((double)tempDouble);
                    double result2 = Value1 + tempDouble - Math.Floor((double)tempDouble);
                    await Task.Delay(0);
                    if (tempDouble > 1000)
                    {
                        return result1;
                    }
                    else
                    {
                        return result2;
                    }
                }
            }
        }
        public async Task<double> TimeMaintenance_CNC2(IEnumerable<EventManagerCNC2> total)
        {
            GC.Collect();
            double u = 0;
            if (total == null)
                return u;
            else
            {
                var run = total.Where(p => p.IdHienTrangMayCNC == 1);
                if (run == null)
                {
                    return u;
                }
                else
                {
                    var lasttotal = total.ToArray().LastOrDefault();
                    var firsttotal = total.ToArray().FirstOrDefault();
                    var last = run.ToArray().LastOrDefault();
                    var first = run.ToArray().FirstOrDefault();
                    double temp = 0;

                    TimeSpan? tpan = DateTime.Now - lasttotal.ThoiDiem;
                    if (lasttotal.IdHienTrangMayCNC == 1)
                    {
                        temp = temp + tpan.Value.TotalSeconds;
                    }
                    foreach (var item in total)
                    {
                        foreach (var item1 in run)
                        {
                            if (item1.Id + 1 == item.Id)
                            {
                                TimeSpan? tpan1 = item.ThoiDiem - item1.ThoiDiem;
                                temp = temp + tpan1.Value.TotalSeconds;
                            }
                        }
                    }
                    double tempDouble = Math.Truncate(temp / 3600 * 100) / 100;
                    int Value1 = Convert.ToInt32(Math.Floor((double)tempDouble));
                    double result1 = Value1 % 1000 + tempDouble - Math.Floor((double)tempDouble);
                    double result2 = Value1 + tempDouble - Math.Floor((double)tempDouble);
                    await Task.Delay(0);
                    if (tempDouble > 1000)
                    {
                        return result1;
                    }
                    else
                    {
                        return result2;
                    }
                }
            }
        }
        public async Task<double> TimeMaintenance_CNC3(IEnumerable<EventManagerCNC3> total)
        {
            GC.Collect();
            double u = 0;
            if (total == null)
                return u;
            else
            {
                var run = total.Where(p => p.IdHienTrangMayCNC == 1);
                if (run == null)
                {
                    return u;
                }
                else
                {
                    var lasttotal = total.ToArray().LastOrDefault();
                    var firsttotal = total.ToArray().FirstOrDefault();
                    var last = run.ToArray().LastOrDefault();
                    var first = run.ToArray().FirstOrDefault();
                    double temp = 0;

                    TimeSpan? tpan = DateTime.Now - lasttotal.ThoiDiem;
                    if (lasttotal.IdHienTrangMayCNC == 1)
                    {
                        temp = temp + tpan.Value.TotalSeconds;
                    }
                    foreach (var item in total)
                    {
                        foreach (var item1 in run)
                        {
                            if (item1.Id + 1 == item.Id)
                            {
                                TimeSpan? tpan1 = item.ThoiDiem - item1.ThoiDiem;
                                temp = temp + tpan1.Value.TotalSeconds;
                            }
                        }
                    }
                    double tempDouble = Math.Truncate(temp / 3600 * 100) / 100;
                    int Value1 = Convert.ToInt32(Math.Floor((double)tempDouble));
                    double result1 = Value1 % 1000 + tempDouble - Math.Floor((double)tempDouble);
                    double result2 = Value1 + tempDouble - Math.Floor((double)tempDouble);
                    await Task.Delay(0);
                    if (tempDouble > 1000)
                    {
                        return result1;
                    }
                    else
                    {
                        return result2;
                    }
                }
            }
        }
        public async Task<double> TimeMaintenance_CNC4(IEnumerable<EventManagerCNC4> total)
        {
            GC.Collect();
            double u = 0;
            if (total == null)
                return u;
            else
            {
                var run = total.Where(p => p.IdHienTrangMayCNC == 1);
                if (run == null)
                {
                    return u;
                }
                else
                {
                    var lasttotal = total.ToArray().LastOrDefault();
                    var firsttotal = total.ToArray().FirstOrDefault();
                    var last = run.ToArray().LastOrDefault();
                    var first = run.ToArray().FirstOrDefault();
                    double temp = 0;

                    TimeSpan? tpan = DateTime.Now - lasttotal.ThoiDiem;
                    if (lasttotal.IdHienTrangMayCNC == 1)
                    {
                        temp = temp + tpan.Value.TotalSeconds;
                    }
                    foreach (var item in total)
                    {
                        foreach (var item1 in run)
                        {
                            if (item1.Id + 1 == item.Id)
                            {
                                TimeSpan? tpan1 = item.ThoiDiem - item1.ThoiDiem;
                                temp = temp + tpan1.Value.TotalSeconds;
                            }
                        }
                    }
                    double tempDouble = Math.Truncate(temp / 3600 * 100) / 100;
                    int Value1 = Convert.ToInt32(Math.Floor((double)tempDouble));
                    double result1 = Value1 % 1000 + tempDouble - Math.Floor((double)tempDouble);
                    double result2 = Value1 + tempDouble - Math.Floor((double)tempDouble);
                    await Task.Delay(0);
                    if (tempDouble > 1000)
                    {
                        return result1;
                    }
                    else
                    {
                        return result2;
                    }
                }
            }
        }
        public async Task<double> TimeMaintenance_CNC5(IEnumerable<EventManagerCNC5> total)
        {
            GC.Collect();
            double u = 0;
            if (total == null)
                return u;
            else
            {
                var run = total.Where(p => p.IdHienTrangMayCNC == 1);
                if (run == null)
                {
                    return u;
                }
                else
                {
                    var lasttotal = total.ToArray().LastOrDefault();
                    var firsttotal = total.ToArray().FirstOrDefault();
                    var last = run.ToArray().LastOrDefault();
                    var first = run.ToArray().FirstOrDefault();
                    double temp = 0;

                    TimeSpan? tpan = DateTime.Now - lasttotal.ThoiDiem;
                    if (lasttotal.IdHienTrangMayCNC == 1)
                    {
                        temp = temp + tpan.Value.TotalSeconds;
                    }
                    foreach (var item in total)
                    {
                        foreach (var item1 in run)
                        {
                            if (item1.Id + 1 == item.Id)
                            {
                                TimeSpan? tpan1 = item.ThoiDiem - item1.ThoiDiem;
                                temp = temp + tpan1.Value.TotalSeconds;
                            }
                        }
                    }
                    double tempDouble = Math.Truncate(temp / 3600 * 100) / 100;
                    int Value1 = Convert.ToInt32(Math.Floor((double)tempDouble));
                    double result1 = Value1 % 1000 + tempDouble - Math.Floor((double)tempDouble);
                    double result2 = Value1 + tempDouble - Math.Floor((double)tempDouble);
                    await Task.Delay(0);
                    if (tempDouble > 1000)
                    {
                        return result1;
                    }
                    else
                    {
                        return result2;
                    }
                }
            }
        }
        public async Task<double> TimeMaintenance_CNC6(IEnumerable<EventManagerCNC6> total)
        {
            GC.Collect();
            double u = 0;
            if (total == null)
                return u;
            else
            {
                var run = total.Where(p => p.IdHienTrangMayCNC == 1);
                if (run == null)
                {
                    return u;
                }
                else
                {
                    var lasttotal = total.ToArray().LastOrDefault();
                    var firsttotal = total.ToArray().FirstOrDefault();
                    var last = run.ToArray().LastOrDefault();
                    var first = run.ToArray().FirstOrDefault();
                    double temp = 0;

                    TimeSpan? tpan = DateTime.Now - lasttotal.ThoiDiem;
                    if (lasttotal.IdHienTrangMayCNC == 1)
                    {
                        temp = temp + tpan.Value.TotalSeconds;
                    }
                    foreach (var item in total)
                    {
                        foreach (var item1 in run)
                        {
                            if (item1.Id + 1 == item.Id)
                            {
                                TimeSpan? tpan1 = item.ThoiDiem - item1.ThoiDiem;
                                temp = temp + tpan1.Value.TotalSeconds;
                            }
                        }
                    }
                    double tempDouble = Math.Truncate(temp / 3600 * 100) / 100;
                    int Value1 = Convert.ToInt32(Math.Floor((double)tempDouble));
                    double result1 = Value1 % 1000 + tempDouble - Math.Floor((double)tempDouble);
                    double result2 = Value1 + tempDouble - Math.Floor((double)tempDouble);
                    await Task.Delay(0);
                    if (tempDouble > 1000)
                    {
                        return result1;
                    }
                    else
                    {
                        return result2;
                    }
                }
            }
        }
        public async Task<double> TimeMaintenance_CNC7(IEnumerable<EventManagerCNC7> total)
        {
            GC.Collect();
            double u = 0;
            if (total == null)
                return u;
            else
            {
                var run = total.Where(p => p.IdHienTrangMayCNC == 1);
                if (run == null)
                {
                    return u;
                }
                else
                {
                    var lasttotal = total.ToArray().LastOrDefault();
                    var firsttotal = total.ToArray().FirstOrDefault();
                    var last = run.ToArray().LastOrDefault();
                    var first = run.ToArray().FirstOrDefault();
                    double temp = 0;

                    TimeSpan? tpan = DateTime.Now - lasttotal.ThoiDiem;
                    if (lasttotal.IdHienTrangMayCNC == 1)
                    {
                        temp = temp + tpan.Value.TotalSeconds;
                    }
                    foreach (var item in total)
                    {
                        foreach (var item1 in run)
                        {
                            if (item1.Id + 1 == item.Id)
                            {
                                TimeSpan? tpan1 = item.ThoiDiem - item1.ThoiDiem;
                                temp = temp + tpan1.Value.TotalSeconds;
                            }
                        }
                    }
                    double tempDouble = Math.Truncate(temp / 3600 * 100) / 100;
                    int Value1 = Convert.ToInt32(Math.Floor((double)tempDouble));
                    double result1 = Value1 % 1000 + tempDouble - Math.Floor((double)tempDouble);
                    double result2 = Value1 + tempDouble - Math.Floor((double)tempDouble);
                    await Task.Delay(0);
                    if (tempDouble > 1000)
                    {
                        return result1;
                    }
                    else
                    {
                        return result2;
                    }
                }
            }
        }
        public async Task<double> TimeMaintenance_CNC8(IEnumerable<EventManagerCNC8> total)
        {
            GC.Collect();
            double u = 0;
            if (total == null)
                return u;
            else
            {
                var run = total.Where(p => p.IdHienTrangMayCNC == 1);
                if (run == null)
                {
                    return u;
                }
                else
                {
                    var lasttotal = total.ToArray().LastOrDefault();
                    var firsttotal = total.ToArray().FirstOrDefault();
                    var last = run.ToArray().LastOrDefault();
                    var first = run.ToArray().FirstOrDefault();
                    double temp = 0;

                    TimeSpan? tpan = DateTime.Now - lasttotal.ThoiDiem;
                    if (lasttotal.IdHienTrangMayCNC == 1)
                    {
                        temp = temp + tpan.Value.TotalSeconds;
                    }
                    foreach (var item in total)
                    {
                        foreach (var item1 in run)
                        {
                            if (item1.Id + 1 == item.Id)
                            {
                                TimeSpan? tpan1 = item.ThoiDiem - item1.ThoiDiem;
                                temp = temp + tpan1.Value.TotalSeconds;
                            }
                        }
                    }
                    double tempDouble = Math.Truncate(temp / 3600 * 100) / 100;
                    int Value1 = Convert.ToInt32(Math.Floor((double)tempDouble));
                    double result1 = Value1 % 1000 + tempDouble - Math.Floor((double)tempDouble);
                    double result2 = Value1 + tempDouble - Math.Floor((double)tempDouble);
                    await Task.Delay(0);
                    if (tempDouble > 1000)
                    {
                        return result1;
                    }
                    else
                    {
                        return result2;
                    }
                }
            }
        }
    }
}

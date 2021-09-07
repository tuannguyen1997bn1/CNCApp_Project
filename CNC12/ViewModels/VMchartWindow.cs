using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System;
using CNC12.Model;
using System.Linq;
using System.Windows.Input;
using CNC12.Views;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.IO;
using LiveCharts.Wpf.Charts.Base;

namespace CNC12.ViewModels
{
    public class VMchartWindow : BaseVM
    {
        #region Declare

        #region Others
        //SaveFileDialog svd;
        Thread Thread_execution;
        private readonly DispatcherTimer timer;
        private string _YearSelected;
        public string YearSelected
        {
            get => _YearSelected;
            set
            {
                _YearSelected = value;
                OnPropertyChanged("YearSelected");
            }
        }
        private string _SeasonSelected;
        public string SeasonSelected
        {
            get => _SeasonSelected;
            set
            {
                _SeasonSelected = value;
                OnPropertyChanged("SeasonSelected");
            }
        }
        private string _MonthSelected;
        public string MonthSelected
        {
            get => _MonthSelected;
            set
            {
                _MonthSelected = value;
                OnPropertyChanged("YearSelected");
            }
        }


        private DateTime _DisplayDateProduct;
        public DateTime DisplayDateProduct
        {
            get => _DisplayDateProduct;
            set
            {
                _DisplayDateProduct = value;
                OnPropertyChanged("DisplayDateProduct");
            }
        }
        private DateTime _DisplayDateSplitTime;
        public DateTime DisplayDateSplitTime
        {
            get => _DisplayDateSplitTime;
            set
            {
                _DisplayDateSplitTime = value;
                OnPropertyChanged("DisplayDateSplitTime");
            }
        }

        private string[] _Labels;
        public string[] Labels
        {
            get => _Labels;
            set
            {
                _Labels = value;
                OnPropertyChanged("Labels");
            }
        }
        private string[] _LabelsSplitTime;
        public string[] LabelsSplitTime
        {
            get => _LabelsSplitTime;
            set
            {
                _LabelsSplitTime = value;
                OnPropertyChanged("LabelsSplitTime");
            }
        }
        private Func<double, string> _Formatter;
        public Func<double, string> Formatter
        {
            get => _Formatter;
            set
            {
                _Formatter = value;
                OnPropertyChanged();
            }
        }
        private Func<double, string> _Formatter1;
        public Func<double, string> Formatter1
        {
            get => _Formatter1;
            set
            {
                _Formatter1 = value;
                OnPropertyChanged();
            }
        }
        private Func<double, string> _FormatterSplitTime;
        public Func<double, string> FormatterSplitTime
        {
            get => _FormatterSplitTime;
            set
            {
                _FormatterSplitTime = value;
                OnPropertyChanged("FormatterSplitTime");
            }
        }
        #endregion

        #region Light Maintenance
        public enum Colorss
        {
            Red, Green, Yellow, Gray
        }
        private Colorss _LightAlarm1;
        public Colorss LightAlarm1
        {
            get
            {
                return _LightAlarm1;
            }
            set
            {
                _LightAlarm1 = value;
                OnPropertyChanged();
            }
        }

        private Colorss _LightAlarm2;
        public Colorss LightAlarm2
        {
            get
            {
                return _LightAlarm2;
            }
            set
            {
                _LightAlarm2 = value;
                OnPropertyChanged();
            }
        }

        private Colorss _LightAlarm3;
        public Colorss LightAlarm3
        {
            get
            {
                return _LightAlarm3;
            }
            set
            {
                _LightAlarm3 = value;
                OnPropertyChanged();
            }
        }

        private Colorss _LightAlarm4;
        public Colorss LightAlarm4
        {
            get
            {
                return _LightAlarm4;
            }
            set
            {
                _LightAlarm4 = value;
                OnPropertyChanged();
            }
        }

        private Colorss _LightAlarm5;
        public Colorss LightAlarm5
        {
            get
            {
                return _LightAlarm5;
            }
            set
            {
                _LightAlarm5 = value;
                OnPropertyChanged();
            }
        }

        private Colorss _LightAlarm6;
        public Colorss LightAlarm6
        {
            get
            {
                return _LightAlarm6;
            }
            set
            {
                _LightAlarm6 = value;
                OnPropertyChanged();
            }
        }

        private Colorss _LightAlarm7;
        public Colorss LightAlarm7
        {
            get
            {
                return _LightAlarm7;
            }
            set
            {
                _LightAlarm7 = value;
                OnPropertyChanged();
            }
        }

        private Colorss _LightAlarm8;
        public Colorss LightAlarm8
        {
            get
            {
                return _LightAlarm8;
            }
            set
            {
                _LightAlarm8 = value;
                OnPropertyChanged();
            }
        }



        #endregion

        #region SeriesCollection SplitTime

        private SeriesCollection _Series;
        public SeriesCollection Series
        {
            get => _Series;
            set
            {
                _Series = value;
                OnPropertyChanged();
            }
        }
        private SeriesCollection _SeriesP;
        public SeriesCollection SeriesP
        {
            get => _SeriesP;
            set
            {
                _SeriesP = value;
                OnPropertyChanged();
            }
        }

        private SeriesCollection _SeriesCollectionSplitTime1;
        public SeriesCollection SeriesCollectionSplitTime1
        {
            get => _SeriesCollectionSplitTime1;
            set
            {
                _SeriesCollectionSplitTime1 = value;
                OnPropertyChanged();
            }
        }
        private SeriesCollection _SeriesCollectionSplitTime2;
        public SeriesCollection SeriesCollectionSplitTime2
        {
            get => _SeriesCollectionSplitTime2;
            set
            {
                _SeriesCollectionSplitTime2 = value;
                OnPropertyChanged();
            }
        }
        private SeriesCollection _SeriesCollectionSplitTime3;
        public SeriesCollection SeriesCollectionSplitTime3
        {
            get => _SeriesCollectionSplitTime3;
            set
            {
                _SeriesCollectionSplitTime3 = value;
                OnPropertyChanged();
            }
        }
        private SeriesCollection _SeriesCollectionSplitTime4;
        public SeriesCollection SeriesCollectionSplitTime4
        {
            get => _SeriesCollectionSplitTime4;
            set
            {
                _SeriesCollectionSplitTime4 = value;
                OnPropertyChanged();
            }
        }
        private SeriesCollection _SeriesCollectionSplitTime5;
        public SeriesCollection SeriesCollectionSplitTime5
        {
            get => _SeriesCollectionSplitTime5;
            set
            {
                _SeriesCollectionSplitTime5 = value;
                OnPropertyChanged();
            }
        }
        private SeriesCollection _SeriesCollectionSplitTime6;
        public SeriesCollection SeriesCollectionSplitTime6
        {
            get => _SeriesCollectionSplitTime6;
            set
            {
                _SeriesCollectionSplitTime6 = value;
                OnPropertyChanged();
            }
        }
        private SeriesCollection _SeriesCollectionSplitTime7;
        public SeriesCollection SeriesCollectionSplitTime7
        {
            get => _SeriesCollectionSplitTime7;
            set
            {
                _SeriesCollectionSplitTime7 = value;
                OnPropertyChanged();
            }
        }
        private SeriesCollection _SeriesCollectionSplitTime8;
        public SeriesCollection SeriesCollectionSplitTime8
        {
            get => _SeriesCollectionSplitTime8;
            set
            {
                _SeriesCollectionSplitTime8 = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region SeriesCollection and IChartValue Summary

        private IChartValues _SummaryTotal1;
        public IChartValues SummaryTotal1
        {
            get => _SummaryTotal1;
            set
            {
                _SummaryTotal1 = value;
                OnPropertyChanged("SummaryTotal1");
            }
        }
        private IChartValues _SummaryTotal2;
        public IChartValues SummaryTotal2
        {
            get => _SummaryTotal2;
            set
            {
                _SummaryTotal2 = value;
                OnPropertyChanged("SummaryTotal2");
            }
        }
        private IChartValues _SummaryTotal3;
        public IChartValues SummaryTotal3
        {
            get => _SummaryTotal3;
            set
            {
                _SummaryTotal3 = value;
                OnPropertyChanged("SummaryTotal3");
            }
        }
        private IChartValues _SummaryTotal4;
        public IChartValues SummaryTotal4
        {
            get => _SummaryTotal4;
            set
            {
                _SummaryTotal4 = value;
                OnPropertyChanged("SummaryTotal3");
            }
        }
        private IChartValues _SummaryFallingTotal;
        public IChartValues SummaryFallingTotal
        {
            get => _SummaryFallingTotal;
            set
            {
                _SummaryFallingTotal = value;
                OnPropertyChanged("SummaryFallingTotal");
            }
        }
        private IChartValues _SummaryProductTotal;
        public IChartValues SummaryProductTotal
        {
            get => _SummaryProductTotal;
            set
            {
                _SummaryProductTotal = value;
                OnPropertyChanged("SummaryProductTotal");
            }
        }
        private SeriesCollection _SeriesTotal;
        public SeriesCollection SeriesTotal
        {
            get => _SeriesTotal;
            set
            {
                _SeriesTotal = value;
                OnPropertyChanged();
            }
        }
        private SeriesCollection _SeriesCollectionProductSummary;
        public SeriesCollection SeriesCollectionProductSummary
        {
            get => _SeriesCollectionProductSummary;
            set
            {
                _SeriesCollectionProductSummary = value;
                OnPropertyChanged();
            }
        }
        private SeriesCollection _SeriesCollectionFallingSummary;
        public SeriesCollection SeriesCollectionFallingSummary
        {
            get => _SeriesCollectionFallingSummary;
            set
            {
                _SeriesCollectionFallingSummary = value;
                OnPropertyChanged();
            }
        }

        private SeriesCollection _SeriesPieSummary;
        public SeriesCollection SeriesPieSummary
        {
            get => _SeriesPieSummary;
            set
            {
                _SeriesPieSummary = value;
                OnPropertyChanged();
            }
        }



        #endregion

        #region SeriesCollection Product
        //public VMchartWindow DataContext { get; private set; }
        private SeriesCollection _SeriesCollection1;
        public SeriesCollection SeriesCollection1
        {
            get { return _SeriesCollection1; }
            set
            {
                _SeriesCollection1 = value;
                OnPropertyChanged("SeriesCollection1");
            }
        }
        private SeriesCollection _SeriesCollection2;
        public SeriesCollection SeriesCollection2
        {
            get { return _SeriesCollection2; }
            set
            {
                _SeriesCollection2 = value;
                OnPropertyChanged("SeriesCollection2");
            }
        }
        private SeriesCollection _SeriesCollection4;
        public SeriesCollection SeriesCollection4
        {
            get { return _SeriesCollection4; }
            set
            {
                _SeriesCollection4 = value;
                OnPropertyChanged("SeriesCollection4");
            }
        }
        private SeriesCollection _SeriesCollection3;
        public SeriesCollection SeriesCollection3
        {
            get { return _SeriesCollection3; }
            set
            {
                _SeriesCollection3 = value;
                OnPropertyChanged("SeriesCollection3");
            }
        }
        private SeriesCollection _SeriesCollection5;
        public SeriesCollection SeriesCollection5
        {
            get { return _SeriesCollection5; }
            set
            {
                _SeriesCollection5 = value;
                OnPropertyChanged("SeriesCollection5");
            }
        }
        private SeriesCollection _SeriesCollection6;
        public SeriesCollection SeriesCollection6
        {
            get { return _SeriesCollection6; }
            set
            {
                _SeriesCollection6 = value;
                OnPropertyChanged("SeriesCollection6");
            }
        }
        private SeriesCollection _SeriesCollection8;
        public SeriesCollection SeriesCollection8
        {
            get { return _SeriesCollection8; }
            set
            {
                _SeriesCollection8 = value;
                OnPropertyChanged("SeriesCollection8");
            }
        }
        private SeriesCollection _SeriesCollection7;
        public SeriesCollection SeriesCollection7
        {
            get { return _SeriesCollection7; }
            set
            {
                _SeriesCollection7 = value;
                OnPropertyChanged("SeriesCollection7");
            }
        }
        #endregion

        #region Values Maintenance
        private double _Segments1;
        public double Segments1
        {
            get { return _Segments1; }
            set
            {
                _Segments1 = value;
                OnPropertyChanged("Segments1");
            }
        }
        private double _Segments2;
        public double Segments2
        {
            get { return _Segments2; }
            set
            {
                _Segments2 = value;
                OnPropertyChanged("Segments2");
            }
        }
        private double _Segments3;
        public double Segments3
        {
            get { return _Segments3; }
            set
            {
                _Segments3 = value;
                OnPropertyChanged("Segments3");
            }
        }
        private double _Segments4;
        public double Segments4
        {
            get { return _Segments4; }
            set
            {
                _Segments4 = value;
                OnPropertyChanged("Segments4");
            }
        }
        private double _Segments5;
        public double Segments5
        {
            get { return _Segments5; }
            set
            {
                _Segments5 = value;
                OnPropertyChanged("Segments5");
            }
        }
        private double _Segments6;
        public double Segments6
        {
            get { return _Segments6; }
            set
            {
                _Segments6 = value;
                OnPropertyChanged("Segments6");
            }
        }
        private double _Segments7;
        public double Segments7
        {
            get { return _Segments7; }
            set
            {
                _Segments7 = value;
                OnPropertyChanged("Segments7");
            }
        }
        private double _Segments8;
        public double Segments8
        {
            get { return _Segments8; }
            set
            {
                _Segments8 = value;
                OnPropertyChanged("Segments8");
            }
        }
        #endregion

        #region ChartNames
        // ChartNameSplitTime
        private string _ChartNameSplitTime1;
        public string ChartNameSplitTime1
        {
            get => _ChartNameSplitTime1;
            set
            {
                _ChartNameSplitTime1 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameSplitTime2;
        public string ChartNameSplitTime2
        {
            get => _ChartNameSplitTime2;
            set
            {
                _ChartNameSplitTime2 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameSplitTime3;
        public string ChartNameSplitTime3
        {
            get => _ChartNameSplitTime3;
            set
            {
                _ChartNameSplitTime3 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameSplitTime4;
        public string ChartNameSplitTime4
        {
            get => _ChartNameSplitTime4;
            set
            {
                _ChartNameSplitTime4 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameSplitTime5;
        public string ChartNameSplitTime5
        {
            get => _ChartNameSplitTime5;
            set
            {
                _ChartNameSplitTime5 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameSplitTime6;
        public string ChartNameSplitTime6
        {
            get => _ChartNameSplitTime6;
            set
            {
                _ChartNameSplitTime6 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameSplitTime7;
        public string ChartNameSplitTime7
        {
            get => _ChartNameSplitTime7;
            set
            {
                _ChartNameSplitTime7 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameSplitTime8;
        public string ChartNameSplitTime8
        {
            get => _ChartNameSplitTime8;
            set
            {
                _ChartNameSplitTime8 = value;
                OnPropertyChanged();
            }
        }
        // ChartNameProducts
        private string _ChartNameProduct1;
        public string ChartNameProduct1
        {
            get => _ChartNameProduct1;
            set
            {
                _ChartNameProduct1 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameProduct2;
        public string ChartNameProduct2
        {
            get => _ChartNameProduct2;
            set
            {
                _ChartNameProduct2 = value;
                OnPropertyChanged();
            }
        }
        private string _ChartNameProduct3;
        public string ChartNameProduct3
        {
            get => _ChartNameProduct3;
            set
            {
                _ChartNameProduct3 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameProduct4;
        public string ChartNameProduct4
        {
            get => _ChartNameProduct4;
            set
            {
                _ChartNameProduct4 = value;
                OnPropertyChanged();
            }
        }
        private string _ChartNameProduct5;
        public string ChartNameProduct5
        {
            get => _ChartNameProduct5;
            set
            {
                _ChartNameProduct5 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameProduct6;
        public string ChartNameProduct6
        {
            get => _ChartNameProduct6;
            set
            {
                _ChartNameProduct6 = value;
                OnPropertyChanged();
            }
        }
        private string _ChartNameProduct7;
        public string ChartNameProduct7
        {
            get => _ChartNameProduct7;
            set
            {
                _ChartNameProduct7 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameProduct8;
        public string ChartNameProduct8
        {
            get => _ChartNameProduct8;
            set
            {
                _ChartNameProduct8 = value;
                OnPropertyChanged();
            }
        }


        // ChartNameMaintenances
        private string _ChartNameMaintenance1;
        public string ChartNameMaintenance1
        {
            get => _ChartNameMaintenance1;
            set
            {
                _ChartNameMaintenance1 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameMaintenance2;
        public string ChartNameMaintenance2
        {
            get => _ChartNameMaintenance2;
            set
            {
                _ChartNameMaintenance2 = value;
                OnPropertyChanged();
            }
        }
        private string _ChartNameMaintenance3;
        public string ChartNameMaintenance3
        {
            get => _ChartNameMaintenance3;
            set
            {
                _ChartNameMaintenance3 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameMaintenance4;
        public string ChartNameMaintenance4
        {
            get => _ChartNameMaintenance4;
            set
            {
                _ChartNameMaintenance4 = value;
                OnPropertyChanged();
            }
        }
        private string _ChartNameMaintenance5;
        public string ChartNameMaintenance5
        {
            get => _ChartNameMaintenance5;
            set
            {
                _ChartNameMaintenance5 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameMaintenance6;
        public string ChartNameMaintenance6
        {
            get => _ChartNameMaintenance6;
            set
            {
                _ChartNameMaintenance6 = value;
                OnPropertyChanged();
            }
        }
        private string _ChartNameMaintenance7;
        public string ChartNameMaintenance7
        {
            get => _ChartNameMaintenance7;
            set
            {
                _ChartNameMaintenance7 = value;
                OnPropertyChanged();
            }
        }

        private string _ChartNameMaintenance8;
        public string ChartNameMaintenance8
        {
            get => _ChartNameMaintenance8;
            set
            {
                _ChartNameMaintenance8 = value;
                OnPropertyChanged();
            }
        }
        private string _ChartNameSummary1;
        public string ChartNameSummary1
        {
            get => _ChartNameSummary1;
            set
            {
                _ChartNameSummary1 = value;
                OnPropertyChanged();
            }
        }
        private string _ChartNameSummary2;
        public string ChartNameSummary2
        {
            get => _ChartNameSummary2;
            set
            {
                _ChartNameSummary2 = value;
                OnPropertyChanged();
            }
        }
        private string _ChartNameSummary3;
        public string ChartNameSummary3
        {
            get => _ChartNameSummary3;
            set
            {
                _ChartNameSummary3 = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region SplitTimeCommands
        public ICommand FilterDatePickerSplitTimeCommand { get; set; }
        public ICommand ChartWindowClose { get; set; }
        public ICommand SelectDateSplitTimeCommand { get; set; }
        public ICommand PickLine1SplitTimeCommand { get; set; }
        public ICommand PickLine2SplitTimeCommand { get; set; }
        public ICommand PickLine3SplitTimeCommand { get; set; }
        public ICommand PickLine4SplitTimeCommand { get; set; }
        #endregion

        #region ProductCommands
        public ICommand FilterDatePickerProductCommand { get; set; }
        public ICommand SelectDateProductCommand { get; set; }
        public ICommand PickLine1ProductCommand { get; set; }
        public ICommand PickLine2ProductCommand { get; set; }
        public ICommand PickLine3ProductCommand { get; set; }
        public ICommand PickLine4ProductCommand { get; set; }
        #endregion

        #region MaintenanceCommands
        public ICommand FilterDatePickerMaintenanceCommand { get; set; }
        public ICommand PickLine1MaintenanceCommand { get; set; }
        public ICommand PickLine2MaintenanceCommand { get; set; }
        public ICommand PickLine3MaintenanceCommand { get; set; }
        public ICommand PickLine4MaintenanceCommand { get; set; }
        #endregion

        #region SummaryCommands
        public ICommand FilterDatePickerSummaryCommand { get; set; }
        public ICommand ExportChartCommand { get; set; }
        public ICommand TabSummayCloseCommand { get; set; }
        public ICommand PickLine1SummaryCommand { get; set; }
        public ICommand PickLine2SummaryCommand { get; set; }
        public ICommand PickLine3SummaryCommand { get; set; }
        #endregion

        #endregion

        #region Contructors
        public VMchartWindow()
        {
            Operation();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 30, 0);
            timer.Tick += Timer_Tick;
            timer.Start();
            ChartWindowClose = new RelayCommand<ChartWindow>(p => { return true; }, p =>
            {
                if (Thread_execution != null)
                {
                    Thread_execution.Abort();
                   
                }
                if (thread_summary != null)
                {
                    thread_summary.Abort();

                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            });

            #region Split Time Commands
            FilterDatePickerSplitTimeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (string.Equals(ChartNameSplitTime1, "CHART LOADING") == false)
                {
                    SplitTimeChart();
                }
            });
            SelectDateSplitTimeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

            });
            PickLine1SplitTimeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SplitTimeOperation("CNC1'S SPLITTIME");
                ChartNameSplitTime1 = "CNC1'S SPLITTIME";
                ChartNameSplitTime2 = "CNC2'S SPLITTIME";
                ChartNameSplitTime3 = "CNC3'S SPLITTIME";
                ChartNameSplitTime4 = "CNC4'S SPLITTIME";
                ChartNameSplitTime5 = "CNC5'S SPLITTIME";
                ChartNameSplitTime6 = "CNC6'S SPLITTIME";
                ChartNameSplitTime7 = "CNC7'S SPLITTIME";
                ChartNameSplitTime8 = "CNC8'S SPLITTIME";

            });
            PickLine2SplitTimeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SplitTimeOperation("CNC9'S SPLITTIME");
                ChartNameSplitTime1 = "CNC9'S SPLITTIME";
                ChartNameSplitTime2 = "CNC10'S SPLITTIME";
                ChartNameSplitTime3 = "CNC11'S SPLITTIME";
                ChartNameSplitTime4 = "CNC12'S SPLITTIME";
                ChartNameSplitTime5 = "CNC13'S SPLITTIME";
                ChartNameSplitTime6 = "CNC14'S SPLITTIME";
                ChartNameSplitTime7 = "CNC15'S SPLITTIME";
                ChartNameSplitTime8 = "CNC16'S SPLITTIME";

            });
            PickLine3SplitTimeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SplitTimeOperation("CNC17'S SPLITTIME");
                ChartNameSplitTime1 = "CNC17'S SPLITTIME";
                ChartNameSplitTime2 = "CNC18'S SPLITTIME";
                ChartNameSplitTime3 = "CNC19'S SPLITTIME";
                ChartNameSplitTime4 = "CNC20'S SPLITTIME";
                ChartNameSplitTime5 = "CNC21'S SPLITTIME";
                ChartNameSplitTime6 = "CNC22'S SPLITTIME";
                ChartNameSplitTime7 = "CNC23'S SPLITTIME";
                ChartNameSplitTime8 = "CNC24'S SPLITTIME";

            });
            PickLine4SplitTimeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SplitTimeOperation("CNC25'S SPLITTIME");
                ChartNameSplitTime1 = "CNC25'S SPLITTIME";
                ChartNameSplitTime2 = "CNC26'S SPLITTIME";
                ChartNameSplitTime3 = "CNC27'S SPLITTIME";
                ChartNameSplitTime4 = "CNC28'S SPLITTIME";
                ChartNameSplitTime5 = "CNC29'S SPLITTIME";
                ChartNameSplitTime6 = "CNC30'S SPLITTIME";
                ChartNameSplitTime7 = "CNC31'S SPLITTIME";
                ChartNameSplitTime8 = "CNC32'S SPLITTIME";

            });
            #endregion

            #region Production Commands
            // Product Command
            FilterDatePickerProductCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (string.Equals(ChartNameProduct1, "CHART LOADING") == false)
                {
                    ProductChart();
                    //timer2.Start();
                    //timer1.Stop();
                    //timer3.Stop();
                    //timer4.Stop();
                }
            });
            SelectDateProductCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //if (string.Equals(ChartNameProduct1, "CHART LOADING") == false)
                //{
                //    ProductChart();
                //    timer1.Start();
                //}
            });
            PickLine1ProductCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                // dựa vào tên này, cho vào hàm if match theo tên thì đẩy các biểu đồ khác nhau
                ProductionOperation("CNC1'S PRODUCTIVITY");
                ChartNameProduct1 = "CNC1'S PRODUCTIVITY";
                ChartNameProduct2 = "CNC2'S PRODUCTIVITY";
                ChartNameProduct3 = "CNC3'S PRODUCTIVITY";
                ChartNameProduct4 = "CNC4'S PRODUCTIVITY";
                ChartNameProduct5 = "CNC5'S PRODUCTIVITY";
                ChartNameProduct6 = "CNC6'S PRODUCTIVITY";
                ChartNameProduct7 = "CNC7'S PRODUCTIVITY";
                ChartNameProduct8 = "CNC8'S PRODUCTIVITY";
            });
            PickLine2ProductCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ProductionOperation("CNC9'S PRODUCTIVITY");
                ChartNameProduct1 = "CNC9'S PRODUCTIVITY";
                ChartNameProduct2 = "CNC10'S PRODUCTIVITY";
                ChartNameProduct3 = "CNC11'S PRODUCTIVITY";
                ChartNameProduct4 = "CNC12'S PRODUCTIVITY";
                ChartNameProduct5 = "CNC13'S PRODUCTIVITY";
                ChartNameProduct6 = "CNC14'S PRODUCTIVITY";
                ChartNameProduct7 = "CNC15'S PRODUCTIVITY";
                ChartNameProduct8 = "CNC16'S PRODUCTIVITY";
            });
            PickLine3ProductCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ProductionOperation("CNC17'S PRODUCTIVITY");
                ChartNameProduct1 = "CNC17'S PRODUCTIVITY";
                ChartNameProduct2 = "CNC18'S PRODUCTIVITY";
                ChartNameProduct3 = "CNC19'S PRODUCTIVITY";
                ChartNameProduct4 = "CNC20'S PRODUCTIVITY";
                ChartNameProduct5 = "CNC21'S PRODUCTIVITY";
                ChartNameProduct6 = "CNC22'S PRODUCTIVITY";
                ChartNameProduct7 = "CNC23'S PRODUCTIVITY";
                ChartNameProduct8 = "CNC24'S PRODUCTIVITY";
            });
            PickLine4ProductCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ProductionOperation("CNC25'S PRODUCTIVITY");
                ChartNameProduct4 = "CNC25'S PRODUCTIVITY";
                ChartNameProduct2 = "CNC26'S PRODUCTIVITY";
                ChartNameProduct3 = "CNC27'S PRODUCTIVITY";
                ChartNameProduct4 = "CNC28'S PRODUCTIVITY";
                ChartNameProduct5 = "CNC29'S PRODUCTIVITY";
                ChartNameProduct6 = "CNC30'S PRODUCTIVITY";
                ChartNameProduct7 = "CNC31'S PRODUCTIVITY";
                ChartNameProduct8 = "CNC32'S PRODUCTIVITY";
            });
            #endregion

            #region Maintenance Commands

            FilterDatePickerMaintenanceCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (string.Equals(ChartNameMaintenance1, "CHART LOADING") == false)
                {
                    MaintenanceChart();
                }
            });
            PickLine1MaintenanceCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MaintenanceOperation("CNC1'S MAINTENANCE");
                ChartNameMaintenance1 = "CNC1'S MAINTENANCE";
                ChartNameMaintenance2 = "CNC2'S MAINTENANCE";
                ChartNameMaintenance3 = "CNC3'S MAINTENANCE";
                ChartNameMaintenance4 = "CNC4'S MAINTENANCE";
                ChartNameMaintenance5 = "CNC5'S MAINTENANCE";
                ChartNameMaintenance6 = "CNC6'S MAINTENANCE";
                ChartNameMaintenance7 = "CNC7'S MAINTENANCE";
                ChartNameMaintenance8 = "CNC8'S MAINTENANCE";
            });
            PickLine2MaintenanceCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MaintenanceOperation("CNC9'S MAINTENANCE");
                ChartNameMaintenance1 = "CNC9'S MAINTENANCE";
                ChartNameMaintenance2 = "CNC10'S MAINTENANCE";
                ChartNameMaintenance3 = "CNC11'S MAINTENANCE";
                ChartNameMaintenance4 = "CNC12'S MAINTENANCE";
                ChartNameMaintenance5 = "CNC13'S MAINTENANCE";
                ChartNameMaintenance6 = "CNC14'S MAINTENANCE";
                ChartNameMaintenance7 = "CNC15'S MAINTENANCE";
                ChartNameMaintenance8 = "CNC16'S MAINTENANCE";
            });
            PickLine3MaintenanceCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MaintenanceOperation("CNC17'S MAINTENANCE");
                ChartNameMaintenance1 = "CNC17'S MAINTENANCE";
                ChartNameMaintenance2 = "CNC18'S MAINTENANCE";
                ChartNameMaintenance3 = "CNC19'S MAINTENANCE";
                ChartNameMaintenance4 = "CNC20'S MAINTENANCE";
                ChartNameMaintenance5 = "CNC21'S MAINTENANCE";
                ChartNameMaintenance6 = "CNC22'S MAINTENANCE";
                ChartNameMaintenance7 = "CNC23'S MAINTENANCE";
                ChartNameMaintenance8 = "CNC24'S MAINTENANCE";

            });
            PickLine4MaintenanceCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MaintenanceOperation("CNC25'S MAINTENANCE");
                ChartNameMaintenance1 = "CNC25'S MAINTENANCE";
                ChartNameMaintenance2 = "CNC26'S MAINTENANCE";
                ChartNameMaintenance3 = "CNC27'S MAINTENANCE";
                ChartNameMaintenance4 = "CNC28'S MAINTENANCE";
                ChartNameMaintenance5 = "CNC29'S MAINTENANCE";
                ChartNameMaintenance6 = "CNC30'S MAINTENANCE";
                ChartNameMaintenance7 = "CNC31'S MAINTENANCE";
                ChartNameMaintenance8 = "CNC32'S MAINTENANCE";
            });

            #endregion

            #region Summary Commands
            FilterDatePickerSummaryCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (YearSelected != null && string.Equals(ChartNameSummary1, "CHART LOADING") == false)
                {
                    SummaryChart();
                }
            });
            ExportChartCommand = new RelayCommand<object>((p) => { return true; }, (p) => { /*ExportChart();*/ });
            PickLine1SummaryCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SummaryOperation("SUMMARY CHART ( MONTH )");
                ChartNameSummary1 = "SUMMARY CHART ( MONTH )";
                ChartNameSummary2 = "TOTAL PRODUCTS ( MONTH )";
                ChartNameSummary3 = "TOTAL FALLINGS ( MONTH )";
            });
            PickLine2SummaryCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SummaryOperation("SUMMARY CHART ( SEASON )");
                ChartNameSummary1 = "SUMMARY CHART ( SEASON )";
                ChartNameSummary2 = "TOTAL PRODUCTS ( SEASON )";
                ChartNameSummary3 = "TOTAL FALLINGS ( SEASON )";
            });
            PickLine3SummaryCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SummaryOperation("SUMMARY CHART ( YEAR )");
                ChartNameSummary1 = "SUMMARY CHART ( YEAR )";
                ChartNameSummary2 = "TOTAL PRODUCTS ( YEAR )";
                ChartNameSummary3 = "TOTAL FALLINGS ( YEAR )";
            });
            #endregion
        }
        //public void ExportChart()
        //{
        //    var cartesian = new LiveCharts.Wpf.CartesianChart();
        //    cartesian.Update(true, true);
        //    svd = new SaveFileDialog();
        //    svd.Title = "Save Export Chart";
        //    svd.DefaultExt = "Export";
        //    svd.Filter = "Image (*.png)|*.png";
        //    svd.RestoreDirectory = true;
        //    if ( == null)
        //    {
        //        return;
        //    }
        //    if (result == true)
        //    {
        //        Rect bounds = VisualTreeHelper.GetDescendantBounds(cwd.cart1);

        //        RenderTargetBitmap renderTarget = new RenderTargetBitmap((Int32)cwd.cart1.Width, (Int32)cwd.cart1.Height, 96, 96, PixelFormats.Pbgra32);


        //        DrawingVisual visual = new DrawingVisual();

        //        using (DrawingContext context = visual.RenderOpen())
        //        {
        //            VisualBrush visualBrush = new VisualBrush(cwd.Cart);
        //            context.DrawRectangle(visualBrush, null, new Rect(new Point(), bounds.Size));
        //        }

        //        renderTarget.Render(visual);
        //        PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
        //        bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
        //        using (Stream stm = File.Create(svd.FileName))
        //        {
        //            bitmapEncoder.Save(stm);
        //        }
        //        MessageBox.Show("Export Image Successfully");
        //    }
        //}
        private void Timer_Tick(object sender, EventArgs e)
        {
            MaintenanceChart();
        }
        public void Operation()
        {
            if (Thread_execution != null)
            {
                Thread_execution.Abort();
            }
            Thread_execution = new Thread(SplitTimeChart);
            Thread_execution.Start();
            try
            {
                ChartNameSplitTime1 = "CHART LOADING";
                ChartNameSplitTime2 = "CHART LOADING";
                ChartNameSplitTime3 = "CHART LOADING";
                ChartNameSplitTime4 = "CHART LOADING";
                ChartNameSplitTime5 = "CHART LOADING";
                ChartNameSplitTime6 = "CHART LOADING";
                ChartNameSplitTime7 = "CHART LOADING";
                ChartNameSplitTime8 = "CHART LOADING";

                ChartNameProduct1 = "CHART LOADING";
                ChartNameProduct2 = "CHART LOADING";
                ChartNameProduct3 = "CHART LOADING";
                ChartNameProduct4 = "CHART LOADING";
                ChartNameProduct5 = "CHART LOADING";
                ChartNameProduct6 = "CHART LOADING";
                ChartNameProduct7 = "CHART LOADING";
                ChartNameProduct8 = "CHART LOADING";

                ChartNameMaintenance1 = "CNC1'S MAINTENANCE";
                ChartNameMaintenance2 = "CNC2'S MAINTENANCE";
                ChartNameMaintenance3 = "CNC3'S MAINTENANCE";
                ChartNameMaintenance4 = "CNC4'S MAINTENANCE";
                ChartNameMaintenance5 = "CNC5'S MAINTENANCE";
                ChartNameMaintenance6 = "CNC6'S MAINTENANCE";
                ChartNameMaintenance7 = "CNC7'S MAINTENANCE";
                ChartNameMaintenance8 = "CNC8'S MAINTENANCE";

                ChartNameSummary1 = "CHART LOADING";
                ChartNameSummary2 = "CHART LOADING";
                ChartNameSummary3 = "CHART LOADING";

                var cartesian = new LiveCharts.Wpf.CartesianChart();
                Labels = new[] { "1", "2", "3", "4" };
                int[] totalPF = { 0, 0, 0, 0 };
                SummaryFallingTotal = new ChartValues<int> { 0, 0, 0, 0 };
                SummaryProductTotal = new ChartValues<int> { 0, 0, 0, 0 };
                SummaryTotal1 = new ChartValues<int> { 0, 0, 0, 0 };
                SummaryTotal2 = new ChartValues<int> { 0, 0, 0, 0 };
                SummaryTotal3 = new ChartValues<int> { 0, 0, 0, 0 };
                SeriesCollectionFallingSummary = SendToPieChartSummary(totalPF);
                SeriesCollectionProductSummary = SendToPieChartSummary(totalPF);
                Formatter = value => value.ToString("N");
                cartesian.Update(true, true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                if (Thread_execution != null)
                {
                    Thread_execution.Abort();
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        #endregion

        #region SplitTimeChart
        public void SplitTimeChart()
        {
            if (Thread_execution != null)
            {
                Thread_execution.Abort();
            }
            Thread_execution = new Thread(SplitTimeChart);
            Thread_execution.Start();
            try
            {
                if (DisplayDateSplitTime != null)
                {
                    var cartesian = new LiveCharts.Wpf.CartesianChart();
                    FormatterSplitTime = value => value.ToString("P") + "Hours";
                    LabelsSplitTime = new[] { "Shift 1", "Shift 2", "Shift 3" };

                    string dayString = DisplayDateSplitTime.ToString("dd/MM/yyyy");

                    if (string.Equals(ChartNameSplitTime1, "CNC1'S SPLITTIME"))
                    {
                        var tableCNC1 = DataProvider.Ins.DB.EventManagerCNC1.AsEnumerable();
                        var tableCNC2 = DataProvider.Ins.DB.EventManagerCNC2.AsEnumerable();
                        var tableCNC3 = DataProvider.Ins.DB.EventManagerCNC3.AsEnumerable();
                        var tableCNC4 = DataProvider.Ins.DB.EventManagerCNC4.AsEnumerable();
                        var tableCNC5 = DataProvider.Ins.DB.EventManagerCNC5.AsEnumerable();
                        var tableCNC6 = DataProvider.Ins.DB.EventManagerCNC6.AsEnumerable();
                        var tableCNC7 = DataProvider.Ins.DB.EventManagerCNC7.AsEnumerable();
                        var tableCNC8 = DataProvider.Ins.DB.EventManagerCNC8.AsEnumerable();

                        var serie1 = SendDataToSplitTimeChartCNC1(tableCNC1);
                        var serie2 = SendDataToSplitTimeChartCNC2(tableCNC2);
                        var serie3 = SendDataToSplitTimeChartCNC3(tableCNC3);
                        var serie4 = SendDataToSplitTimeChartCNC4(tableCNC4);
                        var serie5 = SendDataToSplitTimeChartCNC5(tableCNC5);
                        var serie6 = SendDataToSplitTimeChartCNC6(tableCNC6);
                        var serie7 = SendDataToSplitTimeChartCNC7(tableCNC7);
                        var serie8 = SendDataToSplitTimeChartCNC8(tableCNC8);

                        Task.WhenAll(
                            serie1,
                            serie2,
                            serie3,
                            serie4,
                            serie5,
                            serie6,
                            serie7,
                            serie8);
                        SeriesCollectionSplitTime1 = serie1.Result;
                        SeriesCollectionSplitTime2 = serie2.Result;
                        SeriesCollectionSplitTime3 = serie3.Result;
                        SeriesCollectionSplitTime4 = serie4.Result;
                        SeriesCollectionSplitTime5 = serie5.Result;
                        SeriesCollectionSplitTime6 = serie6.Result;
                        SeriesCollectionSplitTime7 = serie7.Result;
                        SeriesCollectionSplitTime8 = serie8.Result;

                    }
                    if (string.Equals(ChartNameSplitTime1, "CNC9'S SPLITTIME"))
                    {

                    }
                    if (string.Equals(ChartNameSplitTime1, "CNC17'S SPLITTIME"))
                    {

                    }
                    if (string.Equals(ChartNameSplitTime1, "CNC25'S SPLITTIME"))
                    {

                    }
                    cartesian.Update(true, true);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (Thread_execution != null)
                {
                    Thread_execution.Abort();
                }
                GC.Collect();
            }
        }
        #endregion

        #region ProductChart
        public void ProductChart()
        {
            if (Thread_execution != null)
            {
                Thread_execution.Abort();
            }
            Thread_execution = new Thread(ProductChart);
            Thread_execution.Start();
            try
            {
                int DayInt = int.Parse(DisplayDateProduct.ToString("dd"));
                string MonthYear = DisplayDateProduct.ToString("MM/yyyy");
                string[] dayLastString = new string[7];
                string[] DateLast = new string[7];

                for (int i = 0; i < 7; i++)
                {
                    dayLastString[i] = (DayInt + i).ToString();
                }

                for (int i = 0; i < 7; i++)
                {
                    if (dayLastString[i].Length == 1)
                    {
                        dayLastString[i] = "0" + dayLastString[i];
                    }
                }

                string DateLast1 = dayLastString[0] + "/" + MonthYear;
                string DateLast2 = dayLastString[1] + "/" + MonthYear;
                string DateLast3 = dayLastString[2] + "/" + MonthYear;
                string DateLast4 = dayLastString[3] + "/" + MonthYear;
                string DateLast5 = dayLastString[4] + "/" + MonthYear;
                string DateLast6 = dayLastString[5] + "/" + MonthYear;
                string DateLast7 = dayLastString[6] + "/" + MonthYear;
                string[] dayfull = new string[] { DateLast1, DateLast2, DateLast3, DateLast4, DateLast5, DateLast6, DateLast7 };
                var cartesian = new LiveCharts.Wpf.CartesianChart();
                Labels = new[] { dayLastString[0], dayLastString[1], dayLastString[2], dayLastString[3], dayLastString[4], dayLastString[5], dayLastString[6] };
                Formatter = value => value.ToString("N");


                if (string.Equals(ChartNameProduct1, "CNC1'S PRODUCTIVITY"))
                {
                    SeriesCollection1 = SendDataToProductionChartCNC1(DataProvider.Ins.DB.EventManagerCNC1.AsEnumerable());
                    SeriesCollection2 = SendDataToProductionChartCNC2(DataProvider.Ins.DB.EventManagerCNC2.AsEnumerable());
                    SeriesCollection3 = SendDataToProductionChartCNC3(DataProvider.Ins.DB.EventManagerCNC3.AsEnumerable());
                    SeriesCollection4 = SendDataToProductionChartCNC4(DataProvider.Ins.DB.EventManagerCNC4.AsEnumerable());
                    SeriesCollection5 = SendDataToProductionChartCNC5(DataProvider.Ins.DB.EventManagerCNC5.AsEnumerable());
                    SeriesCollection6 = SendDataToProductionChartCNC6(DataProvider.Ins.DB.EventManagerCNC6.AsEnumerable());
                    SeriesCollection7 = SendDataToProductionChartCNC7(DataProvider.Ins.DB.EventManagerCNC7.AsEnumerable());
                    SeriesCollection8 = SendDataToProductionChartCNC8(DataProvider.Ins.DB.EventManagerCNC8.AsEnumerable());
                }
                if (string.Equals(ChartNameProduct1, "CNC9'S PRODUCTIVITY"))
                {

                }
                if (string.Equals(ChartNameProduct1, "CNC17'S PRODUCTIVITY"))
                {

                }
                if (string.Equals(ChartNameProduct1, "CNC25'S PRODUCTIVITY"))
                {

                }

                cartesian.Update(true, true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (Thread_execution != null)
                {
                    Thread_execution.Abort();
                }
                GC.Collect();
            }
        }
        #endregion

        #region MaintenanceChart
        public void MaintenanceChart()
        {
            if (Thread_execution != null)
            {
                Thread_execution.Abort();
            }
            Thread_execution = new Thread(MaintenanceChart);
            Thread_execution.Start();
            try
            {

                if (string.Equals(ChartNameMaintenance1, "CNC1'S MAINTENANCE"))
                {
                    LightAlarm1 = Colorss.Gray;
                    LightAlarm2 = Colorss.Gray;
                    LightAlarm3 = Colorss.Gray;
                    LightAlarm4 = Colorss.Gray;
                    LightAlarm5 = Colorss.Gray;
                    LightAlarm6 = Colorss.Gray;
                    LightAlarm7 = Colorss.Gray;
                    LightAlarm8 = Colorss.Gray;

                    var seg1 = TimeMaintenance_CNC1(DataProvider.Ins.DB.EventManagerCNC1.AsEnumerable());
                    var seg2 = TimeMaintenance_CNC2(DataProvider.Ins.DB.EventManagerCNC2.AsEnumerable());
                    var seg3 = TimeMaintenance_CNC3(DataProvider.Ins.DB.EventManagerCNC3.AsEnumerable());
                    var seg4 = TimeMaintenance_CNC4(DataProvider.Ins.DB.EventManagerCNC4.AsEnumerable());
                    var seg5 = TimeMaintenance_CNC5(DataProvider.Ins.DB.EventManagerCNC5.AsEnumerable());
                    var seg6 = TimeMaintenance_CNC6(DataProvider.Ins.DB.EventManagerCNC6.AsEnumerable());
                    var seg7 = TimeMaintenance_CNC7(DataProvider.Ins.DB.EventManagerCNC7.AsEnumerable());
                    var seg8 = TimeMaintenance_CNC8(DataProvider.Ins.DB.EventManagerCNC8.AsEnumerable());

                    Task.WhenAll(
                        seg1,
                        seg2,
                        seg3,
                        seg4,
                        seg5,
                        seg6,
                        seg7,
                        seg8
                        );

                    Segments1 = seg1.Result;
                    Segments2 = seg2.Result;
                    Segments3 = seg3.Result;
                    Segments4 = seg4.Result;
                    Segments5 = seg5.Result;
                    Segments6 = seg6.Result;
                    Segments7 = seg7.Result;
                    Segments8 = seg8.Result;

                }
                if (string.Equals(ChartNameMaintenance1, "CNC9'S MAINTENANCE"))
                {
                    LightAlarm1 = Colorss.Gray;
                    LightAlarm2 = Colorss.Gray;
                    LightAlarm3 = Colorss.Gray;
                    LightAlarm4 = Colorss.Gray;
                    LightAlarm5 = Colorss.Gray;
                    LightAlarm6 = Colorss.Gray;
                    LightAlarm7 = Colorss.Gray;
                    LightAlarm8 = Colorss.Gray;
                }
                if (string.Equals(ChartNameMaintenance1, "CNC17'S MAINTENANCE"))
                {
                    LightAlarm1 = Colorss.Gray;
                    LightAlarm2 = Colorss.Gray;
                    LightAlarm3 = Colorss.Gray;
                    LightAlarm4 = Colorss.Gray;
                    LightAlarm5 = Colorss.Gray;
                    LightAlarm6 = Colorss.Gray;
                    LightAlarm7 = Colorss.Gray;
                    LightAlarm8 = Colorss.Gray;
                }
                if (string.Equals(ChartNameMaintenance1, "CNC25'S MAINTENANCE"))
                {
                    LightAlarm1 = Colorss.Gray;
                    LightAlarm2 = Colorss.Gray;
                    LightAlarm3 = Colorss.Gray;
                    LightAlarm4 = Colorss.Gray;
                    LightAlarm5 = Colorss.Gray;
                    LightAlarm6 = Colorss.Gray;
                    LightAlarm7 = Colorss.Gray;
                    LightAlarm8 = Colorss.Gray;
                }
                double[] temp = new double[] { Segments1, Segments2, Segments3, Segments4, Segments5, Segments6, Segments7, Segments8 };
                LightAlarm1 = ColorLightMaintenance(temp)[0];
                LightAlarm2 = ColorLightMaintenance(temp)[1];
                LightAlarm3 = ColorLightMaintenance(temp)[2];
                LightAlarm4 = ColorLightMaintenance(temp)[3];
                LightAlarm5 = ColorLightMaintenance(temp)[4];
                LightAlarm6 = ColorLightMaintenance(temp)[5];
                LightAlarm7 = ColorLightMaintenance(temp)[6];
                LightAlarm8 = ColorLightMaintenance(temp)[7];

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (Thread_execution != null)
                {
                    Thread_execution.Abort();
                }
                GC.Collect();
            }
        }
        #endregion

        #region SummaryChart
        Thread thread_summary;
        public void SummaryChart()
        {
            if (Thread_execution != null)
            {
                Thread_execution.Abort();
            }
            Thread_execution = new Thread(SummaryChart);
            Thread_execution.Start();
            try
            {
                var cartesian = new LiveCharts.Wpf.CartesianChart();
                Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
                Formatter = value => value.ToString("N");
                if (YearSelected != null)
                {
                    if (string.Equals(ChartNameSummary1, "SUMMARY CHART ( YEAR )") == true)
                    {
                        YearModeSummary();
                        //if (thread_summary != null)
                        //{
                        //    thread_summary.Abort();
                        //}
                        //thread_summary = new Thread(YearModeSummary);
                        //thread_summary.Start();

                    }
                    if (string.Equals(ChartNameSummary1, "SUMMARY CHART ( MONTH )") == true && MonthSelected != null)
                    {
                        MonthModeSummary();
                        //if (thread_summary != null)
                        //{
                        //    thread_summary.Abort();
                        //}
                        //thread_summary = new Thread(MonthModeSummary);
                        //thread_summary.Start();
                    }
                    if (string.Equals(ChartNameSummary1, "SUMMARY CHART ( SEASON )") == true && SeasonSelected != null)
                    {
                        SeasonModeSummary();
                        //if (thread_summary != null)
                        //{
                        //    thread_summary.Abort();
                        //}
                        //thread_summary = new Thread(SeasonModeSummary);
                        //thread_summary.Start();
                    }
                }
                cartesian.Update(true, true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (Thread_execution != null)
                {
                    Thread_execution.Abort();
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        #endregion

        #region Support Methods
        public void MaintenanceOperation(string nameChart)
        {
            try
            {
                if (ChartNameMaintenance1 != nameChart)
                {
                    Segments1 = 0;
                    Segments2 = 0;
                    Segments3 = 0;
                    Segments4 = 0;
                    Segments5 = 0;
                    Segments6 = 0;
                    Segments7 = 0;
                    Segments8 = 0;

                    LightAlarm1 = Colorss.Gray;
                    LightAlarm2 = Colorss.Gray;
                    LightAlarm3 = Colorss.Gray;
                    LightAlarm4 = Colorss.Gray;
                    LightAlarm5 = Colorss.Gray;
                    LightAlarm6 = Colorss.Gray;
                    LightAlarm7 = Colorss.Gray;
                    LightAlarm8 = Colorss.Gray;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

        }
        
        public void SummaryOperation(string nameChart)
        {
            try
            {
                if (ChartNameSummary1 != nameChart)
                {
                    var cartesian = new LiveCharts.Wpf.CartesianChart();
                    Labels = new[] { "1", "2", "3", "4" };
                    int[] totalPF = { 0, 0, 0, 0 };
                    SummaryFallingTotal = new ChartValues<int> { 0, 0, 0, 0};
                    SummaryProductTotal = new ChartValues<int> { 0, 0, 0, 0};
                    SummaryTotal1 = new ChartValues<int> { 0, 0, 0, 0};
                    SummaryTotal2 = new ChartValues<int> { 0, 0, 0, 0};
                    SummaryTotal3 = new ChartValues<int> { 0, 0, 0, 0 };
                   
                    SeriesCollectionFallingSummary = SendToPieChartSummary(totalPF);
                    SeriesCollectionProductSummary = SendToPieChartSummary(totalPF);
                    Formatter = value => value.ToString("N");
                    Formatter1 = value => value.ToString("N");
                    cartesian.Update(true, true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public void ProductionOperation(string nameChart)
        {
            try
            {
                if (ChartNameProduct1 != nameChart)
                {
                    if (DisplayDateProduct != null)
                    {
                        int DayInt = int.Parse(DisplayDateProduct.ToString("dd"));
                        string MonthYear = DisplayDateProduct.ToString("MM/yyyy");
                        string[] dayLastString = new string[7];
                        string[] DateLast = new string[7];

                        for (int i = 0; i < 7; i++)
                        {
                            dayLastString[i] = (DayInt + i).ToString();
                        }

                        for (int i = 0; i < 7; i++)
                        {
                            if (dayLastString[i].Length == 1)
                            {
                                dayLastString[i] = "0" + dayLastString[i];
                            }
                        }

                        string DateLast1 = dayLastString[0] + "/" + MonthYear;
                        string DateLast2 = dayLastString[1] + "/" + MonthYear;
                        string DateLast3 = dayLastString[2] + "/" + MonthYear;
                        string DateLast4 = dayLastString[3] + "/" + MonthYear;
                        string DateLast5 = dayLastString[4] + "/" + MonthYear;
                        string DateLast6 = dayLastString[5] + "/" + MonthYear;
                        string DateLast7 = dayLastString[6] + "/" + MonthYear;
                        string[] dayfull = new string[] { DateLast1, DateLast2, DateLast3, DateLast4, DateLast5, DateLast6, DateLast7 };
                        Labels = new[] { dayLastString[0], dayLastString[1], dayLastString[2], dayLastString[3], dayLastString[4], dayLastString[5], dayLastString[6] };
                    }

                    SeriesCollection1 = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = "Product",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        },
                        new ColumnSeries
                        {
                            Title = "Falling",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        }
                    };
                    SeriesCollection2 = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = "Product",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        },
                        new ColumnSeries
                        {
                            Title = "Falling",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        }
                    };
                    SeriesCollection3 = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = "Product",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        },
                        new ColumnSeries
                        {
                            Title = "Falling",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        }
                    };
                    SeriesCollection4 = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = "Product",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        },
                        new ColumnSeries
                        {
                            Title = "Falling",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        }
                    };
                    SeriesCollection5 = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = "Product",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        },
                        new ColumnSeries
                        {
                            Title = "Falling",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        }
                    };
                    SeriesCollection6 = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = "Product",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        },
                        new ColumnSeries
                        {
                            Title = "Falling",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        }
                    };
                    SeriesCollection7 = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = "Product",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        },
                        new ColumnSeries
                        {
                            Title = "Falling",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        }
                    };
                    SeriesCollection8 = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = "Product",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        },
                        new ColumnSeries
                        {
                            Title = "Falling",
                            Values = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0 }
                        }
                    };

                    var cartesian = new LiveCharts.Wpf.CartesianChart();
                    Formatter = value => value.ToString("N");
                    cartesian.Update(true, true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

        }
        public void SplitTimeOperation(string nameChart)
        {
            try
            {
                if (string.Equals(ChartNameSplitTime1, nameChart) == false)
                {
                    var cartesian = new LiveCharts.Wpf.CartesianChart();
                    FormatterSplitTime = value => value.ToString("P") + " Hours";
                    LabelsSplitTime = new[] { "Shift 1", "Shift 2", "Shift 3" };

                    SeriesCollectionSplitTime1 = new SeriesCollection
                    {
                        new StackedRowSeries
                        {
                            Title = "Run Time",
                            Values = new ChartValues<double> { 0, 0, 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()

                        },
                        new StackedRowSeries
                        {
                            Title = "Stop Time",
                            Values = new ChartValues<double> { 0 , 0 , 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Fail Time",
                            Values = new ChartValues<double> { 0, 0, 0},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Time Left",
                            Values = new ChartValues<double> { 8, 8, 8},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        }
                    };
                    SeriesCollectionSplitTime2 = new SeriesCollection
                    {
                        new StackedRowSeries
                        {
                            Title = "Run Time",
                            Values = new ChartValues<double> { 0, 0, 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()

                        },
                        new StackedRowSeries
                        {
                            Title = "Stop Time",
                            Values = new ChartValues<double> { 0 , 0 , 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Fail Time",
                            Values = new ChartValues<double> { 0, 0, 0},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Time Left",
                            Values = new ChartValues<double> { 8, 8, 8},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        }
                    };
                    SeriesCollectionSplitTime3 = new SeriesCollection
                    {
                        new StackedRowSeries
                        {
                            Title = "Run Time",
                            Values = new ChartValues<double> { 0, 0, 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()

                        },
                        new StackedRowSeries
                        {
                            Title = "Stop Time",
                            Values = new ChartValues<double> { 0 , 0 , 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Fail Time",
                            Values = new ChartValues<double> { 0, 0, 0},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Time Left",
                            Values = new ChartValues<double> { 8, 8, 8},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        }
                    };
                    SeriesCollectionSplitTime4 = new SeriesCollection
                    {
                        new StackedRowSeries
                        {
                            Title = "Run Time",
                            Values = new ChartValues<double> { 0, 0, 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()

                        },
                        new StackedRowSeries
                        {
                            Title = "Stop Time",
                            Values = new ChartValues<double> { 0 , 0 , 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Fail Time",
                            Values = new ChartValues<double> { 0, 0, 0},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Time Left",
                            Values = new ChartValues<double> { 8, 8, 8},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        }
                    };
                    SeriesCollectionSplitTime5 = new SeriesCollection
                    {
                        new StackedRowSeries
                        {
                            Title = "Run Time",
                            Values = new ChartValues<double> { 0, 0, 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()

                        },
                        new StackedRowSeries
                        {
                            Title = "Stop Time",
                            Values = new ChartValues<double> { 0 , 0 , 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Fail Time",
                            Values = new ChartValues<double> { 0, 0, 0},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Time Left",
                            Values = new ChartValues<double> { 8, 8, 8},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        }
                    };
                    SeriesCollectionSplitTime6 = new SeriesCollection
                    {
                        new StackedRowSeries
                        {
                            Title = "Run Time",
                            Values = new ChartValues<double> { 0, 0, 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()

                        },
                        new StackedRowSeries
                        {
                            Title = "Stop Time",
                            Values = new ChartValues<double> { 0 , 0 , 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Fail Time",
                            Values = new ChartValues<double> { 0, 0, 0},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Time Left",
                            Values = new ChartValues<double> { 8, 8, 8},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        }
                    };
                    SeriesCollectionSplitTime7 = new SeriesCollection
                    {
                        new StackedRowSeries
                        {
                            Title = "Run Time",
                            Values = new ChartValues<double> { 0, 0, 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()

                        },
                        new StackedRowSeries
                        {
                            Title = "Stop Time",
                            Values = new ChartValues<double> { 0 , 0 , 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Fail Time",
                            Values = new ChartValues<double> { 0, 0, 0},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Time Left",
                            Values = new ChartValues<double> { 8, 8, 8},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        }
                    };
                    SeriesCollectionSplitTime8 = new SeriesCollection
                    {
                        new StackedRowSeries
                        {
                            Title = "Run Time",
                            Values = new ChartValues<double> { 0, 0, 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()

                        },
                        new StackedRowSeries
                        {
                            Title = "Stop Time",
                            Values = new ChartValues<double> { 0 , 0 , 0 },
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Fail Time",
                            Values = new ChartValues<double> { 0, 0, 0},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        },
                        new StackedRowSeries
                        {
                            Title = "Time Left",
                            Values = new ChartValues<double> { 8, 8, 8},
                            StackMode = StackMode.Percentage,
                            DataLabels = true,
                            LabelPoint = p => p.X.ToString()
                        }
                    };
                    cartesian.Update(true, true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

        }
        public void YearModeSummary()
        {
            if (thread_summary != null)
            {
                thread_summary.Abort();
            }
            thread_summary = new Thread(YearModeSummary);
            thread_summary.Priority = ThreadPriority.Lowest;
            thread_summary.Start();
            int y = int.Parse(YearSelected);
            Labels = new[] { y.ToString(), (y + 1).ToString(), (y + 2).ToString(), (y + 3).ToString(), (y + 4).ToString(), (y + 5).ToString(), (y + 6).ToString() };
            int[] yearPsum = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            int[] yearFsum = new int[7] { 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < 7; i++) // total Product + Failing Line 1
            {
                var rs1m = ProductivitySummaryChartCNC1(y + i, 1, 12, DataProvider.Ins.DB.EventManagerCNC1);
                var rs2m = ProductivitySummaryChartCNC2(y + i, 1, 12, DataProvider.Ins.DB.EventManagerCNC2);
                var rs3m = ProductivitySummaryChartCNC3(y + i, 1, 12, DataProvider.Ins.DB.EventManagerCNC3);
                var rs4m = ProductivitySummaryChartCNC4(y + i, 1, 12, DataProvider.Ins.DB.EventManagerCNC4);
                var rs5m = ProductivitySummaryChartCNC5(y + i, 1, 12, DataProvider.Ins.DB.EventManagerCNC5);
                var rs6m = ProductivitySummaryChartCNC6(y + i, 1, 12, DataProvider.Ins.DB.EventManagerCNC6);
                var rs7m = ProductivitySummaryChartCNC7(y + i, 1, 12, DataProvider.Ins.DB.EventManagerCNC7);
                var rs8m = ProductivitySummaryChartCNC8(y + i, 1, 12, DataProvider.Ins.DB.EventManagerCNC8);
                Task.WhenAll(rs1m, rs2m, rs3m, rs4m, rs5m, rs6m, rs7m, rs8m);
                yearPsum[i] = rs1m.Result[0] + rs2m.Result[0] + rs3m.Result[0] + rs4m.Result[0] + rs5m.Result[0] + rs6m.Result[0] + rs7m.Result[0] + rs8m.Result[0];
                yearFsum[i] = rs1m.Result[1] + rs2m.Result[1] + rs3m.Result[1] + rs4m.Result[1] + rs5m.Result[1] + rs6m.Result[1] + rs7m.Result[1] + rs8m.Result[1];
            }
            SummaryProductTotal = new ChartValues<int>
            {
                yearPsum[0],
                yearPsum[1],
                yearPsum[2],
                yearPsum[3],
                yearPsum[4],
                yearPsum[5],
                yearPsum[6]
            };
            SummaryFallingTotal = new ChartValues<int>
            {
                yearFsum[0],
                yearFsum[1],
                yearFsum[2],
                yearFsum[3],
                yearFsum[4],
                yearFsum[5],
                yearFsum[6]
            };

            var rs1 = TimeCalculation_AllCNC(1, 12, y);
            var rs2 = TimeCalculation_AllCNC(1, 12, y + 1);
            var rs3 = TimeCalculation_AllCNC(1, 12, y + 2);
            var rs4 = TimeCalculation_AllCNC(1, 12, y + 3);
            var rs5 = TimeCalculation_AllCNC(1, 12, y + 4);
            var rs6 = TimeCalculation_AllCNC(1, 12, y + 5);
            var rs7 = TimeCalculation_AllCNC(1, 12, y + 6);

            Task.WhenAll(rs1, rs2, rs3, rs4, rs5, rs6, rs7);

            double[] total1 = rs1.Result;
            double[] total2 = rs2.Result;
            double[] total3 = rs3.Result;
            double[] total4 = rs4.Result;
            double[] total5 = rs5.Result;
            double[] total6 = rs6.Result;
            double[] total7 = rs7.Result;

            SummaryTotal1 = new ChartValues<double>
            {
                total1[0],total2[0],total3[0],total4[0],total5[0],total6[0],total7[0]
            };
            SummaryTotal2 = new ChartValues<double>
            {
                total1[1],total2[1],total3[1],total4[1],total5[1],total6[1],total7[1]
            };
            SummaryTotal3 = new ChartValues<double>
            {
                total1[2],total2[2],total3[2],total4[2],total5[2],total6[2],total7[2]
            };

            int[] TotalProductYear = new int[4] { 0, 0, 0, 0 };
            int[] TotalFallingYear = new int[4] { 0, 0, 0, 0 };

            TotalProductYear[0] = yearPsum[0]; // product
            TotalFallingYear[0] = yearFsum[0];

            SeriesCollectionFallingSummary = SendToPieChartSummary(TotalFallingYear);
            SeriesCollectionProductSummary = SendToPieChartSummary(TotalProductYear);
            if (thread_summary != null)
            {
                thread_summary.Abort();
            }
        }
        public void MonthModeSummary()
        {
            if (thread_summary != null)
            {
                thread_summary.Abort();
            }
            thread_summary = new Thread(MonthModeSummary);
            thread_summary.Priority = ThreadPriority.Lowest;
            thread_summary.Start();
            Labels = new[] { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
            int[] totalPmonth = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] totalFmonth = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int y = int.Parse(YearSelected);
            for (int i = 0; i < 12; i++)
            {
                var rs1m = ProductivitySummaryChartCNC1(y, i + 1, i + 1, DataProvider.Ins.DB.EventManagerCNC1);
                var rs2m = ProductivitySummaryChartCNC2(y, i + 1, i + 1, DataProvider.Ins.DB.EventManagerCNC2);
                var rs3m = ProductivitySummaryChartCNC3(y, i + 1, i + 1, DataProvider.Ins.DB.EventManagerCNC3);
                var rs4m = ProductivitySummaryChartCNC4(y, i + 1, i + 1, DataProvider.Ins.DB.EventManagerCNC4);
                var rs5m = ProductivitySummaryChartCNC5(y, i + 1, i + 1, DataProvider.Ins.DB.EventManagerCNC5);
                var rs6m = ProductivitySummaryChartCNC6(y, i + 1, i + 1, DataProvider.Ins.DB.EventManagerCNC6);
                var rs7m = ProductivitySummaryChartCNC7(y, i + 1, i + 1, DataProvider.Ins.DB.EventManagerCNC7);
                var rs8m = ProductivitySummaryChartCNC8(y, i + 1, i + 1, DataProvider.Ins.DB.EventManagerCNC8);
                Task.WhenAll(rs1m, rs2m, rs3m, rs4m, rs5m, rs6m, rs7m, rs8m);
                totalPmonth[i] = rs1m.Result[0] + rs2m.Result[0] + rs3m.Result[0] + rs4m.Result[0] + rs5m.Result[0] + rs6m.Result[0] + rs7m.Result[0] + rs8m.Result[0];
                totalFmonth[i] = rs1m.Result[1] + rs2m.Result[1] + rs3m.Result[1] + rs4m.Result[1] + rs5m.Result[1] + rs6m.Result[1] + rs7m.Result[1] + rs8m.Result[1];

            }

            SummaryProductTotal = new ChartValues<int>
            {
                totalPmonth[0],
                totalPmonth[1],
                totalPmonth[2],
                totalPmonth[3],
                totalPmonth[4],
                totalPmonth[5],
                totalPmonth[6],
                totalPmonth[7],
                totalPmonth[8],
                totalPmonth[9],
                totalPmonth[10],
                totalPmonth[11]
            };
            SummaryFallingTotal = new ChartValues<int>
            {
                totalFmonth[0],
                totalFmonth[1],
                totalFmonth[2],
                totalFmonth[3],
                totalFmonth[4],
                totalFmonth[5],
                totalFmonth[6],
                totalFmonth[7],
                totalFmonth[8],
                totalFmonth[9],
                totalFmonth[10],
                totalFmonth[11]
            };
            int[] TotalProductMonth = new int[4] { 0, 0, 0, 0 };
            int[] TotalFallingMonth = new int[4] { 0, 0, 0, 0 };
            int monthint = Convert.ToInt16(MonthSelected);
            TotalProductMonth[0] = totalPmonth[monthint - 1];
            TotalFallingMonth[0] = totalFmonth[monthint - 1];
            SeriesCollectionFallingSummary = SendToPieChartSummary(TotalFallingMonth);
            SeriesCollectionProductSummary = SendToPieChartSummary(TotalProductMonth);

            var total1m = TimeCalculation_AllCNC(1, 1, y);
            var total2m = TimeCalculation_AllCNC(2, 2, y);
            var total3m = TimeCalculation_AllCNC(3, 3, y);
            var total4m = TimeCalculation_AllCNC(4, 4, y);
            var total5m = TimeCalculation_AllCNC(5, 5, y);
            var total6m = TimeCalculation_AllCNC(6, 6, y);
            var total7m = TimeCalculation_AllCNC(7, 7, y);
            var total8m = TimeCalculation_AllCNC(8, 8, y);
            var total9m = TimeCalculation_AllCNC(9, 9, y);
            var total10m = TimeCalculation_AllCNC(10, 10, y);
            var total11m = TimeCalculation_AllCNC(11, 11, y);
            var total12m = TimeCalculation_AllCNC(12, 12, y);

            Task.WhenAll(
                total1m,
                total2m,
                total3m,
                total4m,
                total5m,
                total6m,
                total7m,
                total8m,
                total9m,
                total10m,
                total11m,
                total12m
                );

            double[] total1 = total1m.Result.ToArray();
            double[] total2 = total2m.Result.ToArray();
            double[] total3 = total3m.Result.ToArray();
            double[] total4 = total4m.Result.ToArray();
            double[] total5 = total5m.Result.ToArray();
            double[] total6 = total6m.Result.ToArray();
            double[] total7 = total7m.Result.ToArray();
            double[] total8 = total8m.Result.ToArray();
            double[] total9 = total9m.Result.ToArray();
            double[] total10 = total10m.Result.ToArray();
            double[] total11 = total11m.Result.ToArray();
            double[] total12 = total12m.Result.ToArray();

            SummaryTotal1 = new ChartValues<double>
            {
                total1[0],total2[0],total3[0],total4[0],total5[0],total6[0],total7[0],total8[0],total9[0],total10[0],total11[0],total12[0]
            };
            SummaryTotal2 = new ChartValues<double>
            {
                total1[1],total2[1],total3[1],total4[1],total5[1],total6[1],total7[1],total8[1],total9[1],total10[1],total11[1],total12[1]
            };
            SummaryTotal3 = new ChartValues<double>
            {
                total1[2],total2[2],total3[2],total4[2],total5[2],total6[2],total7[2],total8[2],total9[2],total10[2],total11[2],total12[2]
            };
            if (thread_summary != null)
            {
                thread_summary.Abort();
            }
        }
        public void SeasonModeSummary()
        {
            if (thread_summary != null)
            {
                thread_summary.Abort();
            }
            thread_summary = new Thread(SeasonModeSummary);
            thread_summary.Priority = ThreadPriority.Lowest;
            thread_summary.Start();
            Labels = new[] { "SS1", "SS2", "SS3", "SS4" };
            int[] totalPseason = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] totalFseason = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int y = int.Parse(YearSelected);
            for (int i = 1; i <= 12; i += 3)
            {
                var rs1m = ProductivitySummaryChartCNC1(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC1);
                var rs2m = ProductivitySummaryChartCNC2(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC2);
                var rs3m = ProductivitySummaryChartCNC3(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC3);
                var rs4m = ProductivitySummaryChartCNC4(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC4);
                var rs5m = ProductivitySummaryChartCNC5(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC5);
                var rs6m = ProductivitySummaryChartCNC6(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC6);
                var rs7m = ProductivitySummaryChartCNC7(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC7);
                var rs8m = ProductivitySummaryChartCNC8(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC8);
                Task.WhenAll(rs1m, rs2m, rs3m, rs4m, rs5m, rs6m, rs7m, rs8m);
                totalPseason[i] = rs1m.Result[0] + rs2m.Result[0] + rs3m.Result[0] + rs4m.Result[0] + rs5m.Result[0] + rs6m.Result[0] + rs7m.Result[0] + rs8m.Result[0];
                totalFseason[i] = rs1m.Result[1] + rs2m.Result[1] + rs3m.Result[1] + rs4m.Result[1] + rs5m.Result[1] + rs6m.Result[1] + rs7m.Result[1] + rs8m.Result[1];
            }
            SummaryProductTotal = new ChartValues<int>
            {
                totalPseason[1],
                totalPseason[4],
                totalPseason[7],
                totalPseason[10]
            };
            SummaryFallingTotal = new ChartValues<int>
            {
                totalFseason[1],
                totalFseason[4],
                totalFseason[7],
                totalFseason[10]
            };
            int[] TotalProductSeason1Line = { totalPseason[1], 0, 0, 0 };
            int[] TotalFallingSeason1Line = { totalFseason[1], 0, 0, 0 };
            int[] TotalProductSeason2Line = { totalPseason[4], 0, 0, 0 };
            int[] TotalFallingSeason2Line = { totalFseason[4], 0, 0, 0 };
            int[] TotalProductSeason3Line = { totalPseason[7], 0, 0, 0 };
            int[] TotalFallingSeason3Line = { totalFseason[7], 0, 0, 0 };
            int[] TotalProductSeason4Line = { totalPseason[10], 0, 0, 0 };
            int[] TotalFallingSeason4Line = { totalFseason[10], 0, 0, 0 };

            if (string.Equals(SeasonSelected, "1"))
            {
                SeriesCollectionFallingSummary = SendToPieChartSummary(TotalFallingSeason1Line);
                SeriesCollectionProductSummary = SendToPieChartSummary(TotalProductSeason1Line);
            }
            if (string.Equals(SeasonSelected, "2"))
            {
                SeriesCollectionFallingSummary = SendToPieChartSummary(TotalFallingSeason2Line);
                SeriesCollectionProductSummary = SendToPieChartSummary(TotalProductSeason2Line);
            }
            if (string.Equals(SeasonSelected, "3"))
            {
                SeriesCollectionFallingSummary = SendToPieChartSummary(TotalFallingSeason3Line);
                SeriesCollectionProductSummary = SendToPieChartSummary(TotalProductSeason3Line);
            }
            if (string.Equals(SeasonSelected, "4"))
            {
                SeriesCollectionFallingSummary = SendToPieChartSummary(TotalFallingSeason4Line);
                SeriesCollectionProductSummary = SendToPieChartSummary(TotalProductSeason4Line);
            }

            var total1m = TimeCalculation_AllCNC(1, 3, y);
            var total2m = TimeCalculation_AllCNC(4, 6, y);
            var total3m = TimeCalculation_AllCNC(7, 9, y);
            var total4m = TimeCalculation_AllCNC(10, 12, y);

            Task.WhenAll(
                total1m,
                total2m,
                total3m,
                total4m
                );

            double[] total1 = total1m.Result.ToArray();
            double[] total2 = total2m.Result.ToArray();
            double[] total3 = total3m.Result.ToArray();
            double[] total4 = total4m.Result.ToArray();


            SummaryTotal1 = new ChartValues<double>
            {
                total1[0],total2[0],total3[0],total4[0]
            };
            SummaryTotal2 = new ChartValues<double>
            {
                total1[1],total2[1],total3[1],total4[1]
            };
            SummaryTotal3 = new ChartValues<double>
            {
                total1[2],total2[2],total3[2],total4[2]
            };
            if (thread_summary != null)
            {
                thread_summary.Abort();
            }
        }
        public void SeasonModeSummaryTest()
        {
            if (Thread_execution != null)
            {
                Thread_execution.Abort();
            }
            //Thread_execution = new Thread(SeasonModeSummary);

            //Thread_execution.Start();
            //bool working = true;
            Thread_execution = new Thread(() =>
            {
                // Don't put the working bool in here, otherwise it will 
                // belong to the new thread and not the main UI thread.

                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Put your entire logic code in here.
                    // All of this code will process on the main UI thread because
                    //  of the Invoke.
                    // By doing it this way, you don't have to worry about Invoking individual
                    //  elements as they are needed.
                    Labels = new[] { "SS1", "SS2", "SS3", "SS4" };
                    int[] totalPseason = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] totalFseason = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int y = int.Parse(YearSelected);
                    for (int i = 1; i <= 12; i += 3)
                    {
                        var rs1m = ProductivitySummaryChartCNC1(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC1);
                        var rs2m = ProductivitySummaryChartCNC2(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC2);
                        var rs3m = ProductivitySummaryChartCNC3(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC3);
                        var rs4m = ProductivitySummaryChartCNC4(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC4);
                        var rs5m = ProductivitySummaryChartCNC5(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC5);
                        var rs6m = ProductivitySummaryChartCNC6(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC6);
                        var rs7m = ProductivitySummaryChartCNC7(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC7);
                        var rs8m = ProductivitySummaryChartCNC8(y, i, i + 2, DataProvider.Ins.DB.EventManagerCNC8);
                        Task.WhenAll(rs1m, rs2m, rs3m, rs4m, rs5m, rs6m, rs7m, rs8m);
                        totalPseason[i] = rs1m.Result[0] + rs2m.Result[0] + rs3m.Result[0] + rs4m.Result[0] + rs5m.Result[0] + rs6m.Result[0] + rs7m.Result[0] + rs8m.Result[0];
                        totalFseason[i] = rs1m.Result[1] + rs2m.Result[1] + rs3m.Result[1] + rs4m.Result[1] + rs5m.Result[1] + rs6m.Result[1] + rs7m.Result[1] + rs8m.Result[1];
                    }
                    SummaryProductTotal = new ChartValues<int>
            {
                totalPseason[1],
                totalPseason[4],
                totalPseason[7],
                totalPseason[10]
            };
                    SummaryFallingTotal = new ChartValues<int>
            {
                totalFseason[1],
                totalFseason[4],
                totalFseason[7],
                totalFseason[10]
            };
                    int[] TotalProductSeason1Line = { totalPseason[1], 0, 0, 0 };
                    int[] TotalFallingSeason1Line = { totalFseason[1], 0, 0, 0 };
                    int[] TotalProductSeason2Line = { totalPseason[4], 0, 0, 0 };
                    int[] TotalFallingSeason2Line = { totalFseason[4], 0, 0, 0 };
                    int[] TotalProductSeason3Line = { totalPseason[7], 0, 0, 0 };
                    int[] TotalFallingSeason3Line = { totalFseason[7], 0, 0, 0 };
                    int[] TotalProductSeason4Line = { totalPseason[10], 0, 0, 0 };
                    int[] TotalFallingSeason4Line = { totalFseason[10], 0, 0, 0 };

                    if (string.Equals(SeasonSelected, "1"))
                    {
                        SeriesCollectionFallingSummary = SendToPieChartSummary(TotalFallingSeason1Line);
                        SeriesCollectionProductSummary = SendToPieChartSummary(TotalProductSeason1Line);
                    }
                    if (string.Equals(SeasonSelected, "2"))
                    {
                        SeriesCollectionFallingSummary = SendToPieChartSummary(TotalFallingSeason2Line);
                        SeriesCollectionProductSummary = SendToPieChartSummary(TotalProductSeason2Line);
                    }
                    if (string.Equals(SeasonSelected, "3"))
                    {
                        SeriesCollectionFallingSummary = SendToPieChartSummary(TotalFallingSeason3Line);
                        SeriesCollectionProductSummary = SendToPieChartSummary(TotalProductSeason3Line);
                    }
                    if (string.Equals(SeasonSelected, "4"))
                    {
                        SeriesCollectionFallingSummary = SendToPieChartSummary(TotalFallingSeason4Line);
                        SeriesCollectionProductSummary = SendToPieChartSummary(TotalProductSeason4Line);
                    }

                    var total1m = TimeCalculation_AllCNC(1, 3, y);
                    var total2m = TimeCalculation_AllCNC(4, 6, y);
                    var total3m = TimeCalculation_AllCNC(7, 9, y);
                    var total4m = TimeCalculation_AllCNC(10, 12, y);

                    Task.WhenAll(
                        total1m,
                        total2m,
                        total3m,
                        total4m
                        );

                    double[] total1 = total1m.Result.ToArray();
                    double[] total2 = total2m.Result.ToArray();
                    double[] total3 = total3m.Result.ToArray();
                    double[] total4 = total4m.Result.ToArray();


                    SummaryTotal1 = new ChartValues<double>
                        {
                            total1[0],total2[0],total3[0],total4[0]
                        };
                    SummaryTotal2 = new ChartValues<double>
                        {
                            total1[1],total2[1],total3[1],total4[1]
                        };
                    SummaryTotal3 = new ChartValues<double>
                        {
                            total1[2],total2[2],total3[2],total4[2]
                        };
                });

            });

            Thread_execution.Start();
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
            
            int[] aa = { 11, 12, 13, 14 };
            List<int[]> listArr = new List<int[]> { };
            listArr.Add(aa);   
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
            TimeSpan tpan = t2m - t1m;
            double[] result = new double[3] { 0, 0, 0  };
            for (int i = 0; i < 3; i++)
            {
                result[i] = total1[i] + total2[i] + total3[i] + total4[i] + total5[i] + total6[i] + total7[i] + total8[i];
            }
            return result;

        }
        public Colorss[] ColorLightMaintenance(double[] temp)
        {
            GC.Collect();
            Colorss[] light = new Colorss[8] { Colorss.Green, Colorss.Green, Colorss.Green, Colorss.Green, Colorss.Green, Colorss.Green, Colorss.Green, Colorss.Green };
            for (int i = 0; i < 8; i++)
            {
                if (1000 - temp[i] >= 0 && 1000 - temp[i] <= 24)
                {
                    light[i] = Colorss.Red;
                }
                else
                {
                    light[i] = Colorss.Green;
                }
            }
            return light;

        }
        public SeriesCollection SendToPieChartSummary(int[] valueArray)
        {
            GC.Collect();
            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            Formatter = value => value.ToString("N");
            SeriesPieSummary = new SeriesCollection
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
                    var team = total.ToList();
                    for (int i = 0; i < team.Count(); i++)
                    {
                        if (i + 1 < team.Count())
                        {
                            TimeSpan? tpan1 = team[i + 1].ThoiDiem - team[i].ThoiDiem;
                            if (team[i].IdHienTrangMayCNC == 1)
                            {
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
                    var team = total.ToList();
                    for (int i = 0; i < team.Count(); i++)
                    {
                        if (i + 1 < team.Count())
                        {
                            TimeSpan? tpan1 = team[i + 1].ThoiDiem - team[i].ThoiDiem;
                            if (team[i].IdHienTrangMayCNC == 1)
                            {
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
                    var team = total.ToList();
                    for (int i = 0; i < team.Count(); i++)
                    {
                        if (i + 1 < team.Count())
                        {
                            TimeSpan? tpan1 = team[i + 1].ThoiDiem - team[i].ThoiDiem;
                            if (team[i].IdHienTrangMayCNC == 1)
                            {
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
                    var team = total.ToList();
                    for (int i = 0; i < team.Count(); i++)
                    {
                        if (i + 1 < team.Count())
                        {
                            TimeSpan? tpan1 = team[i + 1].ThoiDiem - team[i].ThoiDiem;
                            if (team[i].IdHienTrangMayCNC == 1)
                            {
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
                    var team = total.ToList();
                    for (int i = 0; i < team.Count(); i++)
                    {
                        if (i + 1 < team.Count())
                        {
                            TimeSpan? tpan1 = team[i + 1].ThoiDiem - team[i].ThoiDiem;
                            if (team[i].IdHienTrangMayCNC == 1)
                            {
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
                    var team = total.ToList();
                    for (int i = 0; i < team.Count(); i++)
                    {
                        if (i + 1 < team.Count())
                        {
                            TimeSpan? tpan1 = team[i + 1].ThoiDiem - team[i].ThoiDiem;
                            if (team[i].IdHienTrangMayCNC == 1)
                            {
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
                    var team = total.ToList();
                    for (int i = 0; i < team.Count(); i++)
                    {
                        if (i + 1 < team.Count())
                        {
                            TimeSpan? tpan1 = team[i + 1].ThoiDiem - team[i].ThoiDiem;
                            if (team[i].IdHienTrangMayCNC == 1)
                            {
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
                    var team = total.ToList();
                    for (int i = 0; i < team.Count(); i++)
                    {
                        if (i + 1 < team.Count())
                        {
                            TimeSpan? tpan1 = team[i + 1].ThoiDiem - team[i].ThoiDiem;
                            if (team[i].IdHienTrangMayCNC == 1)
                            {
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
        public DateTime[] DatetimeSplitTimeChart()
        {
            DateTime t11 = DateTime.ParseExact(DisplayDateSplitTime.ToString("yyyy-MM-dd") + " " + "00:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime t12 = DateTime.ParseExact(DisplayDateSplitTime.ToString("yyyy-MM-dd") + " " + "07:59:59.999", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);

            DateTime t21 = DateTime.ParseExact(DisplayDateSplitTime.ToString("yyyy-MM-dd") + " " + "08:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime t22 = DateTime.ParseExact(DisplayDateSplitTime.ToString("yyyy-MM-dd") + " " + "15:59:59.999", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);

            DateTime t31 = DateTime.ParseExact(DisplayDateSplitTime.ToString("yyyy-MM-dd") + " " + "16:00:00.000", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime t32 = DateTime.ParseExact(DisplayDateSplitTime.ToString("yyyy-MM-dd") + " " + "23:59:59.999", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            DateTime[] result = { t11, t12, t21, t22, t31, t32 };
            return result;
        }
        public SeriesCollection SeriesSplitTimeChart(double[] timeShift1CNC, double[] timeShift2CNC, double[] timeShift3CNC)
        {
            int[] ukm = new int[ 4];
            Array.Sort(ukm);
            int u = ukm.Last();
            SeriesCollection SeriesSplitTime = new SeriesCollection
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
                    Title = "Time Left/Off",
                    Values = new ChartValues<double> { timeShift1CNC[3], timeShift2CNC[3], timeShift3CNC[3]},
                    StackMode = StackMode.Percentage,
                    DataLabels = true,
                    LabelPoint = p => p.X.ToString()
                }
            };
            return SeriesSplitTime;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC1(IEnumerable<EventManagerCNC1> tableCNC)
        {
            DateTime[] time = DatetimeSplitTimeChart();
            var time1 = TimeCalculation_CNC1(time[0], time[1], tableCNC);
            var time2 = TimeCalculation_CNC1(time[2], time[3], tableCNC);
            var time3 = TimeCalculation_CNC1(time[4], time[5], tableCNC);
            await Task.WhenAll
                (
                time1,
                time2,
                time3
                );
            double[] timeShift1CNC = time1.Result;
            double[] timeShift2CNC = time2.Result;
            double[] timeShift3CNC = time3.Result;
            Series = SeriesSplitTimeChart(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC2(IEnumerable<EventManagerCNC2> tableCNC)
        {

            DateTime[] time = DatetimeSplitTimeChart();
            var time1 = TimeCalculation_CNC2(time[0], time[1], tableCNC);
            var time2 = TimeCalculation_CNC2(time[2], time[3], tableCNC);
            var time3 = TimeCalculation_CNC2(time[4], time[5], tableCNC);
            await Task.WhenAll(
                time1,
                time2,
                time3
                );
            double[] timeShift1CNC = time1.Result;
            double[] timeShift2CNC = time2.Result;
            double[] timeShift3CNC = time3.Result;
            Series = SeriesSplitTimeChart(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC3(IEnumerable<EventManagerCNC3> tableCNC)
        {
            DateTime[] time = DatetimeSplitTimeChart();
            var time1 = TimeCalculation_CNC3(time[0], time[1], tableCNC);
            var time2 = TimeCalculation_CNC3(time[2], time[3], tableCNC);
            var time3 = TimeCalculation_CNC3(time[4], time[5], tableCNC);
            await Task.WhenAll
                (
                time1,
                time2,
                time3
                );
            double[] timeShift1CNC = time1.Result;
            double[] timeShift2CNC = time2.Result;
            double[] timeShift3CNC = time3.Result;
            Series = SeriesSplitTimeChart(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC4(IEnumerable<EventManagerCNC4> tableCNC)
        {

            DateTime[] time = DatetimeSplitTimeChart();
            var time1 = TimeCalculation_CNC4(time[0], time[1], tableCNC);
            var time2 = TimeCalculation_CNC4(time[2], time[3], tableCNC);
            var time3 = TimeCalculation_CNC4(time[4], time[5], tableCNC);
            await Task.WhenAll(
                time1,
                time2,
                time3
                );
            double[] timeShift1CNC = time1.Result;
            double[] timeShift2CNC = time2.Result;
            double[] timeShift3CNC = time3.Result;
            Series = SeriesSplitTimeChart(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC5(IEnumerable<EventManagerCNC5> tableCNC)
        {
            DateTime[] time = DatetimeSplitTimeChart();
            var time1 = TimeCalculation_CNC5(time[0], time[1], tableCNC);
            var time2 = TimeCalculation_CNC5(time[2], time[3], tableCNC);
            var time3 = TimeCalculation_CNC5(time[4], time[5], tableCNC);
            await Task.WhenAll
                (
                time1,
                time2,
                time3
                );
            double[] timeShift1CNC = time1.Result;
            double[] timeShift2CNC = time2.Result;
            double[] timeShift3CNC = time3.Result;
            Series = SeriesSplitTimeChart(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC6(IEnumerable<EventManagerCNC6> tableCNC)
        {

            DateTime[] time = DatetimeSplitTimeChart();
            var time1 = TimeCalculation_CNC6(time[0], time[1], tableCNC);
            var time2 = TimeCalculation_CNC6(time[2], time[3], tableCNC);
            var time3 = TimeCalculation_CNC6(time[4], time[5], tableCNC);
            await Task.WhenAll(
                time1,
                time2,
                time3
                );
            double[] timeShift1CNC = time1.Result;
            double[] timeShift2CNC = time2.Result;
            double[] timeShift3CNC = time3.Result;
            Series = SeriesSplitTimeChart(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC7(IEnumerable<EventManagerCNC7> tableCNC)
        {
            DateTime[] time = DatetimeSplitTimeChart();
            var time1 = TimeCalculation_CNC7(time[0], time[1], tableCNC);
            var time2 = TimeCalculation_CNC7(time[2], time[3], tableCNC);
            var time3 = TimeCalculation_CNC7(time[4], time[5], tableCNC);
            await Task.WhenAll
                (
                time1,
                time2,
                time3
                );
            double[] timeShift1CNC = time1.Result;
            double[] timeShift2CNC = time2.Result;
            double[] timeShift3CNC = time3.Result;
            Series = SeriesSplitTimeChart(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }
        public async Task<SeriesCollection> SendDataToSplitTimeChartCNC8(IEnumerable<EventManagerCNC8> tableCNC)
        {

            DateTime[] time = DatetimeSplitTimeChart();
            var time1 = TimeCalculation_CNC8(time[0], time[1], tableCNC);
            var time2 = TimeCalculation_CNC8(time[2], time[3], tableCNC);
            var time3 = TimeCalculation_CNC8(time[4], time[5], tableCNC);
            await Task.WhenAll(
                time1,
                time2,
                time3
                );
            double[] timeShift1CNC = time1.Result;
            double[] timeShift2CNC = time2.Result;
            double[] timeShift3CNC = time3.Result;
            Series = SeriesSplitTimeChart(timeShift1CNC, timeShift2CNC, timeShift3CNC);
            return Series;
        }

        public DateTime[] DatetimeProductChart()
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
            DateTime[] result = { Date1, Date2, Date3, Date4,Date5,Date6,Date7,Date8 };
            return result;

        }
        public SeriesCollection SeriesProductChart(int[] returnDays, int[] returnDays1, int[] returnDays2)
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
            SeriesCollection SeriesProduct = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Product",
                    Values = new ChartValues<double> { returnDays[0], returnDays[1], returnDays[2], returnDays[3], returnDays[4], returnDays[5], returnDays[6] }
                }
            };
            SeriesProduct.Add(new ColumnSeries
            {
                Title = "Falling",
                Values = new ChartValues<double> { returnDays[7], returnDays[8], returnDays[9], returnDays[10], returnDays[11], returnDays[12], returnDays[13] }
            });
            return SeriesProduct;
        }
        public SeriesCollection SendDataToProductionChartCNC1(IEnumerable<EventManagerCNC1> table)
        {
            
            DateTime[] Date = DatetimeProductChart();
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
            SeriesP = SeriesProductChart(returnDays, returnDays1, returnDays2);
            return SeriesP;
        }
        public SeriesCollection SendDataToProductionChartCNC2(IEnumerable<EventManagerCNC2> table)
        {

            DateTime[] Date = DatetimeProductChart();
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
            SeriesP = SeriesProductChart(returnDays, returnDays1, returnDays2);
            return SeriesP;
        }
        public SeriesCollection SendDataToProductionChartCNC3(IEnumerable<EventManagerCNC3> table)
        {

            DateTime[] Date = DatetimeProductChart();
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
            SeriesP = SeriesProductChart(returnDays, returnDays1, returnDays2);
            return SeriesP;
        }
        public SeriesCollection SendDataToProductionChartCNC4(IEnumerable<EventManagerCNC4> table)
        {

            DateTime[] Date = DatetimeProductChart();
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
            SeriesP = SeriesProductChart(returnDays, returnDays1, returnDays2);
            return SeriesP;
        }
        public SeriesCollection SendDataToProductionChartCNC5(IEnumerable<EventManagerCNC5> table)
        {

            DateTime[] Date = DatetimeProductChart();
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
            SeriesP = SeriesProductChart(returnDays, returnDays1, returnDays2);
            return SeriesP;
        }
        public SeriesCollection SendDataToProductionChartCNC6(IEnumerable<EventManagerCNC6> table)
        {

            DateTime[] Date = DatetimeProductChart();
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
            SeriesP = SeriesProductChart(returnDays, returnDays1, returnDays2);
            return SeriesP;
        }
        public SeriesCollection SendDataToProductionChartCNC7(IEnumerable<EventManagerCNC7> table)
        {

            DateTime[] Date = DatetimeProductChart();
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
            SeriesP = SeriesProductChart(returnDays, returnDays1, returnDays2);
            return SeriesP;
        }
        public SeriesCollection SendDataToProductionChartCNC8(IEnumerable<EventManagerCNC8> table)
        {

            DateTime[] Date = DatetimeProductChart();
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
            SeriesP = SeriesProductChart(returnDays, returnDays1, returnDays2);
            return SeriesP;
        }


        // test  
        //public async Task<double[]> TimeCalculation_CNC1(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC1> total)
        //{
        //    TimeSpan? tpanm = t2 - t1;
        //    double[] m = new double[4] { 0, 0, 0, tpanm.Value.TotalHours };
        //    double TimeStop = 0;
        //    double TimeRun = 0;
        //    double TimeFail = 0;
        //    var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
        //    // sử dụng Store procedure cho việc gửi tham số là 1 table, lấy ra vùng tgian này của từng bảng bằng cách truyền tham số bảng khác
        //    // sử dụng query chạy
        //    if (total.Count() == 0) // đây cũng vậy, với tên table là giá trị truyền vào
        //        return m;

        //    var first = season.FirstOrDefault();
        //    var last = season.ToArray().LastOrDefault();
        //    var firsttotal = total.ToArray().FirstOrDefault();
        //    var lasttotal = total.ToArray().LastOrDefault();
        //    var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();

        //    if (LastUp != null)
        //    {
        //        double[] result1 = { 0, 0, 0 };
        //        result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
        //        TimeRun = TimeRun + result1[0];
        //        TimeStop = TimeStop + result1[1];
        //        TimeFail = TimeFail + result1[2];
        //        if (first != null)
        //        {
        //            double[] result2 = { 0, 0, 0 };
        //            result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
        //            TimeRun = TimeRun + result2[0];
        //            TimeStop = TimeStop + result2[1];
        //            TimeFail = TimeFail + result2[2];
        //        }
        //    }

        //    if (season.Count() > 0)
        //    {
        //        double[] result = { 0, 0, 0 };
        //        result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
        //        TimeRun = TimeRun + result[0];
        //        TimeStop = TimeStop + result[1];
        //        TimeFail = TimeFail + result[2];
        //        var team = season.ToList();
        //        for (int i = 0; i < season.Count(); i++)
        //        {
        //            if ( i + 1 < season.Count())
        //            {
        //                TimeSpan? tpan = team[i + 1].ThoiDiem - team[i].ThoiDiem;
        //                if (team[i].IdHienTrangMayCNC == 1)
        //                {
        //                    TimeRun = TimeRun + tpan.Value.TotalSeconds;
        //                }
        //                if (team[i].IdHienTrangMayCNC == 2)
        //                {
        //                    TimeStop = TimeStop + tpan.Value.TotalSeconds;
        //                }
        //                if (team[i].IdHienTrangMayCNC == 3)
        //                {
        //                    TimeFail = TimeFail + tpan.Value.TotalSeconds;
        //                }
        //            }    
        //        }
        //    }
        //    m[0] = Math.Truncate((TimeRun / 3600) * 100) / 100;
        //    m[1] = Math.Truncate((TimeStop / 3600) * 100) / 100;
        //    m[2] = Math.Truncate((TimeFail / 3600) * 100) / 100;
        //    m[3] = Math.Truncate((tpanm.Value.TotalHours - m[0] - m[1] - m[2]) * 100) / 100;
        //    await Task.Delay(0);
        //    return m;
        //}
        //public async Task<double[]> TimeCalculation_CNC9(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC8> total)
        //{
        //    TimeSpan? tpanm = t2 - t1;
        //    double[] m = new double[4] { 0, 0, 0, tpanm.Value.TotalHours };
        //    double TimeStop = 0;
        //    double TimeRun = 0;
        //    double TimeFail = 0;
        //    var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
        //    if (total.Count() == 0)
        //        return m;

        //    var first = season.FirstOrDefault();
        //    var last = season.ToArray().LastOrDefault();
        //    var firsttotal = total.ToArray().FirstOrDefault();
        //    var lasttotal = total.ToArray().LastOrDefault();
        //    var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();

        //    if (LastUp != null)
        //    {
        //        double[] result1 = { 0, 0, 0 };
        //        result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
        //        TimeRun = TimeRun + result1[0];
        //        TimeStop = TimeStop + result1[1];
        //        TimeFail = TimeFail + result1[2];
        //        if (first != null)
        //        {
        //            double[] result2 = { 0, 0, 0 };
        //            result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
        //            TimeRun = TimeRun + result2[0];
        //            TimeStop = TimeStop + result2[1];
        //            TimeFail = TimeFail + result2[2];
        //        }
        //    }

        //    if (season.Count() > 0)
        //    {
        //        double[] result = { 0, 0, 0 };
        //        result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
        //        TimeRun = TimeRun + result[0];
        //        TimeStop = TimeStop + result[1];
        //        TimeFail = TimeFail + result[2];
        //        var team = season.ToList();
        //        foreach (var item0 in season)
        //        {
        //            foreach (var item1 in season)
        //            {
        //                if (item0.Id == item1.Id + 1)
        //                {
        //                    TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
        //                    if (item1.IdHienTrangMayCNC == 1)
        //                    {
        //                        TimeRun += tpan.Value.TotalSeconds;
        //                    }
        //                    if (item1.IdHienTrangMayCNC == 2)
        //                    {
        //                        TimeStop += tpan.Value.TotalSeconds;
        //                    }
        //                    if (item1.IdHienTrangMayCNC == 3)
        //                    {
        //                        TimeFail += tpan.Value.TotalSeconds;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    m[0] = Math.Truncate((TimeRun / 3600) * 100) / 100;
        //    m[1] = Math.Truncate((TimeStop / 3600) * 100) / 100;
        //    m[2] = Math.Truncate((TimeFail / 3600) * 100) / 100;
        //    m[3] = Math.Truncate((tpanm.Value.TotalHours - m[0] - m[1] - m[2]) * 100) / 100;
        //    await Task.Delay(0);
        //    return m;
        //}  //test
        // ----



        public async Task<double[]> TimeCalculation_CNC1(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC1> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] i = new double[4] { 0.0, 0.0, 0.0, tpanm.Value.TotalHours };
            double TimeStop = 0.0;
            double TimeRun = 0.0;
            double TimeFail = 0.0;
            //var season = from p in total.AsEnumerable()
            //                                       where p.ThoiDiem >= t1 && p.ThoiDiem <= t2
            //                                       select p;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
            {
                return i;
            }
            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            //var LastUp = (from p in total.AsEnumerable()
            //                           where p.ThoiDiem < t1
            //                           select p).ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();
            if (LastUp != null)
            {
                double[] result1 = new double[3];
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun += result1[0];
                TimeStop += result1[1];
                TimeFail += result1[2];
                if (first != null)
                {
                    double[] result2 = new double[3];
                    //result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, (from p in total.AsEnumerable()
                    //                                                                        where p.ThoiDiem < t1
                    //                                                                        select p).Count(), first.ThoiDiem, t1);
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun += result2[0];
                    TimeStop += result2[1];
                    TimeFail += result2[2];
                }
            }
            if (season.Count() > 0)
            {
                double[] result = new double[3];
                //result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun += result[0];
                TimeStop += result[1];
                TimeFail += result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail += tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            i[0] = Math.Truncate(TimeRun / 3600.0 * 100.0) / 100.0;
            i[1] = Math.Truncate(TimeStop / 3600.0 * 100.0) / 100.0;
            i[2] = Math.Truncate(TimeFail / 3600.0 * 100.0) / 100.0;
            i[3] = Math.Truncate((tpanm.Value.TotalHours - i[0] - i[1] - i[2]) * 100.0) / 100.0;
            await Task.Delay(0);
            return i;
        }
        public async Task<double[]> TimeCalculation_CNC2(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC2> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] i = new double[4] { 0.0, 0.0, 0.0, tpanm.Value.TotalHours };
            double TimeStop = 0.0;
            double TimeRun = 0.0;
            double TimeFail = 0.0;
            //var season = from p in total.AsEnumerable()
            //                                       where p.ThoiDiem >= t1 && p.ThoiDiem <= t2
            //                                       select p;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
            {
                return i;
            }
            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            //var LastUp = (from p in total.AsEnumerable()
            //                           where p.ThoiDiem < t1
            //                           select p).ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();
            if (LastUp != null)
            {
                double[] result1 = new double[3];
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun += result1[0];
                TimeStop += result1[1];
                TimeFail += result1[2];
                if (first != null)
                {
                    double[] result2 = new double[3];
                    //result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, (from p in total.AsEnumerable()
                    //                                                                        where p.ThoiDiem < t1
                    //                                                                        select p).Count(), first.ThoiDiem, t1);
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun += result2[0];
                    TimeStop += result2[1];
                    TimeFail += result2[2];
                }
            }
            if (season.Count() > 0)
            {
                double[] result = new double[3];
                //result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun += result[0];
                TimeStop += result[1];
                TimeFail += result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail += tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            i[0] = Math.Truncate(TimeRun / 3600.0 * 100.0) / 100.0;
            i[1] = Math.Truncate(TimeStop / 3600.0 * 100.0) / 100.0;
            i[2] = Math.Truncate(TimeFail / 3600.0 * 100.0) / 100.0;
            i[3] = Math.Truncate((tpanm.Value.TotalHours - i[0] - i[1] - i[2]) * 100.0) / 100.0;
            await Task.Delay(0);
            return i;
        }
        public async Task<double[]> TimeCalculation_CNC3(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC3> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] i = new double[4] { 0.0, 0.0, 0.0, tpanm.Value.TotalHours };
            double TimeStop = 0.0;
            double TimeRun = 0.0;
            double TimeFail = 0.0;
            //var season = from p in total.AsEnumerable()
            //                                       where p.ThoiDiem >= t1 && p.ThoiDiem <= t2
            //                                       select p;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
            {
                return i;
            }
            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            //var LastUp = (from p in total.AsEnumerable()
            //                           where p.ThoiDiem < t1
            //                           select p).ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();
            if (LastUp != null)
            {
                double[] result1 = new double[3];
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun += result1[0];
                TimeStop += result1[1];
                TimeFail += result1[2];
                if (first != null)
                {
                    double[] result2 = new double[3];
                    //result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, (from p in total.AsEnumerable()
                    //                                                                        where p.ThoiDiem < t1
                    //                                                                        select p).Count(), first.ThoiDiem, t1);
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun += result2[0];
                    TimeStop += result2[1];
                    TimeFail += result2[2];
                }
            }
            if (season.Count() > 0)
            {
                double[] result = new double[3];
                //result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun += result[0];
                TimeStop += result[1];
                TimeFail += result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail += tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            i[0] = Math.Truncate(TimeRun / 3600.0 * 100.0) / 100.0;
            i[1] = Math.Truncate(TimeStop / 3600.0 * 100.0) / 100.0;
            i[2] = Math.Truncate(TimeFail / 3600.0 * 100.0) / 100.0;
            i[3] = Math.Truncate((tpanm.Value.TotalHours - i[0] - i[1] - i[2]) * 100.0) / 100.0;
            await Task.Delay(0);
            return i;
        }
        public async Task<double[]> TimeCalculation_CNC4(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC4> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] i = new double[4] { 0.0, 0.0, 0.0, tpanm.Value.TotalHours };
            double TimeStop = 0.0;
            double TimeRun = 0.0;
            double TimeFail = 0.0;
            //var season = from p in total.AsEnumerable()
            //                                       where p.ThoiDiem >= t1 && p.ThoiDiem <= t2
            //                                       select p;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
            {
                return i;
            }
            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            //var LastUp = (from p in total.AsEnumerable()
            //                           where p.ThoiDiem < t1
            //                           select p).ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();
            if (LastUp != null)
            {
                double[] result1 = new double[3];
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun += result1[0];
                TimeStop += result1[1];
                TimeFail += result1[2];
                if (first != null)
                {
                    double[] result2 = new double[3];
                    //result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, (from p in total.AsEnumerable()
                    //                                                                        where p.ThoiDiem < t1
                    //                                                                        select p).Count(), first.ThoiDiem, t1);
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun += result2[0];
                    TimeStop += result2[1];
                    TimeFail += result2[2];
                }
            }
            if (season.Count() > 0)
            {
                double[] result = new double[3];
                //result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun += result[0];
                TimeStop += result[1];
                TimeFail += result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail += tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            i[0] = Math.Truncate(TimeRun / 3600.0 * 100.0) / 100.0;
            i[1] = Math.Truncate(TimeStop / 3600.0 * 100.0) / 100.0;
            i[2] = Math.Truncate(TimeFail / 3600.0 * 100.0) / 100.0;
            i[3] = Math.Truncate((tpanm.Value.TotalHours - i[0] - i[1] - i[2]) * 100.0) / 100.0;
            await Task.Delay(0);
            return i;
        }
        public async Task<double[]> TimeCalculation_CNC5(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC5> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] i = new double[4] { 0.0, 0.0, 0.0, tpanm.Value.TotalHours };
            double TimeStop = 0.0;
            double TimeRun = 0.0;
            double TimeFail = 0.0;
            //var season = from p in total.AsEnumerable()
            //                                       where p.ThoiDiem >= t1 && p.ThoiDiem <= t2
            //                                       select p;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
            {
                return i;
            }
            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            //var LastUp = (from p in total.AsEnumerable()
            //                           where p.ThoiDiem < t1
            //                           select p).ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();
            if (LastUp != null)
            {
                double[] result1 = new double[3];
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun += result1[0];
                TimeStop += result1[1];
                TimeFail += result1[2];
                if (first != null)
                {
                    double[] result2 = new double[3];
                    //result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, (from p in total.AsEnumerable()
                    //                                                                        where p.ThoiDiem < t1
                    //                                                                        select p).Count(), first.ThoiDiem, t1);
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun += result2[0];
                    TimeStop += result2[1];
                    TimeFail += result2[2];
                }
            }
            if (season.Count() > 0)
            {
                double[] result = new double[3];
                //result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun += result[0];
                TimeStop += result[1];
                TimeFail += result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail += tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            i[0] = Math.Truncate(TimeRun / 3600.0 * 100.0) / 100.0;
            i[1] = Math.Truncate(TimeStop / 3600.0 * 100.0) / 100.0;
            i[2] = Math.Truncate(TimeFail / 3600.0 * 100.0) / 100.0;
            i[3] = Math.Truncate((tpanm.Value.TotalHours - i[0] - i[1] - i[2]) * 100.0) / 100.0;
            await Task.Delay(0);
            return i;
        }
        public async Task<double[]> TimeCalculation_CNC6(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC6> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] i = new double[4] { 0.0, 0.0, 0.0, tpanm.Value.TotalHours };
            double TimeStop = 0.0;
            double TimeRun = 0.0;
            double TimeFail = 0.0;
            //var season = from p in total.AsEnumerable()
            //                                       where p.ThoiDiem >= t1 && p.ThoiDiem <= t2
            //                                       select p;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
            {
                return i;
            }
            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            //var LastUp = (from p in total.AsEnumerable()
            //                           where p.ThoiDiem < t1
            //                           select p).ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();
            if (LastUp != null)
            {
                double[] result1 = new double[3];
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun += result1[0];
                TimeStop += result1[1];
                TimeFail += result1[2];
                if (first != null)
                {
                    double[] result2 = new double[3];
                    //result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, (from p in total.AsEnumerable()
                    //                                                                        where p.ThoiDiem < t1
                    //                                                                        select p).Count(), first.ThoiDiem, t1);
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun += result2[0];
                    TimeStop += result2[1];
                    TimeFail += result2[2];
                }
            }
            if (season.Count() > 0)
            {
                double[] result = new double[3];
                //result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun += result[0];
                TimeStop += result[1];
                TimeFail += result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail += tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            i[0] = Math.Truncate(TimeRun / 3600.0 * 100.0) / 100.0;
            i[1] = Math.Truncate(TimeStop / 3600.0 * 100.0) / 100.0;
            i[2] = Math.Truncate(TimeFail / 3600.0 * 100.0) / 100.0;
            i[3] = Math.Truncate((tpanm.Value.TotalHours - i[0] - i[1] - i[2]) * 100.0) / 100.0;
            await Task.Delay(0);
            return i;
        }
        public async Task<double[]> TimeCalculation_CNC7(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC7> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] i = new double[4] { 0.0, 0.0, 0.0, tpanm.Value.TotalHours };
            double TimeStop = 0.0;
            double TimeRun = 0.0;
            double TimeFail = 0.0;
            //var season = from p in total.AsEnumerable()
            //                                       where p.ThoiDiem >= t1 && p.ThoiDiem <= t2
            //                                       select p;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
            {
                return i;
            }
            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            //var LastUp = (from p in total.AsEnumerable()
            //                           where p.ThoiDiem < t1
            //                           select p).ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();
            if (LastUp != null)
            {
                double[] result1 = new double[3];
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun += result1[0];
                TimeStop += result1[1];
                TimeFail += result1[2];
                if (first != null)
                {
                    double[] result2 = new double[3];
                    //result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, (from p in total.AsEnumerable()
                    //                                                                        where p.ThoiDiem < t1
                    //                                                                        select p).Count(), first.ThoiDiem, t1);
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun += result2[0];
                    TimeStop += result2[1];
                    TimeFail += result2[2];
                }
            }
            if (season.Count() > 0)
            {
                double[] result = new double[3];
                //result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun += result[0];
                TimeStop += result[1];
                TimeFail += result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail += tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            i[0] = Math.Truncate(TimeRun / 3600.0 * 100.0) / 100.0;
            i[1] = Math.Truncate(TimeStop / 3600.0 * 100.0) / 100.0;
            i[2] = Math.Truncate(TimeFail / 3600.0 * 100.0) / 100.0;
            i[3] = Math.Truncate((tpanm.Value.TotalHours - i[0] - i[1] - i[2]) * 100.0) / 100.0;
            await Task.Delay(0);
            return i;
        }
        public async Task<double[]> TimeCalculation_CNC8(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC8> total)
        {
            TimeSpan? tpanm = t2 - t1;
            double[] i = new double[4] { 0.0, 0.0, 0.0, tpanm.Value.TotalHours };
            double TimeStop = 0.0;
            double TimeRun = 0.0;
            double TimeFail = 0.0;
            //var season = from p in total.AsEnumerable()
            //                                       where p.ThoiDiem >= t1 && p.ThoiDiem <= t2
            //                                       select p;
            var season = total.AsEnumerable().Where(p => p.ThoiDiem >= t1 && p.ThoiDiem <= t2);
            if (total.Count() == 0)
            {
                return i;
            }
            var first = season.FirstOrDefault();
            var last = season.ToArray().LastOrDefault();
            var firsttotal = total.ToArray().FirstOrDefault();
            var lasttotal = total.ToArray().LastOrDefault();
            //var LastUp = (from p in total.AsEnumerable()
            //                           where p.ThoiDiem < t1
            //                           select p).ToArray().LastOrDefault();
            var LastUp = total.AsEnumerable().Where(p => p.ThoiDiem < t1).ToArray().LastOrDefault();
            if (LastUp != null)
            {
                double[] result1 = new double[3];
                result1 = TimeFirstToLastCalculate(season.Count(), total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
                TimeRun += result1[0];
                TimeStop += result1[1];
                TimeFail += result1[2];
                if (first != null)
                {
                    double[] result2 = new double[3];
                    //result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, (from p in total.AsEnumerable()
                    //                                                                        where p.ThoiDiem < t1
                    //                                                                        select p).Count(), first.ThoiDiem, t1);
                    result2 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, total.AsEnumerable().Where(p => p.ThoiDiem < t1).Count(), first.ThoiDiem, t1);
                    TimeRun += result2[0];
                    TimeStop += result2[1];
                    TimeFail += result2[2];
                }
            }
            if (season.Count() > 0)
            {
                double[] result = new double[3];
                //result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
                TimeRun += result[0];
                TimeStop += result[1];
                TimeFail += result[2];
                foreach (var item0 in season)
                {
                    foreach (var item1 in season)
                    {
                        if (item0.Id == item1.Id + 1)
                        {
                            TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
                            if (item1.IdHienTrangMayCNC == 1)
                            {
                                TimeRun += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 2)
                            {
                                TimeStop += tpan.Value.TotalSeconds;
                            }
                            if (item1.IdHienTrangMayCNC == 3)
                            {
                                TimeFail += tpan.Value.TotalSeconds;
                            }
                        }
                    }
                }
            }
            i[0] = Math.Truncate(TimeRun / 3600.0 * 100.0) / 100.0;
            i[1] = Math.Truncate(TimeStop / 3600.0 * 100.0) / 100.0;
            i[2] = Math.Truncate(TimeFail / 3600.0 * 100.0) / 100.0;
            i[3] = Math.Truncate((tpanm.Value.TotalHours - i[0] - i[1] - i[2]) * 100.0) / 100.0;
            await Task.Delay(0);
            return i;
        }




        //public async Task<double[]> TimeCalculation_CNC8(DateTime t1, DateTime t2, IEnumerable<EventManagerCNC8> total)
        //{
        //    TimeSpan? tpanm = t2 - t1;
        //    double[] i = new double[4]
        //    {
        //    0.0,
        //    0.0,
        //    0.0,
        //    tpanm.Value.TotalHours
        //    };
        //    double TimeStop = 0.0;
        //    double TimeRun = 0.0;
        //    double TimeFail = 0.0;
        //    IEnumerable<EventManagerCNC8> season = from p in total.AsEnumerable()
        //                                           where p.ThoiDiem >= t1 && p.ThoiDiem <= t2
        //                                           select p;
        //    if (total.Count() == 0)
        //    {
        //        return i;
        //    }
        //    EventManagerCNC8 first = season.FirstOrDefault();
        //    EventManagerCNC8 last = season.ToArray().LastOrDefault();
        //    total.ToArray().FirstOrDefault();
        //    EventManagerCNC8 lasttotal = total.ToArray().LastOrDefault();
        //    EventManagerCNC8 LastUp = (from p in total.AsEnumerable()
        //                               where p.ThoiDiem < t1
        //                               select p).ToArray().LastOrDefault();
        //    if (LastUp != null)
        //    {
        //        _ = new double[3];
        //        double[] result2 = TimeFirstToLastCalculate(season.Count(), (from p in total.AsEnumerable()
        //                                                                     where p.ThoiDiem < t1
        //                                                                     select p).Count(), LastUp.IdHienTrangMayCNC, t1, t2);
        //        TimeRun += result2[0];
        //        TimeStop += result2[1];
        //        TimeFail += result2[2];
        //        if (first != null)
        //        {
        //            _ = new double[3];
        //            double[] result3 = TimeStartToFirstCalculate(LastUp.IdHienTrangMayCNC, (from p in total.AsEnumerable()
        //                                                                                    where p.ThoiDiem < t1
        //                                                                                    select p).Count(), first.ThoiDiem, t1);
        //            TimeRun += result3[0];
        //            TimeStop += result3[1];
        //            TimeFail += result3[2];
        //        }
        //    }
        //    if (season.Count() > 0)
        //    {
        //        _ = new double[3];
        //        double[] result = TimeLastToEndCalculate(lasttotal.Id, last.Id, last.IdHienTrangMayCNC, last.ThoiDiem, lasttotal.ThoiDiem, t1, t2);
        //        TimeRun += result[0];
        //        TimeStop += result[1];
        //        TimeFail += result[2];
        //        foreach (EventManagerCNC8 item0 in season)
        //        {
        //            foreach (EventManagerCNC8 item1 in season)
        //            {
        //                if (item0.Id == item1.Id + 1)
        //                {
        //                    TimeSpan? tpan = item0.ThoiDiem - item1.ThoiDiem;
        //                    if (item1.IdHienTrangMayCNC == 1)
        //                    {
        //                        TimeRun += tpan.Value.TotalSeconds;
        //                    }
        //                    if (item1.IdHienTrangMayCNC == 2)
        //                    {
        //                        TimeStop += tpan.Value.TotalSeconds;
        //                    }
        //                    if (item1.IdHienTrangMayCNC == 3)
        //                    {
        //                        TimeFail += tpan.Value.TotalSeconds;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    i[0] = Math.Truncate(TimeRun / 3600.0 * 100.0) / 100.0;
        //    i[1] = Math.Truncate(TimeStop / 3600.0 * 100.0) / 100.0;
        //    i[2] = Math.Truncate(TimeFail / 3600.0 * 100.0) / 100.0;
        //    i[3] = Math.Truncate((tpanm.Value.TotalHours - i[0] - i[1] - i[2]) * 100.0) / 100.0;
        //    await Task.Delay(0);
        //    return i;
        //}
        #endregion
    }
}

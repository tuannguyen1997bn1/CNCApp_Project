using CNC12.Model;
using CNC12.Views;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Ubiety.Dns.Core;
using System.Timers;
using static CNC12.Model.DataRequest1;
using static CNC12.ViewModels.StatusVM;


namespace CNC12.ViewModels
{
    public class VMmainWindow : BaseVM
    {
        #region Declare       

        public int Temp { get; set; }
        private string _UserName;
        public string UserName
        {
            get => _UserName;
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
        }
        private bool _user1;
        public bool user1
        {
            get => _user1;
            set
            {
                _user1 = value;
                OnPropertyChanged();
            }
        }
        private bool _user2;
        public bool user2
        {
            get => _user2;
            set
            {
                _user2 = value;
                OnPropertyChanged();
            }
        }
        private bool _user3;
        public bool user3
        {
            get => _user3;
            set
            {
                _user3 = value;
                OnPropertyChanged();
            }
        }
        private bool _user4;
        public bool user4
        {
            get => _user4;
            set
            {
                _user4 = value;
                OnPropertyChanged();
            }
        }

        private bool _boolSetting;
        public bool boolSetting
        {
            get => _boolSetting;
            set
            {
                _boolSetting = value;
                OnPropertyChanged();
            }
        }

        #region Status Machine
        private string _statusMachine1;
        public string StatusMachine1
        {
            get { return _statusMachine1; }
            set
            {
                _statusMachine1 = value;
                OnPropertyChanged("StatusMachine1");
            }
        }
        private string _statusMachine2;
        public string StatusMachine2
        {
            get { return _statusMachine2; }
            set
            {
                _statusMachine2 = value;
                OnPropertyChanged("StatusMachine2");
            }
        }
        private string _statusMachine3;
        public string StatusMachine3
        {
            get { return _statusMachine3; }
            set
            {
                _statusMachine3 = value;
                OnPropertyChanged("StatusMachine3");
            }
        }
        private string _statusMachine4;
        public string StatusMachine4
        {
            get { return _statusMachine4; }
            set
            {
                _statusMachine4 = value;
                OnPropertyChanged("StatusMachine4");
            }
        }
        private string _statusMachine5;
        public string StatusMachine5
        {
            get { return _statusMachine5; }
            set
            {
                _statusMachine5 = value;
                OnPropertyChanged("StatusMachine5");
            }
        }
        private string _statusMachine6;
        public string StatusMachine6
        {
            get { return _statusMachine6; }
            set
            {
                _statusMachine6 = value;
                OnPropertyChanged("StatusMachine6");
            }
        }
        private string _StatusMachine7;
        public string StatusMachine7
        {
            get { return _StatusMachine7; }
            set
            {
                _StatusMachine7 = value;
                OnPropertyChanged("StatusMachine7");
            }
        }
        private string _StatusMachine8;
        public string StatusMachine8
        {
            get { return _StatusMachine8; }
            set
            {
                _StatusMachine8 = value;
                OnPropertyChanged("StatusMachine8");
            }
        }
        #endregion

        #region Status Door
        private string _statusDoor1;
        public string StatusDoor1
        {
            get { return _statusDoor1; }
            set
            {
                _statusDoor1 = value;
                OnPropertyChanged("StatusDoor1");
            }
        }
        private string _statusDoor2;
        public string StatusDoor2
        {
            get { return _statusDoor2; }
            set
            {
                _statusDoor2 = value;
                OnPropertyChanged("StatusDoor2");
            }
        }
        private string _statusDoor3;
        public string StatusDoor3
        {
            get { return _statusDoor3; }
            set
            {
                _statusDoor3 = value;
                OnPropertyChanged("StatusDoor3");
            }
        }
        private string _statusDoor4;
        public string StatusDoor4
        {
            get { return _statusDoor4; }
            set
            {
                _statusDoor4 = value;
                OnPropertyChanged("StatusDoor4");
            }
        }
        private string _statusDoor5;
        public string StatusDoor5
        {
            get { return _statusDoor5; }
            set
            {
                _statusDoor5 = value;
                OnPropertyChanged("StatusDoor5");
            }
        }
        private string _statusDoor6;
        public string StatusDoor6
        {
            get { return _statusDoor6; }
            set
            {
                _statusDoor6 = value;
                OnPropertyChanged("StatusDoor6");
            }
        }
        private string _statusDoor7;
        public string StatusDoor7
        {
            get { return _statusDoor7; }
            set
            {
                _statusDoor7 = value;
                OnPropertyChanged("StatusDoor7");
            }
        }
        private string _statusDoor8;
        public string StatusDoor8
        {
            get { return _statusDoor8; }
            set
            {
                _statusDoor8 = value;
                OnPropertyChanged("StatusDoor8");
            }
        }

        #endregion

        #region Lights
        public enum Colorss
        {
            Red, Green, Yellow, Gray
        }
        private Colorss _Light1;
        public Colorss Light1
        {
            get { return _Light1; }
            set
            {
                _Light1 = value;
                OnPropertyChanged("Light1");
            }
        }
        private Colorss _Light2;
        public Colorss Light2
        {
            get { return _Light2; }
            set
            {
                _Light2 = value;
                OnPropertyChanged("Light2");
            }
        }
        private Colorss _Light3;
        public Colorss Light3
        {
            get { return _Light3; }
            set
            {
                _Light3 = value;
                OnPropertyChanged("Light3");
            }
        }
        private Colorss _Light4;
        public Colorss Light4
        {
            get { return _Light4; }
            set
            {
                _Light4 = value;
                OnPropertyChanged("Light4");
            }
        }
        private Colorss _Light5;
        public Colorss Light5
        {
            get { return _Light5; }
            set
            {
                _Light5 = value;
                OnPropertyChanged("Light5");
            }
        }
        private Colorss _Light6;
        public Colorss Light6
        {
            get { return _Light6; }
            set
            {
                _Light6 = value;
                OnPropertyChanged("Light6");
            }
        }
        private Colorss _Light7;
        public Colorss Light7
        {
            get { return _Light7; }
            set
            {
                _Light7 = value;
                OnPropertyChanged("Light7");
            }
        }
        private Colorss _Light8;
        public Colorss Light8
        {
            get { return _Light8; }
            set
            {
                _Light8 = value;
                OnPropertyChanged("Light8");
            }
        }
        #endregion

        #region WISE
        private string _Wise11;
        public string Wise11 { get => _Wise11; set { _Wise11 = value; OnPropertyChanged(); } }
        private string _Wise21;
        public string Wise21 { get => _Wise21; set { _Wise21 = value; OnPropertyChanged(); } }
        private string _Wise31;
        public string Wise31 { get => _Wise31; set { _Wise31 = value; OnPropertyChanged(); } }
        private string _Wise41;
        public string Wise41 { get => _Wise41; set { _Wise41 = value; OnPropertyChanged(); } }
        private string _Wise12;
        public string Wise12 { get => _Wise12; set { _Wise12 = value; OnPropertyChanged(); } }
        private string _Wise22;
        public string Wise22 { get => _Wise22; set { _Wise22 = value; OnPropertyChanged(); } }
        private string _Wise32;
        public string Wise32 { get => _Wise32; set { _Wise32 = value; OnPropertyChanged(); } }
        private string _Wise42;
        public string Wise42 { get => _Wise42; set { _Wise42 = value; OnPropertyChanged(); } }
        #endregion

        #endregion

        #region Command

        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand ClosedWindowCommand { get; set; }
        public ICommand ChartCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand ContactCommand { get; set; }
        public ICommand WarningCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand ChonMayCNC1Command { get; set; }
        public ICommand ChonMayCNC2Command { get; set; }
        public ICommand ChonMayCNC3Command { get; set; }
        public ICommand ChonMayCNC4Command { get; set; }
        #endregion
        // tao tao 1 thread nua ơ day, rồi để xem no mo cai window nào thì truyền vào window đó được ko nhỉ??
        //  còn về tốc độ thì vẫn chậm lắm
        readonly AdvantechHttpWebUtility m_httpRequest1;
        readonly AdvantechHttpWebUtility m_httpRequest2;
        readonly AdvantechHttpWebUtility m_httpRequest3;
        readonly AdvantechHttpWebUtility m_httpRequest4;
        readonly DispatcherTimer timer;
        public VMmainWindow()
        {
            user1 = false;
            user2 = false;
            user3 = false;
            user4 = false;
            Temp = 0;
            m_httpRequest1 = new AdvantechHttpWebUtility();
            m_httpRequest2 = new AdvantechHttpWebUtility();
            m_httpRequest3 = new AdvantechHttpWebUtility();
            m_httpRequest4 = new AdvantechHttpWebUtility();
            m_httpRequest1.ResquestResponded += this.OnGetRequestData1;
            m_httpRequest2.ResquestResponded += this.OnGetRequestData2;
            m_httpRequest3.ResquestResponded += this.OnGetRequestData3;
            m_httpRequest4.ResquestResponded += this.OnGetRequestData4;
            m_httpRequest1.ResquestOccurredError += this.OnGetErrorRequest1;
            m_httpRequest2.ResquestOccurredError += this.OnGetErrorRequest2;
            m_httpRequest3.ResquestOccurredError += this.OnGetErrorRequest3;
            m_httpRequest4.ResquestOccurredError += this.OnGetErrorRequest4;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            timer.Tick += Timer_Tick;
            timer.Start();

            #region command
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Wise11 = "Loading...";
                Wise12 = "Loading...";
                Wise21 = "Loading...";
                Wise22 = "Loading...";
                Wise31 = "Loading...";
                Wise32 = "Loading...";
                Wise41 = "Loading...";
                Wise42 = "Loading...";
                StatusMachine1 = StatusDoor1 = "Error load";
                StatusMachine2 = StatusDoor2 = "Error load";
                StatusMachine3 = StatusDoor3 = "Error load";
                StatusMachine4 = StatusDoor4 = "Error load";
                StatusMachine5 = StatusDoor5 = "Error load";
                StatusMachine6 = StatusDoor6 = "Error load";
                StatusMachine7 = StatusDoor7 = "Error load";
                StatusMachine8 = StatusDoor8 = "Error load";
                Light1 = Colorss.Gray;
                Light2 = Colorss.Gray;
                Light3 = Colorss.Gray;
                Light4 = Colorss.Gray;
                Light5 = Colorss.Gray;
                Light6 = Colorss.Gray;
                Light7 = Colorss.Gray;
                Light8 = Colorss.Gray;
                if (p == null)
                    return;
                p.Hide();
                using (CNCProjectEntities entities = new CNCProjectEntities())
                {
                    var db = entities.NhanViens;
                    ManagerWindow loginWindow = new ManagerWindow();
                    loginWindow.ShowDialog();
                    if (loginWindow.DataContext == null)
                        return;
                    var loginVM = loginWindow.DataContext as VMmanagerWindow;
                    if (loginVM.IsLogin)
                    {
                        p.Show();
                        Temp = 1;
                        OnlineStatus();
                        foreach (var item in db)
                        {
                            if (item.IdChucVu == 1 && item.FullName == loginWindow.username.Text)
                            {
                                boolSetting = true;
                                return;
                            }
                            else
                            {
                                boolSetting = false;
                            }
                        }
                    }
                    else
                    {
                        p.Close();
                        timer.Stop();
                        timer.IsEnabled = false;
                    }
                }
            });
            ClosedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Temp = 2;
                OnlineStatus();
                Thread.Sleep(500);
                timer.Stop();
                timer.IsEnabled = false;
                Application.Current.Shutdown();
            });
            ChartCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { ChartWindow wd = new ChartWindow(); wd.ShowDialog(); }); // tim hieu 1 luc ddi xong ty quy lai t laij xem
            ReportCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { ReportWindow wd = new ReportWindow(); wd.ShowDialog(); });
            ContactCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { ContactWindow wd = new ContactWindow(); wd.ShowDialog(); });
            WarningCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { WarningWindow wd = new WarningWindow(); wd.ShowDialog(); });
            SettingCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { SettingWindow wd = new SettingWindow(); wd.ShowDialog(); });
            ChonMayCNC1Command = new RelayCommand<RadioButton>((p) => { return true; }, (p) =>
            {
                Wise11 = "CNC 1";
                Wise12 = "CNC 2";
                Wise21 = "CNC 3";
                Wise22 = "CNC 4";
                Wise31 = "CNC 5";
                Wise32 = "CNC 6";
                Wise41 = "CNC 7";
                Wise42 = "CNC 8";
                StatusMachine1 = StatusDoor1 = "Error load";
                StatusMachine2 = StatusDoor2 = "Error load";
                StatusMachine3 = StatusDoor3 = "Error load";
                StatusMachine4 = StatusDoor4 = "Error load";
                StatusMachine5 = StatusDoor5 = "Error load";
                StatusMachine6 = StatusDoor6 = "Error load";
                StatusMachine7 = StatusDoor7 = "Error load";
                StatusMachine8 = StatusDoor8 = "Error load";
                Light1 = Colorss.Gray;
                Light2 = Colorss.Gray;
                Light3 = Colorss.Gray;
                Light4 = Colorss.Gray;
                Light5 = Colorss.Gray;
                Light6 = Colorss.Gray;
                Light7 = Colorss.Gray;
                Light8 = Colorss.Gray;
            });
            ChonMayCNC2Command = new RelayCommand<RadioButton>((p) => { return true; }, (p) =>
            {
                Wise11 = "CNC 9";
                Wise12 = "CNC 10";
                Wise21 = "CNC 11";
                Wise22 = "CNC 12";
                Wise31 = "CNC 13";
                Wise32 = "CNC 14";
                Wise41 = "CNC 15";
                Wise42 = "CNC 16";
                StatusMachine1 = StatusDoor1 = "Error load";
                StatusMachine2 = StatusDoor2 = "Error load";
                StatusMachine3 = StatusDoor3 = "Error load";
                StatusMachine4 = StatusDoor4 = "Error load";
                StatusMachine5 = StatusDoor5 = "Error load";
                StatusMachine6 = StatusDoor6 = "Error load";
                StatusMachine7 = StatusDoor7 = "Error load";
                StatusMachine8 = StatusDoor8 = "Error load";
                Light1 = Colorss.Gray;
                Light2 = Colorss.Gray;
                Light3 = Colorss.Gray;
                Light4 = Colorss.Gray;
                Light5 = Colorss.Gray;
                Light6 = Colorss.Gray;
                Light7 = Colorss.Gray;
                Light8 = Colorss.Gray;
            });
            ChonMayCNC3Command = new RelayCommand<RadioButton>((p) => { return true; }, (p) =>
            {
                Wise11 = "CNC 17";
                Wise12 = "CNC 18";
                Wise21 = "CNC 19";
                Wise22 = "CNC 20";
                Wise31 = "CNC 21";
                Wise32 = "CNC 22";
                Wise41 = "CNC 23";
                Wise42 = "CNC 24";
                StatusMachine1 = StatusDoor1 = "Error load";
                StatusMachine2 = StatusDoor2 = "Error load";
                StatusMachine3 = StatusDoor3 = "Error load";
                StatusMachine4 = StatusDoor4 = "Error load";
                StatusMachine5 = StatusDoor5 = "Error load";
                StatusMachine6 = StatusDoor6 = "Error load";
                StatusMachine7 = StatusDoor7 = "Error load";
                StatusMachine8 = StatusDoor8 = "Error load";
                Light1 = Colorss.Gray;
                Light2 = Colorss.Gray;
                Light3 = Colorss.Gray;
                Light4 = Colorss.Gray;
                Light5 = Colorss.Gray;
                Light6 = Colorss.Gray;
                Light7 = Colorss.Gray;
                Light8 = Colorss.Gray;
            });
            ChonMayCNC4Command = new RelayCommand<RadioButton>((p) => { return true; }, (p) =>
            {
                Wise11 = "CNC 25";
                Wise12 = "CNC 26";
                Wise21 = "CNC 27";
                Wise22 = "CNC 28";
                Wise31 = "CNC 29";
                Wise32 = "CNC 30";
                Wise41 = "CNC 31";
                Wise42 = "CNC 32";
                StatusMachine1 = StatusDoor1 = "Error load";
                StatusMachine2 = StatusDoor2 = "Error load";
                StatusMachine3 = StatusDoor3 = "Error load";
                StatusMachine4 = StatusDoor4 = "Error load";
                StatusMachine5 = StatusDoor5 = "Error load";
                StatusMachine6 = StatusDoor6 = "Error load";
                StatusMachine7 = StatusDoor7 = "Error load";
                StatusMachine8 = StatusDoor8 = "Error load";
                Light1 = Colorss.Gray;
                Light2 = Colorss.Gray;
                Light3 = Colorss.Gray;
                Light4 = Colorss.Gray;
                Light5 = Colorss.Gray;
                Light6 = Colorss.Gray;
                Light7 = Colorss.Gray;
                Light8 = Colorss.Gray;
            });
            #endregion

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                m_httpRequest1.SendGETRequest1(m_httpRequest1.BasicAuthAccount1, m_httpRequest1.BasicAuthPassword1, m_httpRequest1.URL1);
                m_httpRequest2.SendGETRequest2(m_httpRequest2.BasicAuthAccount2, m_httpRequest2.BasicAuthPassword2, m_httpRequest2.URL2);
                m_httpRequest3.SendGETRequest3(m_httpRequest3.BasicAuthAccount3, m_httpRequest3.BasicAuthPassword3, m_httpRequest3.URL3);
                m_httpRequest4.SendGETRequest4(m_httpRequest4.BasicAuthAccount4, m_httpRequest4.BasicAuthPassword4, m_httpRequest4.URL4);
            }
            catch (Exception err)
            {
                StatusMachine1 = StatusMachine2 = StatusDoor1 = StatusDoor2 = err.ToString();
                StatusMachine3 = StatusMachine4 = StatusDoor3 = StatusDoor4 = err.ToString();
                StatusMachine5 = StatusMachine6 = StatusDoor5 = StatusDoor6 = err.ToString();
                StatusMachine7 = StatusMachine8 = StatusDoor7 = StatusDoor8 = err.ToString();
            }
        }
        public void OnlineStatus()
        {
            ManagerWindow loginWindow = new ManagerWindow();
            using (CNCProjectEntities ent = new CNCProjectEntities())
            {
                var db1 = DataProvider.Ins.DB.NhanViens;
                var db = new OnlineStatu();
                if (loginWindow.username.Text != null)
                {
                    db.DisplayName = loginWindow.username.Text;
                    db.ThoiDiem = DateTime.Now;
                    DateTime ca1 = DateTime.ParseExact("00:00:00.000", "HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime ca2 = DateTime.ParseExact("08:00:00.000", "HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime ca3 = DateTime.ParseExact("16:00:00.000", "HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime ca4 = DateTime.ParseExact("23:59:59.999", "HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                    foreach (var item in db1)
                    {
                        if (item.IdChucVu == 1 && item.FullName == loginWindow.username.Text)
                        {
                            db.IdChucVu = 1;
                            db.IdCaLamViec = 0;
                        }
                        if (item.IdChucVu != 1 && item.FullName == loginWindow.username.Text)
                        {
                            db.IdChucVu = 2;

                            if (db.ThoiDiem.Value.TimeOfDay >= ca1.TimeOfDay && db.ThoiDiem.Value.TimeOfDay < ca2.TimeOfDay)
                            {
                                db.IdCaLamViec = 1;
                            }
                            if (db.ThoiDiem.Value.TimeOfDay >= ca2.TimeOfDay && db.ThoiDiem.Value.TimeOfDay < ca3.TimeOfDay)
                            {
                                db.IdCaLamViec = 2;
                            }
                            if (db.ThoiDiem.Value.TimeOfDay >= ca3.TimeOfDay && db.ThoiDiem.Value.TimeOfDay <= ca4.TimeOfDay)
                            {
                                db.IdCaLamViec = 3;
                            }
                        }
                    }
                    if (Temp == 1)
                    {
                        db.StatusOnl = 1;
                    }
                    if (Temp == 2)
                    {
                        db.StatusOnl = 0;
                    }
                    if (Temp == 0)
                        return;

                    var current = DataProvider.Ins.DB.OnlineStatus.ToArray().LastOrDefault();
                    if (current == null)
                        return;

                    if (current.DisplayName != db.DisplayName || current.IdCaLamViec != db.IdCaLamViec || current.IdChucVu != db.IdChucVu || current.StatusOnl != db.StatusOnl)
                    {
                        ent.OnlineStatus.Add(db);
                        ent.SaveChanges();
                    }

                    var onl0 = DataProvider.Ins.DB.OnlineStatus.AsEnumerable().Where(p => p.DisplayName == "admin").LastOrDefault();
                    var onl1 = DataProvider.Ins.DB.OnlineStatus.AsEnumerable().Where(p => p.DisplayName == "nhanvien1").LastOrDefault();
                    var onl2 = DataProvider.Ins.DB.OnlineStatus.AsEnumerable().Where(p => p.DisplayName == "nhanvien2").LastOrDefault();
                    var onl3 = DataProvider.Ins.DB.OnlineStatus.AsEnumerable().Where(p => p.DisplayName == "nhanvien3").LastOrDefault();

                    if (onl0 != null)
                    {
                        if (onl0.StatusOnl == 1)
                        {
                            user1 = true;
                        }
                        else
                        {
                            user1 = false;
                        }
                    }

                    if (onl1 != null)
                    {
                        if (onl1.StatusOnl == 1)
                        {
                            user2 = true;
                        }
                        else
                        {
                            user2 = false;
                        }
                    }

                    if (onl2 != null)
                    {
                        if (onl2.StatusOnl == 1)
                        {
                            user3 = true;
                        }
                        else
                        {
                            user3 = false;
                        }
                    }
                    if (onl3 != null)
                    {
                        if (onl3.StatusOnl == 1)
                        {
                            user4 = true;
                        }
                        else
                        {
                            user4 = false;
                        }
                    }
                }
            }
        }
        private void OnGetErrorRequest1(Exception e)
        {
            StatusMachine1 = "Error load";
            StatusDoor1 = "Error load";
            Light1 = Colorss.Gray;

            StatusMachine2 = "Error load";
            StatusDoor2 = "Error load";
            Light2 = Colorss.Gray;
        }
        private void OnGetErrorRequest2(Exception e)
        {
            StatusMachine3 = "Error load";
            StatusDoor3 = "Error load";
            Light3 = Colorss.Gray;

            StatusMachine4 = "Error load";
            StatusDoor4 = "Error load";
            Light4 = Colorss.Gray;
        }
        private void OnGetErrorRequest3(Exception e)
        {
            StatusMachine5 = "Error load";
            StatusDoor5 = "Error load";
            Light5 = Colorss.Gray;

            StatusMachine6 = "Error load";
            StatusDoor6 = "Error load";
            Light6 = Colorss.Gray;
        }
        private void OnGetErrorRequest4(Exception e)
        {
            StatusMachine7 = "Error load";
            StatusDoor7 = "Error load";
            Light7 = Colorss.Gray;

            StatusMachine8 = "Error load";
            StatusDoor8 = "Error load";
            Light8 = Colorss.Gray;
        }
        private void OnGetRequestData1(string Jsonstr1)
        {
            DeserialiseJson1(Jsonstr1);
        }
        private void OnGetRequestData2(string Jsonstr2)
        {
            DeserialiseJson2(Jsonstr2);
        }
        private void OnGetRequestData3(string Jsonstr3)
        {
            DeserialiseJson3(Jsonstr3);
        }
        private void OnGetRequestData4(string Jsonstr4)
        {
            DeserialiseJson4(Jsonstr4);
        }

        #region ResponseDes
        private void DeserialiseJson1(string Jsonstr)
        {
            try
            {
                var Jwise = JsonConvert.DeserializeObject<Wise1>(Jsonstr);
                StatusVM.CheckState(Jwise);
                if (Jsonstr == null)
                {
                    if (Wise11 == "CNC 1")
                    {
                        StatusMachine1 = StatusMachine2 = "Error load";
                        StatusDoor1 = StatusDoor2 = "Error load";
                        Light1 = Colorss.Gray;
                        Light2 = Colorss.Gray;
                    }
                    return;
                }
                else
                {
                    if (Wise11 == "CNC 1")
                    {
                        if (instance.machinestate == Machine3State.Running)
                        {
                            StatusMachine1 = "RUNNING";
                            Light1 = Colorss.Green;
                        }
                        else if (instance.machinestate == Machine3State.Stopping)
                        {
                            StatusMachine1 = "STOPPING";
                            Light1 = Colorss.Red;
                        }
                        else if (instance.machinestate == Machine3State.Falling)
                        {
                            StatusMachine1 = "FALLING";
                            Light1 = Colorss.Yellow;
                        }
                        else if (instance.machinestate == Machine3State.Waiting)
                        {
                            StatusMachine1 = "WAITING";
                            Light1 = Colorss.Gray;
                        }

                        if (instance.statedoor == MachineDoor2Status.Closing)
                        {
                            StatusDoor1 = "CLOSING";
                        }
                        else
                        {
                            StatusDoor1 = "OPENING";
                        }
                        if (instance1.machinestate == Machine3State.Running)
                        {
                            StatusMachine2 = "RUNNING";
                            Light2 = Colorss.Green;
                        }
                        else if (instance1.machinestate == Machine3State.Stopping)
                        {
                            StatusMachine2 = "STOPPING";
                            Light2 = Colorss.Red;
                        }
                        else if (instance1.machinestate == Machine3State.Falling)
                        {
                            StatusMachine2 = "FALLING";
                            Light2 = Colorss.Yellow;
                        }
                        else if (instance1.machinestate == Machine3State.Waiting)
                        {
                            StatusMachine2 = "WAITING";
                            Light2 = Colorss.Gray;
                        }
                        if (instance1.statedoor == MachineDoor2Status.Closing)
                        {
                            StatusDoor2 = "CLOSING";
                        }
                        else
                        {
                            StatusDoor2 = "OPENNING";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        private void DeserialiseJson2(string Jsonstr)
        {
            try
            {
                var Jwise = JsonConvert.DeserializeObject<Wise1>(Jsonstr);
                //StatusVM.CheckState(Jwise);

                if (Jsonstr == null)
                {
                    if (Wise11 == "CNC 1")
                    {
                        StatusMachine3 = StatusMachine4 = "Error load";
                        StatusDoor3 = StatusDoor4 = "Error load";
                        Light3 = Colorss.Gray;
                        Light4 = Colorss.Gray;
                    }
                    return;
                }
                else
                {
                    if (Wise11 == "CNC 1")
                    {
                        if (instance.machinestate == Machine3State.Running)
                        {
                            StatusMachine3 = "RUNNING";
                            Light3 = Colorss.Green;
                        }
                        else if (instance.machinestate == Machine3State.Stopping)
                        {
                            StatusMachine3 = "STOPPING";
                            Light3 = Colorss.Red;
                        }
                        else if (instance.machinestate == Machine3State.Falling)
                        {
                            StatusMachine3 = "FALLING";
                            Light3 = Colorss.Yellow;
                        }
                        else if (instance.machinestate == Machine3State.Waiting)
                        {
                            StatusMachine3 = "WAITING";
                            Light3 = Colorss.Gray;
                        }
                        if (instance.statedoor == MachineDoor2Status.Closing)
                        {
                            StatusDoor3 = "CLOSING";
                        }
                        else
                        {
                            StatusDoor3 = "OPENING";
                        }
                        if (instance1.machinestate == Machine3State.Running)
                        {
                            StatusMachine4 = "RUNNING";
                            Light4 = Colorss.Green;
                        }
                        else if (instance1.machinestate == Machine3State.Stopping)
                        {
                            StatusMachine4 = "STOPPING";
                            Light4 = Colorss.Red;
                        }
                        else if (instance1.machinestate == Machine3State.Falling)
                        {
                            StatusMachine4 = "FALLING";
                            Light4 = Colorss.Yellow;
                        }
                        else if (instance1.machinestate == Machine3State.Waiting)
                        {
                            StatusMachine4 = "WAITING";
                            Light4 = Colorss.Gray;
                        }
                        if (instance1.statedoor == MachineDoor2Status.Closing)
                        {
                            StatusDoor4 = "CLOSING";
                        }
                        else
                        {
                            StatusDoor4 = "OPENNING";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        private void DeserialiseJson3(string Jsonstr)
        {
            try
            {
                var Jwise = JsonConvert.DeserializeObject<Wise1>(Jsonstr);
                StatusVM.CheckState(Jwise);
                if (Jsonstr == null)
                {
                    if (Wise11 == "CNC 1")
                    {
                        StatusMachine5 = StatusMachine6 = "Error load";
                        StatusDoor5 = StatusDoor6 = "Error load";
                        Light5 = Colorss.Gray;
                        Light6 = Colorss.Gray;
                    }
                    return;
                }
                else
                {
                    if (Wise11 == "CNC 1")
                    {
                        if (instance.machinestate == Machine3State.Running)
                        {
                            StatusMachine5 = "RUNNING";
                            Light5 = Colorss.Green;
                        }
                        else if (instance.machinestate == Machine3State.Stopping)
                        {
                            StatusMachine5 = "STOPPING";
                            Light5 = Colorss.Red;
                        }
                        else if (instance.machinestate == Machine3State.Falling)
                        {
                            StatusMachine5 = "FALLING";
                            Light5 = Colorss.Yellow;
                        }
                        else if (instance.machinestate == Machine3State.Waiting)
                        {
                            StatusMachine5 = "WAITING";
                            Light5 = Colorss.Gray;
                        }
                        if (instance.statedoor == MachineDoor2Status.Closing)
                        {
                            StatusDoor5 = "CLOSING";
                        }
                        else
                        {
                            StatusDoor5 = "OPENING";
                        }
                        if (instance1.machinestate == Machine3State.Running)
                        {
                            StatusMachine6 = "RUNNING";
                            Light6 = Colorss.Green;
                        }
                        else if (instance1.machinestate == Machine3State.Stopping)
                        {
                            StatusMachine6 = "STOPPING";
                            Light6 = Colorss.Red;
                        }
                        else if (instance1.machinestate == Machine3State.Falling)
                        {
                            StatusMachine6 = "FALLING";
                            Light6 = Colorss.Yellow;
                        }
                        else if (instance1.machinestate == Machine3State.Waiting)
                        {
                            StatusMachine6 = "WAITING";
                            Light6 = Colorss.Gray;
                        }
                        if (instance1.statedoor == MachineDoor2Status.Closing)
                        {
                            StatusDoor6 = "CLOSING";
                        }
                        else
                        {
                            StatusDoor6 = "OPENNING";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        private void DeserialiseJson4(string Jsonstr)
        {
            try
            {
                var Jwise = JsonConvert.DeserializeObject<Wise1>(Jsonstr);
                StatusVM.CheckState(Jwise);
                if (Jsonstr == null)
                {
                    if (Wise11 == "CNC 1")
                    {
                        StatusMachine7 = StatusMachine8 = "Error load";
                        StatusDoor7 = StatusDoor8 = "Error load";
                        Light7 = Colorss.Gray;
                        Light8 = Colorss.Gray;
                    }
                    return;
                }
                else
                {
                    if (Wise11 == "CNC 1")
                    {
                        if (instance.machinestate == Machine3State.Running)
                        {
                            StatusMachine7 = "RUNNING";
                            Light7 = Colorss.Green;
                        }
                        else if (instance.machinestate == Machine3State.Stopping)
                        {
                            StatusMachine7 = "STOPPING";
                            Light7 = Colorss.Red;
                        }
                        else if (instance.machinestate == Machine3State.Falling)
                        {
                            StatusMachine7 = "FALLING";
                            Light7 = Colorss.Yellow;
                        }
                        else if (instance.machinestate == Machine3State.Waiting)
                        {
                            StatusMachine7= "WAITING";
                            Light7 = Colorss.Gray;
                        }
                        if (instance.statedoor == MachineDoor2Status.Closing)
                        {
                            StatusDoor7 = "CLOSING";
                        }
                        else
                        {
                            StatusDoor7 = "OPENING";
                        }
                        if (instance1.machinestate == Machine3State.Running)
                        {
                            StatusMachine8 = "RUNNING";
                            Light8 = Colorss.Green;
                        }
                        else if (instance1.machinestate == Machine3State.Stopping)
                        {
                            StatusMachine8 = "STOPPING";
                            Light8 = Colorss.Red;
                        }
                        else if (instance1.machinestate == Machine3State.Falling)
                        {
                            StatusMachine8 = "FALLING";
                            Light8 = Colorss.Yellow;
                        }
                        else if (instance1.machinestate == Machine3State.Waiting)
                        {
                            StatusMachine8 = "WAITING";
                            Light8 = Colorss.Gray;
                        }
                        if (instance1.statedoor == MachineDoor2Status.Closing)
                        {
                            StatusDoor8 = "CLOSING";
                        }
                        else
                        {
                            StatusDoor8 = "OPENNING";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

    }
}

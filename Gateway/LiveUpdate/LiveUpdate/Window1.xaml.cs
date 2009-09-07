using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Visifire.Charts;
using Visifire.Commons;
using System.Data;
using System.IO.Ports;

namespace LiveUpdate
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string datad = "";
        int rate = 120;
        SerialPort _serialPort;
        public Window1()
        {
            InitializeComponent();
            // Create a Visifire Chart
            CreateChart();
        //    StartSeiral();
        }

        public void StartSeiral()
        {
            _serialPort = new SerialPort("COM7", 9600, Parity.None, 8, StopBits.One);
            _serialPort.Handshake = Handshake.None;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.Open();
            timer.Start();
        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(rate);
            datad += _serialPort.ReadExisting();
        }
        /// <summary>
        /// Function to create a chart
        /// </summary>
        public void CreateChart()
        {
            try
            {

                // Create a new instance of Chart
                chart = new Chart();

                chart.Watermark = false;
                chart.ScrollingEnabled = false;
                // Create a new instance of DataSeries
                DataSeries dataSeries = new DataSeries();

                Axis axis = new Axis();
                axis.AxisMaximum = 160;
                axis.AxisMinimum = 120;
                chart.AxesY.Add(axis);

                Axis axisX = new Axis();
                axisX.Interval = 10;
                axis.ScrollBarOffset = 1;
                chart.AxesY.Add(axis);

                // Set DataSeries property
                dataSeries.RenderAs = RenderAs.Line;
                dataSeries.LineStyle = LineStyles.Solid;
                dataSeries.LineThickness = 3;
                dataSeries.LabelEnabled = false;
                // Add dataSeries to Series collection.
                chart.Series.Add(dataSeries);

                // Attach a Loaded event to chart in order to attach a timer's Tick event
                chart.Loaded += new RoutedEventHandler(chart_Loaded);

                // Add chart to Chart Grid
                ChartGrid.Children.Add(chart);

                string[] a = { "145", "150", "154", "156", "2:153", "148", "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130", "2:129", "2:128", "2:127", "191:128", "128", "129", "130", "4:129", "2:128", "127", "127", "6:128", "130", "132", "135", "140", "145", "150", "154", "156", "2:153", "148", "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130", "2:129", "2:128", "2:127", "191:128", "128", "129", "130", "4:129", "2:128", "127", "127", "6:128", "130", "132", "135", "140", "145", "150", "154", "156", "2:153", "148", "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130" };//, "2:129", "2:128", "2:127", "191:128", "128", "129", "130", "4:129", "2:128", "127", "127", "6:128", "130", "132", "135", "140", "145", "150", "154", "156", "2:153", "148", "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130", "2:129", "2:128", "2:127", "191:128", "128", "129", "130", "4:129", "2:128", "127", "127", "6:128", "130", "132", "135", "140", "145", "150", "154", "156", "2:153", "148", "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130", "2:129", "2:128", "2:127", "191:128", "128", "129", "130", "4:129", "2:128", "127", "127", "6:128", "130", "132", "135", "140", "145", "150", "154", "156", "2:153", "148" };//, "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130", "2:129", "2:128", "2:127", "191:128", "128", "129", "130", "4:129", "2:128", "127", "127", "6:128", "130", "132", "135", "140", "145", "150", "154", "156", "2:153", "148", "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130", "2:129", "2:128", "2:127", "191:128", "128", "129", "130", "4:129", "2:128", "127", "127", "6:128", "130", "132", "135", "140", "145", "150", "154", "156", "2:153", "148", "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130", "2:129", "2:128", "2:127", "191:128", "128", "129", "130", "4:129", "2:128", "127", "127", "6:128", "130", "132", "135", "140", "145", "150", "154", "156", "2:153", "148", "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130", "2:129", "2:128", "2:127", "191:128", "128", "129", "130", "4:129", "2:128", "127", "127", "6:128", "130", "132", "135", "140", "145", "150", "154", "156", "2:153", "148", "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130", "2:129", "2:128", "2:127", "191:128", "128", "129", "130", "4:129", "2:128", "127", "127", "6:128", "130", "132", "135", "140", "145", "150", "154", "156", "2:153", "148", "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130", "2:129", "2:128", "2:127", "191:128", "128", "129", "130", "4:129", "2:128", "127", "127", "6:128", "130", "132", "135", "140", "145", "150", "154", "156", "2:153", "148", "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130", "2:129", "2:128", "2:127", "191:128", "128", "129", "130", "4:129", "2:128", "127", "127", "6:128", "130", "132", "135", "140", "145", "150", "154", "156", "2:153", "148", "142", "136", "131", "128", "127", "126", "2:126", "127", "4:127", "2:128", "2:129", "130", "131", "132", "3:132", "2:131", "2:130", "2:129", "2:128", "2:127" };
                foreach (var item in a)
                {
                    int count = 1;
                    string val = item;

                    if (item.Contains(":"))
                    {
                        val = item.Substring(item.IndexOf(":") + 1);
                        count = int.Parse(item.Substring(0, item.IndexOf(":")));
                    }
                    for (int i = 0; i < count; i++)
                    {
                        DataPoint dataPoint = new DataPoint();
                        dataPoint.YValue = int.Parse(val);
                        chart.Series[0].DataPoints.Add(dataPoint);
                    }

                }
            }
            catch (Exception ex)
            {
            }

        }

        /// <summary>
        /// Event handler for loaded event of chart
        /// </summary>
        /// <param name="sender">Chart</param>
        /// <param name="e">RoutedEventArgs</param>
        void chart_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, rate);
        }

        /// <summary>
        /// Event handler for Tick event of Timer
        /// </summary>
        /// <param name="sender"> System.Windows.Threading.DispatcherTimer</param>
        /// <param name="e">EventArgs</param>
        int pointCount = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            if (pointCount > 300)
            {
                chart.Series[0].DataPoints.Clear();

                pointCount = 0;
            }

            string datas = datad;
            datad = "";
            int first = datas.IndexOf(",") + 1;
            int last = datas.LastIndexOf(",");
            if (datas.IndexOf(",") != datas.LastIndexOf(","))
            {
                string data = datas.Substring(first, last - first);

                if (data.Contains(','))
                    foreach (var item in data.Split(','))
                    {
                        try
                        {
                            string count = "1";
                            string val = item;

                            if (item.Contains(":"))
                            {
                                val = item.Substring(item.IndexOf(":") + 1);
                                count = item.Substring(0, item.IndexOf(":"));
                            }

                            if (marker == 'e' || marker == count[0])
                            {
                                if (marker == count[0])
                                    count = "1";
                                for (int i = 0; i < int.Parse(count); i++)
                                {
                                    DataPoint dataPoint = new DataPoint();
                                    dataPoint.YValue = int.Parse(val);

                                    pointCount++;

                                    chart.Series[0].DataPoints.Add(dataPoint);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            //throw ex;
                        }
                    }
            }
        }

        char marker;

        private bool isInt(string s)
        {
            try
            {
                int i = int.Parse(s);
                if (i > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
            }

            return false;

        }

        /// <summary>
        /// Event handler for Click event of UpdateButton
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">RoutedEventArgs</param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Event handler for Click event of UpdateStopButton
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">RoutedEventArgs</param>
        private void UpdateStopButton_Click(object sender, RoutedEventArgs e)
        {
        }

        Chart chart;                                            // Chart object
        Random rand = new Random(DateTime.Now.Millisecond);     // Create a random class variable
        System.Windows.Threading.DispatcherTimer timer = new    // Create a new instance of timer object
            System.Windows.Threading.DispatcherTimer();

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chart.Series[0].DataPoints.Clear();

            switch (listview1.SelectedIndex + 1)
            {
                case  1:
                    marker = 'e';
                    break;
                case 2:
                    marker = 't';
                    break;
                case 3:
                    marker = 'h';
                    break;
                case 4:
                    marker = 'd';
                    break;
                case 5:
                    marker = 'b';
                    break;
                case 6:
                    marker = 'p';
                    break;
                case 7:
                    marker = 'l';
                    break;
                default:
                    break;
            }


            switch (listview1.SelectedIndex + 1)
            {
                case 1:
                    chart.AxesY[0].AxisMinimum = 120;
                    chart.AxesY[0].AxisMaximum = 160;
                    break;
                case 3:
                case 2:
                    chart.AxesY[0].AxisMinimum = 0;
                    chart.AxesY[0].AxisMaximum = 100;
                    break;
                case 7:
                case 6:
                case 4:
                    chart.AxesY[0].AxisMinimum = 0;
                    chart.AxesY[0].AxisMaximum = 1024;
                    break;
                case 5:
                    chart.AxesY[0].AxisMinimum = 0;
                    chart.AxesY[0].AxisMaximum = 2;
                    break;
                default:
                    break;
            }
        }
    }
}

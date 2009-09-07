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

namespace LiveUpdate
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            // Create a Visifire Chart
            CreateChart();
        }

        public void CreateTable() 
        {
          

        }
        /// <summary>
        /// Function to create a chart
        /// </summary>
        public void CreateChart()
        {
            // Create a new instance of Chart
            chart = new Chart();

            chart.Watermark = false;

            // Create a new instance of DataSeries
            DataSeries dataSeries = new DataSeries();
 
            // Set DataSeries property
            dataSeries.RenderAs = RenderAs.Line;
            dataSeries.LineStyle = LineStyles.Solid;
            dataSeries.LineThickness = 3;
            dataSeries.LabelEnabled = false;

            // Create a DataPoint
            DataPoint dataPoint;

            for (int i = 0; i < 10; i++)
            {
                // Create a new instance of DataPoint
                dataPoint = new DataPoint(); 

                // Set YValue for a DataPoint
                dataPoint.YValue = rand.Next(-100, 100); 
                
                // Add dataPoint to DataPoints collection
                dataSeries.DataPoints.Add(dataPoint); 
            }

            // Add dataSeries to Series collection.
            chart.Series.Add(dataSeries);

            // Attach a Loaded event to chart in order to attach a timer's Tick event
            chart.Loaded += new RoutedEventHandler(chart_Loaded);

            // Add chart to Chart Grid
            ChartGrid.Children.Add(chart);
        }

        /// <summary>
        /// Event handler for loaded event of chart
        /// </summary>
        /// <param name="sender">Chart</param>
        /// <param name="e">RoutedEventArgs</param>
        void chart_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
        }

        /// <summary>
        /// Event handler for Tick event of Timer
        /// </summary>
        /// <param name="sender"> System.Windows.Threading.DispatcherTimer</param>
        /// <param name="e">EventArgs</param>
        void timer_Tick(object sender, EventArgs e)
        {
            for (Int32 i = 0; i < 5; i++)
            {
                // Create a new instance of DataPoint
                DataPoint dataPoint = new DataPoint();

                // Set YValue for a DataPoint
                dataPoint.YValue = rand.Next(-100, 100);

                // Add dataPoint to DataPoints collection
                chart.Series[0].DataPoints.Add(dataPoint);
            }
        }

        /// <summary>
        /// Event handler for Click event of UpdateButton
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">RoutedEventArgs</param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // timer starts
            timer.Start(); 
        }

        /// <summary>
        /// Event handler for Click event of UpdateStopButton
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">RoutedEventArgs</param>
        private void UpdateStopButton_Click(object sender, RoutedEventArgs e)
        {
            // timer stops
            timer.Stop(); 
        }

        Chart chart;                                            // Chart object
        Random rand = new Random(DateTime.Now.Millisecond);     // Create a random class variable
        System.Windows.Threading.DispatcherTimer timer = new    // Create a new instance of timer object
            System.Windows.Threading.DispatcherTimer();
    }
}

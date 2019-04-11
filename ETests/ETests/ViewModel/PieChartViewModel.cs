using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ETests.ViewModel
{
    class PieChartViewModel : INotifyPropertyChanged
    {

        private PlotModel pieModel { get; set; }
        public int Right;
        public int Wrong;
        private string testname;
        int numberofcount;
        public PlotModel PieModel
        {
            get
            {
                return pieModel;
            }
            set
            {
                pieModel = value;
            }
        }
        

        public PieChartViewModel( string testname, int numberofcount,int Wrong,int Right)
        {
            this.testname = testname;
            this.numberofcount = numberofcount;
            this.Wrong = Wrong;
            this.Right = Right;
            LoadPieChart();
        }

        public void LoadPieChart()
        {
            PieModel = null;
            OnPropertyChanged("PieModel");
            var piemodel = new PlotModel { };
            var ps = new PieSeries
            {
                StrokeThickness = 0.25,
                AngleSpan = 360,
                StartAngle = 0,
                InsideLabelPosition = 0.5
                ,InsideLabelColor=OxyColor.Parse("#ffffff"),
                InnerDiameter=0.5,
                InsideLabelFormat = @"{0:#\%}"
                ,
                
                
                OutsideLabelFormat="{1}",
                TickHorizontalLength = 0,
                TickRadialLength = 1,TickLabelDistance=25.3,TickDistance=3
               
            };

            ps.Slices.Add(new PieSlice("InCorrect",Wrong) { IsExploded = true, Fill = OxyColor.Parse("#FF6600") });

            ps.Slices.Add(new PieSlice("Correct", Right) { IsExploded = true, Fill = OxyColor.Parse("#01579B") });

            //ps.Slices.Add(new PieSlice("Cat", 152) { IsExploded = false, Fill = OxyColor.Parse("#9b59b6") });

            //ps.Slices.Add(new PieSlice("Goldfish", 62) { IsExploded = false, Fill = OxyColor.Parse("#34495e") });

            //ps.Slices.Add(new PieSlice("Hamster", 68) { IsExploded = false, Fill = OxyColor.Parse("#e74c3c") });

            //ps.Slices.Add(new PieSlice("Birds", 101) { IsExploded = false, Fill = OxyColor.Parse("#f1c40f") });
            piemodel.Series.Add(ps);
            PieModel = piemodel;

            OnPropertyChanged("PieModel");
        }

        #region INotifyChangedProperties
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion INotifyChangedProperties
    }

}

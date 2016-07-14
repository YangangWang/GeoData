


using System;
using OGT.Production.Infrastructure.BusinessObject;

namespace testwinform
{
    [Serializable]
    public class WellSummary : IWellSummary
    {
        #region IWellSummary 成员

        public int WID { get; set; }

        public string Name { get; set; }

        public string Caption { get; set; }

        public WellCategory Category { get; set; }

        public string CategoryName { get; set; }

        public double CoordinateX { get; set; }

        public double CoordinateY { get; set; }

        //public float ProducingBottom { get; internal set; }
        //public float ProducingTop { get; internal set; }

        #endregion

        //internal bool Initialized { get; set; }

        public WellSummary()
        {
        }

        public WellSummary(int wid, string name, string caption, WellCategory category)
            : base()
        {
            WID = wid;
            Name = name;
            Caption = caption;
            Category = category;
        }

        public WellSummary(int wid, string name, string caption, WellCategory category, double coordinateX, double coordinateY)
            : base()
        {
            WID = wid;
            Name = name;
            Caption = caption;
            Category = category;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

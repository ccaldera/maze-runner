using System;

namespace ValantDemoApi.Application.ValueObjects
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Value { get; set; }
        public bool IsStart 
        {
            get
            {
                return Value.Equals("S", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public bool IsEnd
        {
            get
            {
                return Value.Equals("E", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public bool IsValidMovement
        {
            get
            {
                return Value.Equals("0", StringComparison.InvariantCultureIgnoreCase) || IsStart || IsEnd;
            }
        }

        public bool IsForbidden
        {
            get
            {
                return Value.Equals("X", StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}

using System;

namespace ValantDemoApi.Application.ValueObjects
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
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
                return Value.Equals("O", StringComparison.InvariantCultureIgnoreCase) || IsStart || IsEnd;
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

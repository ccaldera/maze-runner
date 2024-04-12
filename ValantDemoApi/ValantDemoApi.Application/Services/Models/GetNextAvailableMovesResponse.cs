using System.Collections.Generic;

namespace ValantDemoApi.Models
{
    public class GetNextAvailableMovesResponse
    {
        public bool GameEnded { get; set; }
        public List<string> Moves { get; set; } = new List<string>();
    }
}

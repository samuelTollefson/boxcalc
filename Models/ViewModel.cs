using System.ComponentModel;

namespace boxcalcui2.Models
{
    public class ViewModel
    {
        public string? Text { get; set; }
        public int CurrentRoute { get; set; }
        public int TotalRoutes { get; set; }
        public int Boxes { get; set; }
        public int Bags { get; set; }
        public string? Message { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBA.Models.BuyBuddie
{
    public class Search
    {
        public int RiskScore { get; set; }
        public string AlertSummary { get; set; }
        public string SecondaryTerm { get; set; }
        public List<Issue> Issues { get; set; }
        public List<Alternative> Alternatives { get; set; }
        public List<Marketplace> MarketplaceItems { get; set; }
        public string ScoreGraphic { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Dtos
{
    public class Datum
    {
        public int updated_at { get; set; }
        public string image_url { get; set; }
        public string keyword { get; set; }
        public int points { get; set; }
    }

    public class TikiHotSearchDto
    {
        public List<Datum> data { get; set; }
        public int is_personalized { get; set; }
    }
}

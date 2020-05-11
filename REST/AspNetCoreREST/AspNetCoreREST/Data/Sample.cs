using System;
using System.Collections.Generic;

namespace AspNetCoreREST.Data
{
    public partial class Sample
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gateway.Models.RequestModels
{
    public class PackageRequestModel
    {
        public string Sender { get; set; }
        public string ReceiverId { get; set; }
        public string Name { get; set; }
        public string CollectionPointId { get; set; }
    }
}

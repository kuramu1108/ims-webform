﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSLogicLayer.Models
{
    public class District : IMSDBLayer.DataModels.District
    {
        public District(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
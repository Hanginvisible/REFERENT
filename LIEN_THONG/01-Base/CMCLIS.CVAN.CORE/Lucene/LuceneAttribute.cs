﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCLIS.CVAN.CORE.AILucene
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class LuceneAttribute : System.Attribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsStored { get; set; }
        public bool IsSearchable { get; set; }

        public LuceneAttribute() { }

    }
}
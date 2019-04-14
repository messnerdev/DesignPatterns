using System;

namespace ChainOfResponsibility.BrokerChain
{
    public class Query
    {
        public string CreatureName;
        public QueryArgument WhatToQuery;
        public int Value;

        public Query(string creatureName, QueryArgument whatToQuery, int value)
        {
            CreatureName = creatureName ?? throw new ArgumentNullException(nameof(creatureName));
            WhatToQuery = whatToQuery;
            Value = value;
        }
    }
}
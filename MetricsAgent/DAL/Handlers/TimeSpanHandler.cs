using System;
using System.Data;
using Dapper;

namespace MetricsAgent.DAL.Handlers
{
    public class TimeSpanHandler : SqlMapper.TypeHandler<TimeSpan>
    {
        public override TimeSpan Parse(object value) => TimeSpan.FromSeconds((long)value);

        public override void SetValue(IDbDataParameter parameter, TimeSpan value) => parameter.Value = value;

        //public TimeSpan ConvertTimeSpan(Int64 val) => new TimeSpan(val);
    }
}

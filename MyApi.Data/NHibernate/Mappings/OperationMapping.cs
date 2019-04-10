using FluentNHibernate.Mapping;
using MyApi.Data.Entities;

namespace MyApi.Data.NHibernate.Mappings
{
    public class OperationMapping : ClassMap<Operation>
    {
        public OperationMapping()
        {
            Id(o => o.Id);
            Map(o => o.Data);
        }
    }
}

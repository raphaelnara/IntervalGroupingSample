using System;
using System.Collections.Generic;
using MyApi.Data.Entities;
using MyApi.Data.Model;
using MyApi.Data.Repositories.Interfaces;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace MyApi.Data.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public OperationRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IEnumerable<CountByDate> GetTotalByDate(DateTime initialDate, DateTime endDate)
        {
            Operation operation = null;

            using (var session = _sessionFactory.OpenSession())
            {
                const int intervalInMinutes = 5;

                var groupProjection = Projections.GroupProperty(
                    Projections.SqlFunction("minute_interval",
                        NHibernateUtil.DateTime,
                        Projections.Property(() => operation.Date),
                        Projections.Constant(intervalInMinutes)));

                var query = session.QueryOver(() => operation)
                    .Select(groupProjection, Projections.Count(() => operation.Id))
                    .AndRestrictionOn(() => operation.Date).IsBetween(initialDate).And(endDate)
                    .TransformUsing(Transformers.AliasToBean<CountByDate>());

                return query.List<CountByDate>();
            }
        }
    }
}

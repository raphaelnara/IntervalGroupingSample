using NHibernate;
using NHibernate.Dialect;
using NHibernate.Dialect.Function;

namespace MyApi.Data.NHibernate.Config
{
    public class CustomMsSql2012Dialect : MsSql2012Dialect
    {
        public CustomMsSql2012Dialect()
        {
            RegisterFunction("minute_interval",
                             new SQLFunctionTemplate(NHibernateUtil.DateTime,
                                                     "DATEADD(MINUTE,(DATEDIFF(MINUTE, 0 , ?1)/?2)*?2,0)"));
        }
    }
}

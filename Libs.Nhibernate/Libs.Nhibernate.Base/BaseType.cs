using Libs.System.Extensions;
using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using System;
using System.Data;
using System.Data.Common;

namespace Libs.Nhibernate.Base
{
    public abstract class BaseType<T> : IUserType
    {
        public bool IsMutable
        {
            get
            {
                return false;
            }
        }

        public Type ReturnedType
        {
            get
            {
                return typeof(T);
            }
        }

        public SqlType[] SqlTypes
        {
            get
            {
                return new[] { NHibernateUtil.String.SqlType };
            }
        }

        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Disassemble(object value)
        {
            return value;
        }

        public new bool Equals(object x, object y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            return x.Equals(y);
        }

        public int GetHashCode(object x)
        {
            return x == null ? typeof(bool).GetHashCode() + 473 : x.GetHashCode();
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }
        public virtual object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            object obj = NHibernateUtil.String.NullSafeGet(rs, names[0], session);
            if (obj.IsNull())
                return null;
            return QueryValueToEntity(obj);
        }

        public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            IDataParameter parameter = cmd.Parameters[index];
            if (value == null)
                parameter.Value = DBNull.Value;
            
            parameter.Value = EntityToQueryValue((T)value);
            
        }
        public abstract object EntityToQueryValue(T value);
        public abstract object QueryValueToEntity(object value);
    }
}

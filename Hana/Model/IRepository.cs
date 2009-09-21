using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Hana.Model {
    public interface IRepository {

        IQueryable<T> All<T>() where T : class, new();
        T Single<T>(Expression<Func<T, bool>> expression) where T : class, new();
        IList<T> Find<T>(Expression<Func<T, bool>> expression) where T : class, new();

        void Add<T>(T item) where T : class, new();
        void Update<T>(T item) where T : class, new();
        void Delete<T>(T item) where T : class, new();
        void Delete<T>(Expression<Func<T, bool>> expression) where T : class, new();

        IList<T2> GetAssociated<T1, T2>(T1 item)
            where T1 : class, new()
            where T2 : class, new();

        void ManyToManyAssociate<T1, T2>(T1 item, T2 other, string joinTable)
            where T1 : class, new()
            where T2 : class, new();

        void ManyToManyAssociate<T1, T2>(T1 item, T2 other)
            where T1 : class, new()
            where T2 : class, new();

        void ManyToManyDisassociate<T1, T2>(T1 item, T2 other, string joinTable)
            where T1 : class, new()
            where T2 : class, new();

        void ManyToManyDisassociate<T1, T2>(T1 item, T2 other)
            where T1 : class, new()
            where T2 : class, new();

    }
}

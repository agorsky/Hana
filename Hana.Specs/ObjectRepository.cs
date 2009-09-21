using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o.Linq;
using SubSonic.Schema;
using Db4objects.Db4o;
using System.Linq.Expressions;
using Hana.Model;

namespace Hana.Specs {
    public class ObjectRepository : IRepository {
        DB4O db;
        public ObjectRepository() {

            db = new DB4O();
        }

        /// <summary>
        /// Returns a single instance of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T Single<T>(Expression<Func<T, bool>> expression) where T : class, new() {
            return All<T>().FirstOrDefault(expression);
        }

        /// <summary>
        /// Returns a List of T satisfying passed-in criteria"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IList<T> Find<T>(Expression<Func<T, bool>> expression) where T : class, new() {
            return All<T>().Where(expression).ToList();
        }

        /// <summary>
        /// Returns all T records in the repository
        /// </summary>
        public IQueryable<T> All<T>() where T : class, new() {
            IQueryable<T> result;
            //using (var container = db.Container)
            //{
            var list = from T items in db.Container
                       select items;
            result = list.AsQueryable();
            //}
            return result;
        }


        /// <summary>
        /// Saves an item to the database
        /// </summary>
        /// <param name="item"></param>
        public void Add<T>(T item) where T : class, new() {
            //using (var container = db.Container)
            //{
            db.Container.Store(item);
            //}
        }
        /// <summary>
        /// Saves an item to the database
        /// </summary>
        /// <param name="item"></param>
        public void Update<T>(T item) where T : class, new() {
            //using (var container = db.Container)
            //{
            db.Container.Store(item);
            //}
        }
        /// <summary>
        /// Deletes an item from the database
        /// </summary>
        /// <param name="item"></param>
        public void Delete<T>(T item) where T : class, new() {
            //using (var container = db.Container)
            //{
            db.Container.Delete(item);
            //}
        }
        /// <summary>
        /// Deletes an item from the database
        /// </summary>
        /// <param name="item"></param>
        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class, new() {
            //using (var container = db.Container)
            // {
            var list = from T items in db.Container
                       select items;
            var deleted = list.Where(expression);
            foreach (var item in deleted) {
                Delete(item);
            }
            //}

        }
        public void CommitChanges() {
            db.Container.Commit();

        }



        public void ManyToManyAssociate<T1, T2>(T1 item, T2 other)
            where T1 : class, new()
            where T2 : class, new() {

            //add T2 to T1 - the assumption is there's a collection there
            var props = typeof(T1).GetProperties();

            var prop = props.SingleOrDefault(x => x.PropertyType == typeof(IList<T2>));

            if (prop != null) {
                IList<T2> list = (IList<T2>)item.GetType().GetProperty(prop.Name).GetValue(item, null);
                if (!list.Contains(other)) {
                    list.Add(other);
                }

                item.GetType().GetProperty(prop.Name).SetValue(item, list, null);
            }
        }


        public void ManyToManyDisassociate<T1, T2>(T1 item, T2 other)
            where T1 : class, new()
            where T2 : class, new() {
            //remove T2 from T1 - the assumption is there's a collection there
            var props = typeof(T1).GetProperties();

            var prop = props.SingleOrDefault(x => x.PropertyType == typeof(IList<T2>));

            if (prop != null) {
                IList<T2> list = (IList<T2>)item.GetType().GetProperty(prop.Name).GetValue(item, null);
                if (list.Contains(other)) {
                    list.Remove(other);
                }

                item.GetType().GetProperty(prop.Name).SetValue(item, list, null);
            }
        }


        public void ManyToManyAssociate<T1, T2>(T1 item, T2 other, string joinTable)
            where T1 : class, new()
            where T2 : class, new() {
            ManyToManyAssociate(item, other);
        }

        public void ManyToManyDisassociate<T1, T2>(T1 item, T2 other, string joinTable)
            where T1 : class, new()
            where T2 : class, new() {
            ManyToManyDisassociate(item, other);
        }



        public IList<T2> GetAssociated<T1, T2>(T1 item)
            where T1 : class, new()
            where T2 : class, new() {

            var props = typeof(T1).GetProperties();

            var prop = props.SingleOrDefault(x => x.PropertyType == typeof(IList<T2>));
            IList<T2> list = null;
            if (prop != null) {
                list = (IList<T2>)item.GetType().GetProperty(prop.Name).GetValue(item, null);

            }

            return list;
        }

    }
}

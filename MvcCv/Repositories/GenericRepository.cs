using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities4 db = new DbCvEntities4();
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)   //bu kaydetme için yapılan generic komut
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TDelete(T p) //bu ise silme için yaplan generic komut
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void TUpdate(T p) //güncellemede, direkt olarak değişiklikleri kaydetmesini söyledik
        {
            db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where) //silinecek şeyi önce bulması gerekiyor, bu nedenle bu metodu yazdık
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}
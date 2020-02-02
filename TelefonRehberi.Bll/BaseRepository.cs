using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Dal;
using TelefonRehberi.Dal.EntityFramework;

namespace TelefonRehberi.Bll
{
    public class BaseRepository<T> : IDisposable where T : class, new()
    {
        protected TelefonRehberiContext context = new TelefonRehberiContext();
        
        public bool Add(T data)
        {
            try
            {
                context.Entry<T>(data).State = EntityState.Added;
                int sonuc = context.SaveChanges();
                return sonuc > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public bool Update(T data)
        {          
            try
            {
                context.Entry<T>(data).State = EntityState.Modified;
                int sonuc = context.SaveChanges();
                return sonuc > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<T> GetByFilter(Expression<Func<T,bool>> filter)
        {
            return context.Set<T>().Where(filter).ToList();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    
}

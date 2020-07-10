using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hudys.PlanilhaFinanceira.Domain.Interfaces;
using Hudys.PlanilhaFinanceira.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Hudys.PlanilhaFinanceira.Application.Services
{
    public class ServiceBase<T> : IDisposable
    where T : class
    {
        protected readonly PlanilhaFinanceiraDbContext Context;
        protected readonly DbSet<T> DbSet;

        public ServiceBase(PlanilhaFinanceiraDbContext _context)
        {
            Context = _context;
            DbSet = _context.Set<T>();
        }

        protected virtual Task<List<T>> GetAllAsync()
        {
            return Query.ToListAsync();
        }

        protected virtual List<T> GetAll()
        {
            return Query.ToList();
        }

        protected virtual IQueryable<T> Find(int id)
        {
            return Query.Where(t => ((IBasisTable)t).Id == id);
        }

        protected virtual IQueryable<T> Query => DbSet;


        protected virtual async Task<T> AddAsync(T obj)
        {
            if (obj != null)
            {
                var ret = DbSet.Add(obj).Entity;
                await SaveChangesAsync();

                return ret;
            }
            return null;
        }

        protected virtual T Add(T obj)
        {
            if (obj != null)
            {
                var ret = DbSet.Add(obj).Entity;
                SaveChanges();

                return ret;
            }
            return null;
        }

        protected virtual async Task<T> UpdateAsync(T obj)
        {
            if (obj != null)
            {
                var ret = DbSet.Update(obj).Entity;
                await SaveChangesAsync();

                return ret;
            }
            return null;
        }

        protected virtual T Update(T obj)
        {
            if (obj != null)
            {
                var ret = DbSet.Update(obj).Entity;
                SaveChanges();

                return ret;
            }
            return null;
        }

        protected virtual async Task DeleteAsync(T obj)
        {
            if (obj != null)
            {
                DbSet.Remove(obj);

                await SaveChangesAsync();
            }
        }

        protected virtual void Delete(T obj)
        {
            if (obj != null)
            {
                DbSet.Remove(obj);

                SaveChanges();
            }
        }

        protected virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        protected virtual Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
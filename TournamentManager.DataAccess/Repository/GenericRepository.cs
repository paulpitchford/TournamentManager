﻿using TournamentManager.Infrastructure.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TournamentManager.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PokerDbContext _context;
        public GenericRepository(PokerDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).TagWith($"Generic: Find {nameof(T)}");
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().TagWith($"Generic: Get All {nameof(T)}").ToList();
        }
        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}

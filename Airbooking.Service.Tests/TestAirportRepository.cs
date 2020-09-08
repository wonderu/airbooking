using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Airbooking.Data.Repositories;
using Airbooking.Model;

namespace Airbooking.Service.Tests
{
    public class TestAirportRepository: IAirportRepository
    {
        private readonly Airport _airport;

        public TestAirportRepository(Airport airport)
        {
            _airport = airport;
        }

        public void Add(Airport entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Airport entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Airport entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Expression where)
        {
            throw new System.NotImplementedException();
        }

        public Airport GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Airport> GetAll()
        {
            return new List<Airport> {_airport};
        }

        public Airport GetAirportByCode(string code)
        {
            return _airport;
        }

        public IEnumerable GetMany(Expression where)
        {
            throw new System.NotImplementedException();
        }

        public Airport Get(Expression where)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Expression<Func<Airport, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Airport Get(Expression<Func<Airport, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Airport> GetMany(Expression<Func<Airport, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
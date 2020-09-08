using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Airbooking.Data.Repositories;
using Airbooking.Model;

namespace Airbooking.Service.Tests.Fake
{
    public class TestBookingRepository:IBookingRepository
    {
        private readonly IEnumerable<Booking> _bookings;
        private readonly Booking _booking;

        public TestBookingRepository(Booking booking)
        {
            _booking = booking;
        }

        public TestBookingRepository(IEnumerable<Booking> bookings)
        {
            _bookings = bookings;
        }

        public void Add(Booking entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Booking entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Booking entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Booking, bool>> @where)
        {
            throw new NotImplementedException();
        }

        public Booking GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Booking Get(Expression<Func<Booking, bool>> @where)
        {
            return _booking;
        }

        public IEnumerable<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetMany(Expression<Func<Booking, bool>> where)
        {
            return _bookings;
        }

        public int AddBookingAndCommit(Booking booking)
        {
            return booking.Id = 543;
        }
    }
}

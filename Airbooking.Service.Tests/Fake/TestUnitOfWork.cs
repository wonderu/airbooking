using Airbooking.Data.Infrastructure;

namespace Airbooking.Service.Tests.Fake
{
    public class TestUnitOfWork: IUnitOfWork
    {
        public bool Commited { get; set; }

        public void Commit()
        {
            Commited = true;
        }
    }
}
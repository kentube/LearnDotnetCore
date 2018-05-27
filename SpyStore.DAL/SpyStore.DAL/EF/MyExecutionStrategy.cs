using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace SpyStore.DAL.EF
{
    public class MyExecutionStrategy : ExecutionStrategy
    {
        public MyExecutionStrategy(
            DbContext context) :
            base(context, ExecutionStrategy.DefaultMaxRetryCount, ExecutionStrategy.DefaultMaxDelay)
        {
        }

        public MyExecutionStrategy(DbContext context, int maxRetryCount, TimeSpan maxRetryDelay) :
            base(context, maxRetryCount, maxRetryDelay)
        {
        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            return true;
        }
    }
}

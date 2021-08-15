using PremiumCalculator.API.Repository.Queries.GetOccupations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RepositoryTests.Queries.GetOccupations
{
    public class GetOccupationsQueryTests
    {
        private GetOccupationsQuery query;
        private GetOccupationsQuery.Handler _handler;
        private static readonly CancellationToken CancellationToken = CancellationToken.None;
        public GetOccupationsQueryTests()
        {
            query = new GetOccupationsQuery();
            _handler = new GetOccupationsQuery.Handler();
        }

        [Fact]
        public async Task Should_Not_Return_Empty()
        {
            // Act
            var result = await _handler.Handle(query, CancellationToken);

            // Assert  
            Assert.NotEmpty(result);
        }
    }
}

using MediatR;
using PremiumCalculator.API.Repository.Queries.GetOccupations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumCalculator.API.Repository.Queries.GetOccupations
{
    public class GetOccupationsQuery : IRequest<List<OccupationFactor>>
    {
        public class Handler : IRequestHandler<GetOccupationsQuery, List<OccupationFactor>>
        {
            public async Task<List<OccupationFactor>> Handle(GetOccupationsQuery query, CancellationToken cancellationToken)
            {
                var occupations = new List<Occupation>
            {
                new Occupation { Name = "Cleaner", Rating = "Light Manual" },
                new Occupation { Name = "Doctor", Rating = "Professional" },
                new Occupation { Name = "Author", Rating = "White Collar" },
                new Occupation { Name = "Farmer", Rating = "Heavy Manual" },
                new Occupation { Name = "Mechanic", Rating = "Heavy Manual" },
                new Occupation { Name = "Florist", Rating = "Light Manual" }
            };

                var ratingFactor = new List<RatingFactor>
            {
                new RatingFactor { Rating = "Professional", Factor = Convert.ToDecimal(1.0) },
                new RatingFactor { Rating = "White Collar", Factor = Convert.ToDecimal(1.25) },
                new RatingFactor { Rating = "Light Manual", Factor = Convert.ToDecimal(1.50) },
                new RatingFactor { Rating = "Heavy Manual", Factor = Convert.ToDecimal(1.75) }
            };
                List<OccupationFactor> occupationItems = (from o in occupations
                                                          join or in ratingFactor
                                                               on o.Rating equals or.Rating
                                                          select new OccupationFactor()
                                                          {
                                                              OccupationName = o.Name,
                                                              FactorValue = or.Factor.ToString()
                                                          }).ToList();
                return occupationItems;
            }
        }
    }
}

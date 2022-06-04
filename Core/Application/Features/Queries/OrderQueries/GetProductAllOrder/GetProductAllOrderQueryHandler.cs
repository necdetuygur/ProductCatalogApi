using Application.Features.Queries.UserQueries.GetByIdUser;
using Application.Repositories.OrderRepository;
using Application.Repositories.UserRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.OrderQueries.GetProductAllOrder
{
    public class GetProductAllOrderQueryHandler : IRequestHandler<GetProductAllOrderQueryRequest, List<GetProductAllOrderQueryResponse>>
    {
        private readonly IOrderReadRepository _OrderReadRepository;
        private readonly IUserReadRepository _UserReadRepository;

        public GetProductAllOrderQueryHandler(IOrderReadRepository OrderReadRepository, IUserReadRepository UserReadRepository)
        {
            _OrderReadRepository = OrderReadRepository;
            _UserReadRepository = UserReadRepository;
        }
        public async Task<List<GetProductAllOrderQueryResponse>> Handle(GetProductAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetProductAllOrderQueryResponse> responseList = new();

            var orders = await _OrderReadRepository.Table.Where(p => p.ProductId == Guid.Parse(request.ProductId)).ToListAsync();

            foreach (var p in orders)
            {
                var u = _UserReadRepository.Table.FirstOrDefault(x => x.Id == p.UserId);
                GetByIdUserQueryResponse user = new();
                user.Id = u.Id;
                user.Name = u.Name;
                user.Surname = u.Surname;
                user.Email = u.Email;

                responseList.Add(new GetProductAllOrderQueryResponse
                {
                    Id = p.Id,
                    Price = p.Price,
                    ProductId = p.ProductId,
                    UserId = p.UserId,
                    StatusId = p.StatusId,
                    User = user,
                });
            }
            return responseList;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Repositories.OrderRepository
{
    public interface IOrderReadRepository : IReadRepository<Order>
    {
    }

}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCommerce.Shared.CQRS
{
    public interface IQuery< out TResult> : IRequest<TResult>
    {
    }

}

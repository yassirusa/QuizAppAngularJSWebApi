using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Interfaces.Domain;

namespace Quiz.Interfaces.ServiceInterfaces
{
    public interface IEntityService<T1, T2> : IService
        where T1: IDomainBase
        where T2: IDomainBase
    { 
        T1 Get();
        T2 GetOneById(int id);
    }
}

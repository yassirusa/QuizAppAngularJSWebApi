using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Interfaces.Model;

namespace Quiz.Interfaces
{
    public interface IEntityDataLayer<T>
        where T : IEntity
    {
        T GetEntityById(int id);
        IEnumerable<T> GetAllEntities();
    }
}

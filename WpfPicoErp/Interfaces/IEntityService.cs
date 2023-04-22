using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPicoErp.Interfaces
{
    public interface IEntityService<TEntity> where TEntity : class
    {
        void UpdateEntity(TEntity updatedEntity);
        TEntity GetOriginalEntity(TEntity entity);
    }
}

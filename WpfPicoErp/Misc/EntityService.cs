using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPicoErp.Context;
using WpfPicoErp.Interfaces;

namespace WpfPicoErp.Misc
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class, new ()
    {
        private readonly PicoDbContext _dbContext;

        public EntityService(PicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateEntity(TEntity updatedEntity)
        {
            _dbContext.Entry(updatedEntity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public TEntity GetOriginalEntity(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);
            var originalValues = entry.OriginalValues;

            var originalEntity = new TEntity();
            foreach (var property in originalValues.Properties)
            {
                var propertyInfo = typeof(TEntity).GetProperty(property.Name);
                propertyInfo.SetValue(originalEntity, originalValues[property.Name]);
            }

            return originalEntity;
        }       
    }
}

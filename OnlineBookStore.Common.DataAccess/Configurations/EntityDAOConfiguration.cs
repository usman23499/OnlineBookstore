using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnlineBookStore.Common.DataAccess.DAO;
using System;
using System.Linq;
using System.Reflection;

namespace OnlineBookStore.Common.DataAccess.Configurations
{
    public static class EntityDAOConfiguration
    {
        static void Configure<TEntity, TKey>(ModelBuilder modelBuilder)
            where TEntity : EntityDAO<TKey>
        {
            modelBuilder.Entity<TEntity>(builder =>
            {
                builder.Property(x => x.PersistentId).ValueGeneratedOnAdd();
                //builder.Property(x => x.PersistentId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                builder.HasQueryFilter(x => !x.IsDeleted);
                builder.Ignore(x => x.IntegrationEvents);
                builder.Ignore(x => x.DomainEvents);
            });
        }

        public static ModelBuilder ApplyEntityDAOConfiguration(this ModelBuilder modelBuilder)
        {
            var method = typeof(EntityDAOConfiguration)
                .GetTypeInfo()
                .DeclaredMethods
                .Single(m => m.Name == nameof(Configure));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.IsOfTypeEntityDAO(out var T))
                    method.MakeGenericMethod(entityType.ClrType, T).Invoke(null, new[] { modelBuilder });
            }

            return modelBuilder;
        }

        static bool IsOfTypeEntityDAO(this Type type, out Type T)
        {
            for (var baseType = type.BaseType; baseType != null; baseType = baseType.BaseType)
            {
                if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == typeof(EntityDAO<>))
                {
                    T = baseType.GetGenericArguments()[0];
                    return true;
                }
            }
            T = null;
            return false;
        }
    }
}
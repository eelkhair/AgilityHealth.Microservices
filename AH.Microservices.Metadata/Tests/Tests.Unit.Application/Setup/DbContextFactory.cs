﻿using AH.Metadata.Application.Interfaces;
using AH.Metadata.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Tests.Unit.Application.Setup;

internal abstract class DbContextFactory
{
    public static MetadataDbContext Create()
    {
        var options = new DbContextOptionsBuilder<MetadataDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new MetadataDbContext(options);
        context.Database.EnsureCreated();
        
        SeedDatabase(context);
 
        return context;
    }
    
    public static void Destroy(DbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
    
    public static void CreateBatchEntities<TEntity>(MetadataDbContext context, Func<TEntity> entityDelegate, int recordCount, bool saveChanges = true)
    {
        for (var i = 0; i < recordCount; i++)
        {
            var entity = entityDelegate.Invoke();
            if (entity != null) context.Add(entity);
        }

        if (saveChanges) { context.SaveChanges(); }
        
    }

    public static TEntity CreateEntity<TEntity>(MetadataDbContext context, TEntity entity)
    {
        if (entity != null) context.Add(entity);
        context.SaveChanges();
        return entity;
    }

    private static void SeedDatabase(MetadataDbContext context)
    {
        context.Countries.ToList().ForEach(x=> x.UId = Guid.NewGuid());
        context.SurveyTypes.ToList().ForEach(x=> x.UId = Guid.NewGuid());
        context.GrowthPlanStatuses.ToList().ForEach(x=> x.UId = Guid.NewGuid());
        context.Industries.ToList().ForEach(x=> x.UId = Guid.NewGuid());
        context.SaveChanges();
    }
}
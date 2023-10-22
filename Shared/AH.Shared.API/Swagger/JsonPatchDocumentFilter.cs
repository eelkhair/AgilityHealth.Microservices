﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AH.Shared.Api.Swagger;

 public class JsonPatchDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            //Remove irrelevant schemas
            var schemas = swaggerDoc.Components.Schemas.ToList();
            foreach (var item in schemas.Where(item => item.Key.StartsWith("Operation") || item.Key.StartsWith("JsonPatchDocument")))
            {
                swaggerDoc.Components.Schemas.Remove(item.Key);
            }

            //Add accurate schemas
            swaggerDoc.Components.Schemas.Add("Operation", new OpenApiSchema
            {
                Type = "object",
                Properties = new Dictionary<string, OpenApiSchema>
                {
                    {"op", new OpenApiSchema{ Type = "string" } },
                    {"value", new OpenApiSchema{ Type = "object", Nullable = true } },
                    {"path", new OpenApiSchema{ Type = "string" } }
                }
            });

            swaggerDoc.Components.Schemas.Add("JsonPatchDocument", new OpenApiSchema
            {
                Type = "array",
                Items = new OpenApiSchema
                {
                    Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = "Operation" }
                },
                Description = "Array of operations to perform"
            });

            //Fix up the patch references
            foreach (var path in swaggerDoc.Paths.SelectMany(p => p.Value.Operations)
                .Where(p => p.Key == OperationType.Patch))
            {
                foreach (var item in path.Value.RequestBody.Content.Where(c => c.Key != "application/json-patch+json"))
                    path.Value.RequestBody.Content.Remove(item.Key);
                var response = path.Value.RequestBody.Content.Single(c => c.Key == "application/json-patch+json");
                response.Value.Schema = new OpenApiSchema
                {
                    Reference = new OpenApiReference { Type = ReferenceType.Schema, Id = "JsonPatchDocument" }
                };
            }
        }
    }
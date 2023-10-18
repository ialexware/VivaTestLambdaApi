﻿using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using VivaTestLambdaApi.Contracts.Dto;

namespace VivaTestLambdaApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IAmazonDynamoDB _dynamoDb;
        private readonly string _tableName;

        public ProductRepository(IAmazonDynamoDB dynamoDb, string tableName)
        {
            _dynamoDb = dynamoDb;
            _tableName = tableName;
        }

        public async Task<bool> CreateAsync(ProductDto product)
        {
            var customerAsJson = JsonSerializer.Serialize(product);
            var itemAsDocument = Document.FromJson(customerAsJson);
            var itemAsAttributes = itemAsDocument.ToAttributeMap();
            var createItemRequest = new PutItemRequest
            {
                TableName = _tableName,
                Item = itemAsAttributes
            };

            var response = await _dynamoDb.PutItemAsync(createItemRequest);
            return response.HttpStatusCode == HttpStatusCode.OK;
        }

        public async Task<ProductDto?> GetAsync(Guid id)
        {
            var getItemRequest = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>()
            {
                { "pk", new AttributeValue { S = id.ToString() } },
                { "sk", new AttributeValue { S = id.ToString() } }
            },
                ConsistentRead = true
            };

            var response = await _dynamoDb.GetItemAsync(getItemRequest);
            if (response.Item.Count == 0)
            {
                return null;
            }

            var itemAsDocument = Document.FromAttributeMap(response.Item);
            return JsonSerializer.Deserialize<ProductDto>(itemAsDocument.ToJson());
        }

        public async Task<bool> UpdateAsync(ProductDto product)
        {
            var customerAsJson = JsonSerializer.Serialize(product);
            var itemAsDocument = Document.FromJson(customerAsJson);
            var itemAsAttributes = itemAsDocument.ToAttributeMap();
            var updateItemRequest = new PutItemRequest
            {
                TableName = _tableName,
                Item = itemAsAttributes
            };

            var response = await _dynamoDb.PutItemAsync(updateItemRequest);
            return response.HttpStatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var deleteItemRequest = new DeleteItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>()
            {
                { "pk", new AttributeValue { S = id.ToString() } },
                { "sk", new AttributeValue { S = id.ToString() } }
            }
            };
            var response = await _dynamoDb.DeleteItemAsync(deleteItemRequest);
            return response.HttpStatusCode == HttpStatusCode.OK;
        }
    }
}

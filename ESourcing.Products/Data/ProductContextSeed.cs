using ESourcing.Products.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ESourcing.Products.Data
{
	public class ProductContextSeed
	{
		public static void SeedData(IMongoCollection<Product> productCollection)
		{
			bool existProduct = productCollection.Find(p => true).Any();
			if (!existProduct)
			{
				productCollection.InsertManyAsync(GetConfigureProducts());
			}
		}

		private static IEnumerable<Product> GetConfigureProducts()
		{
			return new List<Product>()
			{
				new Product
				{
					Name = "Name 1",
					Summary = "Summary of name 1",
					Description = "Description of name 1",
					ImageFile = "product-4.png",
					Price = 472.00M,
					Category = "Smart Phone"
				},
				new Product
				{
					Name = "Name 2",
					Summary = "Summary of name 2",
					Description = "Description of name 2",
					ImageFile = "product-4.png",
					Price = 400.00M,
					Category = "White Appliances"
				},
				new Product
				{
					Name = "Name 3",
					Summary = "Summary of name 3",
					Description = "Description of name 3",
					ImageFile = "product-4.png",
					Price = 200.00M,
					Category = "White Appliances"
				},
				new Product
				{
					Name = "Name 4",
					Summary = "Summary of name 4",
					Description = "Description of name 4",
					ImageFile = "product-4.png",
					Price = 402.00M,
					Category = "Home Appliances"
				},
				new Product
				{
					Name = "Name 4",
					Summary = "Summary of name 5",
					Description = "Description of name 5",
					ImageFile = "product-4.png",
					Price = 472.00M,
					Category = "White Appliances"
				},
				new Product
				{
					Name = "Name 6",
					Summary = "Summary of name 6",
					Description = "Description of name 6",
					ImageFile = "product-4.png",
					Price = 872.00M,
					Category = "Smart Appliances"
				},
			};
		}
	}
}

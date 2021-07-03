using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Shop
{ 
   class Program 
   { 
    
        private static string _connectionString = @"Data Source=WIN-J8MCEPL7DG6;Initial Catalog=Shop;Integrated Security=True";
        static void Main(string[] args)
        {

            Console.WriteLine($"Доступные комманды: SelectCustomer, SelectOrder, InsertCustomer, InsertOreders, \r\n" +
                $"UpdateCustomer, UpdateOrder, NumberOfCustomer, NumberOfOrder, SumOrder, HumanStatistics. \r\n" + 
                $"Завершить работу: exit.");
            string command = Console.ReadLine().ToLower();
            List<Order> orders = null;
            List<Customer> customers = null;
            while (command != "exit")
            {
                switch(command){
                    case "exit":
                        return;
                    case "selectcustomer":
                        customers = ReadCustomers();
                        foreach (Customer customer in customers)
                        {
                            Console.WriteLine($"| {customer.CustomerId} | {customer.Name} | {customer.City} |");
                        }
                        break;
                    case "selectorder":
                        orders = ReadOrders();
                        foreach (Order order in orders)
                        {
                            Console.WriteLine($"| {order.OrderId} | {order.IdCustomer} | {order.ProductName} | {order.Price} |");
                        }
                        break;
                    case "insertorders":
                        Order createdOrder = InsertOrder(2, 9, "Тыква", 123);
                        Console.WriteLine($"Created post: \r\n" +
                            $"| {createdOrder.OrderId} | {createdOrder.IdCustomer} | {createdOrder.ProductName} | {createdOrder.Price} |");
                        break;
                    case "insertcustomer":
                        Customer createdCustomer = InsertCustomer(4, "Артём", "Москва");
                        Console.WriteLine($"Created post: \r\n" +
                            $"| {createdCustomer.CustomerId} | {createdCustomer.Name} | {createdCustomer.City} |");
                        break;
                    case "updatecustomer":
                         UpdateCustomer(5, "Фирдавси");
                        break;
                    case "updateorder":
                        UpdateOrder(5, 132);
                        break;
                    case "numberofcustomer":
                        Console.WriteLine($"Количество человек: {NumberOfCustomer()}");
                        break;
                    case "numberoforder":
                        Console.WriteLine($"Количество заказов: {NumberOfOrder()}");
                        break;
                    case "sumorder":
                        Console.WriteLine($"Сумма заказов: {SumOrder()}");
                        break;
                    case "humanstatistics":
                        NumberOrder(1);
                        break;
                    default:
                        Console.WriteLine($"Комманда {command} некорректна.");
                        break;
                }
                command = Console.ReadLine().ToLower();
            }
        }

        private static List<Customer> ReadCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText =
                    @"SELECT 
                        *                    
                    FROM [Customer]";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var customer = new Customer
                            {
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                Name = Convert.ToString(reader["Name"]),
                                City = Convert.ToString(reader["City"])
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }
            return customers;
        }

         private static List<Order> ReadOrders()
          {
              List<Order> orders = new List<Order>();
              using (SqlConnection connection = new SqlConnection(_connectionString))
              {
                  connection.Open();
                  using (SqlCommand command = new SqlCommand())
                  {
                      command.Connection = connection;
                      command.CommandText =
                      @"SELECT 
                          *                    
                      FROM [Order]";
         
                      using (SqlDataReader reader = command.ExecuteReader())
                      {
                          while (reader.Read())
                          {
                              var order = new Order
                              {
                                  OrderId = Convert.ToInt32(reader["OrderId"]),
                                  IdCustomer = Convert.ToInt32(reader["IdCustomer"]),
                                  ProductName = Convert.ToString(reader["ProductName"]),
                                  Price = Convert.ToInt32(reader["Price"])
                              };
                              orders.Add(order);
                          }
                      }
                  }
              }
              return orders;
          }

        private static Order InsertOrder(int orderId, int customer, string productName, int price)
        {
            Order order = new Order();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO [Order]
                       ([OrderId],
                        [Customer],
                        [productName],
                        [Price]) 
                    VALUES 
                       (@orderId,
                        @customer,
                        @productName,
                        @price)
                    SELECT SCOPE_IDENTITY()";

                    command.Parameters.Add("@orderId", SqlDbType.NVarChar).Value = orderId;
                    order.OrderId = orderId;
                    command.Parameters.Add("@customer", SqlDbType.NVarChar).Value = customer;
                    order.IdCustomer = customer;
                    command.Parameters.Add("@productName", SqlDbType.Int).Value = productName;
                    order.ProductName = productName;
                    command.Parameters.Add("@price", SqlDbType.NVarChar).Value = price;
                    order.Price = price;

                    return order;
                }
            }
        }

        private static Customer InsertCustomer(int customerId, string name, string city)
        {
            Customer customer = new Customer();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO [Order]
                       ([CustomerId],
                        [Name],
                        [City]) 
                    VALUES 
                       (@customerId,
                        @name,
                        @productName,
                        @city)
                    SELECT SCOPE_IDENTITY()";

                    command.Parameters.Add("@customerId", SqlDbType.NVarChar).Value = customerId;
                    customer.CustomerId = customerId;
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    customer.Name = name;
                    command.Parameters.Add("@city", SqlDbType.Int).Value = city;
                    customer.City = city;

                    return customer;
                }
            }
        }

        private static void UpdateCustomer(int customerId, string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        UPDATE [Customer]
                        SET [Name] = @name
                        WHERE [CustomerId] = @customerId";

                    command.Parameters.Add("@customerId", SqlDbType.BigInt).Value = customerId;
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Имя у СustomerId {customerId} изменено на {name}");
                }
            }
        }

        private static void UpdateOrder(int orderId, int price)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        UPDATE [Order]
                        SET [Price] = @price
                        WHERE [OrderId] = @orderId";

                    command.Parameters.Add("@orderId", SqlDbType.BigInt).Value = orderId;
                    command.Parameters.Add("@price", SqlDbType.BigInt).Value = price;
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Цена у orderId {orderId} изменено на {price}");
                }
            }
        }

        private static int NumberOfCustomer()
        {
            int number = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT COUNT(*) AS AllCustomer FROM [Customer]";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            number = Convert.ToInt32(reader.GetInt32(number));
                        }
                    }
                }
            }
            return number;
        }

        private static int NumberOfOrder()
        {
            int number = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT COUNT(*) AS AllCustomer FROM [Order]";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            number = reader.GetInt32(number);
                        }
                    }
                }
            }
            return number;
        }
        private static int SumOrder()
        {
            int sum = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT SUM(Price) AS SumOrder FROM [Order]";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sum = reader.GetInt32(sum);
                        }
                    }
                }
            }
            return sum;
        }

        private static void NumberOrder(int customerId)
        {
            int allSumOrders = 0;
            int numberOfOrders = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT COUNT(*)  AS NumberOfOrder FROM ([Customer] JOIN [Order] ON [Customer].CustomerId = [Order].IdCustomer) WHERE [Customer].CustomerId = {customerId}";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            numberOfOrders = reader.GetInt32(numberOfOrders);
                        }
                    }
                    command.CommandText = $"SELECT Sum(Price) AS AllPrice FROM ([Customer] JOIN [Order] ON [Customer].CustomerId = [Order].IdCustomer) WHERE [Customer].CustomerId = {customerId} ";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allSumOrders = reader.GetInt32(allSumOrders);
                        }
                    }
                }
            }
            Console.WriteLine($"У {customerId}-го человека {numberOfOrders} заказов на сумму {allSumOrders}");
        }
    }
}

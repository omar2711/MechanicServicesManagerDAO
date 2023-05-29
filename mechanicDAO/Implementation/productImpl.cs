using mechanicDAO.Interfaces;
using mechanicDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanicDAO.Implementation
{
    public class productImpl : BaseImpl, IProduct
    {
        public int Delete(product t)
        {
            string query = @"UPDATE product SET status = 0, userId = @userId WHERE id = " + t.ID;
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userId", SessionClass.ID);
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
            
        }

        public int Insert(product t)
        {
            string query = @"INSERT INTO product (name, price, stock, categoryId, productBrandId, userId) VALUES (@name, @price, @stock, @categoryId, @productBrandId, @userId)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@price", t.Price);
            command.Parameters.AddWithValue("@stock", t.Stock);
            command.Parameters.AddWithValue("@categoryId", t.ProductCategoryID);
            command.Parameters.AddWithValue("@productBrandId", t.ProductBrandID);
            command.Parameters.AddWithValue("@userId", SessionClass.ID);

            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
            
        }

        public DataTable Select()
        {
            string query = @"SELECT p.id, p.name AS Producto, p.price AS Precio, p.stock AS Stock, pc.name AS Categoria, pb.name AS Marca FROM product p INNER JOIN productCategory pc ON p.categoryId = pc.id INNER JOIN productBrand pb ON p.productBrandId = pb.id WHERE p.status = 1";
            SqlCommand command = CreateBasicCommand(query);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            try
            {
                command.Connection.Open();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int Update(product t)
        {
            string query = @"UPDATE product SET name = @name, price = @price, stock = @stock, categoryId = @categoryId, productBrandId = @productBrandId, userId = @userId, modificationDate = CURRENT_TIMESTAMP WHERE id = " + t.ID;
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@price", t.Price);
            command.Parameters.AddWithValue("@stock", t.Stock);
            command.Parameters.AddWithValue("@categoryId", t.ProductCategoryID);
            command.Parameters.AddWithValue("@productBrandId", t.ProductBrandID);
            command.Parameters.AddWithValue("@userId", SessionClass.ID);

            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}

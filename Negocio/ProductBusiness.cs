using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Utilities;

namespace Business
{
    public class ProductBusiness
    {
        private DataAccess data;

        public ProductBusiness()
        {
            data = new DataAccess();
        }

        public List<Product> list(string id = "")
        {
            List<Product> list = new List<Product>();

            try
            {
                string query = "select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, IdCategoria, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id";
                if (id != "")
                {
                    query += " and A.Id = " + id;
                }

                data.setQuery(query);


                data.executeRead();


                while (data.Reader.Read())
                {
                    Product product = new Product();

                    product.id = (int)data.Reader["Id"];
                    product.code = (string)data.Reader["Codigo"];
                    product.name = (string)data.Reader["Nombre"];
                    product.description = (string)data.Reader["Descripcion"];
                    product.imageUrl = (string)data.Reader["ImagenUrl"];
                    product.price = (decimal)data.Reader["Precio"];

                    product.brand = new Brand((int)data.Reader["IdMarca"], (string)data.Reader["Marca"]);
                    product.category = new Category((int)data.Reader["IdCategoria"], (string)data.Reader["Categoria"]);

                    list.Add(product);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public void add(Product product)
        {
            try
            {
                data.setQuery("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@code, @name, @description, @brandId, @categoryId, @img, @price)");
                data.setParam("@code", product.code);
                data.setParam("@name", product.name);
                data.setParam("@description", product.description);
                data.setParam("@img", product.imageUrl);
                data.setParam("@brandId", product.brand.id);
                data.setParam("@categoryId", product.category.id);
                data.setParam("@price", product.price);
                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public void update(Product product)
        {
            try
            {
                data.setQuery("Update ARTICULOS set Codigo = @code, Nombre = @name, Descripcion = @description, ImagenUrl = @img, IdMarca = @brandId, IdCategoria = @categoryId, Precio = @price where Id = @id ");
                data.setParam("@code", product.code);
                data.setParam("@name", product.name);
                data.setParam("@description", product.description);
                data.setParam("@img", product.imageUrl);
                data.setParam("@brandId", product.brand.id);
                data.setParam("@categoryId", product.category.id);
                data.setParam("@price", product.price);
                data.setParam("@id", product.id);

                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public void delete(Product product)
        {
            try
            {
                data.setQuery("Delete ARTICULOS where Id = @id");
                data.setParam("@id", product.id);
                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public List<Product> filter(string field, string criterion, string filter)
        {
            List<Product> list = new List<Product>();
            BrandBusiness brandBusiness = new BrandBusiness();
            CategoryBusiness categoryBusiness = new CategoryBusiness();

            try
            {
                string query = "select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, IdCategoria, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id and ";
                switch (field)
                {
                    case "Marca":
                        Brand brand = brandBusiness.searchByDescription(criterion);
                        query += "M.Id = '" + brand.id.ToString() + "'";
                        break;
                    case "Categoria":
                        Category category = categoryBusiness.searchByDescription(criterion);
                        query += "C.Id = '" + category.id.ToString() + "'";
                        break;
                    case "Precio":
                        if(!ValidationUtilities.onlyNumbers(filter))
                        {
                            throw new Exception("Solo numeros admitidos para el campo seleccionado");
                        }

                        if (criterion == "Mayor a")
                        {
                            query += "Precio >= " + filter;
                        }
                        else
                        {
                            query += "Precio <= " + filter;
                        }
                        break;
                    case "Codigo":
                        switch (criterion)
                        {
                            case "Letra":
                                query += "Codigo like '" + filter + "%'";
                                break;
                            case "Numero":
                                query += "Codigo like '%" + filter + "'";
                                break;
                            case "Codigo completo":
                                if (!ValidationUtilities.isProductCode(filter))
                                {
                                    throw new Exception("Codigo de producto invalido");
                                }
                                query += "Codigo like '" + filter + "'";
                                break;
                        }
                        break;
                    case "Descripcion":
                        switch (criterion)
                        {
                            case "Empieza con":
                                query += "A.Descripcion like '" + filter + "%'";
                                break;
                            case "Termina con":
                                query += "A.Descripcion like '%" + filter + "'";
                                break;
                            case "Contiene":
                                query += "A.Descripcion like '%" + filter + "%'";
                                break;
                        }
                        break;
                    default:
                        break;
                }

                data.setQuery(query);
                data.executeRead();

                while (data.Reader.Read())
                {
                    Product product = new Product();

                    product.id = (int)data.Reader["Id"];
                    product.code = (string)data.Reader["Codigo"];
                    product.name = (string)data.Reader["Nombre"];
                    product.description = (string)data.Reader["Descripcion"];
                    product.imageUrl = (string)data.Reader["ImagenUrl"];
                    product.price = (decimal)data.Reader["Precio"];

                    product.brand = new Brand((int)data.Reader["IdMarca"], (string)data.Reader["Marca"]);
                    product.category = new Category((int)data.Reader["IdCategoria"], (string)data.Reader["Categoria"]);

                    list.Add(product);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Favoritos
        public List<Product> getFavorites(int userId)
        {
            List<Product> favorites = new List<Product>();
            try
            {
                data.setQuery("select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, IdCategoria, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C, FAVORITOS F where A.IdMarca = M.Id and A.IdCategoria = C.Id and F.IdArticulo = A.Id and F.IdUser = @userId");
                data.setParam("@userId", userId);
                data.executeRead();

                while (data.Reader.Read())
                {
                    Product product = new Product();

                    product.id = (int)data.Reader["Id"];
                    product.code = (string)data.Reader["Codigo"];
                    product.name = (string)data.Reader["Nombre"];
                    product.description = (string)data.Reader["Descripcion"];
                    product.imageUrl = (string)data.Reader["ImagenUrl"];
                    product.price = (decimal)data.Reader["Precio"];

                    product.brand = new Brand((int)data.Reader["IdMarca"], (string)data.Reader["Marca"]);
                    product.category = new Category((int)data.Reader["IdCategoria"], (string)data.Reader["Categoria"]);

                    favorites.Add(product);
                }

                return favorites;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public bool addFavorite(int productId, int userId)
        {
            try
            {
                data.setQuery("insert into FAVORITOS (IdUser ,IdArticulo) values (@userId ,@productId)");
                data.setParam("@userId", userId);
                data.setParam("@productId", productId);

                data.executeAction();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public bool deleteFavorite(int productId, int userId)
        {
            try
            {
                data.setQuery("Delete FAVORITOS where IdUser = @userId and IdArticulo = @productId");
                data.setParam("@userId", userId);
                data.setParam("@productId", productId);

                data.executeAction();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.closeConnection(); }
        }

        public bool isFavorite(int productId, int userId)
        {
            try
            {
                data.setQuery("select IdUser, IdArticulo from FAVORITOS where IdUser = @userId and IdArticulo = @productId");
                data.setParam("@userId", userId);
                data.setParam("@productId", productId);

                data.executeRead();

                if (data.Reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.closeConnection(); }
        }
    }
}

using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Business
{
    public class UserBusiness
    {

        private DataAccess data;

        public UserBusiness() 
        {
            data = new DataAccess();
        }

        public bool login(User user)
        {
            try
            {
                data.setQuery("select id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS where email = @email and pass = @password");
                data.setParam("@email", user.email);
                data.setParam("@password", user.password);

                data.executeRead();

                if(data.Reader.Read())
                {
                    user.id = (int)data.Reader["id"];
                    user.isAdmin = (bool)data.Reader["admin"];
                    if (!(data.Reader["urlImagenPerfil"] is DBNull))
                        user.imageUrl = (string)data.Reader["urlImagenPerfil"];
                    if (!(data.Reader["nombre"] is DBNull))
                        user.name = (string)data.Reader["nombre"];
                    if (!(data.Reader["apellido"] is DBNull))
                        user.surname = (string)data.Reader["apellido"];

                    return true;
                }
                return false;
            
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                data.closeConnection();
            }
        }

        public bool create(User user)
        {
            try
            {
                data.setQuery("insert into USERS (email, pass, nombre, apellido, urlImagenPerfil, admin) values (@email, @pass, @name, @surname, @image, @admin)");
                data.setParam("@email", user.email);
                data.setParam("@pass", user.password);
                data.setParam("@name", user.name);
                data.setParam("@surname", user.surname);
                data.setParam("@image", user.imageUrl);
                data.setParam("@admin", user.isAdmin);
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

        public bool update(User user)
        {
            try
            {

                data.setQuery("Update USERS set email = @email, nombre = @name, apellido = @surname, urlImagenPerfil = @image where Id = @id");
                data.setParam("@email", user.email);
                data.setParam("@name", user.name);
                data.setParam("@surname", user.surname);
                data.setParam("@image", user.imageUrl);
                data.setParam("@id", user.id);

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

        public bool delete(User user)
        {
            try
            {
                data.setQuery("Delete USERS where Id = @id");
                data.setParam("@id", user.id);
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
    }
}

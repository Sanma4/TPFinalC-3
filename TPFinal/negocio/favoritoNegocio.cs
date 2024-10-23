﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class favoritoNegocio
    {
		public List<Favoritos> Listar()
		{
			List<Favoritos> lista = new List<Favoritos>();	
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("select U.Id, F.Id, IdArticulo, IdUser, A.Id, A.Nombre, A.Descripcion, A.IdMarca, A.ImagenUrl from FAVORITOS F, ARTICULOS A, USERS U where F.IdArticulo = A.Id and F.IdUser = U.Id");
				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
					Favoritos aux = new Favoritos();
					aux.Id = (int)datos.Lector["Id"];
					aux.IdArticulo = (int)datos.Lector["IdArticulo"];
					aux.IdUsuario = (int)datos.Lector["IdUser"];
					
					lista.Add(aux);

				}

				return lista;
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}
        public void AgregarFavorito(articulo Producto, Usuario User)
        {
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("Insert into Favoritos values (@IdUsuario, @IdArticulo)");
				datos.setearParametro("@IdUsuario", User.Id);
				datos.setearParametro("@IdArticulo", Producto.Id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }
    }
}

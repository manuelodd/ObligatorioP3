using Dominio.Entities;
using Dominio.Enums;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Historias
{
    public class EditarHistoriaCU : IEditarHistoria
    {
        private IRepositorioHistorias repositorio;
        private IRepositorioCategorias repositorioC;

        public EditarHistoriaCU(    IRepositorioHistorias repo,
                                    IRepositorioCategorias repoC)
        {
            repositorio = repo;
            repositorioC = repoC;
        }

        public void Execute(HistoriaDTO dto)
        {
            Historia historia = repositorio.FindById(dto.Id);

            if (historia == null)   throw new Exception("No existe la historia.");

            historia.Titulo = dto.Titulo;
            historia.Sinopsis = dto.Sinopsis;
            historia.Estado = (EstadoHistoria)dto.Estado;
            // capaz lo meto adentro del if, pero para no complicarme la vida lo hago asi
            historia.Categorias.Clear();

            if (!repositorio.TieneMasDeUnCapitulo(dto.Id))
            {
                historia.CapituloInicial.Titulo = dto.TituloCapInicial;
                historia.CapituloInicial.Texto = dto.TextoCapInicial;
            }

            if (dto.CategoriasId != null)
            {
                foreach (int id in dto.CategoriasId)
                {
                    Categoria categoria = repositorioC.FindById(id);
                    if (categoria == null)  throw new Exception("Categoria inexistente.");
                    historia.Categorias.Add(categoria);
                }
            }
            else
            {
                throw new HistoriaException("Debe elegir al menos una categoría.");
            }

            // El resto de las validaciones las agregamos acá.

            repositorio.Update(historia);
        }
    }
}

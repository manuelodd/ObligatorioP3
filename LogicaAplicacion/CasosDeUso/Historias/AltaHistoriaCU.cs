using Dominio.Entities;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.CasosDeUso.Auditorias;
using LogicaAplicacion.InterfacesCasosDeUso.Auditorias;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Historias
{
    public class AltaHistoriaCU : IAltaHistoria
    {
        private IRepositorioHistorias repositorio;
        private IRepositorioCategorias repositorioC;
        private IRegistrarAuditoria regisAudi;

        public AltaHistoriaCU(  IRepositorioHistorias repo, 
                                IRepositorioCategorias repoc,
                                IRegistrarAuditoria regisAu)
        {
            repositorio = repo;
            repositorioC = repoc;
            regisAudi = regisAu;
        }

        public void Execute(HistoriaDTO dto, int adminId)
        {
            Historia historia = HistoriaDTOMapper.FromDTO(dto);
            historia.Categorias = new List<Categoria>();

            if (dto.CategoriasId != null)
            {
                foreach (int idC in dto.CategoriasId)
                {
                    Categoria categoria = repositorioC.FindById(idC);
                    historia.Categorias.Add(categoria);
                }
            }
            else
            {
                throw new HistoriaException("Debe seleccionar al menos una categoria");
            }
            repositorio.Add(historia);
            regisAudi.Execute(historia.Id, adminId, Dominio.Enums.AccionAuditoria.HISTORIA_CREATE);
        }
    }
}

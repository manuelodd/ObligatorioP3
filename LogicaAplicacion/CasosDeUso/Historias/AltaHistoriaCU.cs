using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Historias
{
    public class AltaHistoriaCU : IAltaHistoria
    {
        private IRepositorioHistorias repositorio;
        public AltaHistoriaCU(IRepositorioHistorias repo)
        {
            repositorio = repo;
        }
        public void Execute(HistoriaDTO dto)
        {
            repositorio.Add(HistoriaDTOMapper.FromDTO(dto));
        }
    }
}

using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Historias
{
    public class ObtenerFinalesAlcanzadosHistoriaCU : IObtenerFinalesAlcanzadosHistoria
    {
        private IRepositorioHistorias repositorio;

        public ObtenerFinalesAlcanzadosHistoriaCU(IRepositorioHistorias repo)
        {
            repositorio = repo;
        }

        public List<FinalesAlcanzadosDTO> Execute(int historiaId)
        {
            Historia historia = repositorio.FindById(historiaId);
            if (historia == null)throw new Exception("No existe la historia.");

            List<Final> finales = new List<Final>();

            foreach (Capitulo capitulo in historia.Capitulos)
            {
                if (capitulo is Final final)    finales.Add(final);
            }

            List<FinalesAlcanzadosDTO> stats = new List<FinalesAlcanzadosDTO>();

            if (finales.Count == 0) return stats;

            int mayorCantidad = finales.Max(f => f.CantidadVecesAlcanzado);

            foreach (Final final in finales)
            {
                bool esElMasFrecuente = final.CantidadVecesAlcanzado == mayorCantidad;

                stats.Add(FinalesAlcanzadosDTOMapper.ToDTO(final, esElMasFrecuente)
                );
            }

            return stats.OrderByDescending(f => f.CantidadVecesAlcanzado).ToList();
        }
    }
}

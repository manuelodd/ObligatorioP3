using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class ObtenerUsuarioHistoriasRankingsCU : IObtenerUsuarioHistoriasRankings
    {
        private IRepositorioLecturas repositorio;
        public ObtenerUsuarioHistoriasRankingsCU(IRepositorioLecturas repo)
        {
            repositorio = repo;
        }

        public List<UsuarioHistoriasRankingsDTO> Execute()
        {
            List<Lectura> lecturas = repositorio.FindAll()  .Where(l => l.FechaFin != null)
                                                            .ToList();
            //lecturas son las lecturas que ya estan terminadas
            List<UsuarioHistoriasRankingsDTO> ranking = new List<UsuarioHistoriasRankingsDTO>();

            //recorro esas lectras
            foreach (Lectura lectura in lecturas)
            {
                //corroboro si el usuario de esa lectura ya fue agregado a "ranking"
                bool yaEstaEnRanking = ranking.Any(r => r.UsuId == lectura.UsuarioId);


                //si no esta en ranking calculo las historias diferentes que leyo
                if (!yaEstaEnRanking)
                {
                    List<int> historiasDistintas = new List<int>();

                    //vuelvo a recorrer las lect para calcular la cant
                    foreach (Lectura l in lecturas)
                    {
                        //lecturas que pertenezcan al mismo usu y no se haya n contabilizado todavia las agrego a la list<int>
                        if (l.UsuarioId == lectura.UsuarioId && !historiasDistintas.Contains(l.HistoriaId)) 
                            historiasDistintas.Add(l.HistoriaId);
                    }
                    //agrego usuario al ranking con la cant de historias distintas que leyo
                    ranking.Add(UsuarioHistoriasRankingsDTOMapper.ToDTO(lectura.Usuario, historiasDistintas.Count)
                    );
                }
            }

            return ranking.OrderByDescending(u => u.CantidadHistoriasCompletadas).ToList();
        }
    }
}
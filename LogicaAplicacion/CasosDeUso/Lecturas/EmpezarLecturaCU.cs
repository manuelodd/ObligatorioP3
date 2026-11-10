using Dominio.Entities;
using Dominio.Enums;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosDeUso.Lecturas;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Lecturas
{
    public class EmpezarLecturaCU : IEmpezarLectura
    {
        private IRepositorioLecturas repositorio;
        private IRepositorioHistorias repositorioH;
        private IRepositorioUsuarios repositorioU;
        public EmpezarLecturaCU(IRepositorioLecturas repo, IRepositorioHistorias repoH, IRepositorioUsuarios repoU)
        {
            repositorio = repo;
            repositorioH = repoH;
            repositorioU = repoU;
        }

        public Lectura Execute(int usuarioId, int historiaId)
        {
            Usuario usuario = repositorioU.FindById(usuarioId);
            if (usuario == null) throw new LecturaException("Usuario no existe.");

            Historia historia = repositorioH.FindById(historiaId);
            if (historia == null) throw new LecturaException("Historia No Existe.");

            if (historia.Estado != EstadoHistoria.PUBLICADA)
                               throw new LecturaException("Historia no publicada.");

            if (historia.CapituloInicial == null)
                            throw new LecturaException("Historia no tiene comienzo.");

            Lectura lectura = new Lectura
            {
                UsuarioId = usuarioId,
                HistoriaId = historiaId,
                FechaInicio = DateTime.Now,
                CapituloActualId = historia.CapituloInicialId
            };

            repositorio.Add(lectura);
            return lectura;
        }
    }
}

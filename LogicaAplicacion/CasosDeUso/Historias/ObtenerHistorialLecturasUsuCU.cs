using Dominio.Entities;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Historias
{
    public class ObtenerHistorialLecturasUsuCU : IObtenerHistorialLecturasUsu
    {
        private IRepositorioLecturas repositorio;

        public ObtenerHistorialLecturasUsuCU(IRepositorioLecturas repo)
        {
            repositorio = repo;
        }

        public List<LecturaHistorialDTO> Execute(int usuarioId, int mes, int anio)
        {
            if (mes < 1 || mes > 12)    throw new LecturaException("Mes ingresado inválido.");

            List<Lectura> lecturas = repositorio.FindAll()
                                                        .Where(l => l.UsuarioId == usuarioId &&
                                                                    l.FechaInicio.Month == mes &&
                                                                    l.FechaInicio.Year == anio)
                                                         .ToList();

            List<LecturaHistorialDTO> historial = new List<LecturaHistorialDTO>();

            foreach (Lectura lec in lecturas)
            {
                historial.Add(new LecturaHistorialDTO
                {
                    TituloHistoria = lec.Historia.Titulo,
                    EstaCompletada = lec.FechaFin != null,
                    TituloCapFinal = lec.FinalAlcanzado?.Titulo
                });
            }

            return historial;
        }
    }
}

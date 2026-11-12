using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Lecturas;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Lecturas
{
    public class ObtenerCapituloLecturaCU : IObtenerCapituloLectura
    {
        private IRepositorioLecturas repositorio;
        public ObtenerCapituloLecturaCU(IRepositorioLecturas repo)
        {
            repositorio = repo;
        }

        public CapituloLecturaDTO Execute(int lecturaId)
        {
            Lectura lectura = repositorio.FindById(lecturaId);

            if (lectura == null) throw new Exception("Lectura no existe.");
            //if (lectura.FechaFin != null) throw new Exception("Lectura terminada.");

            Capitulo capitulo = lectura.CapituloActual;

            CapituloLecturaDTO dto = new CapituloLecturaDTO
            {
                Id = capitulo.Id,
                Titulo = capitulo.Titulo,
                Texto = capitulo.Texto,
                EsFinal = capitulo is Final,
                Opciones = new List<OpcionDTO>()
            };

            if (capitulo is Intermedio intermedio)
            {
                foreach (Opcion opcion in intermedio.Opciones)
                {
                    dto.Opciones.Add(new OpcionDTO {    Id = opcion.Id, 
                                                        Texto = opcion.Texto});
                }
            }
            return dto;
        }
    }
}

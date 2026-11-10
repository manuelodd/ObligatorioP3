using Dominio.Entities;
using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosDeUso.Lecturas;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Lecturas
{

    public class SeguirLecturaCU : ISeguirLectura
    {
        private IRepositorioLecturas repositorioL;
        private IRepositorioOpciones repositorioO;
        private IRepositorioCapitulos repositorioC;

        public SeguirLecturaCU(IRepositorioLecturas repoL,
                                        IRepositorioOpciones repoO,
                                        IRepositorioCapitulos repoC)
        {
            repositorioL = repoL;
            repositorioO = repoO;
            repositorioC = repoC;
        }

        public Lectura Execute(int lecturaId, int opcionId)
        {
            Lectura lectura = repositorioL.FindById(lecturaId);

            if (lectura == null) throw new Exception("No existe la lectura.");
            if (lectura.FechaFin != null) throw new Exception("Esta lectura ya terminó.");
            if (lectura.CapituloActual is not Intermedio) throw new Exception("Haz llegado a un final.");

            Opcion opcion = repositorioO.FindById(opcionId);

            if (opcion == null) throw new Exception("No existe la opción.");
            if (!repositorioC.ExisteOpcionEnCapitulo(opcionId, lectura.CapituloActualId)) throw new Exception("Opción invalida.");

            Capitulo destino = opcion.SiguienteCapitulo;
            lectura.CapituloActualId = destino.Id;

            if (destino is Final final)
            {
                lectura.FechaFin = DateTime.Now;
                lectura.FinalAlcanzadoId = final.Id;
                repositorioC.IncrementarVecesAlcanzado(final.Id);
            }

            repositorioL.Update(lectura);
            return lectura;
        }
    }
}

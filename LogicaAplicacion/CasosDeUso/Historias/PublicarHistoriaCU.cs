using Dominio.Entities;
using Dominio.Enums;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using LogicaAplicacion.InterfacesCasosDeUso.Auditorias;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Historias
{
    public class PublicarHistoriaCU : IPublicarHistoria
    {
        private IRepositorioHistorias repositorio;
        private IRegistrarAuditoria regisAudi;

        public PublicarHistoriaCU(
                                        IRepositorioHistorias repo,
                                        IRegistrarAuditoria regisAu)
        {
            repositorio = repo;
            regisAudi = regisAu;
        }

        public void Execute(int historiaId, int administradorId)
        {
            Historia historia = repositorio.FindById(historiaId);

            if (historia == null)
                throw new HistoriaException("No existe la historia.");

            if (historia.Estado != EstadoHistoria.BORRADOR)
                throw new HistoriaException("La historia ya está publicada.");

            // Validar que todos los capítulos intermedios tengan opciones.
            foreach (Capitulo capitulo in historia.Capitulos)
            {
                if (capitulo is Intermedio intermedio &&
                    intermedio.Opciones.Count == 0)
                {
                    throw new HistoriaException(
                        "Todos los capítulos intermedios deben tener al menos una opción."
                    );
                }
            }
            historia.Estado = EstadoHistoria.PUBLICADA;
            repositorio.Update(historia);

            regisAudi.Execute(historia.Id,administradorId, AccionAuditoria.HISTORIA_PUBLISH
            );
        }
    }
}

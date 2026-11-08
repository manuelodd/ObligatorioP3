using Dominio.Entities;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using LogicaAplicacion.InterfacesCasosDeUso.Auditorias;
using LogicaAplicacion.InterfacesCasosDeUso.Capitulos;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Capitulos
{
    public class EditarCapituloCU : IEditarCapitulo
    {
        private IRepositorioCapitulos repositorio;
        private IRegistrarAuditoria regisAudi;

        public EditarCapituloCU (IRepositorioCapitulos repo,
                                 IRegistrarAuditoria regisAu
                                 )
        {
            repositorio = repo;
            regisAudi = regisAu;
        }

        public void Execute(CapitulosToListDTO dto, int administradorId)
        {
            Capitulo cap = repositorio.FindById(dto.CapId);

            if (cap == null) {
                throw new CapituloException("El capitulo no existe.");
            }

            if(cap.Historia.Estado != Dominio.Enums.EstadoHistoria.BORRADOR)
            {
                throw new CapituloException("Capitulo pertenece a historia publicada, no modificable");
            }

            cap.Texto = dto.CapTexto;
            cap.Titulo = dto.CapTitulo;
            repositorio.Update(cap);

            regisAudi.Execute(cap.HistoriaId, administradorId, Dominio.Enums.AccionAuditoria.CAPITULO_EDIT);
        }
    }
}

using Dominio.Entities;
using Dominio.Enums;
using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using LogicaAccesoDatos.RepositoriosEF.Repositorios;
using LogicaAplicacion.InterfacesCasosDeUso.Capitulos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosDeUso.Capitulos
{
    public class AltaCapituloCU : IAltaCapitulo
    {
        private IRepositorioCapitulos repositorio;
        private IRepositorioHistorias repositorioH;

        public AltaCapituloCU(  IRepositorioCapitulos repo,
                                IRepositorioHistorias repoH)
        {
            repositorio = repo;
            repositorioH = repoH;
        }

        /*
        public void Execute(CapituloAltaDTO dto)
        {
            Historia historia = repositorioH.FindById(dto.HistoriaId);
            Capitulo antecedente = repositorio.FindUltimoCapitulo(dto.HistoriaId);
            Capitulo nuevo;

            if (antecedente is Final) throw new CapituloException("Historia finalizada, imposible agregar capitulos.");

            if (dto.Tipo == 1)
            {
                nuevo = new Intermedio(dto.Titulo, dto.Texto);
            }
            else
            {
                nuevo = new Final
                {
                    Titulo = dto.Titulo,
                    Texto = dto.Texto,
                    CantidadVecesAlcanzado = 0
                };
            }

            Intermedio intermedio = (Intermedio)antecedente;

            Opcion opcion = new Opcion
            {
                Texto = dto.TextoOpcion,
                SiguienteCapitulo = nuevo
            };

            intermedio.Opciones.Add(opcion);
            repositorio.Add(nuevo, opcion);
            
        }
        */

        public void Execute(CapituloAltaDTO dto)
        {
            Historia historia = repositorioH.FindById(dto.HistoriaId);

            if (historia.Estado != EstadoHistoria.BORRADOR)
                                                        throw new CapituloException("Historia publicada, no modificable.");

            Capitulo antecedente = repositorio.FindById(dto.CapituloAntecedenteId);


            //validaciones en caso de recibir un DTO modificado, utilizando la interfaz de usuario son redundantes
            //siempre va a pertenecer a la historia y siempre va a ser intermedio
            if (antecedente.HistoriaId != historia.Id)
                                                        throw new CapituloException("El antecedente no pertenece a la historia.");
            if (antecedente is not Intermedio intermedio)
                                                        throw new CapituloException("El antecedente debe ser intermedio.");
            Capitulo nuevo;

            if (dto.Tipo == 1)
            {
                nuevo = new Intermedio(dto.Titulo, dto.Texto);
            }
            else
            {
                nuevo = new Final
                {
                    Titulo = dto.Titulo,
                    Texto = dto.Texto,
                    CantidadVecesAlcanzado = 0
                };
            }

            Opcion opcion = new Opcion
            {
                Texto = dto.TextoOpcion,
                SiguienteCapitulo = nuevo
            };

            repositorio.AgregarCapitulo(intermedio, nuevo, opcion, historia.Id);
        }

        /*
                 public int HistoriaId { get; set; }
        public int CapituloAntecedenteId { get; set; }
        public int Tipo { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string TextoOpcion { get; set; }*/
    }
}

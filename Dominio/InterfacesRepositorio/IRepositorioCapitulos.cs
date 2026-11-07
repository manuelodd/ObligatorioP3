using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioCapitulos : IRepositorio<Capitulo>
    {
        public void Add(Capitulo capitulo, Opcion opcion);
        public Capitulo FindUltimoCapitulo(int historiaId);
        public List<Intermedio> FindAllAntecedentes(int historiaId);
    }
}

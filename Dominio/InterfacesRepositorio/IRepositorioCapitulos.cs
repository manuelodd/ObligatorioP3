using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioCapitulos : IRepositorio<Capitulo>
    {
        public List<Intermedio> FindAllAntecedentes(int historiaId);
        public void AgregarCapitulo(Intermedio antecedente, Capitulo nuevo, Opcion opcion, int historiaId);
        //public void EditarCapitulo(Capitulo nuevo);
    }
}

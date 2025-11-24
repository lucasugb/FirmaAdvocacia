using Microsoft.AspNetCore.Mvc.Rendering;
using FirmaAdvocacia.Models;
using System.Collections.Generic;

namespace FirmaAdvocacia.ViewModels
{
    public class ProcessoViewModel
    {
        public Processo Processo { get; set; } = new();

        public List<int> ClientesSelecionados { get; set; } = new List<int>();

        public List<SelectListItem> ListaCliente { get; set; } = new();
        public List<int> AdvogadosSelecionados { get; set; } = new List<int>();
        public List<SelectListItem> ListaAdvogado { get; set; } = new();
    }
}


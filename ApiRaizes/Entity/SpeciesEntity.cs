using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRaizes.DTO
{
    public class SpeciesEntity
    {
        public int Id { get; set; }
        public string NomeComum { get; set; }
        public string NomeCientifico { get; set; }
        public string Variedade { get; set; }
        public string EpocaDePlantio { get; set; }
        public string EpocaDeColheita { get; set; }

        public int TempoDeColheita { get; set; }
        public int TipoSoloIdealId { get; set; }
        public decimal IdealUmidadeMin { get; set; }
        public decimal IdealUmidadeMax { get; set; }
        public string Caracteristicas { get; set; }

        public List<string> EpocaDePlantioLista
        {
            get
            {
                return EpocaDePlantio?.Split(',')
                                       .Select(x => x.Trim())
                                       .Where(x => !string.IsNullOrWhiteSpace(x))
                                       .ToList() ?? new List<string>();
            }
        }

        public List<string> EpocaDeColheitaLista
        {
            get
            {
                return EpocaDeColheita?.Split(',')
                                        .Select(x => x.Trim())
                                        .Where(x => !string.IsNullOrWhiteSpace(x))
                                        .ToList() ?? new List<string>();
            }
        }
    }

}
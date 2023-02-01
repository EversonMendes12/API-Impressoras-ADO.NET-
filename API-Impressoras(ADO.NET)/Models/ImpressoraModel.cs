namespace Api_Impressora_ADO.NET.Models
{
    public class ImpressoraModel
    {
        public int ImpressoraID { get; set; }
        public string Nome { get; set; }
        public string? ModeloToner { get; set; }
        public int? RendimentoToner { get; set; }
        public string? Fotocondutor { get; set; }
        public int? RendimentoFotocondutor { get; set; }
        public int? QtdToner { get; set; }
        public int? QtdFoto { get; set; }
        public double? VolumeImpressao { get; set; }
        public decimal? UnitTonerReais { get; set; }
        public decimal? UnitFotoReais { get; set; }
        public decimal? TotalTonerReais { get; set; }
        public decimal? TotalFotoReais { get; set; }

    }
}

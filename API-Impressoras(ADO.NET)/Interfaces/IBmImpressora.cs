using Api_Impressora_ADO.NET.Models;

namespace Api_Impressora_ADO.NET.Interfaces
{
    public interface IBmImpressora
    {

        public List<ImpressoraModel> GetImpressoras();
        public ImpressoraModel GetImpressora(int id);

        public void AddImpressora(ImpressoraModel model);

    }
}

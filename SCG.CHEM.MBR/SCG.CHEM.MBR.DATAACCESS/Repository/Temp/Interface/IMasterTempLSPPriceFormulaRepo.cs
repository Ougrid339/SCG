using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempLSPPriceFormulaRepo : IRepositoryBase<MBR_TMP_LSP_PRICE_FORMULA>
    {
        void Truncate();
    }
}
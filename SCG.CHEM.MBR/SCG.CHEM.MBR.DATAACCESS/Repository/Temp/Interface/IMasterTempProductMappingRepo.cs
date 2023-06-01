using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempProductMappingRepo : IRepositoryBase<MBR_TMP_PRODUCT_MAPPING>
    {
        void Truncate();
    }
}
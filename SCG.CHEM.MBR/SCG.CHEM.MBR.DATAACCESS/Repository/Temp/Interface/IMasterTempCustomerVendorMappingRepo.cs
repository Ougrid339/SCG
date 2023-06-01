using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;

namespace SCG.CHEM.MBR.DATAACCESS.Repository.Temp.Interface
{
    public interface IMasterTempCustomerVendorMappingRepo : IRepositoryBase<MBR_TMP_CUSTOMER_VENDOR_MAPPING>
    {
        void Truncate();
    }
}
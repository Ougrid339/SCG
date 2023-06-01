using System.ComponentModel.DataAnnotations;

namespace SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience
{
    public class DataWitOptienceModel<T1>
    {
        [Required]
        public T1 Criteria { get; set; }

        public List<ValidateFeedPurchaseModel> FeedPurchaseData { get; set; } = new List<ValidateFeedPurchaseModel>();

        public List<ValidateFeedPurchaseModel> FeedPurchaseDataWarnning { get; set; } = new List<ValidateFeedPurchaseModel>();
        public List<ValidateFeedConsumptionModel> FeedConsumptionData { get; set; } = new List<ValidateFeedConsumptionModel>();
        public List<ValidateFeedConsumptionModel> FeedConsumptionDataWarnning { get; set; } = new List<ValidateFeedConsumptionModel>();
        public List<ValidateProductionVolumeModel> ProductionVolumeData { get; set; } = new List<ValidateProductionVolumeModel>();
        public List<ValidateProductionVolumeModel> ProductionVolumeDataWarnning { get; set; } = new List<ValidateProductionVolumeModel>();
        public List<ValidateBeginningInventoryModel> BeginningInventoryData { get; set; } = new List<ValidateBeginningInventoryModel>();
        public List<ValidateBeginningInventoryModel> BeginningInventoryDataWarnning { get; set; } = new List<ValidateBeginningInventoryModel>();

        public long? InterfaceIdFeedPurchase { get; set; }
        public long? InterfaceIdFeedConsumption { get; set; }
        public long? InterfaceIdBeginningInventory { get; set; }
        public long? InterfaceIdProductionVolume { get; set; }
    }

    public class DataWitOptienceDataModel<T1, T2>
    {
        [Required]
        public T1 Criteria { get; set; }

        public List<T2> Data { get; set; } = new List<T2>();

        public long? InterfaceId { get; set; }
    }
}
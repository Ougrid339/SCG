using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Attributes;
using SCG.CHEM.MBR.COMMON.API.AppModels.HistoryType;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Dropdown.Interfaces;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SSPUnitOfWork = SCG.CHEM.SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork;

namespace SCG.CHEM.MBR.COMMON.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiException]
    public class CommonDropdownController : ControllerBase
    {
        private readonly AppSettings _appSetting;
        private readonly UnitOfWork _unit;
        private readonly SSPUnitOfWork _sspUnit;
        private readonly IDropdownService _dropdownService;

        #region Inject
        public CommonDropdownController(AppSettings appSetting, UnitOfWork unit, SSPUnitOfWork sspUnit, IDropdownService dropdownService)
        {
            _appSetting = appSetting;
            _unit = unit;
            _sspUnit = sspUnit;
            _dropdownService = dropdownService;
        }

        #endregion Inject

        #region Common Dropdown
        [HttpGet]
        public ActionResult<CommonResultModel<List<DropdownModel>>> Case()
        {
            var result = _dropdownService.GetCase();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public ActionResult<CommonResultModel<List<DropdownModel>>> Scenario()
        {
            var result = _dropdownService.GetScenario();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public ActionResult<CommonResultModel<List<DropdownModel>>> ScenarioWithActual()
        {
            var result = _dropdownService.GetScenarioWithActual();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public CommonResultModel<MarketPriceForecastMergeScenarioModel> MergeScenarioMarketPriceForecast()
        {
            var result = _dropdownService.GetMergeScenarioMarketPriceForecast();
            return CommonResultModel<MarketPriceForecastMergeScenarioModel>.Success(result, result?.Available?.Count);
        }

        [HttpGet]
        public CommonResultModel<OptienceMergeScenarioModel> MergeScenarioOptience()
        {
            var result = _dropdownService.GetMergeScenarioOptience();
            return CommonResultModel<OptienceMergeScenarioModel>.Success(result, result?.Available?.Count);
        }

        [HttpGet]
        public CommonResultModel<FeedInfoMergeScenarioModel> MergeScenarioFeedInfo()
        {
            var result = _dropdownService.GetMergeScenarioFeedInfo();
            return CommonResultModel<FeedInfoMergeScenarioModel>.Success(result, result?.Available?.Count);
        }

        [HttpGet]
        public CommonResultModel<SalesMergeScenarioModel> MergeScenarioSales()
        {
            var result = _dropdownService.GetMergeScenarioSales();
            return CommonResultModel<SalesMergeScenarioModel>.Success(result, result?.Available?.Count);
        }

        [HttpGet]
        public CommonResultModel<List<DropdownModel>> OptienceType()
        {
            var result = _dropdownService.GetOptienceType();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public CommonResultModel<List<DropdownModel>> OptienceTypeByToken()
        {
            var result = _dropdownService.GetOptienceTypeByToken();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public CommonResultModel<List<DropdownModel>> Company()
        {
            var result = _dropdownService.GetCompany();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public CommonResultModel<List<DropdownModel>> CompanyByToken()
        {
            var result = _dropdownService.GetCompanyByToken();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public CommonResultModel<List<DropdownModel>> HistoryGroup()
        {
            var result = _dropdownService.GetHistoryGroup();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public CommonResultModel<List<HistoryTypeResponse>> HistoryType()
        {
            var result = _dropdownService.GetHistoryType();
            return CommonResultModel<List<HistoryTypeResponse>>.Success(result, result?.Count);
        }

        [HttpGet]
        public CommonResultModel<List<DropdownModel>> FeedNameKey()
        {
            var result = _dropdownService.GetFeedNameKey();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public CommonResultModel<List<DropdownModel>> ProductGroup()
        {
            var result = _dropdownService.GetProductGroup();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public CommonResultModel<List<DropdownModel>> Product()
        {
            var result = _dropdownService.GetProduct();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public CommonResultModel<List<DropdownModel>> FeedGeoCategoryKey()
        {
            var result = _dropdownService.GetFeedGeoCategoryKey();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public CommonResultModel<List<DropdownModel>> Channel()
        {
            var result = _dropdownService.GetChannel();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }

        [HttpGet]
        public CommonResultModel<List<DropdownModel>> GetUserAD()
        {
            var result = _dropdownService.GetUserAD();
            return CommonResultModel<List<DropdownModel>>.Success(result, result?.Count);
        }
        #endregion

    }
}
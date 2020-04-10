using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using KiwoomController;
using AxKHOpenAPILib;

namespace KiwoomCore
{
    public partial class Core : Form
    {
        private KiwoomController.KWController contoroller = new KiwoomController.KWController();
        private HttpClient client = new HttpClient();

        public Uri OnReceiveTrDataUri  { private get; set; }
        public Uri OnReceiveRealDataUri  { private get; set; }
        public Uri OnReceiveMsgUri  { private get; set; }
        public Uri OnReceiveChejanDataUri  { private get; set; }
        public Uri OnEventConnectUri { private get; set; }
        public Uri OnReceiveRealConditionUri  { private get; set; }
        public Uri OnReceiveTrConditionUri  { private get; set; }
        public Uri OnReceiveConditionVerUri  { private get; set; }

        public Core()
        {
            InitializeComponent();
            this.Controls.Add(contoroller);
            contoroller.Dock = DockStyle.Fill;
            contoroller.Api.OnReceiveTrData += OnReceiveTrDataEventHandler;
            contoroller.Api.OnReceiveRealData += OnReceiveRealDataEventHandler;
            contoroller.Api.OnReceiveMsg += OnReceiveMsgEventHandler;
            contoroller.Api.OnReceiveChejanData += OnReceiveChejanDataEventHandler;
            contoroller.Api.OnEventConnect += OnEventConnectEventHandler;
            contoroller.Api.OnReceiveRealCondition += OnReceiveRealConditionEventHandler;
            contoroller.Api.OnReceiveTrCondition += OnReceiveTrConditionEventHandler;
            contoroller.Api.OnReceiveConditionVer += OnReceiveConditionVerEventHandler;
            client.Timeout = new TimeSpan(0, 0, 10);
        }

        public void OnReceiveTrDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (OnReceiveTrDataUri != null)
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
                client.PostAsync(OnReceiveTrDataUri, content);
            }
        }

        public void OnReceiveRealDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            if (OnReceiveRealDataUri != null)
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
                client.PostAsync(OnReceiveRealDataUri, content);
            }
        }

        public void OnReceiveMsgEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e)
        {
            if (OnReceiveMsgUri != null)
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
                client.PostAsync(OnReceiveMsgUri, content);
            }
        }

        public void OnReceiveChejanDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
        {
            if (OnReceiveChejanDataUri != null)
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
                client.PostAsync(OnReceiveChejanDataUri, content);
            }
        }

        public void OnEventConnectEventHandler(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (OnEventConnectUri != null)
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
                client.PostAsync(OnEventConnectUri, content);
            }
        }

        public void OnReceiveRealConditionEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
        {
            if (OnReceiveRealConditionUri != null)
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
                client.PostAsync(OnReceiveRealConditionUri, content);
            }
        }

        public void OnReceiveTrConditionEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
        {
            if (OnReceiveTrConditionUri != null)
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
                client.PostAsync(OnReceiveTrConditionUri, content);
            }
        }

        public void OnReceiveConditionVerEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
        {
            if (OnReceiveConditionVerUri != null)
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
                client.PostAsync(OnReceiveConditionVerUri, content);
            }
        }

        public int CommConnect()
        {
            return this.contoroller.Api.CommConnect();
        }

        public string CommGetData(string sJongmokCode, string sRealType, string sFieldName, int nIndex, string sInnerFieldName)
        {
            return this.contoroller.Api.CommGetData(sJongmokCode, sRealType, sFieldName, nIndex, sInnerFieldName);
        }

        public int CommInvestRqData(string sMarketGb, string sRQName, string sScreenNo)
        {
            return this.contoroller.Api.CommInvestRqData(sMarketGb, sRQName, sScreenNo);
        }

        public int CommKwRqData(string sArrCode, int bNext, int nCodeCount, int nTypeFlag, string sRQName, string sScreenNo)
        {
            return this.contoroller.Api.CommKwRqData(sArrCode, bNext, nCodeCount, nTypeFlag, sRQName, sScreenNo);
        }

        public int CommRqData(string sRQName, string sTrCode, int nPrevNext, string sScreenNo)
        {
            return this.contoroller.Api.CommRqData(sRQName, sTrCode, nPrevNext, sScreenNo);
        }

        public void CommTerminate()
        {
            this.contoroller.Api.CommTerminate();
        }

        public void DisconnectRealData(string sScnNo)
        {
            this.contoroller.Api.DisconnectRealData(sScnNo);
        }

        public string GetActPriceList()
        {
            return this.contoroller.Api.GetActPriceList();
        }

        public string GetAPIModulePath()
        {
            return this.contoroller.Api.GetAPIModulePath();
        }

        public string GetBranchCodeName()
        {
            return this.contoroller.Api.GetBranchCodeName();
        }

        public string GetChejanData(int nFid)
        {
            return this.contoroller.Api.GetChejanData(nFid);
        }

        public string GetCodeListByMarket(string sMarket)
        {
            return this.contoroller.Api.GetCodeListByMarket(sMarket);
        }

        public string GetCommData(string strTrCode, string strRecordName, int nIndex, string strItemName)
        {
            return this.contoroller.Api.GetCommData(strTrCode, strRecordName, nIndex, strItemName);
        }

        public object GetCommDataEx(string strTrCode, string strRecordName)
        {
            return this.contoroller.Api.GetCommDataEx(strTrCode, strRecordName);
        }

        public string GetCommRealData(string sTrCode, int nFid)
        {
            return this.contoroller.Api.GetCommRealData(sTrCode, nFid);
        }

        public int GetConditionLoad()
        {
            return this.contoroller.Api.GetConditionLoad();
        }

        public string GetConditionNameList()
        {
            return this.contoroller.Api.GetConditionNameList();
        }

        public int GetConnectState()
        {
            return this.contoroller.Api.GetConnectState();
        }

        public int GetDataCount(string strRecordName)
        {
            return this.contoroller.Api.GetDataCount(strRecordName);
        }

        public string GetFutureCodeByIndex(int nIndex)
        {
            return this.contoroller.Api.GetFutureCodeByIndex(nIndex);
        }

        public string GetFutureList()
        {
            return this.contoroller.Api.GetFutureList();
        }

        public string GetLoginInfo(string sTag)
        {
            return this.contoroller.Api.GetLoginInfo(sTag);
        }

        public int GetMarketType(string sTrCode)
        {
            return this.contoroller.Api.GetMarketType(sTrCode);
        }

        public string GetMasterCodeName(string sTrCode)
        {
            return this.contoroller.Api.GetMasterCodeName(sTrCode);
        }

        public string GetMasterConstruction(string sTrCode)
        {
            return this.contoroller.Api.GetMasterConstruction(sTrCode);
        }

        public string GetMasterLastPrice(string sTrCode)
        {
            return this.contoroller.Api.GetMasterLastPrice(sTrCode);
        }

        public int GetMasterListedStockCnt(string sTrCode)
        {
            return this.contoroller.Api.GetMasterListedStockCnt(sTrCode);
        }

        public string GetMasterListedStockDate(string sTrCode)
        {
            return this.contoroller.Api.GetMasterListedStockDate(sTrCode);
        }

        public string GetMasterStockState(string sTrCode)
        {
            return this.contoroller.Api.GetMasterStockState(sTrCode);
        }

        public string GetMonthList()
        {
            return this.contoroller.Api.GetMonthList();
        }

        public string GetOptionATM()
        {
            return this.contoroller.Api.GetOptionATM();
        }

        public string GetOptionCode(string strActPrice, int nCp, string strMonth)
        {
            return this.contoroller.Api.GetOptionCode(strActPrice, nCp, strMonth);
        }

        public string GetOptionCodeByActPrice(string sTrCode, int nCp, int nTick)
        {
            return this.contoroller.Api.GetOptionCodeByActPrice(sTrCode, nCp, nTick);
        }

        public string GetOptionCodeByMonth(string sTrCode, int nCp, string strMonth)
        {
            return this.contoroller.Api.GetOptionCodeByMonth(sTrCode, nCp, strMonth);
        }

        public string GetOutputValue(string strRecordName, int nRepeatIdx, int nItemIdx)
        {
            return this.contoroller.Api.GetOutputValue(strRecordName, nRepeatIdx, nItemIdx);
        }

        public int GetRepeatCnt(string sTrCode, string sRecordName)
        {
            return this.contoroller.Api.GetRepeatCnt(sTrCode, sRecordName);
        }

        public string GetSActPriceList(string strBaseAssetGb)
        {
            return this.contoroller.Api.GetSActPriceList(strBaseAssetGb);
        }

        public string GetSFOBasisAssetList()
        {
            return this.contoroller.Api.GetSFOBasisAssetList();
        }

        public string GetSFutureCodeByIndex(string strBaseAssetCode, int nIndex)
        {
            return this.contoroller.Api.GetSFutureCodeByIndex(strBaseAssetCode, nIndex);
        }

        public string GetSFutureList(string strBaseAssetCode)
        {
            return this.contoroller.Api.GetSFutureList(strBaseAssetCode);
        }

        public string GetSMonthList(string strBaseAssetGb)
        {
            return this.contoroller.Api.GetSMonthList(strBaseAssetGb);
        }

        public string GetSOptionATM(string strBaseAssetGb)
        {
            return this.contoroller.Api.GetSOptionATM(strBaseAssetGb);
        }

        public string GetSOptionCode(string strBaseAssetGb, string strActPrice, int nCp, string strMonth)
        {
            return this.contoroller.Api.GetSOptionCode(strBaseAssetGb, strActPrice, nCp, strMonth);
        }

        public string GetSOptionCodeByActPrice(string strBaseAssetGb, string sTrCode, int nCp, int nTick)
        {
            return this.contoroller.Api.GetSOptionCodeByActPrice(strBaseAssetGb, sTrCode, nCp, nTick);
        }

        public string GetSOptionCodeByMonth(string strBaseAssetGb, string sTrCode, int nCp, string strMonth)
        {
            return this.contoroller.Api.GetSOptionCodeByMonth(strBaseAssetGb, sTrCode, nCp, strMonth);
        }

        public string GetThemeGroupCode(string strThemeCode)
        {
            return this.contoroller.Api.GetThemeGroupCode(strThemeCode);
        }

        public string GetThemeGroupList(int nType)
        {
            return this.contoroller.Api.GetThemeGroupList(nType);
        }

        public string KOA_Functions(string sFunctionName, string sParam)
        {
            return this.contoroller.Api.KOA_Functions(sFunctionName, sParam);
        }

        public int SendCondition(string strScrNo, string strConditionName, int nIndex, int nSearch)
        {
            return this.contoroller.Api.SendCondition(strScrNo, strConditionName, nIndex, nSearch);
        }

        public void SendConditionStop(string strScrNo, string strConditionName, int nIndex)
        {
            this.contoroller.Api.SendConditionStop(strScrNo, strConditionName, nIndex);
        }

        public int SendOrder(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sOrgOrderNo)
        {
            return this.contoroller.Api.SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sOrgOrderNo);
        }

        public int SendOrderCredit(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sCreditGb, string sLoanDate, string sOrgOrderNo)
        {
            return this.contoroller.Api.SendOrderCredit(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sCreditGb, sLoanDate, sOrgOrderNo);
        }

        public int SendOrderFO(string sRQName, string sScreenNo, string sAccNo, string sCode, int lOrdKind, string sSlbyTp, string sOrdTp, int lQty, string sPrice, string sOrgOrdNo)
        {
            return this.contoroller.Api.SendOrderFO(sRQName, sScreenNo, sAccNo, sCode, lOrdKind, sSlbyTp, sOrdTp, lQty, sPrice, sOrgOrdNo);
        }

        public int SetInfoData(string sInfoData)
        {
            return this.contoroller.Api.SetInfoData(sInfoData);
        }

        public void SetInputValue(string sID, string sValue)
        {
            this.contoroller.Api.SetInputValue(sID, sValue);
        }

        public int SetOutputFID(string sID)
        {
            return this.contoroller.Api.SetOutputFID(sID);
        }

        public int SetRealReg(string strScreenNo, string strCodeList, string strFidList, string strOptType)
        {
            return this.contoroller.Api.SetRealReg(strScreenNo, strCodeList, strFidList, strOptType);
        }

        public void SetRealRemove(string strScrNo, string strDelCode)
        {
            this.contoroller.Api.SetRealRemove(strScrNo, strDelCode);
        }
    }
}

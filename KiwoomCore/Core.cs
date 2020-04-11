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
using System.Reflection;

namespace KiwoomCore
{
    public partial class Core : Form
    {
        private KiwoomController.KWController contoroller = new KiwoomController.KWController();
        private HttpClient client = new HttpClient();

        public Uri? OnReceiveTrDataUri  { private get; set; }
        public Uri? OnReceiveRealDataUri  { private get; set; }
        public Uri? OnReceiveMsgUri  { private get; set; }
        public Uri? OnReceiveChejanDataUri  { private get; set; }
        public Uri? OnEventConnectUri { private get; set; }
        public Uri? OnReceiveRealConditionUri  { private get; set; }
        public Uri? OnReceiveTrConditionUri  { private get; set; }
        public Uri? OnReceiveConditionVerUri  { private get; set; }

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

        public object? Call(string methodName, object?[]? parameters)
        {
            MethodInfo? methodInfo = typeof(AxKHOpenAPI).GetMethod(methodName);
            if (methodInfo == null)
            {
                return -21; // 메소드가 없음
            }
            else
            {
                try
                {
                    return methodInfo?.Invoke(this.contoroller.Api, parameters);
                }
                catch
                {
                    return -20; // 메소드 실행 실패
                }
            }
        }

        public int AddUri(string eventName, string uriString)
        {
            Uri uri;
            if (uriString == null)
            {
                return -32; // Uri가 없음
            }
            else
            {
                try
                {
                    uri = new Uri(uriString);
                }
                catch
                {
                    return -33; // Uri 변환 실패
                }
            }
            switch (eventName)
            {
                case "OnReceiveTrData":
                    OnReceiveTrDataUri = uri;
                    break;
                case "OnReceiveRealData":
                    OnReceiveRealDataUri = uri;
                    break;
                case "OnReceiveMsg":
                    OnReceiveMsgUri = uri;
                    break;
                case "OnReceiveChejanData":
                    OnReceiveChejanDataUri = uri;
                    break;
                case "OnEventConnect":
                    OnEventConnectUri = uri;
                    break;
                case "OnReceiveRealCondition":
                    OnReceiveRealConditionUri = uri;
                    break;
                case "OnReceiveTrCondition":
                    OnReceiveTrConditionUri = uri;
                    break;
                case "OnReceiveConditionVer":
                    OnReceiveConditionVerUri = uri;
                    break;
                default:
                    return -31; // 이벤트가 없음
            }
            return 0;
        }
    }
}

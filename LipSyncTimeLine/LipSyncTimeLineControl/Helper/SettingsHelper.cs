using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using LipSyncTimeLineControl.Models;
using Newtonsoft.Json;

namespace LipSyncTimeLineControl.Helper
{
    public static class SettingsHelper
    {
        private static string _dirSettingsName = Application.StartupPath + @"\Settings\";

        public static string DirSettingsName
        {
            get
            {
                if (!Directory.Exists(_dirSettingsName))
                    Directory.CreateDirectory(_dirSettingsName);

                return _dirSettingsName;
            }
            set => _dirSettingsName = value;
        }

        private const string ExpressionTemplateFileName = @"ExpressionTemplate.json";

        public static string ExpressionTemplateFullFileName => DirSettingsName + ExpressionTemplateFileName;

        public static bool IsSaveProcess { get; set; }

        public static Dictionary<string, ExpressionTimelineTrack> LoadExpressionTemplate()
        {
            while (IsSaveProcess)
                Debug.WriteLine("IsSaveProcess");
        
            using (StreamReader sr = new StreamReader(ExpressionTemplateFullFileName))
            {
                string jsonStr = sr.ReadToEnd();
                Dictionary<string, ExpressionTimelineTrack> expressionTemplateDic = JsonConvert.DeserializeObject<Dictionary<string, ExpressionTimelineTrack>>(jsonStr);
                return expressionTemplateDic;
            }
        }
    }
}

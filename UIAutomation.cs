using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UCNLUI
{
    public class UIAutomation
    {
        #region Properties

        Regex wsRemover = new Regex(@"\s+");
        Dictionary<string, Action<string>> uiActions;
        public static readonly string LogID = "UI_ACTION";

        #endregion

        #region Constructor

        public UIAutomation()
        {
            uiActions = new Dictionary<string, Action<string>>();
        }

        #endregion

        #region Methods

        public void Clear()
        {
            uiActions.Clear();
        }

        public void PerformUIAction(string uiAction)
        {
            if (uiActions.ContainsKey(uiAction))
                uiActions[uiAction](string.Empty);
            else
            {
                var splits = uiAction.Split('=');
                if (splits.Length == 2)
                {
                    if (uiActions.ContainsKey(splits[0]))
                        uiActions[splits[0]](splits[1]);
                }
            }
        }

        public void InitIntProperty<T>(object o, string property) where T : class
        {
            PropertyInfo pInfo = typeof(T).GetProperty(property, BindingFlags.NonPublic | BindingFlags.Instance);
            if (pInfo != null)
            {
                uiActions.Add(property, x => pInfo.SetValue(o, int.Parse(x)));
            }
        }

        public void InitBoolProperty<T>(object o, string property) where T : class
        {
            PropertyInfo pInfo = typeof(T).GetProperty(property, BindingFlags.NonPublic | BindingFlags.Instance);
            if (pInfo != null)
            {
                uiActions.Add(string.Format("{0}=True", property), delegate { pInfo.SetValue(o, true); });
                uiActions.Add(string.Format("{0}=False", property), delegate { pInfo.SetValue(o, false); });
            }
        }

        public string GetBoolPropertyStateLogString<T>(object o, string property) where T : class
        {
            PropertyInfo pInfo = typeof(T).GetProperty(property, BindingFlags.NonPublic | BindingFlags.Instance);

            if (pInfo != null)
            {
                return string.Format("{0}: {1}={2}", LogID, property, pInfo.GetValue(o));
            }
            else
                throw new KeyNotFoundException();
        }

        public string GetPropertyStateLogString<T>(object o, string property)
        {
            PropertyInfo pInfo = typeof(T).GetProperty(property, BindingFlags.NonPublic | BindingFlags.Instance);

            if (pInfo != null)
            {
                return string.Format("{0}: {1}={2}", LogID, property, pInfo.GetValue(o));
            }
            else
                throw new KeyNotFoundException();
        }

        #endregion
    }
}

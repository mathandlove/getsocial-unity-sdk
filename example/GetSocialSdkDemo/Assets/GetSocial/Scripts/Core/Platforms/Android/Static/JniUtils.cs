#if UNITY_ANDROID
using System;
using UnityEngine;
using System.Collections.Generic;
using GetSocialSdk.MiniJSON;

namespace GetSocialSdk.Core
{
    public static class JniUtils
    {
        static AndroidJavaObject _activity;

        public static AndroidJavaObject Activity
        {
            get { return _activity ?? (_activity = GetMainActivity()); }
        }

        public static AndroidJavaObject GetMainActivity()
        {
            var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            return activity;
        }

        public static void RunOnUiThread(Action action)
        {
            Activity.Call("runOnUiThread", new AndroidJavaRunnable(action));
        }

        /// <summary>
        /// Run on UI thread whicle catching all exceptions
        /// </summary>
        /// <param name="action"></param>
        /// <returns>true if there was not exception, false otherwise</returns>
        public static bool RunOnUiThreadSafe(Action action)
        {
            try
            {
                RunOnUiThread(action);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void CheckIfClassIsCorrect(AndroidJavaObject ajo, string expectedSimpleClassName)
        {
            var actualSimpleClassName = ajo.GetClassSimpleName();
            if (actualSimpleClassName != expectedSimpleClassName)
            {
                throw new InvalidOperationException(string.Format(
                    "This AndroidJavaObject is not {0}, it is {1}!", expectedSimpleClassName, actualSimpleClassName));
            }
        }

        public static AndroidJavaObject NewJavaThrowable(string message)
        {
            return new AndroidJavaObject("java.lang.Throwable", message);
        }

        public static AndroidJavaObject NewJavaGetSocialException(int errorCode, string message)
        {
            return new AndroidJavaObject("im.getsocial.sdk.core.exception.GetSocialException", errorCode, message);
        }

        public static string FromLocalizableText(this AndroidJavaObject localizableTextAJO)
        {
            if (localizableTextAJO.IsJavaNull())
            {
                return null;
            }

            CheckIfClassIsCorrect(localizableTextAJO, "LocalizableText");

            using (localizableTextAJO)
            {
                return localizableTextAJO.CallStr("getLocalisedString");
            }
        }

        public static bool IsJavaNull(this AndroidJavaObject ajo)
        {
            return ajo == null || ajo.GetRawObject().ToInt32() == 0;
        }

        #region collections

        const string JavaHashMapClass = "java.util.HashMap";

        public static AndroidJavaObject ToJavaHashMap<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            var objHashMap = new AndroidJavaObject(JavaHashMapClass);

            foreach (var keyValuePair in dictionary)
            {
                objHashMap.CallStr("put", keyValuePair.Key, keyValuePair.Value);
            }

            return objHashMap;
        }

        public static Dictionary<string, string> FromJavaHashMap(this AndroidJavaObject javaHashMap)
        {
            if (javaHashMap == null)
            {
                return new Dictionary<string, string>();
            }

            if (javaHashMap.IsJavaNull())
            {
                return new Dictionary<string, string>();
            }

            int size = javaHashMap.CallInt("size");
            var dictionary = new Dictionary<string, string>(size);

            var iterator = javaHashMap.CallAJO("keySet").CallAJO("iterator");
            while (iterator.CallBool("hasNext"))
            {
                string key = iterator.CallStr("next");
                string value = javaHashMap.CallStr("get", key);
                dictionary.Add(key, value);
            }

            javaHashMap.Dispose();
            return dictionary;
        }

        public static List<AndroidJavaObject> FromJavaList(this AndroidJavaObject javaList)
        {
            var list = new List<AndroidJavaObject>();
            using (javaList)
            {
                using (var iterator = javaList.CallAJO("iterator"))
                {
                    while (iterator.CallBool("hasNext"))
                    {
                        var item = iterator.CallAJO("next");
                        list.Add(item);
                    }    
                }
                
            }
            return list;
        }

        #endregion

        public static string GetErrorMsg(this AndroidJavaObject throwable)
        {
            return throwable.CallStr("getMessage");
        }

        public static GetSocialError ToGetSocialError(this AndroidJavaObject getSocialExceptionAJO)
        {
            return new GetSocialError().ParseFromAJO(getSocialExceptionAJO);
        }

        public static string GetClassName(this AndroidJavaObject ajo)
        {
            return ajo.GetJavaClass().Call<string>("getName");
        }

        public static string GetClassSimpleName(this AndroidJavaObject ajo)
        {
            return ajo.GetJavaClass().Call<string>("getSimpleName");
        }

        public static AndroidJavaObject GetJavaClass(this AndroidJavaObject ajo)
        {
            return ajo.CallAJO("getClass");
        }

        public static string JavaToString(this AndroidJavaObject ajo)
        {
            return ajo.Call<string>("toString");
        }

        public static Texture2D FromAndroidBitmap(this AndroidJavaObject bitmapAJO)
        {
            if (!bitmapAJO.IsJavaNull())
            {
                return new AndroidJavaClass("im.getsocial.sdk.unity.BitmapFactory")
                    .CallStaticStr("encodeBase64", bitmapAJO).FromBase64();
            }
            return null;
        }

        public static AndroidJavaObject ToAjoBitmap(this Texture2D texture2D)
        {
            return new AndroidJavaClass("im.getsocial.sdk.unity.BitmapFactory").CallStaticAJO("decodeBase64", texture2D.TextureToBase64());
        }
    }
}

#endif
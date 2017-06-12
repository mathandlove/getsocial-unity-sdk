﻿#if UNITY_IOS && USE_GETSOCIAL_UI
using System;
using AOT;
using GetSocialSdk.Core;

namespace GetSocialSdk.Ui
{
    delegate void AvatarClickListenerDelegate(IntPtr avatarClickListenerPtr, string serializedPublicUser);

    public static class AvatarClickListenerCallback
    {
        [MonoPInvokeCallback(typeof(AvatarClickListenerDelegate))]
        public static void OnAvatarClicked(IntPtr onAvatarClickedPtr, string serializedPublicUser)
        {
            GetSocialDebugLogger.D(string.Format("OnAvatarClicked for user {0}", serializedPublicUser));

            if (onAvatarClickedPtr != IntPtr.Zero)
            {
                var publicUser = new PublicUser().ParseFromJson(serializedPublicUser);
                onAvatarClickedPtr.Cast<Action<PublicUser>>().Invoke(publicUser);
            }
        }
    }
}
#endif
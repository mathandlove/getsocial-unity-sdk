using System;

#if UNITY_ANDROID
using UnityEngine;
#endif

#if UNITY_IOS
using System.Collections.Generic;
#endif

namespace GetSocialSdk.Core
{
    /// <summary>
    ///  Stores information about a way to send an invite and how it should be presented in a list.
    /// </summary>
    public sealed class InviteChannel : IGetSocialBridgeObject<InviteChannel>
    {
        /// <summary>
        /// Gets the invite channel identifier.
        /// </summary>
        /// <value>The invite channel identifier.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the invite channel name.
        /// </summary>
        /// <value>The invite channel name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the invite channel icon image URL.
        /// </summary>
        /// <value>The invite channel icon image URL.</value>
        public string IconImageUrl { get; private set; }

        /// <summary>
        /// Gets invite channel the display order as configured on GetSocial Dashboard.
        /// </summary>
        /// <value>The invite channel the display order as configured on GetSocial Dashboard.</value>
        public int DisplayOrder { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this invite channel is enabled on GetSocial Dashboard.
        /// </summary>
        /// <value><c>true</c> if this invite channel is enabled on GetSocial Dashboard; otherwise, <c>false</c>.</value>
        public bool IsEnabled { get; private set; }

        /// <summary>
        /// Gets the content of the invite.
        /// </summary>
        /// <value>The content of the invite.</value>
        public InviteContent InviteContent { get; private set; }

        public override string ToString()
        {
            return
                string.Format(
                    "[InviteChannel: Id={0}, Name={1}, IconImageUrl={2}, DisplayOrder={3}, IsEnabled={4}, InviteContent={5}]",
                    Id, Name, IconImageUrl, DisplayOrder, IsEnabled, InviteContent);
        }

#if UNITY_ANDROID
        public AndroidJavaObject ToAJO()
        {
            throw new NotImplementedException();
        }

        public InviteChannel ParseFromAJO(AndroidJavaObject ajo)
        {
            JniUtils.CheckIfClassIsCorrect(ajo, "InviteChannel");

            using (ajo)
            {
                Id = ajo.CallStr("getChannelId");
                Name = ajo.CallAJO("getName").FromLocalizableText();
                IconImageUrl = ajo.CallStr("getIconImageUrl");
                DisplayOrder = ajo.CallInt("getDisplayOrder");
                IsEnabled = ajo.CallBool("isEnabled");
                InviteContent = new InviteContent().ParseFromAJO(ajo.CallAJO("getInviteContent"));
                return this;
            }
        }
#elif UNITY_IOS
        public string ToJson()
        {
            throw new NotImplementedException("Invite Channel is only received from iOS");
        }
        
        public InviteChannel ParseFromJson(Dictionary<string, object> jsonDic)
        {
            Id = jsonDic["Id"] as string;
            Name = jsonDic["Name"] as string;
            IconImageUrl = jsonDic["IconImageUrl"] as string;
            DisplayOrder = (int) (long) jsonDic["DisplayOrder"];
            IsEnabled = (bool) jsonDic["IsEnabled"];

            var inviteContent = jsonDic["InviteContent"] as Dictionary<string, object>;
            InviteContent = new InviteContent().ParseFromJson(inviteContent);

            return this;
        }
#endif
    }
}
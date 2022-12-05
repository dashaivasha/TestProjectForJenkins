using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace JsonplaceholderTypicodeTests.Constants
{
    public static class Keys
    {
        public enum DataKey
        {
            [Description("Url")]
            Url,
            [Description("NotExistingPostId")]
            NotExistingPostId,
            [Description("userIdForPostPost")]
            userIdForPostPost,
            [Description("RandomStringLength")]
            RandomStringLength,
            [Description("ContentType")]
            ContentType,
        }

        public static string GetDescription(this Enum genericEnum)
        {
            var genericEnumType = genericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(genericEnum.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Count() > 0)
                {
                    return ((DescriptionAttribute)attributes.ElementAt(0)).Description;
                }
            }

            return genericEnum.ToString();
        }

    }
}

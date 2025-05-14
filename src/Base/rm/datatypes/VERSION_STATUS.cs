using System.Runtime.Serialization;

namespace Base.rm.datatypes
{
    public enum VERSION_STATUS
    {
        /// <summary>
        /// Value representing a version which is 'unstable', i.e. contains an unknown size of change with
        /// respect to its base version. Rendered with the build number as a string in the form "N.M.P-alpha.B"
        /// e.g. "2.0.1-alpha.154".
        /// </summary>
        [EnumMember(Value = "alpha")]
        Alpha,

        /// <summary>
        /// Value representing a version which is 'beta', i.e. contains an unknown but reducing size of change
        /// with respect to its base version. Rendered with the build number as a string in the form "N.M.P-beta.B"
        /// e.g. "2.0.1-beta.154".
        /// </summary>
        [EnumMember(Value = "beta")]
        Beta,

        /// <summary>
        /// Value representing a version which is 'release candidate', i.e. contains only patch-level changes on
        /// the base version. Rendered as a string as "N.M.P-rc.B" e.g. "2.0.1-rc.27".
        /// </summary>
        [EnumMember(Value = "rc")]
        ReleaseCandidate,

        /// <summary>
        /// Value representing a version which is 'released', i.e. is the definitive base version. Rendered with the
        /// build number as a string in the form "N.M.P" e.g. "2.0.1".
        /// </summary>
        [EnumMember(Value = "")]
        Released,

        /// <summary>
        /// Value representing a version which is a build of the current base release. Rendered with the build number
        /// as a string in the form "N.M.P+B" e.g. "2.0.1+33".
        /// </summary>
        [EnumMember(Value = "+")]
        Build
    }

    public static class VersionStatusExtensions
    {
        private static readonly Dictionary<VERSION_STATUS, string> _values = new Dictionary<VERSION_STATUS, string>
    {
        { VERSION_STATUS.Alpha, "alpha" },
        { VERSION_STATUS.Beta, "beta" },
        { VERSION_STATUS.ReleaseCandidate, "rc" },
        { VERSION_STATUS.Released, "" },
        { VERSION_STATUS.Build, "+" }
    };

        public static string GetValue(this VERSION_STATUS versionStatus)
        {
            return _values[versionStatus];
        }

        public static VERSION_STATUS FromString(string value)
        {
            if (value.StartsWith("-"))
            {
                value = value.Substring(1);
            }

            foreach (var pair in _values)
            {
                if (pair.Value == value)
                {
                    return pair.Key;
                }
            }

            throw new ArgumentException($"Unknown String value: {value}");
        }
    }
}

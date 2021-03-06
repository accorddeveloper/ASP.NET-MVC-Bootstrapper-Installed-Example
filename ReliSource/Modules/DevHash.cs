﻿using System.Text;

namespace ReliSource.Modules {
    public static class DevHash {
        /// <summary>
        ///     Checks nulls and returns only codes for existing ones.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string Get(params object[] o) {
            var sb = new StringBuilder(10);
            sb.Clear();

            for (var i = 0; o[i] != null && i < o.Length; i++) {
                sb.AppendLine(o[i].GetHashCode() + "_");
            }
            return sb.ToString();
        }
    }
}
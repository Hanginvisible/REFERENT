using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// class extension
/// </summary>
/// created by: ntkien5 07.02.2020
namespace CMCLIS.GATEWAY.CORE
{
    public static class ExtensionClass
    {
        /// <summary>
        /// hàm dùng để compare string mà không cần kiểm tra null
        /// Lưu ý: không phân biệt hoa thường. đối tượng so sánh hoặc giá trị nếu bằng null thì chuyển về string.empty rồi so sánh
        /// </summary>
        /// <param name="obj">đối tượng so sánh</param>
        /// <param name="value">giá trị so sánh</param>
        /// <returns>True: nếu giống nhau</returns>
        /// created by: ntkien5 07.02.2020
        public static bool EqualsValue(this string obj,string value)
        {
            if (string.IsNullOrWhiteSpace(obj)) obj = "";
            if (string.IsNullOrWhiteSpace(value)) value = "";
            return obj.Trim().Equals(value.Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }
}

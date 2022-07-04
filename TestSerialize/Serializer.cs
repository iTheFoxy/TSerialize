using System;
using System.Text;

namespace Serialize
{
    public class Serializer
    {
        public static T Deserialize<T>(string s)
        {
            var obj = Activator.CreateInstance(typeof(T));
            foreach (var item in s.Split('\n'))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    var type = obj.GetType().GetProperty(item.Split('=')[0]).PropertyType;
                    var value = Convert.ChangeType(item.Split('=')[1], type);
                    obj.GetType().GetProperty(item.Split('=')[0]).SetValue(obj, value);
                }
            }
            return (T)obj;
        }
        public static string Serialize<T>(T obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var a = obj.GetType().GetProperties();
            foreach (var item in a)
            {
                stringBuilder.Append(item.Name + "=" + item.GetValue(obj) + '\n');
            }
            return stringBuilder.ToString();
        }
    }
}

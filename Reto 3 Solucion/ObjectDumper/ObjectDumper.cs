using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDumper
{
    public class ObjectDumper<T>
    {

        private readonly Dictionary<string, Delegate> _templates;

        public ObjectDumper()
        {
            _templates = new Dictionary<string, Delegate>();
        }

        public void AddTemplateFor<TR>(Expression<Func<T, TR>> propExp, Func<TR, string> template)
        {
            var property = propExp.AsPropertyInfo();
            if (property == null)
            {
                return;
            }
            _templates.Add(property.Name, template);

        }

        public IEnumerable<KeyValuePair<string, string>> Dump(T data)
        {

            if (((object)data) == null ) yield break;

            var dataType = data.GetType();
            foreach (var property in dataType.GetProperties().Where(p => p.CanRead).OrderBy(p=>p.Name))
            {
                var template = _templates.ContainsKey(property.Name) ? _templates[property.Name] : null;
                if (template != null)
                {
                    yield return ApplyTemplateForProperty(property, data, template);
                }
                else yield return ApplyStandardDumpForProperty(property, data);
            }
        }

        private KeyValuePair<string, string> ApplyTemplateForProperty(PropertyInfo property, T data, Delegate template)
        {
            var value = property.GetValue(data);
            return new KeyValuePair<string, string>(property.Name, template.DynamicInvoke(value) as string);
        }

        private KeyValuePair<string, string> ApplyStandardDumpForProperty(PropertyInfo property, T data)
        {
            var value = property.GetValue(data);
            return new KeyValuePair<string, string>(property.Name, Convert.ToString(value));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleObjectMapper
{
    public static class SimpleObjectMapperExtensions
    {
        public static T MapObject<L, T>(this L model)
        {
            var viewModelDestination = Activator.CreateInstance<T>();
            var viewModelPropertyNames = viewModelDestination.GetType().GetProperties().Select(x => x.Name);
            var modelPropertyNames = model.GetType().GetProperties().Select(x => x.Name);
            var namesInCommon = viewModelPropertyNames.Intersect(modelPropertyNames);
            foreach (var propertyName in namesInCommon)
            {
                //check type before setting value.. maybe also canread,canwrite
                viewModelDestination.GetType().GetProperty(propertyName).SetValue(viewModelDestination, model.GetType().GetProperty(propertyName).GetValue(model));
            }
            return viewModelDestination;
        }
    }
}

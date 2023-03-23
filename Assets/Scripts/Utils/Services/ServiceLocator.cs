using System;
using System.Collections.Generic;

namespace TestTask100HPGames.Utils.Services
{
    public class ServiceLocator<T> : IServiceLocator<T>
    {
        protected Dictionary<Type, T> _itemsMap { get; }

        public ServiceLocator()
        {
            _itemsMap = new Dictionary<Type, T>();
        }

        public virtual TP Register<TP>(TP newService) where TP : T
        {
            var type = newService.GetType();

            if (_itemsMap.ContainsKey(type))
            {
                throw new Exception($"Can't add item of type {type}. This type already exists in this service locator");
            }

            _itemsMap[type] = newService;

            return newService;
        }

        public void Unregister<TP>(TP service) where TP : T
        {
            var type = service.GetType();

            if (_itemsMap.ContainsKey(type))
            {
                _itemsMap.Remove(type);
            }
        }

        public TP Get<TP>() where TP : T
        {
            var type = typeof(TP);

            if (!_itemsMap.ContainsKey(type))
            {
                throw new Exception($"There is no item of type {type} in this service locator");
            }

            return (TP)_itemsMap[type];
        }
    }
}

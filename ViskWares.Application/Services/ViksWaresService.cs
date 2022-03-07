using System.Collections.Generic;
using ViksWares.Application.Factories;
using ViksWares.Contract.Services;
using ViksWares.Domain.Models;

namespace ViksWares.Application
{   
    public class ViksWaresService : IViksWaresService
    {
        private readonly IList<Item> _items;
        private readonly ItemHandlersFactory _itemHandlersFactory;

        public ViksWaresService(IList<Item> items) : this(items, new ItemHandlersFactory())
        {
        }

        private ViksWaresService(IList<Item> items, ItemHandlersFactory factory)
        {
            _items = items;
            _itemHandlersFactory = factory;
        }

        public void UpdateValue()
        {
            foreach (var t in _items)
            {
                var handler = _itemHandlersFactory.CreateHandler(t.Name);

                handler.UpdateItem(t);
            }
        }
    }
}

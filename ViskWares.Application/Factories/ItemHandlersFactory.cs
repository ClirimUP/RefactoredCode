using System.Collections.Generic;
using ViksWares.Application.Handlers;
using ViksWares.Contract.Handlers;

namespace ViksWares.Application.Factories
{
    public class ItemHandlersFactory
    {
        private readonly Dictionary<string, IItemHandler> _handlers;

        public ItemHandlersFactory()
        {
            _handlers = new Dictionary<string, IItemHandler>
            {
                { "default", new DefaultHandler() },
                { "Aged Parmigiano", new AgedParmigianoHandler() },
                { "Saffron Powder", new SaffronPowderHandler() },
                { "Concert tickets to Talkins Festival", new ConcertTicketsToTalkinsFestivalHandler() },
                { "Refrigerated milk", new RefrigeratedMilkHandler() }
            };
        }

        public IItemHandler CreateHandler(string name)
        {
            return _handlers.TryGetValue(name, out var handler) ? handler : _handlers["default"];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ViksWares.Contract.Handlers;

namespace ViksWares.Application.Factories
{
    public class ItemHandlersFactory
    {
        private readonly Dictionary<string, IItemHandler> _handlers;
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ViksWares.Domain.Models;

namespace ViksWares.Contract.Handlers
{
    public interface IItemHandler
    {
        void UpdateItem(Item item);
    }
}

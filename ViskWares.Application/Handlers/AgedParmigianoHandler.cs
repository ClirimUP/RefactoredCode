using System;
using System.Collections.Generic;
using System.Text;
using ViksWares.Contract.Handlers;
using ViksWares.Domain.Models;

namespace ViksWares.Application.Handlers
{
    public class AgedParmigianoHandler : IItemHandler
    {
        public void UpdateItem(Item item)
        {
            if (item.Value < 50)
            {
                item.Value += 1;
            }

            item.SellBy -= 1;

            if (item.SellBy < 0 && item.Value < 50)
            {
                item.Value += 1;
            }
        }
    }
}

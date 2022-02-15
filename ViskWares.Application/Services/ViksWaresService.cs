using System.Collections.Generic;
using ViksWares.Domain;
using ViksWares.Domain.Models;

namespace ViksWares.Application
{   
    public class ViksWaresService
    {
        IList<Item> Items;
        public ViksWaresService(IList<Item> Items)
        {
            this.Items = Items;
        }

        private void CalculatePhaseOne(Item item, int size)
        {
            if (item.Name != "Aged Parmigiano" && item.Name != "Concert tickets to Talkins Festival" && item.Value > 0 && item.Name != "Saffron Powder")
            {
                item.Value = item.Value - 1;
                if (item.Name == "Refrigerated milk")
                {
                    item.Value -= 1;

                    if (item.SellBy <= 0)
                    {
                        item.Value -= 1;
                    }
                }
            }
            else
            {
                if(item.Value < 50 && item.Name != "Saffron Powder") { 
                item.Value += 1;

                    if (item.Name != "Concert tickets to Talkins Festival") return;
                    if (item.SellBy < 11 && item.Value < 50)
                    {
                        item.Value += 1;
                    }

                    if (item.SellBy >= 6) return;
                    if (item.Value < 50)
                    {
                        item.Value += 1;
                    }
                }
            }
        }

        public void CalculatePhaseTwo(Item item)
        {
            if(item.SellBy < 0)
            { 
                if (item.Name != "Aged Parmigiano")
                {
                    if (item.Name != "Concert tickets to Talkins Festival")
                    {
                        if (item.Value <= 0) return;

                        if (item.Name != "Saffron Powder")
                        {
                            item.Value -= 1;
                        }
                    }
                    else
                    {
                        item.Value -= item.Value;
                    }
                }
                else
                {
                    if (item.Value < 50)
                    {
                        item.Value += 1;
                    }
                }
            }
        }
        
        public void UpdateValue()
        
        {
            foreach (var t in Items)
            {
                CalculatePhaseOne(t, Items.Count);
                
                if (t.Name != "Saffron Powder")
                {
                    t.SellBy -= 1;
                }

                CalculatePhaseTwo(t);
            }
        }
    }
}

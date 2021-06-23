using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (WillDecreaseQuality(i))
                    Items[i].Quality = Items[i].Quality - 1;
                
                else if (Items[i].Quality < 50)
                    IncreaseQuality(i);
                

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }


                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }

            }
        }

        private void IncreaseQuality(int i)
        {
            Items[i].Quality += 1;
            if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (WillIncreaseQualityCase1(i))
                    Items[i].Quality += 1;

                if (WillIncreaseQualityCase2(i))
                    Items[i].Quality += 1;
            }
        }

        private bool WillIncreaseQualityCase2(int i)
        {
            return Items[i].SellIn < 6 && Items[i].Quality < 50;
        }

        private bool WillIncreaseQualityCase1(int i)
        {
            return Items[i].SellIn < 11 && Items[i].Quality < 50;
        }

        private bool WillDecreaseQuality(int i)
        {
            return Items[i].Name != "Aged Brie" && 
                   Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" && 
                   Items[i].Quality > 0 && 
                   Items[i].Name != "Sulfuras, Hand of Ragnaros";
        }
    }
}

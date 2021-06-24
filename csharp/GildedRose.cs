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
                ChangeQualityCase1(Items[i]);
                
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    Items[i].SellIn -= 1;

                if (Items[i].SellIn < 0)
                    ChangeQualityCase2(Items[i]);
            }
        }

        private void ChangeQualityCase2(Item item)
        {
            if (item.Name != "Aged Brie")
            {
                if (WillDecreaseQualityCase2(item))
                    item.Quality -= 1;
                else
                    item.Quality = 0;
            }
            else if (item.Quality < 50)
                item.Quality += 1;
        }

        private bool WillDecreaseQualityCase2(Item item)
        {
            return item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros" && item.Name != "Backstage passes to a TAFKAL80ETC concert";
        }

        private void ChangeQualityCase1(Item item)
        {
            if (WillDecreaseQualityCase1(item))
                item.Quality -= 1;

            else if (item.Quality < 50)
                IncreaseQuality(item);
        }

        private void IncreaseQuality(Item item)
        {
            item.Quality += 1;
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (WillIncreaseQualityCase1(item))
                    item.Quality += 1;

                if (WillIncreaseQualityCase2(item))
                    item.Quality += 1;
            }
        }

        private bool WillIncreaseQualityCase2(Item item)
        {
            return item.SellIn < 6 && item.Quality < 50;
        }

        private bool WillIncreaseQualityCase1(Item item)
        {
            return item.SellIn < 11 && item.Quality < 50;
        }

        private bool WillDecreaseQualityCase1(Item item)
        {
            return item.Name != "Aged Brie" &&
                   item.Name != "Backstage passes to a TAFKAL80ETC concert" &&
                   item.Quality > 0 &&
                   item.Name != "Sulfuras, Hand of Ragnaros";
        }
    }
}

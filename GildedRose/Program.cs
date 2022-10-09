﻿namespace GildedRose;

public class Program
{
    public IList<Item>? Items;
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        var app = new Program()
        {
            Items = new List<Item>{
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10,Quality = 49},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5,Quality = 49},
                // this conjured item does not work properly yet
                new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            }
        };

        for (var i = 0; i < 31; i++)
        {
            Console.WriteLine(String.Format("-------- day {0} --------", i));   
            Console.WriteLine("name, sellIn, quality");
            foreach (Item item in app.Items)
            {
                Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }

    internal int increase(int start, int extra = 1){
        return Math.Min(50, start+extra);
    }

    internal int decrease(int start, int less = 1){
        return Math.Max(0, start-less);
    }

    public void UpdateQuality()
    {
        foreach (Item active in Items!)
        {
            bool isBrie = active.Name == "Aged Brie"; 
            bool isBackstage = active.Name == "Backstage passes to a TAFKAL80ETC concert";
            bool isSulfuras = active.Name == "Sulfuras, Hand of Ragnaros";
            bool isStandardItem = !isBrie && !isBackstage;

            if(isSulfuras)
            {
                return;
            }

            if(active.Quality > 50){
                active.Quality = 50;
            }

            if(active.Quality < 0){
                active.Quality = 0;
            }

            if (isStandardItem)
            {
                active.Quality = decrease(active.Quality);
            }
            else
            {
                active.Quality = increase(active.Quality);

                if (isBackstage)
                {
                    if (active.SellIn < 11)
                    {
                       active.Quality = increase(active.Quality);
                    }

                    if (active.SellIn < 6)
                    {
                       active.Quality = increase(active.Quality);
                    }
                }
            }
            
            active.SellIn--;

            if (active.SellIn < 0)
            {
                if(isBrie)
                {
                    active.Quality = increase(active.Quality);
                    return;
                }

                if(isBackstage)
                {
                    active.Quality = 0;
                    return;
                }

                active.Quality = decrease(active.Quality);
            }
        }
    }
}


public class Item
{
    public string? Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }
}


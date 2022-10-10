namespace GildedRose;

public class Program
{
    public IList<Item>? Items;
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        var app = new Program()
        {
            Items = new List<Item>{
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
                // this conjured item does not work properly yet
                new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
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

    internal int increase(int start, int addition = 1){
        return Math.Min(50, start+addition);
    }

    internal int decrease(int start, int subtraction = 1){
        return Math.Max(0, start-subtraction);
    }

    public void UpdateQuality()
    {
        foreach (Item item in Items!)
        {
            bool isBrie = item.Name == "Aged Brie"; 
            bool isBackstage = item.Name == "Backstage passes to a TAFKAL80ETC concert";
            bool isSulfuras = item.Name == "Sulfuras, Hand of Ragnaros";
            bool isStandardItem = !isBrie && !isBackstage && !isSulfuras;

            if(isSulfuras)
            {
                updateLegendary(item);
                return;
            }

            if(isBrie)
            {
                updateCheese(item);
            }

            if(isBackstage)
            {
                updateBackstage(item);
            }

            if(isStandardItem)
            {
                updateStandard(item);
            }

            ensurePostCondition(item);
        }
    }

    internal void updateStandard(Item item){
        item.Quality = decrease(item.Quality);
        item.SellIn--;
        if(experied(item.SellIn)){
            item.Quality = decrease(item.Quality);
        }
    }
    internal void updateCheese(Item item){
        item.Quality = increase(item.Quality);
        item.SellIn--;
        if(experied(item.SellIn))
        {
            item.Quality = increase(item.Quality);
        }
    }

    internal void updateBackstage(Item item){
        if(item.SellIn >= 11)
        {
            item.Quality = increase(item.Quality, 1);
        }
        if(item.SellIn is >= 6 and <= 10)
        {
            item.Quality = increase(item.Quality, 2);
        }
        if(item.SellIn is >= 0 and <= 5)
        {
            item.Quality = increase(item.Quality, 3);
        }

        item.SellIn--;

        if(experied(item.SellIn))
        {
            item.Quality = 0;
        }
    }

    internal void updateLegendary(Item item)
    {
        // empty on purpose
    }

    internal void ensurePostCondition(Item item)
    {
        item.Quality = increase(item.Quality, 0);
        item.Quality = decrease(item.Quality, 0);
    }

    internal bool experied(int sellIn){
        return sellIn < 0;
    }
}

public class Item
{
    public string? Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }
}


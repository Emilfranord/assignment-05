namespace GildedRose.Tests;

public class ProgramTests
{

   [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
    }

    [Fact]
    public void UpdateQuality_Does_Quality_Degrade() {
        var app = new Program()
        {
            Items = new List<Item> {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}
            }
        };

        app.UpdateQuality();

        app.Items[0].SellIn.Should().Be(9);
        app.Items[0].Quality.Should().Be(19);

    }

    [Fact]
    public void UpdateQuality_Quality_Degrade_After_Sell_Date_Has_Passed() {
        var app = new Program()
        {
            Items = new List<Item> {
            new Item {Name = "+5 Dexterity Vest", SellIn = -1, Quality = 20}
            }
        };

        app.UpdateQuality();

        app.Items[0].Quality.Should().Be(18);
    }

    [Fact (Skip = "Not implemented yet")]
    public void UpdateQuality_Quality_Is_Never_Above_50() {
        var app = new Program()
        {
            Items = new List<Item> {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 55 },
            new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 52 },
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 52 }
            }
        };

        app.UpdateQuality();

        app.Items[0].Quality.Should().Be(50);
        app.Items[1].Quality.Should().Be(50);
        app.Items[2].Quality.Should().Be(50);
    }

    [Fact (Skip = "Not implemented yet")]
    public void UpdateQuality_Quality_Of_Brie_Stops_At_50() {
        var app = new Program()
        {
            Items = new List<Item> {
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 60 }
            }
        };

        app.UpdateQuality();

        app.Items[0].Quality.Should().Be(50);
    }

    [Fact (Skip = "Not implemented yet")]
    public void UpdateQuality_Quality_Of_Sulfuras_Is_Always_80() {
                var app = new Program()
        {
            Items = new List<Item> {
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 70 }
            }
        };

        app.UpdateQuality();

        app.Items[0].Quality.Should().Be(80);
    }

    [Fact]
    public void SULFURAS_SHOULD_NOT_CHANGE_QUALITY()
    {
        //Arrange
        var app = new Program()
        {
            Items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 79 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 81 }
            }
        };

        //Act
        app.UpdateQuality();

        //Assert
        app.Items[0].Quality.Should().Be(79);
        app.Items[1].Quality.Should().Be(80);
        app.Items[2].Quality.Should().Be(81);
    }

    [Fact]
    public void SULFURAS_SHOULD_NOT_UPDATE_SELLIN()
    {
        //Arrange
        var app = new Program()
        {
            Items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
            }
        };

        //Act
        app.UpdateQuality();

        //Assert
        app.Items[0].SellIn.Should().Be(0);
    }

    [Fact]
    public void BRIE_SHOULD_INCREASE_IN_QUALITY()
    {
        //Arrange
        var app = new Program()
        {
            Items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 }
            }
        };

        //Act
        app.UpdateQuality();

        //Assert
        app.Items[0].Quality.Should().Be(1);
    }
}
namespace GildedRose.Tests;

public class ProgramTests
{
    [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
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
namespace GildedRose.Tests;

public class ProgramTests
{
    [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
    }

    [Fact]
    public void QualityAndSellecreasesForShirt()
    {
        var app = new Program(){
            Items = new List<Item>{
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }
            }
        };

        app.UpdateQuality();

        app.Items[0].Quality.Should().Be(19);
        app.Items[0].SellIn.Should().Be(9);
    }

    [Fact]
    public void QualityNonNegative()
    {
        var app = new Program(){
            Items = new List<Item>{
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 1 }
            }
        };

        app.UpdateQuality();
        app.Items[0].Quality.Should().Be(0);
    }

    [Fact]
    public void QualityNonNegativeRepeatedDecreasesAlsoKeepItNonNegative()
    {
        var app = new Program(){
            Items = new List<Item>{
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 1 }
            }
        };

        app.UpdateQuality();
        app.UpdateQuality();
        app.UpdateQuality();
        app.Items[0].Quality.Should().Be(0);
    }
    
}
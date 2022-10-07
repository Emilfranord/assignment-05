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

    [Fact (Skip = "Not Defined In the current Build")]
    public void QualityStartingAsNegativeIsMadeNonNegative(){
        var app = new Program(){
            Items = new List<Item>{
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = -100 }
            }
        };

        app.UpdateQuality();
        app.Items[0].Quality.Should().Be(0);
    }
    [Fact]
    public void BackstagePassDoesNotDecreaseInValue()
    {

        for (var i = 1; i<25; i++){
            var sell = i;
            var qua = 10; 

            var app = new Program(){
                Items = new List<Item>{
                    new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sell, Quality = qua }
                }
            };

            app.UpdateQuality();
            app.Items[0].Quality.Should().BeGreaterThanOrEqualTo(qua);
        }
    }

    [Fact]
    public void BackstagePassKeepsValue11DaysOut()
    {
        var app = new Program(){
            Items = new List<Item>{
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10}
            }
        };
        app.UpdateQuality();
        app.Items[0].Quality.Should().Be(11);
    }

    [Fact]
    public void BackstagePassIncreaseValue20DaysOut()
    {
        var app = new Program(){
            Items = new List<Item>{
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10}
            }
        };
        app.UpdateQuality();
        app.Items[0].Quality.Should().Be(11);
    }


    [Fact]
    public void BackstagePassIncreaseValue10DaysOut()
    {
        var app = new Program(){
            Items = new List<Item>{
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10}
            }
        };
        app.UpdateQuality();
        app.Items[0].Quality.Should().Be(12);
    }

    [Fact]
    public void BackstagePassIncreaseValueMoreWhen5DaysOut()
    {
        var app = new Program(){
            Items = new List<Item>{
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10}
            }
        };
        app.UpdateQuality();
        app.Items[0].Quality.Should().Be(13);
    }

    [Fact]
    public void BackstagePassLooseValueWhenUpdatingOnZeroDay()
    {
        var app = new Program(){
            Items = new List<Item>{
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10}
            }
        };
        app.UpdateQuality();
        app.Items[0].Quality.Should().Be(0);
    }
}
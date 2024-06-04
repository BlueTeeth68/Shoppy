namespace Application.Test.Utils;

public class StringUtils
{
    [Theory]
    [InlineData("joHn doE", "John Doe")]
    [InlineData("nguyễN vĂN A", "Nguyễn Văn A")]
    [InlineData("CON LẠC ĐÀ", "Con Lạc Đà")]
    [InlineData("  CON đà Điểu   ", "Con Đà Điểu")]
    [InlineData(null, "")]
    [InlineData("        ", "")]
    public void FormatName_ValidInput_ReturnFormatedOutput(string input, string output)
    {
        //arrange
        //act
        var result = Shoppy.Application.Utils.StringUtils.FormatName(input);

        //assert
        Assert.NotNull(result);
        Assert.Equal(output, result);
    }
}
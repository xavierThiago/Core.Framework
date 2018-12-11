using Core.Framework.Docs.PDF;
using Xunit;

namespace Core.Framework.xUnit
{
    public class GenerateDocTest
    {
        [Fact]
        public void GeneratePDF()
        {
            //Arrange
            PDFDoc doc = new PDFDoc("PDF de Teste", @"lorem ipsum");
            //Act
            var pdf = doc.Generate();
            //Assert
            Assert.NotNull(pdf);
        }
    }
}

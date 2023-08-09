namespace MasterResolveTest
{
    public class ConsoleTextHandlerTests
    {
        [Fact]
        public void ReadArgs_ValidInput_ReturnsParsedArguments()
        {
            // Arrange
            string[] args = new string[] { "-input", "input.txt", "-output", "output.txt", "domain1.com", "domain2.com" };
            ConsoleTextHandler textHandler = new ConsoleTextHandler();

            // Act
            List<(string Type, string Value)> parsedArgs = textHandler.ReadArgs(args);

            // Assert
            Assert.NotNull(parsedArgs);
            Assert.Equal(4, parsedArgs.Count);
        }

        [Fact]
        public void ReadArgs_InvalidInput_ThrowsArgumentException()
        {
            // Arrange
            string[] args = new string[] { "-input", "-output", "output.txt" };
            ConsoleTextHandler textHandler = new ConsoleTextHandler();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => textHandler.ReadArgs(args));
        }

        [Fact]
        public void GetDomainArgumentsFromArgs_ValidParsedArgs_ReturnsDomainArgs()
        {
            // Arrange
            List<(string Type, string Value)> parsedArgs = new List<(string Type, string Value)>
            {
                ("domain", "domain1.com"),
                ("dns", "8.8.8.8"),
                ("domain", "domain2.com")
            };
            ConsoleTextHandler textHandler = new ConsoleTextHandler();

            // Act
            List<string> domainArgs = textHandler.GetDomainArgumentsFromArgs(parsedArgs);

            // Assert
            Assert.NotNull(domainArgs);
            Assert.Equal(2, domainArgs.Count);
        }
    }
}

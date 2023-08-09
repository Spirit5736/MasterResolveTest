namespace MasterResolveTest
{
    public class FileHandlerTests
    {
        [Fact]
        public void ReadFile_ValidFilePath_ReturnsNonEmptyList()
        {
            // Arrange
            string filePath = "domains.txt";

            // Act
            List<string> words = FileHandler.ReadFile(filePath);

            // Assert
            Assert.NotNull(words);
            Assert.NotEmpty(words);
        }

        [Fact]
        public void SaveListToFile_ValidInput_SavesDataToFile()
        {
            // Arrange
            string outputFilePath = "ips.txt";
            List<string> testData = new List<string> { "word1", "word2", "word3" };

            // Act
            FileHandler.SaveListToFile(testData, outputFilePath);

            // Assert
            Assert.True(File.Exists(outputFilePath));

            // Clean up
            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }
        }
    }
}

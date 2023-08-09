namespace MasterResolveTest
{
    public class DNSParserTests
    {
        [Fact]
        public async Task GetMXRecordsAsync_ValidInput_ReturnsMXRecords()
        {
            // Arrange
            var dnsLite = new DNSParser.DnsLite();
            var dns = "8.8.8.8";
            var hosts = new List<string> { "hotmail.com", "gmail.com" };

            // Act
            var mxRecords = await dnsLite.GetMXRecordsAsync(hosts, dns);

            // Assert
            Assert.NotNull(mxRecords);
            Assert.NotEmpty(mxRecords);
        }
    }
}

using Base.rm.datatypes;

namespace Base.Tests.rm.Tests.datatypes.Tests
{
    public class OPENEHR_DEFINITIONS_tests
    {
        [Fact]
        public void Constructor_Should_Initialize_LocalTerminologyId_With_DefaultValue()
        {
            // Arrange & Act
            var definitions = new OPENEHR_DEFINITIONS();

            // Assert
            Assert.Equal("local", definitions.Local_terminology_id);
        }

        [Fact]
        public void LocalTerminologyId_Should_Return_DefaultValue_When_Not_Set()
        {
            // Arrange
            var definitions = new OPENEHR_DEFINITIONS();

            // Act
            string result = definitions.Local_terminology_id;

            // Assert
            Assert.Equal("local", result);
        }


        [Fact]
        public void LocalTerminologyId_Should_Set_And_Get_Value_Correctly()
        {
            // Arrange
            var definitions = new OPENEHR_DEFINITIONS();
            const string newValue = "custom_terminology";

            // Act
            definitions.Local_terminology_id = newValue;

            // Assert
            Assert.Equal(newValue, definitions.Local_terminology_id);
        }

        [Fact]
        public void LocalTerminologyId_Should_Allow_Setting_Empty_String()
        {
            // Arrange
            var definitions = new OPENEHR_DEFINITIONS();

            // Act
            definitions.Local_terminology_id = string.Empty;

            // Assert
            Assert.Equal(string.Empty, definitions.Local_terminology_id);
        }

        [Fact]
        public void LocalTerminologyId_Should_Allow_Setting_Null_Value()
        {
            // Arrange
            var definitions = new OPENEHR_DEFINITIONS();

            // Act
            definitions.Local_terminology_id = null;

            // Assert
            Assert.Null(definitions.Local_terminology_id);
        }

        [Theory]
        [InlineData("test")]
        [InlineData("local_2")]
        [InlineData("CUSTOM_TERMINOLOGY")]
        [InlineData("123_terminology")]
        [InlineData("special-chars!@#")]
        public void LocalTerminologyId_Should_Accept_Various_String_Values(string value)
        {
            // Arrange
            var definitions = new OPENEHR_DEFINITIONS();

            // Act
            definitions.Local_terminology_id = value;

            // Assert
            Assert.Equal(value, definitions.Local_terminology_id);
        }

        [Fact]
        public void LocalTerminologyId_Should_Preserve_Value_After_Multiple_Sets()
        {
            // Arrange
            var definitions = new OPENEHR_DEFINITIONS();
            const string firstValue = "first";
            const string secondValue = "second";
            const string finalValue = "final";

            // Act
            definitions.Local_terminology_id = firstValue;
            definitions.Local_terminology_id = secondValue;
            definitions.Local_terminology_id = finalValue;

            // Assert
            Assert.Equal(finalValue, definitions.Local_terminology_id);
        }

        [Fact]
        public void Multiple_Instances_Should_Have_Independent_Values()
        {
            // Arrange
            var definitions1 = new OPENEHR_DEFINITIONS();
            var definitions2 = new OPENEHR_DEFINITIONS();

            // Act
            definitions1.Local_terminology_id = "instance1";
            definitions2.Local_terminology_id = "instance2";

            // Assert
            Assert.Equal("instance1", definitions1.Local_terminology_id);
            Assert.Equal("instance2", definitions2.Local_terminology_id);
        }

        [Fact]
        public void LocalTerminologyId_Should_Handle_Whitespace_Correctly()
        {
            // Arrange
            var definitions = new OPENEHR_DEFINITIONS();
            const string valueWithWhitespace = "  local terminology  ";

            // Act
            definitions.Local_terminology_id = valueWithWhitespace;

            // Assert  
            Assert.Equal(valueWithWhitespace, definitions.Local_terminology_id);
            // Note: The property doesn't trim whitespace, so it's preserved
        }

        [Fact]
        public void LocalTerminologyId_Should_Handle_Unicode_Characters()
        {
            // Arrange
            var definitions = new OPENEHR_DEFINITIONS();
            const string unicodeValue = "ローカル用語";

            // Act
            definitions.Local_terminology_id = unicodeValue;

            // Assert
            Assert.Equal(unicodeValue, definitions.Local_terminology_id);
        }
    }
}
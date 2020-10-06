using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInExperienceWhenNew()
        {

            PlayerCharacter sut = new PlayerCharacter();
            Assert.True(sut.IsNoob);                

        }

        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Charneet";
            sut.LastName = "Kaur";

            Assert.Equal("Charneet Kaur", sut.FullName);

        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Charneet";
            sut.LastName = "Kaur";

            Assert.StartsWith("Charneet", sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Charneet";
            sut.LastName = "Kaur";

            Assert.EndsWith("Kaur", sut.FullName);
        }
    }
}

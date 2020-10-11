using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests 
{
    public class PlayerCharacterShould : IDisposable
    {
        public readonly PlayerCharacter _sut;
        public readonly ITestOutputHelper _output;

        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Creating new PlayerCharacter");
            _sut = new PlayerCharacter();
        }

        public void Dispose()
        {
            _output.WriteLine($" Disposing PlayerCharacter {_sut.FullName}");
            //_sut.Dispose();
        }

        [Fact]
        public void BeInExperienceWhenNew()
        {

             
            Assert.True(_sut.IsNoob);

        }

        [Fact]
        public void CalculateFullName()
        {
             
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Equal("Sarah Smith", _sut.FullName);

        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
             
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.StartsWith("Sarah", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
             

            _sut.LastName = "Smith";

            Assert.EndsWith("Smith", _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
             

            _sut.FirstName = "SARAH";
            _sut.LastName = "SMITH";

            Assert.Equal("Sarah Smith", _sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubtringAssertExample()
        {
             

            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Contains("ah Sm", _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_WithTitleCase()
        {
             

            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
        }

        [Fact]
        public void StatWithDefaultHealth()
        {
             

            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StatWithDefaultHealth_NotEqualExample()
        {
             

            Assert.NotEqual(0, _sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
             
            _sut.Sleep();

            Assert.True(_sut.Health >= 100 && _sut.Health <= 200);
            Assert.InRange(_sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
             

            Assert.Null(_sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
             

            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
             

            Assert.DoesNotContain("Staff Of Wonder", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
             

            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
             

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };
        }


        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
             

            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
             

            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }


        [Fact]
        public void RaisePropertyChangedEvent()
        {
             

            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }

        
    }
}

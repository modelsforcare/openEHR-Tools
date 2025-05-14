using clarotech.openehr.AOM.aom;

namespace clarotech.openehr.AOM.Tests
{
    public class CSecondOrderTests
    {
        private class MockArchetypeConstraint : ArchetypeConstraint
        {
            public CSecondOrder<MockArchetypeConstraint> SocParent { get; set; }
        }

        [Fact]
        public void GetMember_ValidIndex_ReturnsCorrectMember()
        {
            // Arrange
            var secondOrder = new CSecondOrder<MockArchetypeConstraint>();
            var member1 = new MockArchetypeConstraint();
            var member2 = new MockArchetypeConstraint();
            secondOrder.AddMember(member1);
            secondOrder.AddMember(member2);

            // Act
            var result = secondOrder.GetMember(1);

            // Assert
            Assert.Equal(member2, result);
        }

        [Fact]
        public void Members_SetAndGet_ReturnsCorrectList()
        {
            // Arrange
            var secondOrder = new CSecondOrder<MockArchetypeConstraint>();
            var member1 = new MockArchetypeConstraint();
            var member2 = new MockArchetypeConstraint();
            var newMembers = new List<MockArchetypeConstraint> { member1, member2 };

            // Act
            secondOrder.Members = newMembers;

            // Assert
            Assert.Equal(newMembers, secondOrder.Members);
        }

        [Fact]
        public void Members_SetToNull_InitializesEmptyList()
        {
            // Arrange
            var secondOrder = new CSecondOrder<MockArchetypeConstraint>();

            // Act
            secondOrder.Members = null;

            // Assert
            Assert.NotNull(secondOrder.Members);
            Assert.Empty(secondOrder.Members);
        }

        [Fact]
        public void AddMember_AddsMemberToList()
        {
            // Arrange
            var secondOrder = new CSecondOrder<MockArchetypeConstraint>();
            var member = new MockArchetypeConstraint();

            // Act
            secondOrder.AddMember(member);

            // Assert
            Assert.Single(secondOrder.Members);
            Assert.Equal(member, secondOrder.Members[0]);
        }

        [Fact]
        public void AddMember_SetsSocParent()
        {
            // Arrange
            var secondOrder = new CSecondOrder<MockArchetypeConstraint>();
            var member = new MockArchetypeConstraint();

            // Act
            secondOrder.AddMember(member);

            // Assert
            Assert.Equal(secondOrder, member.SocParent);
        }

        [Fact]
        public void Members_SetList_SetsSocParentForAllMembers()
        {
            // Arrange
            var secondOrder = new CSecondOrder<MockArchetypeConstraint>();
            var member1 = new MockArchetypeConstraint();
            var member2 = new MockArchetypeConstraint();
            var newMembers = new List<MockArchetypeConstraint> { member1, member2 };

            // Act
            secondOrder.Members = newMembers;

            // Assert
            Assert.Equal(secondOrder, member1.SocParent);
            Assert.Equal(secondOrder, member2.SocParent);
        }
    }
}
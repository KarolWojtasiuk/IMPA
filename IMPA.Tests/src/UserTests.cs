using Xunit;

namespace IMPA
{
    public class UserTests
    {
        [Fact]
        public void PasswordHashingTest()
        {
            var user = new User("testName", "testPassword");
            Assert.True(user._password.VerifyPassword("testPassword"));
            Assert.False(user._password.VerifyPassword("testpassword"));

            user._password.ChangePassword("newPassword");
            Assert.False(user._password.VerifyPassword("testPassword"));
            Assert.True(user._password.VerifyPassword("newPassword"));
        }
    }
}

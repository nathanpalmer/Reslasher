using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Shouldly;

namespace Reslasher.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Does_It_Slash_Properly()
        {
            // Arrange
            var input = @"C:\Folder\Root";

            // Act
            input = input.Reslash();

            // Assert
            input.ShouldBe("C:/Folder/Root");
        }

        [Test]
        public void Can_It_Slash_The_Other_Way()
        {
            // Arrange
            var input = @"C:/Folder/Root";

            // Act
            input = input.Reslash('/','\\');

            // Assert
            input.ShouldBe(@"C:\Folder\Root");
        }

        [Test]
        public void Mixed_Slashes_Get_Normalized()
        {
            // Arrange
            var input = @"C:\Folder/Root";

            // Act
            input = input.Reslash();
            
            // Assert
            input.ShouldBe("C:/Folder/Root");
        }

        [Test]
        public void Can_Combine_Path_With_Root()
        {
            // Arrange
            var input = @"C:\Root\Path";
            var next = @"/Other/Path";

            // Act
            var result = input.Combine(next);

            // Assert
            result.ShouldBe(@"C:\Root\Path\Other\Path");
        }

        [Test]
        public void Can_Combine_Multiple_Paths()
        {
            // Arrange
            var input = @"C:\Root\Path";
            var next1 = @"Other";
            var next2 = @"Moar\Path";

            // Act
            var result = input.Combine(next1, next2);

            // Assert
            result.ShouldBe(@"C:\Root\Path\Other\Moar\Path");
        }
    }
}

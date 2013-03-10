using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit;

namespace Coursera.DataStructures.Tests.Conventions
{
    public class HeapTestConventionAttribute : AutoDataAttribute
    {
        public HeapTestConventionAttribute() 
            : base(new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}

using System.Collections.Generic;
using System.Reflection;
using Ploeh.AutoFixture.Kernel;

namespace Ploeh.AutoFixture.Idioms
{
    public class BasicEqualityRulesAssertion : IdiomaticAssertion
    {
        private readonly CompositeIdiomaticAssertion compositeIdiomaticAssertion;

        public BasicEqualityRulesAssertion(ISpecimenBuilder builder)
            : this(new List<IIdiomaticAssertion>() { new EqualityWithSelfAssertion(builder), new EqualityWithNullAssertion(builder) })
        {
            
        }

        public BasicEqualityRulesAssertion(IEnumerable<IIdiomaticAssertion> idiomaticAssertions)
        {
            this.compositeIdiomaticAssertion = new CompositeIdiomaticAssertion(idiomaticAssertions);
        }

        public virtual void Verify(MethodInfo methodInfo)
        {
            this.compositeIdiomaticAssertion.Verify(methodInfo);
        }
    }
}
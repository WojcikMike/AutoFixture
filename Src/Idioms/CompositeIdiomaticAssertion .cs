using System.Collections.Generic;
using System.Reflection;

namespace Ploeh.AutoFixture.Idioms
{
    internal class CompositeIdiomaticAssertion : IdiomaticAssertion
    {
        private readonly IEnumerable<IIdiomaticAssertion> idiomaticAssertions;

        public CompositeIdiomaticAssertion(IEnumerable<IIdiomaticAssertion> idiomaticAssertions)
        {
            this.idiomaticAssertions = idiomaticAssertions;
        }

        public override void Verify(FieldInfo fieldInfo)
        {
            foreach (var idiomaticAssertion in this.idiomaticAssertions)
            {
                idiomaticAssertion.Verify(fieldInfo);
            }
        }

        public override void Verify(ConstructorInfo constructorInfo)
        {
            foreach (var idiomaticAssertion in this.idiomaticAssertions)
            {
                idiomaticAssertion.Verify(constructorInfo);
            }
        }

        public override void Verify(MethodInfo methodInfo)
        {
            foreach (var idiomaticAssertion in this.idiomaticAssertions)
            {
                idiomaticAssertion.Verify(methodInfo);
            }
        }

        public override void Verify(PropertyInfo propertyInfo)
        {
            foreach (var idiomaticAssertion in this.idiomaticAssertions)
            {
                idiomaticAssertion.Verify(propertyInfo);
            }
        }
    }
}
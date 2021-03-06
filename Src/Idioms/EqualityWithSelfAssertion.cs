﻿using System;
using System.Reflection;
using Ploeh.AutoFixture.Kernel;

namespace Ploeh.AutoFixture.Idioms
{
    public class EqualityWithSelfAssertion : IdiomaticAssertion
    {
        private readonly ISpecimenBuilder builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualityWithSelfAssertion"/> class.
        /// </summary>
        /// <param name="builder">
        /// A composer which can create instances required to implement the idiomatic unit test,
        /// such as the owner of the method.
        /// </param>
        /// <remarks>
        /// <para>
        /// <paramref name="builder" /> will typically be a <see cref="Fixture" /> instance.
        /// </para>
        /// </remarks>
        public EqualityWithSelfAssertion(ISpecimenBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            this.builder = builder;
        }

        /// <summary>
        /// Gets the builder supplied via the constructor.
        /// </summary>
        public ISpecimenBuilder Builder
        {
            get { return this.builder; }
        }

        public override void Verify(Type type)
        {
            var specimen = this.builder.Create(type);
            if (!specimen.Equals(specimen))
                throw new EqualityException(
                    "Equals method returns false on x.Equals(x) calls, which indicate bad implementation. Please review it's implementation");
        }
    }
}
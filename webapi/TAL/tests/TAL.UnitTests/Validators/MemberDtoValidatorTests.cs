using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.TestHelper;
using TAL.WebApi.Validators;
using Xunit;

namespace TAL.UnitTests.Validators
{
    public class MemberDtoValidatorTests
    {
        private readonly MemberDtoValidator _validator = new MemberDtoValidator();

        [Theory]
        [InlineData(1)]
        public void GivenAValidOccupation_ShouldNotHaveValidationError(int occupationId)
            => _validator.ShouldNotHaveValidationErrorFor(model => model.OccupationId, occupationId);

        [Theory]
        [InlineData(0)]
        public void GivenAInValidOccupation_ShouldHaveValidationError(int occupationId)
            => _validator.ShouldHaveValidationErrorFor(model => model.OccupationId, occupationId);
    }
}

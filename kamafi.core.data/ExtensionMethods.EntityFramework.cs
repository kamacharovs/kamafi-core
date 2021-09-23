using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kamafi.core.data
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Used with <see cref="Microsoft.EntityFrameworkCore"/> to indicate that a column has a snake case name
        /// </summary>
        /// <param name="propertyBuilder"><see cref="Microsoft.EntityFrameworkCore"/> PropertyBuilder</param>
        /// <returns></returns>
        public static PropertyBuilder HasSnakeCaseColumnName(this PropertyBuilder propertyBuilder)
        {
            propertyBuilder.Metadata.SetColumnName(
                propertyBuilder
                    .Metadata
                    .Name
                    .ToSnakeCase());

            return propertyBuilder;
        }
    }
}

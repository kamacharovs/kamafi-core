namespace kamafi.core.data
{
    /// <summary>
    /// Serves as an object to store general details on an OpenAPI definition. Such as name, title, etc.
    /// Primarily used in the kamafi.core.middleware package (AddKamafiSwaggerGen)
    /// </summary>
    public class OpenApiGeneral
    {
        /// <summary>
        /// Name of the OpenAPI definition
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Title of the OpenAPI definition
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Version of the OpenAPI definition
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Description of the OpenAPI definition
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Path to the XML comments
        /// </summary>
        public string XmlCommentsPath { get; set; }
    }
}

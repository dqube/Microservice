namespace CompanyName.MyProjectName.BuildingBlocks.Security.Vault;

    public class RuntimeSettings
    {
        public static RuntimeSettings Create(string env)
        {
            Enum.TryParse(env, out Environment environment);
            var v = new RuntimeSettings();
            v.CurrentEnvironment = environment;
            return v;
        }

        /// <summary>
        /// Specifies the environment in which the application is running.
        /// </summary>
        public enum Environment
        {
            /// <summary>
            /// The development environment.
            /// </summary>
            Development,

            /// <summary>
            /// The production environment.
            /// </summary>
            Production,

            /// <summary>
            /// The test environment.
            /// </summary>
            Test,

            /// <summary>
            /// The pre-production environment.
            /// </summary>
            PPE
        }

        public Environment CurrentEnvironment { get; set; }

        public string UAMI { get; set; } = string.Empty;
}

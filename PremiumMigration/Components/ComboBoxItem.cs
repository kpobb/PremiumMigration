namespace PremiumMigration.Components
{
    internal class ComboBoxItem
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string SetupPageUrl { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

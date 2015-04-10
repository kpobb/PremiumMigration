using System;

namespace PremiumMigration.Components.Migration
{
    internal class MigrationData
    {
        private readonly string _migrationType;
        private readonly string _messageType;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private readonly string _domain;

        public MigrationData(string domain, string messageType, string migrationType)
        {
            _domain = domain;
            _startDate = DateTime.Now;
            _endDate = DateTime.Now.AddDays(7);
            _messageType = messageType;
            _migrationType = migrationType;
        }

        public string Url
        {
            get
            {
                return string.Format("{0}/account/addMigratePlayer.action?migrationType={1}&startDate={2: M/d/yyyy}" +
                                     "&endDate={3: M/d/yyyy}&messageType=message{4}&bonusCode=", _domain, _migrationType, 
                                     _startDate, _endDate, _messageType);
            }
        }
    }
}

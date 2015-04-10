using System;
using System.Reflection;
using System.Windows.Forms;

namespace PremiumMigration.Components.ViewState
{
    internal class FormViewState
    {
        private readonly ComboBox _environments;
        private readonly ComboBox _messageTypes;
        private readonly ComboBox _migrationTypes;
        private readonly TextBox _username;

        public FormViewState(ComboBox environments, ComboBox messageTypes, ComboBox migrationTypes, TextBox username)
        {
            _environments = environments;
            _messageTypes = messageTypes;
            _migrationTypes = migrationTypes;
            _username = username;
        }

        public Version ApplicationVersion
        {
            get { return Assembly.GetEntryAssembly().GetName().Version; }
        }

        public string AccountName
        {
            get { return _username.Text; }
        }

        public string MessageType
        {
            get { return _messageTypes.SelectedItem.ToString(); }
        }

        public string MigrationType
        {
            get { return _migrationTypes.SelectedItem.ToString(); }
        }

        private static Backoffice _backOfficeInstance;

        public Backoffice Backoffice
        {
            get
            {
                var env = (ComboBoxItem)_environments.SelectedItem;

                if (_backOfficeInstance == null)
                {
                    _backOfficeInstance = new Backoffice
                    {
                        Password = env.Password,
                        UserName = env.Username,
                        SetupPageUrl = env.SetupPageUrl
                    };
                }
                else
                {
                    _backOfficeInstance.Password = env.Password;
                    _backOfficeInstance.SetupPageUrl = env.SetupPageUrl;
                    _backOfficeInstance.UserName = env.Username;
                }

                return _backOfficeInstance;
            }
        }

        public bool IsHardMigration()
        {
            return MigrationType.Equals("Hard", StringComparison.InvariantCultureIgnoreCase);
        }

        public bool IsAccountNameNotSet()
        {
            return string.IsNullOrWhiteSpace(AccountName);
        }

        public void FillComboBoxes()
        {
            object[] environmentsData =
            {
                new ComboBoxItem
                {
                    Name = "FVT",
                    Username = "guest",
                    Password = "123123",
                    SetupPageUrl = "http://10.1.234.174/E7-SETUP/E7-Setup_Setup_Details.html"
                },
                new ComboBoxItem
                {
                    Name = "QA1",
                    Username = "guest",
                    Password = "123123",
                    SetupPageUrl = "http://10.1.146.208/E3-SETUP/E3-SETUP_Setup_Details.html"
                },
                new ComboBoxItem
                {
                    Name = "QA2",
                    Username = "guest",
                    Password = "123123",
                    SetupPageUrl = "http://tr-su.ivycomptech.co.in/tr_Setup_Details.html"
                }
            };

            FillComboBox(_environments, environmentsData);

            FillComboBox(_migrationTypes, new object[] { "Soft", "Semihard", "Hard" });

            FillComboBox(_messageTypes, new object[] { "A", "B", "C", "D", "E" });
        }

        private void FillComboBox(ComboBox cbox, object[] values)
        {
            cbox.Items.AddRange(values);
            cbox.SelectedIndex = 0;
        }
    }
}

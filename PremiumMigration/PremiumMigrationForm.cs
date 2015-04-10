using System;
using System.Net;
using System.Windows.Forms;
using PremiumMigration.Components;
using PremiumMigration.Components.Migration;
using PremiumMigration.Components.ViewState;
using PremiumMigration.Properties;

namespace PremiumMigration
{
    public sealed partial class PremiumMigrationForm : Form
    {
        private readonly WebRequestHandler _requestHandler;
        private readonly FormViewState _viewState;
        private readonly MigrationHandler _migrationHandler;

        public PremiumMigrationForm()
        {
            InitializeComponent();

            var assemblyResolver = new AssemblyResolver();
            assemblyResolver.Resolve();

            _requestHandler = new WebRequestHandler();

            _viewState = new FormViewState(environmentCbox, messageTypeCbox, migrationTypeCbox, usernameTbox);
            _viewState.FillComboBoxes();

            _migrationHandler = new MigrationHandler(_requestHandler, _viewState);

            Text = string.Format("Premium Migration v{0}.{1}", _viewState.ApplicationVersion.Major, _viewState.ApplicationVersion.Minor);
        }

        private void MigrationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_viewState.IsHardMigration())
            {
                messageTypeCbox.SelectedIndex = 0;
                messageTypeCbox.Enabled = false;
            }
            else
            {
                messageTypeCbox.Enabled = true;
            }
        }

        private void Environment_SelectedIndexChanged(object sender, EventArgs e)
        {
            _requestHandler.ClearCookies();
        }

        private void Migrate_Click(object sender, EventArgs e)
        {
            if (_viewState.IsAccountNameNotSet())
            {
                MessageBox.Show(Resources.EmptyUsernameFieldMessage, Resources.ErrorMessageTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            try
            {
                _migrationHandler.LoginToBackoffice();
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorMessageTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            catch
            {
                MessageBox.Show(Resources.BackofficeLoginInternalErrorMessage, Resources.ErrorMessageTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            try
            {
                var message = _migrationHandler.MigrateUserToPremium();

                MessageBox.Show(message, Resources.MigrationStateTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(Resources.PremiumMigrationInternalErrorMessage, Resources.ErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Check_Click(object sender, EventArgs e)
        {
            if (_viewState.IsAccountNameNotSet())
            {
                MessageBox.Show(Resources.EmptyUsernameFieldMessage, Resources.ErrorMessageTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            try
            {
                _migrationHandler.LoginToBackoffice();
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, Resources.ErrorMessageTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            catch
            {
                MessageBox.Show(Resources.BackofficeLoginInternalErrorMessage, Resources.ErrorMessageTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            try
            {
                var message = _migrationHandler.GetMigratedAccountStatus();

                MessageBox.Show(message, Resources.MigrationStateTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(Resources.GettingAccountStatusErrorMessage, Resources.ErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using PremiumMigration.Components.ViewState;

namespace PremiumMigration.Components.Migration
{
    internal class MigrationHandler
    {
        private readonly WebRequestHandler _requestHandler;
        private readonly FormViewState _viewState;

        public MigrationHandler(WebRequestHandler requestHandler, FormViewState viewState)
        {
            _requestHandler = requestHandler;
            _viewState = viewState;
        }

        public void LoginToBackoffice()
        {
            if (_requestHandler.Cookies.Count != 0)
            {
                return;
            }

            _viewState.Backoffice.LoginUrl = FindBackofficeLoginUrl();

            var loginData = string.Format("j_username={0}&j_password={1}&submit=", _viewState.Backoffice.UserName, _viewState.Backoffice.Password);

            var loginUrl = string.Format("{0}/j_spring_security_check", _viewState.Backoffice.LoginUrl);

            _requestHandler.ExecutePost(loginUrl, loginData, true);
        }

        private string FindBackofficeLoginUrl()
        {
            var response = _requestHandler.ExecuteGet(_viewState.Backoffice.SetupPageUrl);

            return Regex.Match(response, @">(\S+)/home.action").Groups[1].Value;
        }

        public string MigrateUserToPremium()
        {
            var migrationData = new MigrationData(_viewState.Backoffice.LoginUrl, _viewState.MessageType, _viewState.MigrationType);
            var postData = string.Format("accountNames={0}", _viewState.AccountName);
            var response = _requestHandler.ExecutePost(migrationData.Url, postData);

            var doc = new HtmlDocument();
            doc.LoadHtml(response);
            var td = doc.DocumentNode.SelectSingleNode("//td[@class='tableBorderNone']");

            if (td != null)
            {
                return Regex.Replace(td.InnerText, "(\t|\r|\n)+", string.Empty).Replace(".", ". ");
            }

            return "Internal error.";
        }

        public string GetMigratedAccountStatus()
        {
            var url = string.Format("{0}/account/migrationResultsSearch.action?searchDateType=OFFER_START_DATE&" +
                        "startDate=&endDate=&accountName={1}&searchbyType=BY_NAME&" +
                        "migrationType=Premium", _viewState.Backoffice.LoginUrl, _viewState.AccountName);

            var response = _requestHandler.ExecutePost(url);

            var doc = new HtmlDocument();
            doc.LoadHtml(response);

            var tr = doc.DocumentNode.SelectNodes("//tr[@class='odd']");

            if (tr != null && tr.Count > 0)
            {
                var td = tr[0].SelectNodes("//td");

                if (td != null && td.Count >= 7)
                {
                    var migrationType = td[4].InnerHtml;

                    var accountStatus = td[7].InnerHtml;

                    return string.Format("Account status is {0}\nMigration type is {1}", accountStatus.ToUpper(), migrationType.ToUpper());
                }
            }

            return "Player does not exists.";
        }
    }
}
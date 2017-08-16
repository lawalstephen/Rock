<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PowerBiAccountRegister.ascx.cs" Inherits="RockWeb.Plugins.com_mineCartStudio.Bi.PowerBiAccountRegister" %>

<asp:UpdatePanel ID="upnlContent" runat="server">
    <ContentTemplate>

        <div class="panel panel-block">

            <div class="panel-heading panel-follow clearfix">
                <h1 class="panel-title">
                    <i class="fa fa-bar-chart"></i> Power BI Account Register
                </h1>
            </div>
                
            <div class="panel-body">

                <asp:Panel ID="pnlEntry" runat="server" >
                    <h4>Step 1: Register Your Application</h4>
                    <p>
                        <ol>
                            <li>Register your application at the <a href="https://dev.powerbi.com/apps?type=web">Power BI Developer site</a>.</li>
                            <li>Provide a friendly application name.</li>
                            <li>Select the application type of 'Server-side Web app'.</li>
                            <li>Provide a redirect URL. Recommended: <asp:Literal ID="lRedirectUrl" runat="server" />.</li>
                            <li>Enter in the homepage for your Rock server (this is only displayed during the application setup process). Recommended: <asp:Literal ID="lHomepage" runat="server" /></li>
                            <li>Select all of the APIs.</li>
                            <li>Register the application and not the returned client id and secret.</li>
                        </ol>
                    </p>

                    <h4>Step 2: Authenicate</h4>
                    <p>
                        Select a name for your account and provide the Client ID and secret from step 1 below.
                    </p>

                    <Rock:RockTextBox ID="txtAccountName" runat="server" Label="Account Name" Required="true" Help="A name to assign to this account registration. This name will be used when selecting which BI account should be used." />

                    <Rock:RockTextBox ID="txtAccountDescription" runat="server" Label="Account Description" TextMode="MultiLine" Help="A brief description of the account and how it will be used." />

                    <hr />

                    <Rock:RockTextBox ID="txtRedirectUrl" runat="server" Label="Redirect URL" Required="true" Help="Must match the redirect URL you registered your app with." />
                    <Rock:RockTextBox ID="txtClientId" runat="server" Label="Client ID" Required="true" />
                    <Rock:RockTextBox ID="txtClientSecret" runat="server" Label="Client Secret" Required="true" />  

                    <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary" Text="Register" OnClick="btnRegister_Click" />
                </asp:Panel>
                
                <asp:Panel ID="pnlResponse" runat="server">
                    <Rock:NotificationBox ID="nbResponse" runat="server" />
                </asp:Panel>
            </div>
        </div>

    </ContentTemplate>
</asp:UpdatePanel>

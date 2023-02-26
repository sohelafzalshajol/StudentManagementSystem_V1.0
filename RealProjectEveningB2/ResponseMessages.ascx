<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResponseMessages.ascx.cs" Inherits="RealProjectEveningB2.ResponseMessages" %>


<asp:Panel ID="pnlSuccess" runat="server" Visible="false">
    <div style="margin:10px auto 10px auto; width:auto;border:solid 0px Green; padding:5px 5px 5px 5px; background-color:darkgreen;color:white;text-align:center;">
        <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
    </div>
</asp:Panel>
<asp:Panel ID="pnlFailure" runat="server" Visible="false">
    <div style="margin:10px auto 10px auto; width:auto;border:solid 0px Green; padding:5px 5px 5px 5px; background-color:darkred;color:white;text-align:center;">
        <asp:Label ID="lblFailure" runat="server" Text=""></asp:Label>
    </div>
</asp:Panel>

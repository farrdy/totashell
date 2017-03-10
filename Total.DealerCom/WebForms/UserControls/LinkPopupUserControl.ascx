<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkPopupUserControl.ascx.cs"
    Inherits="TotalDealer_2008.LinkPopupUserControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script language="javascript" type="text/javascript">
   
 
    function ShowLinkPopupControl() {

        document.getElementById('dvIframe').style.display = "none";
        document.getElementById('dvPleaseWait').style.display = "block";

        var url = document.getElementById('<%= hdnUrl.ClientID %>').value;
        var queryStringParams = document.getElementById('<%= hdnClientQueryStringValue.ClientID %>').value;

        var x = queryStringParams.split("|");

        for (i = 0; i < x.length; i++) {

            var qs = x[i].split("=");
            url = queryStringAdd(url, qs[0], qs[1]);
        }

        url = queryStringAdd(url, "dt", (new Date()).valueOf());


        var iframe = document.getElementById('<%= frmSearch.ClientID %>');

        iframe.setAttribute("width", document.getElementById('<%= hdniFrameWidth.ClientID %>').value + "px");
        iframe.setAttribute("height", document.getElementById('<%= hdniFrameHeight.ClientID %>').value + "px");
        document.getElementById('dvPleaseWait').style.width = document.getElementById('<%= hdniFrameWidth.ClientID %>').value + "px";
        document.getElementById('dvPleaseWait').style.height = document.getElementById('<%= hdniFrameHeight.ClientID %>').value + "px";
        document.getElementById('<%= tblHead.ClientID %>').style.width = document.getElementById('<%= hdniFrameWidth.ClientID %>').value + "px";
        document.getElementById('<%= tblHead.ClientID %>').style.height = document.getElementById('<%= hdniFrameHeight.ClientID %>').value + "px";


        var modalpopup = $find('prodSearchpopup');

        modalpopup.show();

        var path = url;

        document.getElementById('<%= frmSearch.ClientID %>').src = path;

        //getPageResponse(document.getElementById('<%= frmSearch.ClientID %>'), document.getElementById('<%= hdnUrl.ClientID %>').value, document.getElementById('<%= hdnquerystringName.ClientID %>').value, document.getElementById('<%= hdnserverQueryStringValue.ClientID %>').value, document.getElementById('dvPleaseWait'), document.getElementById('dvIframe'));

    }

   

    function setPopupQueryTitle(value) {
        if (document.all) {
         document.getElementById('<%= lblHeading.ClientID %>').innerText = value;
        } else {
        document.getElementById('<%= lblHeading.ClientID %>').textContent = value;
        }
    }

    function setPopupQueryStringValue(value) {
        document.getElementById('<%= hdnClientQueryStringValue.ClientID %>').value = value;
    }

    function setPopUpParams(URl, queryStringParams, width, height) {
        // example of queryStringParams required , x=2|e=3|t=6
        var serverquery = document.getElementById('<%= hdnserverQueryStringValue.ClientID %>').value;

        if (queryStringParams != "" && serverquery != "") {

            document.getElementById('<%= hdnClientQueryStringValue.ClientID %>').value = "|" + queryStringParams;
        }
        else {
            document.getElementById('<%= hdnClientQueryStringValue.ClientID %>').value = serverquery + queryStringParams;
        }
        document.getElementById('<%= hdnUrl.ClientID%>').value = URl;
        document.getElementById('<%= hdniFrameWidth.ClientID %>').value = width;
        document.getElementById('<%= hdniFrameHeight.ClientID %>').value = height;
    }



  

    function checkIframeLoading() {
        // Get a handle to the iframe element
        var iframe = document.getElementById('<%= frmSearch.ClientID %>');

        // Check if loading is complete
        if (iframe.document.readyState == 'complete') {
            // The loading is complete, call the function we want executed once the iframe is loaded
            iframeLoaded();
            return;
        }

        // If we are here, it is not loaded. Set things up so we check the status again in 100 milliseconds
        window.setTimeout('checkIframeLoading();', 100);
    }


</script>



<asp:HiddenField ID="hdnquerystringName" runat="server" />
<asp:HiddenField ID="hdnserverQueryStringValue" runat="server" />
<asp:HiddenField ID="hdnClientQueryStringValue" runat="server" />
<asp:HiddenField ID="hdnUrl" runat="server" />
<asp:HiddenField ID="hdniFrameWidth" Value="400" runat="server" />
<asp:HiddenField ID="hdniFrameHeight" Value="400" runat="server" />
<style type="text/css">
.bg{background-color: #808080;opacity:.7;filter:alpha(opacity=70)}
</style>
<asp:UpdatePanel ID="upanel" runat="server">
    <ContentTemplate>
        <asp:UpdateProgress runat="server" ID="pUpdateProgress" Visible="false">
            <ProgressTemplate>
                <div class="PopUp">
                    <span class="subheading">&nbsp;Processing...</span>
                    <asp:Image runat="server" ID="ProgressIndicator" ImageUrl="~/images/ajax-loader.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:Panel ID="pnlmessage" runat="server" Style="display: none; background-color: transparent;">
            <div>
                <table style="border-collapse: collapse; max-width: 1020px; border: solid 4px black"
                    cellpadding="0" cellspacing="0" id="tblHead" runat="server">
                    <tr style="border-top: none 0px black; border-left: none 0px black; border-right: none 0px black;">
                        <td style="background-color: #808080">
                            <table id="tblheadContent" cellpadding="0" cellspacing="0" width="100%" height="20px"
                                runat="server" style="cursor: move;">
                                <tr>
                                    <td class="sub-head">
                                        <%-- <asp:Image runat="server" ID="imgWizardHead" ImageUrl="~/images/cubes.png" />--%>
                                    </td>
                                    <td class="sub-head" align="center" style="color: #FFFFFF; font-size: 16px; font-family: Verdana;
                                        height: 40px">
                                        &nbsp<asp:Label ID="lblHeading" runat="server"></asp:Label>
                                    </td>
                                    <td class="sub-head" align="right" style="width: 1%; padding-top:2px; padding-right: 6px" >
                                        <asp:ImageButton ID="imgpopupclose" runat="server" Style="cursor: pointer;" OnClientClick="Closepopup();return false;"
                                         alt="Close Window"    ImageUrl="~/images/popup_close.gif"></asp:ImageButton>
                                       
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="background-color: #FFFFFF;">
                            <!-- Popup Content Section -->
                            <div class="PopUp" id="dvPleaseWait" style="width: 50px">
                                <div id="dvPleasewaitContent">
                                    <table width="100%" height="100%">
                                        <tr>
                                            <td valign="middle" align="center">
                                                <br />
                                                <br />
                                                <br>
                                                <center>
                                                    <asp:Image runat="server" ID="Image1" ImageUrl="~/images/ajax-loader.gif" ImageAlign="AbsMiddle" />
                                                    <span class="subheading">&nbsp;Processing...</span>
                                                </center>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="dvIframe" style="padding: 1px;">
                                <iframe id="frmSearch" scrolling="auto" runat="server" EnableViewState="True" frameborder="0"
                                    src="about:blank" style="overflow: auto; margin: 0px; max-width: 1020px;" height="500px"
                                    width="700px"></iframe>
                            </div>
                            <!-- Popup Content Section -->
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:ImageButton ID="bntOkPopup" runat="server" Style="visibility: hidden" />
        &nbsp;
        <asp:ImageButton ID="btnCancelPopup" runat="server" 
            Style="visibility: hidden" />
        <asp:ImageButton ID="btnmodalpopupdefault" runat="server" 
            Style="visibility: hidden" />
        <div id="test" runat="server">
        </div>
        <cc1:ModalPopupExtender ID="messagemodalpopup" runat="server" BackgroundCssClass="bg"
            BehaviorID="prodSearchpopup" CancelControlID="btnCancelPopup" DropShadow="false"
            OkControlID="bntOkPopup" PopupControlID="pnlmessage" RepositionMode="RepositionOnWindowResizeAndScroll"
            Drag="true" PopupDragHandleControlID="tblheadContent" TargetControlID="btnmodalpopupdefault">
        </cc1:ModalPopupExtender>
    </ContentTemplate>
</asp:UpdatePanel>

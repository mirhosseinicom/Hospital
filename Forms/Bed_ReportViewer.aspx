<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bed_ReportViewer.aspx.cs" Inherits="Hospital_asp.Forms.Bed_Report_viewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>گزارش تخت خالی</title>
    <link href="../css-common/commons.css" rel="stylesheet" />
    <link href="../assets/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body align="center" style="background-color: #f0e9d7;" class="col-lg-6 col-lg-offset-3">

    <form id="form1" runat="server" >
        <div align="center" style="background-color: #f0e9d7;direction:rtl" >
            
            <asp:GridView Width="100%" ID="Grid_Report_Bed" AllowPaging="True" PageSize="20" CssClass="Grid " runat="server" PagerStyle-CssClass="pgr" AutoGenerateColumns="False">


                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="BED_ID" HeaderText="ردیف">

                        <ControlStyle Width="10px" />
                        <FooterStyle Width="10px" Wrap="True" />
                        <HeaderStyle Width="10px" Height="30px"/>
                        <ItemStyle Width="10px" />

                    </asp:BoundField>
                     <asp:BoundField DataField="DPRM_NAME" HeaderText="نام ساختمان">

                        <ItemStyle Width="80px" />

                    </asp:BoundField>
                    <asp:BoundField DataField="PART_NAME" HeaderText="نام بخش">

                        <ItemStyle Width="40px" />

                    </asp:BoundField>
                    <asp:BoundField DataField="ROOM_NUMBER" HeaderText="شماره اتاق">

                        <ItemStyle Width="40px" />

                    </asp:BoundField>
                     <asp:BoundField DataField="BED_NUMBER" HeaderText="شماره تخت">

                        <ItemStyle Width="40px" />

                    </asp:BoundField>
                   


                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#e2dede" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEDED" ForeColor="#333333" />
                <SelectedRowStyle ForeColor="White" Font-Bold="True"
                    BackColor="#9471DE"></SelectedRowStyle>
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>

        </div>
    </form>

</body>
</html>

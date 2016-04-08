<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accept_ReportViewer.aspx.cs" Inherits="Hospital_asp.Forms.Accept_ReportViewer" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>گزارش پذیرش</title>
    <link href="../css-common/commons.css" rel="stylesheet" />
</head>
<body align="center" style="background-color: #f0e9d7;">

    <form id="form1" runat="server">
        <div align="center" style="background-color: #f0e9d7;direction:rtl" class="col-lg-10 col-lg-offset-1">

            <%-- <CR:CrystalReportViewer Width="1111px" Height="1111px" id="CrystalReportViewer1" 
            runat="server" AutoDataBind="True" ReportSourceID="CrystalReportSource1" 
            ToolPanelWidth="0px" />
    
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Accept_Report.rpt">
            </Report>
        </CR:CrystalReportSource>--%>

            <asp:GridView Width="100%" ID="Grid_Report_Accept" AllowPaging="True" PageSize="20" CssClass="Grid " runat="server" PagerStyle-CssClass="pgr" AutoGenerateColumns="False">


                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ACPT_ID" HeaderText="ردیف">

                        <ControlStyle Width="10px" />
                        <FooterStyle Width="10px" Wrap="True" />
                        <HeaderStyle Width="10px" Height="30px"/>
                        <ItemStyle Width="10px" />

                    </asp:BoundField>
                    <asp:BoundField DataField="PTNT_NAME" HeaderText="نام و نام خانوادگی">

                        <ItemStyle Width="100px" />

                    </asp:BoundField>


                    <asp:BoundField DataField="PTNT_NATIONAL" HeaderText="کد ملی">

                        <ItemStyle Width="10px" />

                    </asp:BoundField>
                     <asp:BoundField DataField="PTNT_COMPEER_NAME" HeaderText="همراه بیمار ">

                        <ItemStyle Width="100px" />

                    </asp:BoundField>
                    <asp:BoundField DataField="PTNT_GENEDER" HeaderText="جنسیت ">

                        <ItemStyle Width="10px" />

                    </asp:BoundField>
                    <asp:BoundField DataField="ACPT_TYPE" HeaderText="علت مراجعه ">

                        <ItemStyle Width="40px" />

                    </asp:BoundField>
                     <asp:BoundField DataField="DOC_NAME" HeaderText="پزشک معالج">

                        <ItemStyle Width="100px" />

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
                    <asp:BoundField DataField="ACPT_DATE" HeaderText="تاریخ پذیرش">

                        <ItemStyle Width="20px" />

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

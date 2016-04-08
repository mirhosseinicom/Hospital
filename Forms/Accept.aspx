<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Accept.aspx.cs" Inherits="Hospital_asp.Forms.Accept" %>

<%@ Register Assembly="AspNetPersianDatePickup" Namespace="AspNetPersianDatePickup" TagPrefix="pcal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-9 main-form  pull-left">
        <div class=" col-lg-12 ">
            <div class="panel row">
                <header class="panel-heading " dir="rtl">
                    مشخصات بیماران
                </header>
                <div class="panel-body ">
                    <form class="form-horizontal" role="form">
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:TextBox runat="server" class="form-control" ID="inpName" placeholder="نام" />
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:نام</label>
                        </div>
                        <div class="form-group col-lg-5 pull-right">
                            <div class="col-lg-7 ">
                                <asp:TextBox runat="server" class=" form-control" ID="inpFamily" placeholder="نام خانوادگی" />
                            </div>
                            <label for="inputPassword1" class="col-lg-5  control-label">:نام ونام خانوادگی</label>
                        </div>
                        <div class="form-group col-lg-4 pull-right">
                            <div class="col-lg-8 ">

                                <asp:TextBox runat="server" class="form-control" ID="inpFather" placeholder="نام پدر" />
                            </div>
                            <label for="inputEmail1" class="col-lg-4  control-label">:نام پدر</label>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-7 ">
                                <asp:TextBox runat="server" class="form-control" ID="inpNation" placeholder="کد ملی" />
                            </div>
                            <label for="inputEmail1" class="col-lg-5  control-label">:کد ملی</label>
                        </div>
                        <div class="form-group col-lg-6 pull-right">

                            <label for="inputEmail1" class="col-lg-3 pull-right control-label">:علت مراجعه</label>
                            <div class="col-lg-7 pull-right">
                                <asp:TextBox runat="server" class="form-control " ID="inpType" placeholder="علت مراجعه" />
                            </div>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:TextBox runat="server" class="form-control" ID="inpHistory" placeholder="سابقه بیماری قبلی" />
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:سابقه</label>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <pcal:PersianDatePickup ID="PDPDate" class="form-control" placeholder="تاریخ" runat="server"></pcal:PersianDatePickup>
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:تاریخ</label>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="DrpPart" AutoPostBack="true" OnSelectedIndexChanged="DrpPart_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:بخش</label>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="DrpRoom" AutoPostBack="true" OnSelectedIndexChanged="DrpRoom_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:اتاق</label>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="DrpDoctore">
                                </asp:DropDownList>
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:دکتر</label>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="DrpNurse">
                                </asp:DropDownList>
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:پرستار</label>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="DrpBed">
                                </asp:DropDownList>
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:تخت</label>
                        </div>
                        <div class="form-group form-inline col-lg-3 pull-right"">
                              <label for="inputEmail1" class="col-lg-3 pull-right control-label">:جنسیت</label>
                           
                                <div class="checkbox col-lg-4 pull-right">
                                    <label>
                                         <asp:RadioButton GroupName="radiobutton_Gender" Checked="true" runat="server" id="rdbFamale"/>
                                       زن
                                             
                                    </label>
                                </div>
                                <div class="checkbox col-lg-4 pull-right">
                                    <label>
                                        <asp:RadioButton GroupName="radiobutton_Gender" runat="server"  id="rdbMale" />
                                       مرد
                                             
                                    </label>
                                </div>
                           
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:TextBox runat="server" class="form-control" ID="inpCompeer" placeholder=" نام همراه" />
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:همراه</label>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:TextBox runat="server" class="form-control" ID="inpMoblie_Compeer" placeholder="موبایل همراه" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:همراه</label>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-offset-5 col-lg-3">
                                <input type="button" value="جستجو" id="dd" class="btnShow_search btn btn-default " />
                                <asp:Button runat="server" Text="ذخیره" ID="btnAccept_sabt"  AutoPostBack="true" class=" btn btn-default " OnClick="btnAccept_sabt_Click" />

                            </div>
                        </div>
                        <div class="col-lg-12 panel hidden panel_search">
                            <div class="col-lg-10 panel-body col-lg-offset-1" runat="server" id="panel_body_search">
                                <div class="form-group col-lg-6 pull-right">
                                    <div class="col-lg-7 ">
                                        <asp:TextBox runat="server" class=" form-control" ID="inp_Search_family" placeholder="نام ونام خانوادگی" />
                                    </div>
                                    <label for="inputPassword1" class="col-lg-5  control-label">:نام ونام خانوادگی</label>
                                </div>
                                <div class="form-group col-lg-4 pull-right">
                                    <div class="col-lg-9 ">
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="Drp_Search_Part">
                                        </asp:DropDownList>
                                    </div>
                                    <label for="inputEmail1" class="col-lg-3  control-label">:بخش</label>
                                </div>
                                <div class="form-group col-lg-6 pull-right">
                                    <div class="col-lg-7 ">

                                        <asp:TextBox runat="server" class="form-control" ID="inp_Search_Type" placeholder="علت مراجعه" />
                                    </div>
                                    <label for="inputEmail1" class="col-lg-4  control-label">:علت مراجعه</label>
                                </div>
                                <div class="form-group form-inline col-lg-5 pull-right">
                                    <label for="inputEmail1" class="col-lg-3 pull-right control-label">:جنسیت</label>

                                    <div class="checkbox col-lg-3 pull-right">
                                        <label>
                                            <asp:RadioButton GroupName="radiobutton_Gender1" Checked="true" runat="server" ID="rdb_Search_Famale" />
                                            زن
                                             
                                        </label>
                                    </div>
                                    <div class="checkbox col-lg-3 pull-right">
                                        <label>
                                            <asp:RadioButton GroupName="radiobutton_Gender1" runat="server" ID="rdb_Search_Male" />
                                            مرد
                                             
                                        </label>
                                    </div>

                                </div>
                                <div class="form-group col-lg-10 pull-right">

                                    <label for="inputPassword1" class="col-lg-3 pull-right control-label">:تاریخ</label>
                                    <div class="col-lg-3 pull-right ">

                                        <pcal:PersianDatePickup ID="PDPSearchDate" class="form-control" placeholder="تاریخ" runat="server"></pcal:PersianDatePickup>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-offset-5 col-lg-3">

                                        <asp:Button runat="server" Text="جستجو کن " ID="btn_Search" class=" btn btn-default " OnClick="btn_Search_Click" />

                                    </div>
                                </div>
                            </div>

                        </div>

                        <div id="show-datagrid" style="overflow-x: scroll;" class=" col-lg-12">

                            <asp:GridView Width="2000px" ID="Grid_Accept" AllowPaging="True" PageSize="4" CssClass="Grid scroll" runat="server" PagerStyle-CssClass="pgr" AutoGenerateColumns="False" OnPageIndexChanging="Grid_Accept_PageIndexChanging" OnRowDeleting="Grid_Accept_RowDeleting" OnRowEditing="Grid_Accept_RowEditing">


                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="ACPT_ID" HeaderText="ردیف">

                                        <ControlStyle Width="20px" />
                                        <FooterStyle Width="20px" Wrap="True" />
                                        <HeaderStyle Width="20px" />
                                        <ItemStyle Width="20px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="PTNT_NAME" HeaderText="نام">

                                        <ItemStyle Width="60px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="PTNT_FAMILY" HeaderText="نام خانوادگی">

                                        <ItemStyle Width="150px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="PTNT_FATHER_NAME" HeaderText="نام پدر">

                                        <ItemStyle Width="100px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="PTNT_NATIONAL" HeaderText="کد ملی">

                                        <ItemStyle Width="40px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="PTNT_GENEDER" HeaderText="جنسیت ">

                                        <ItemStyle Width="30px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="ACPT_TYPE" HeaderText="علت مراجعه ">

                                        <ItemStyle Width="100px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="NURS_NAME" HeaderText="پرستار">

                                        <ItemStyle Width="150px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="DOC_NAME" HeaderText="دکتر">

                                        <ItemStyle Width="150px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="PART_NAME" HeaderText="نام بخش">

                                        <ItemStyle Width="100px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="ROOM_NUMBER" HeaderText="شماره اتاق">

                                        <ItemStyle Width="80px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="BED_NUMBER" HeaderText="شماره تخت">

                                        <ItemStyle Width="80px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="PTNT_COMPEER_NAME" HeaderText="همراه ">

                                        <ItemStyle Width="150px" />

                                    </asp:BoundField>

                                    <asp:BoundField DataField="PTNT_COMPEER_MOBILE" HeaderText="موبایل همراه ">

                                        <ItemStyle Width="40px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="ACPT_DATE" HeaderText="تاریخ پذیرش">

                                        <ItemStyle Width="100px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="PTNT_TYPE_HISTORY_PATIENT" HeaderText="سابقه بیماری">

                                        <ItemStyle Width="100px" />

                                    </asp:BoundField>
                           <asp:TemplateField HeaderText="ویرایش">
                                  <EditItemTemplate>
        <asp:ImageButton ID="ButtonUpdate" runat="server" CommandName="Update"  Text="Update"  />
       
    </EditItemTemplate>
     <ItemTemplate>
        <asp:LinkButton ID="ButtonEdit" runat="server" ControlStyle-CssClass=" glyphicon glyphicon-pencil" CommandName="Edit"    />
      
    </ItemTemplate>
                                     <ItemStyle Width="20px" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="حذف">
                                         <ItemTemplate>
      
        <asp:LinkButton ID="ButtonDelete" runat="server" CommandName="Delete"  ControlStyle-CssClass=" glyphicon glyphicon-trash"   />
    </ItemTemplate>
                                           <ItemStyle Width="20px" />
                                           </asp:TemplateField>
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

                </div>
            </div>
        </div>
    </div>
</asp:Content>

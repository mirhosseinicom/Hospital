﻿<%@ Page Title="بیمارستان" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" Inherits="Hospital_asp.Forms.Doctors" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-lg-9 main-form  pull-left">
        <div class=" col-lg-11 col-lg-offset-1 ">
            <div class="panel row">
                <header class="panel-heading " dir="rtl">
                    مشخصات پزشکان
                </header>
                <div class="panel-body ">
                    <form class="form-horizontal form-doctores" role="form">
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:TextBox runat="server" class="form-control" name="inpName" ID="inpName" placeholder="نام" />
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:نام</label>
                        </div>
                        <div class="form-group col-lg-6 pull-right">
                            <div class="col-lg-7 ">
                                <asp:TextBox runat="server" name="inpFamily" class=" form-control" ID="inpFamily" placeholder="نام خانوادگی" />
                            </div>
                            <label for="inputPassword1" class="col-lg-5  control-label">:نام ونام خانوادگی</label>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">

                                <asp:TextBox runat="server" name="inpExpert" class="form-control" ID="inpExpert" placeholder="تخصص" />
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:تخصص</label>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:TextBox runat="server" name="inpDegree" class="form-control" ID="inpDegree" placeholder="درجه" />
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:درجه</label>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:TextBox runat="server" name="inpMobile" class="form-control" ID="inpMobile" placeholder="موبایل" />
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:موبایل</label>
                        </div>
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                <asp:DropDownList runat="server" name="DrpPart" CssClass="form-control" ID="DrpPart">
                                </asp:DropDownList>
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:بخش</label>
                        </div>
                         <div class="form-group form-inline col-lg-3 pull-right"">
                              <label for="inputEmail1" class="col-lg-3 pull-right control-label">:جنسیت</label>
                           
                                <div class="checkbox col-lg-4 pull-right">
                                    <label>
                                         <asp:RadioButton GroupName="radiobutton_Gender"  Checked="true" runat="server" id="rdbFamale"/>
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
                        <div class="form-group">
                            <div class="col-lg-offset-5 col-lg-3">

                               <input  type="button" value="جستجو" id="" class="btnShow_search btn btn-default "   />
                                <asp:Button runat="server" data-target="#modalDoctor" Text="ذخیره" ID="btnDoctor_sabt" class=" btn btn-default btnDoctor_sabt" OnClick="btnDoctor_sabt_Click" />

                            </div>
                        </div>
                        <div class="col-lg-12 panel hidden panel_search">
                            <div class="col-lg-10 panel-body col-lg-offset-1" runat="server" id="panel_body_search">
                                <div class="form-group col-lg-8 pull-right">
                                    <div class="col-lg-8 ">
                                        <asp:TextBox runat="server" class=" form-control" ID="inp_Search_family" placeholder="نام ونام خانوادگی" />
                                    </div>
                                    <label for="inputPassword1" class="col-lg-4  control-label">:نام ونام خانوادگی</label>
                                </div>
                                <div class="form-group col-lg-4 pull-right">
                                    <div class="col-lg-9 ">
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="Drp_Search_Part">
                                        </asp:DropDownList>
                                    </div>
                                    <label for="inputEmail1" class="col-lg-3  control-label">:بخش</label>
                                </div>
                                <div class="form-group col-lg-6 pull-right">
                                    <div class="col-lg-8 ">

                                        <asp:TextBox runat="server" class="form-control" ID="inp_Search_Expert" placeholder="تخصص" />
                                    </div>
                                    <label for="inputEmail1" class="col-lg-3  control-label">:تخصص</label>
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
                                <div class="form-group">
                                    <div class="col-lg-offset-5 col-lg-3">

                                        <asp:Button runat="server" Text="جستجو کن " ID="btn_Search" class=" btn btn-default " OnClick="btn_Search_Click" />

                                    </div>
                                </div>
                            </div>

                        </div>

                        <div id="show-datagrid" class="col-lg-12">

                            <asp:GridView Width="100%" ID="Grid_doctore" AllowPaging="True" PageSize="4" CssClass="Grid" runat="server" PagerStyle-CssClass="pgr" AutoGenerateColumns="False" OnPageIndexChanging="Grid_doctore_PageIndexChanging" OnRowDeleting="Grid_doctore_RowDeleting" OnRowEditing="Grid_doctore_RowEditing" OnRowCommand="Grid_doctore_RowCommand" OnRowUpdating="Grid_doctore_RowUpdating">


                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="DOC_ID" HeaderText="ردیف">

                                        <ControlStyle Width="30px" />
                                        <FooterStyle Width="30px" Wrap="True" />
                                        <HeaderStyle Width="30px" />
                                        <ItemStyle Width="30px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="DOC_NAME" HeaderText="نام">

                                        <ItemStyle Width="70px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="DOC_FAMILY" HeaderText="نام خانوادگی">

                                        <ItemStyle Width="150px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="DOC_EXPERT" HeaderText="تخصص">

                                        <ItemStyle Width="60px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="DOC_DEGREE" HeaderText="درجه ">

                                        <ItemStyle Width="60px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="DOC_MOBILE" HeaderText="موبایل">

                                        <ItemStyle Width="60px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="DOC_GENDER" HeaderText="جنسیت">

                                        <ItemStyle Width="40px" />

                                    </asp:BoundField>
                                    <asp:BoundField DataField="PART_NAME" HeaderText="نام بخش">

                                        <ItemStyle Width="70px" />

                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="ویرایش">
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" />

                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="ButtonEdit" runat="server" ControlStyle-CssClass=" glyphicon glyphicon-pencil" CommandName="Edit" />

                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="حذف">
                                        <ItemTemplate>

                                            <asp:LinkButton ID="ButtonDelete" runat="server" CommandName="Delete" ControlStyle-CssClass=" glyphicon glyphicon-trash" />
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
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

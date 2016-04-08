<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Accept_Report.aspx.cs" Inherits="Hospital_asp.Forms.Accept_Report" %>
<%@ Register Assembly="AspNetPersianDatePickup" Namespace="AspNetPersianDatePickup" TagPrefix="pcal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="col-lg-9 main-form  pull-left">
        <div class=" col-lg-10 col-lg-offset-1 ">
            <div class="panel row">
                <header class="panel-heading " dir="rtl">
                    مشخصات پزشکان
                </header>
                <div class="panel-body ">
                    <form class="form-horizontal " role="form">
                      
                         
                                <div class="form-group col-lg-6 pull-right">
                                    <div class="col-lg-7 ">
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
                                    <div class="col-lg-7 ">

                                        <asp:TextBox runat="server" class="form-control" ID="inp_Search_Type" placeholder="علت مراجعه" />
                                    </div>
                                    <label for="inputEmail1" class="col-lg-3  control-label">:علت مراجعه</label>
                                </div>
                                <div class="form-group form-inline col-lg-5 pull-right">
                                    <label for="inputEmail1" class="col-lg-3 pull-right control-label">:جنسیت</label>

                                    <div class="checkbox col-lg-3 pull-right">
                                        <label>
                                            <asp:RadioButton GroupName="radiobutton_Gender1" runat="server" Checked="true" ID="rdb_Search_Famale" />
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
                                <div class="form-group col-lg-8 pull-right">

                                    <label for="inputPassword1" class="col-lg-4 pull-right control-label">:تاریخ</label>
                                    <div class="col-lg-5 pull-right ">

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
                     
                    
                     
                  
                    </form>

                </div>
            </div>
      

</asp:Content>

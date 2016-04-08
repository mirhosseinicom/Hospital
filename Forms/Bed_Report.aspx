<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bed_Report.aspx.cs" Inherits="Hospital_asp.Forms.bed_Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-9 main-form  pull-left">
        <div class=" col-lg-8 col-lg-offset-2 ">
            <div class="panel row">
                <header class="panel-heading " dir="rtl">
                 تخت های خالی بخش
                </header>
                <div class="panel-body ">
                    <form class="form-horizontal " role="form">
                      
                          <div class="form-group col-lg-6 pull-right">
                            <div class="col-lg-8 ">
                                <asp:DropDownList runat="server" CssClass="form-control  pull-right" id="Drp_Part" AppendDataBoundItems="True"  >
                                    
                                </asp:DropDownList>
                             
                            </div>  
                            <label for="inputPassword1" class="col-lg-3  control-label">: بخش</label>
                        </div>
                                <div class="form-group col-lg-offset-3 col-lg-3">
                                    <div class="">

                                        <asp:Button runat="server" Text="جستجو  " ID="btn_Search" class=" btn btn-default " OnClick="btn_Search_Click"  />

                                    </div>
                                </div>
                            </div>

                        </div>
                     
                    
                     
                  
                    </form>

                </div>
            </div>
      



</asp:Content>

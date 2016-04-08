<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Hospital_asp.Forms.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="col-lg-9 main-form  pull-left">
        <div class=" col-lg-10 col-lg-offset-1">
            <div class="panel row">
                <header class="panel-heading " dir="rtl">
                   کاربر سیستم
                </header>
                <div class="panel-body ">
                    <form class="form-horizontal form-users" role="form">
                        <div class="form-group col-lg-3 pull-right">
                            <div class="col-lg-9 ">
                                 <asp:TextBox runat="server" CssClass="form-control validate{required}"  id="inpName" name="inpName" placeholder="نام"/>
                            </div>
                            <label for="inputEmail1" class="col-lg-3  control-label">:نام</label>
                        </div>
                        <div class="form-group col-lg-5 pull-right">
                            <div class="col-lg-7 ">
                                <asp:TextBox runat="server" class=" form-control" name="inpFamily" id="inpFamily" placeholder="نام خانوادگی"/>
                            </div>
                            <label for="inputPassword1" class="col-lg-5  control-label">:نام ونام خانوادگی</label>
                        </div>
                        <div class="form-group col-lg-4 pull-right">
                            <div class="col-lg-8 ">
                               
                                 <asp:TextBox runat="server" class="form-control" name="inpUser" id="inpUser" placeholder="نام کاربری"/>
                            </div>
                            <label for="inputEmail1" class="col-lg-4  control-label">:نام کاربری</label>
                        </div>
                        <div class="form-group col-lg-4 pull-right">
                            <div class="col-lg-8 ">
                                <asp:TextBox runat="server" class="form-control" name="inpPass" id="inpPass" placeholder="رمز عبور"/>
                            </div>
                            <label for="inputEmail1" class="col-lg-4  control-label">:رمز عبور </label>
                        </div>
                         <div class="form-group col-lg-6 pull-right">
                           
                            <label for="inputEmail1" class="col-lg-3 pull-right control-label">:آپلودعکس</label>
                              <div class="col-lg-9 pull-right">
                                <asp:FileUpload runat="server" name="FileUpload" class="form-control " id="FileUpload" placeholder="عکس"/>
                            </div>
                        </div>
                        
                       
                        <div class="form-group" >
                            <div class="col-lg-offset-5 col-lg-3" >
                               
                                 <asp:Button runat="server"  Text="ذخیره" id="btnUsers_sabt" class=" btn btn-default users" OnClick="btnUsers_sabt_Click"  />
                                
                            </div>
                        </div>
                   
                            
                       <div id="show-datagrid"  class=" col-lg-12">

                           <asp:GridView width="100%" ID="Grid_User" AllowPaging="True" PageSize="4" CssClass="Grid"    runat="server"  PagerStyle-CssClass="pgr"  AutoGenerateColumns="False" OnPageIndexChanging="Grid_User_PageIndexChanging" OnRowDeleting="Grid_User_RowDeleting" >
                               
                               
                               <AlternatingRowStyle BackColor="White" />
                               <Columns>
                                    <asp:BoundField DataField="USER_ID" HeaderText="ردیف">
                                 
                                    <ControlStyle Width="20px" />
                                    <FooterStyle Width="20px" Wrap="True" />
                                    <HeaderStyle Width="20px" />
                                    <ItemStyle Width="20px" />
                                 
                                   </asp:BoundField>
                                  
                                    <asp:BoundField DataField="USER_FName" HeaderText="نام ">
                                  
                                    <ItemStyle Width="60px" />
                                  
                                   </asp:BoundField>
                                   <asp:BoundField DataField="USER_FAMILY" HeaderText="نام خانوادگی">
                                  
                                    <ItemStyle Width="100px" />
                                  
                                   </asp:BoundField>
                                   <asp:BoundField DataField="USER_USERNAME" HeaderText="نام کاربری">
                                  
                                    <ItemStyle Width="60px" />
                                  
                                   </asp:BoundField>
                                    <asp:BoundField DataField="USER_IMAG" HeaderText="عکس ">
                                  
                                    <ItemStyle Width="60px" />
                                  
                                   </asp:BoundField>
                                     <asp:TemplateField HeaderText="حذف">
                                         <ItemTemplate>
      
                                   <asp:LinkButton ID="ButtonDelete" runat="server" CommandName="Delete" Text=""  ControlStyle-CssClass=" glyphicon glyphicon-trash"   />
                                          
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

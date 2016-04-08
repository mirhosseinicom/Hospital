<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Beds.aspx.cs" Inherits="Hospital_asp.Forms.Beds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <div class="col-lg-9 main-form  pull-left">
        <div class=" col-lg-8 col-lg-offset-2 ">
            <div class="panel row">
                <header class="panel-heading " dir="rtl">
                   اتاق وتخت
                </header>
                <div class="panel-body ">
                    <form class="form-horizontal" role="form">
                       <div class="form-group col-lg-6 pull-right">
                            <div class="col-lg-7 ">
                                <asp:DropDownList runat="server" CssClass="form-control  pull-right" id="Drp_Part" AppendDataBoundItems="True"  >
                                    
                                </asp:DropDownList>
                             
                            </div>  
                            <label for="inputPassword1" class="col-lg-3  control-label">: بخش</label>
                        </div>
                        <div class="form-group col-lg-6 pull-right">
                            <div class="col-lg-7 ">
                                <asp:TextBox runat="server" class=" pull-right form-control" id="inpNumber_Room" placeholder=" شماره اتاق" />
                            </div>
                            <label for="inputPassword1" class="col-lg-5  control-label">:شماره اتاق</label>
                        </div>
                       
                       
                        
                          <div class="form-group  col-lg-7 pull-right">
                            <div class="col-lg-12">
                                 <asp:Button runat="server"  Text="ذخیره" id="btn_Room_Sabt" class=" btn btn-default " OnClick="btn_Room_Sabt_Click"  />
                            </div>
                        </div>
                        
                        <div  class="col-lg-offset-2 col-lg-8">
                              <asp:GridView width="100%" ID="Grid_ROOM" AllowPaging="True" PageSize="3" CssClass="Grid"    runat="server"  PagerStyle-CssClass="pgr"  AutoGenerateColumns="False" OnPageIndexChanging="Grid_ROOM_PageIndexChanging" OnRowDeleting="Grid_ROOM_RowDeleting" OnRowEditing="Grid_ROOM_RowEditing"  >
                               
                               
                               <AlternatingRowStyle BackColor="White" />
                               <Columns>
                                    <asp:BoundField DataField="ROOM_ID" HeaderText="ردیف">
                                 
                                    <ControlStyle Width="30px" />
                                    <FooterStyle Width="30px" Wrap="True" />
                                    <HeaderStyle Width="30px" />
                                    <ItemStyle Width="30px" />
                                 
                                   </asp:BoundField>
                                   <asp:BoundField DataField="PART_NAME" HeaderText="بخش">
                                 
                                    <ItemStyle Width="100px" />
                                 
                                   </asp:BoundField>
                                   <asp:BoundField DataField="ROOM_NUMBER" HeaderText="شماره اتاق">
                                  
                                    <ItemStyle Width="60px" />
                                  
                                   </asp:BoundField>
                                <asp:TemplateField HeaderText="ویرایش">
                                  <EditItemTemplate>
        <asp:ImageButton ID="ButtonUpdate" runat="server" CommandName="Update"  Text="Update"  />
       
    </EditItemTemplate>
     <ItemTemplate>
        <asp:LinkButton ID="ButtonEdit" runat="server" ControlStyle-CssClass=" glyphicon glyphicon-pencil" CommandName="Edit"    />
      
    </ItemTemplate>
                                     <HeaderStyle Width="30px" />
                                     <ItemStyle Width="30px" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="حذف">
                                         <ItemTemplate>
      
        <asp:LinkButton ID="ButtonDelete" runat="server" CommandName="Delete"  ControlStyle-CssClass=" glyphicon glyphicon-trash"   />
    </ItemTemplate>
                                           <ItemStyle Width="30px" />
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
                         
                         <div class="form-group col-lg-6 pull-right"  style="margin-top:20px;">
                            <div class="col-lg-7 ">
                                <asp:DropDownList runat="server" CssClass="form-control  pull-right" id="DrpRoom_Number" AppendDataBoundItems="True"  >
                                    
                                </asp:DropDownList>
                             
                            </div>  
                            <label for="inputPassword1" class="col-lg-4  control-label">: اتاق</label>
                        </div>
                        <div class="form-group col-lg-5 pull-right" style="margin-top:20px;">
                            <div class="col-lg-7 ">
                               <asp:TextBox runat="server" class="pull-right form-control" id="inpBed_Number" placeholder=" شماره تخت"/>
                            </div>
                            <label for="inputEmail1" class="col-lg-5  control-label">:شماره تخت</label>
                        </div>
                        
                        <div class="form-group">
                            <div class="col-lg-offset-5 col-lg-3">
                                <%-- <input  type="button" value="جستجو" id="btnShow_search" class=" btn btn-default "   />--%>
                                 <asp:Button runat="server"  Text="ذخیره" id="btnBed_sabt" class=" btn btn-default " OnClick="btnBed_sabt_Click"   />
                            </div>
                        </div>
                     
                            
                       <div id="show-datagrid" class="col-lg-offset-2 col-lg-8">

                           <asp:GridView width="100%" ID="Grid_BED" AllowPaging="True" PageSize="3" CssClass="Grid"    runat="server"  PagerStyle-CssClass="pgr"  AutoGenerateColumns="False" OnPageIndexChanging="Grid_BED_PageIndexChanging" OnRowDeleting="Grid_BED_RowDeleting" OnRowEditing="Grid_BED_RowEditing"  >
                               
                               
                               <AlternatingRowStyle BackColor="White" />
                               <Columns>
                                    <asp:BoundField DataField="BED_ID" HeaderText="ردیف">
                                 
                                    <ControlStyle Width="30px" />
                                    <FooterStyle Width="30px" Wrap="True" />
                                    <HeaderStyle Width="30px" />
                                    <ItemStyle Width="30px" />
                                 
                                   </asp:BoundField>
                                   <asp:BoundField DataField="BED_NUMBER" HeaderText="شماره تخت">
                                 
                                    <ItemStyle Width="100px" />
                                 
                                   </asp:BoundField>
                                   <asp:BoundField DataField="ROOM_NUMBER" HeaderText="شماره اتاق">
                                  
                                    <ItemStyle Width="60px" />
                                  
                                   </asp:BoundField>
                                <asp:TemplateField HeaderText="ویرایش">
                                  <EditItemTemplate>
        <asp:ImageButton ID="ButtonUpdate" runat="server" CommandName="Update"  Text="Update"  />
       
    </EditItemTemplate>
     <ItemTemplate>
        <asp:LinkButton ID="ButtonEdit" runat="server" ControlStyle-CssClass=" glyphicon glyphicon-pencil" CommandName="Edit"    />
      
    </ItemTemplate>
                                     <ItemStyle Width="30px" />
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="حذف">
                                         <ItemTemplate>
      
        <asp:LinkButton ID="ButtonDelete" runat="server" CommandName="Delete"  ControlStyle-CssClass=" glyphicon glyphicon-trash"   />
    </ItemTemplate>
                                           <ItemStyle Width="30px" />
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

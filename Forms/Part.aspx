<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Part.aspx.cs" Inherits="Hospital_asp.Forms.Part" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="col-lg-9 main-form  pull-left">
        <div class=" col-lg-8 col-lg-offset-2 ">
            <div class="panel row">
                <header class="panel-heading " dir="rtl">
                    ساختمان و بخش
                </header>
                <div class="panel-body ">
                    <form class="form-horizontal" role="form">
                       
                        <div class="form-group col-lg-7 pull-right">
                            <div class="col-lg-7 ">
                                <asp:TextBox runat="server" class=" pull-right form-control" id="inpDepartment_Name" placeholder=" ساختمان" />
                            </div>
                            <label for="inputPassword1" class="col-lg-4  control-label">:نام ساختمان</label>
                        </div>
                         <div class="form-group  col-lg-2 pull-right">
                            <div class="col-lg-12">
                                 <asp:Button runat="server"  Text="ذخیره" id="btn_Sabt_Department" class=" btn btn-default " OnClick="btn_Sabt_Department_Click"  />
                            </div>
                        </div>
                        <br />
                        <hr style="margin-top: 38px"/>
                        <div class="form-group col-lg-7 pull-right">
                            <div class="col-lg-7 ">
                                <asp:DropDownList runat="server" CssClass="form-control  pull-right" id="Drp_Dempartment" AppendDataBoundItems="True"  >
                                    
                                </asp:DropDownList>
                             
                            </div>  
                            <label for="inputPassword1" class="col-lg-4  control-label">: ساختمان</label>
                        </div>
                        
                        
                        <div class="form-group col-lg-5 pull-right">
                            <div class="col-lg-8 ">
                               <asp:TextBox runat="server" class="pull-right form-control" id="inp_part_Name" placeholder=" بخش"/>
                            </div>
                            <label for="inputEmail1" class="col-lg-4  control-label">:نام بخش</label>
                        </div>
                        
                        <div class="form-group">
                            <div class="col-lg-offset-5 col-lg-3">
                              
                                 <asp:Button runat="server"  Text="ذخیره" id="btnDoctor_sabt" class=" btn btn-default " OnClick="btnPart_sabt_Click"  />
                            </div>
                        </div>
                       
                            
                       <div id="show-datagrid" class="col-lg-offset-2 col-lg-8">

                           <asp:GridView width="100%" ID="GridView1" AllowPaging="True" PageSize="4" CssClass="Grid"    runat="server"  PagerStyle-CssClass="pgr"  AutoGenerateColumns="False"  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" >
                               
                               
                               <AlternatingRowStyle BackColor="White" />
                               <Columns>
                                    <asp:BoundField DataField="PART_ID" HeaderText="ردیف">
                                 
                                    <ControlStyle Width="30px" />
                                    <FooterStyle Width="30px" Wrap="True" />
                                    <HeaderStyle Width="30px" />
                                    <ItemStyle Width="30px" />
                                 
                                   </asp:BoundField>
                                   <asp:BoundField DataField="DPRM_NAME" HeaderText="نام ساختمان">
                                 
                                    <ItemStyle Width="150px" />
                                 
                                   </asp:BoundField>
                                   <asp:BoundField DataField="PART_NAME" HeaderText="نام بخش">
                                  
                                    <ItemStyle Width="90px" />
                                  
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

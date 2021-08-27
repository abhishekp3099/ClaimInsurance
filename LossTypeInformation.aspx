<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="LossTypeInformation.aspx.cs" Inherits="ClaimInsurance.LossTypeInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Loss Type Information</title>
     <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
<link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
    media="screen" />
    
</head>
<body>
    <form id="form1" runat="server">
         
        <asp:Repeater ID="Repeater1" runat="server">
              
             <HeaderTemplate>  
               
                        <table class="table table-striped table-bordered">
                            
                            
                            <tr>  
                                <td><b>CreatedId</b></td>
                                <td><b>CreatedDate</b></td>
                                <td><b>LossTypeId</b></td>  
                                <td><b>LossTypeCode</b></td>  
                                <td><b>LossTypeDescription</b></td>  
                                <td><b>Active</b></td>  
                                <td><b>LastUpdatedId</b></td>
                                <td><b>LastUpdatedDate</b></td>       
                            </tr>  
                    </HeaderTemplate>  
                    <ItemTemplate>  
                        <tr>  
                            <td>  
                                <%# DataBinder.Eval(Container.DataItem, "CreatedId") %>   
                            </td>
                             <td>  
                                <%# DataBinder.Eval(Container.DataItem, "CreatedDate") %>   
                            </td>
                            <td>  
                                <%# DataBinder.Eval(Container.DataItem, "LossTypeId") %>   
                            </td>  
                            <td>  
                                <%# DataBinder.Eval(Container.DataItem, "LossTypeCode") %>   
                            </td>  
                            <td>  
                                <%# DataBinder.Eval(Container.DataItem, "LossTypeDescription") %>  
                            </td>  
                            <td>  
                                <%# DataBinder.Eval(Container.DataItem, "Active") %>   
                            </td> 
                            <td>  
                                <%# DataBinder.Eval(Container.DataItem, "LastUpdatedId") %>   
                            </td>
                            <td>  
                                <%# DataBinder.Eval(Container.DataItem, "LastUpdatedDate") %>   
                            </td>    
                        </tr>  
                    </ItemTemplate>  
                    <FooterTemplate>  
                        </table>   
                    </FooterTemplate>  

        </asp:Repeater>
    </form>
</body>
</html>

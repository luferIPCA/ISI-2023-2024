<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallRestService.aspx.cs" Inherits="UsaRestJQuery.CallRestService" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>USAR REST WCF com JQuery</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#bntGetHoteis').click(function () {
                alert("IN");
                $.ajax({
                    url: "http://localhost:6418/Service.svc/All/json",
                    type: "GET",
                    dataType: 'json',
                    contentType:'json',
                    success: function (json) {
                        alert("OK");
                    },
                    error: function (e) {
                        alert("Error: " + e);
                    }
                });
            });
        });
        //alert("IN");
        //$.ajax({
        //    type: "GET",
        //    url: "http://localhost:6418/Service.svc/All",
        //    dataType: "xml",
        //    success: function (xml) {
        //        debugger;
        //        alert("IN: " + $xml);
        //        $(xml).find('Hotel').each(function () {
        //            var nome = $(this).find('Nome').text();
        //            var cidade = $(this).find('Cidade').text();
        //            var cap = $(this).find('Capacidade').text();
        //            $('<tr><td>' + nome + '</td><td>' + cidade + "</td><td>" + cap + "</td><td>" + category).appendTo('#hoteis');
        //        });
        //    },
        //    error: function (xhr) {
        //        alert("Erro:" + xhr.responseText);
        //    }
    //});
    //});
    </script>
</head>
    
<body style="font-family: Arial">
    <form id="form1" runat="server">
        <input type="button" id="bntGetHoteis" value="Get Hotels" /><br /><br />
            <table border="1" id="hoteis" style="border-collapse:collapse">
             <tr>
                <td><b>Nome</b></td>
                <td><b>Cidade</b></td>
                <td><b>Capacidade</b></td>
            </tr>
            </table>
     </form>
</body>
</html>
